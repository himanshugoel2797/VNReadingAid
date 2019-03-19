using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using CefSharp;
using CefSharp.WinForms;
using Wacton.Desu.Enums;
using Wacton.Desu.Japanese;
using Wacton.Desu.Romaji;
using NMeCab;
using Wacton.Desu.Kanji;
using CefSharp.SchemeHandler;

namespace VNReadingAid
{
    public partial class Form1 : Form
    {
        ChromiumWebBrowser browser;
        bool scriptLoaded = false;
        string prevClipboard = "";
        Dictionary<string, IJapaneseEntry> japDict;
        Dictionary<string, IKanjiEntry> kanjiDict;
        MeCabTagger tagger;

        PopoutBrowser popout;

        public Form1()
        {
            japDict = new Dictionary<string, IJapaneseEntry>();
            var dict = new JapaneseDictionary().GetEntries().ToArray();
            for (int i = 0; i < dict.Length; i++)
            {
                foreach (IKanji k in dict[i].Kanjis)
                    japDict[k.Text] = dict[i];

                foreach (Wacton.Desu.Japanese.IReading r in dict[i].Readings)
                    japDict[r.Text] = dict[i];
            }

            kanjiDict = new Dictionary<string, IKanjiEntry>();
            var kanji = new KanjiDictionary().GetEntries().ToArray();
            for (int i = 0; i < kanji.Length; i++)
                kanjiDict[kanji[i].Literal] = kanji[i];

            tagger = MeCabTagger.Create();

            InitializeComponent();

            var settings = new CefSettings
            {
                CachePath = "Cache"
            };
            settings.RegisterScheme(new CefCustomScheme
            {
                SchemeName = "localfolder",
                DomainName = "data",
                SchemeHandlerFactory = new ResourceSchemeHandlerFactory()
            });

            Cef.Initialize(settings);
            browser = new ChromiumWebBrowser("localfolder://data/translator.html");

            panel1.Controls.Add(browser);
            browser.Refresh();
            browser.FrameLoadEnd += Browser_FrameLoadEnd;
        }

        private void Browser_FrameLoadEnd(object sender, FrameLoadEndEventArgs e)
        {
            scriptLoaded = true;
        }

        private async void InputTextBox_TextChanged(object sender, EventArgs e)
        {
            while (!scriptLoaded)
                await Task.Delay(1000);

            var filters = new string[] { "EOS\r", "\"" };

            string itext = inputTextBox.Text;
            var words_base = tagger.Parse(itext).Split('\n');
            var base_words = words_base.Where(a => !filters.Contains(a.Split('\t')[0]) && !string.IsNullOrEmpty(a)).Select(a => a.Split('\t')[1].Split(',')[6]).ToArray();
            //var kana = words_base.Where(a => !filters.Contains(a.Split('\t')[0]) && !string.IsNullOrEmpty(a)).Select(a => KatakanaToHiragana( a.Split('\t')[1].Split(',')[7]) ).ToArray();
            var words = words_base.Where(a => !filters.Contains(a.Split('\t')[0]) && !string.IsNullOrEmpty(a)).Select(a => a.Split('\t')[0]).ToArray();

            var task = await browser.EvaluateScriptAsync("translate_furigana", itext, "x-large");

            string f_defs = "";
            for (int i = 0; i < base_words.Length; i++)
            {
                if (base_words[i].Trim() == "*")
                    base_words[i] = words[i];

                if (japDict.ContainsKey(base_words[i]))
                    f_defs += (base_words[i] != words[i] ? "(" + base_words[i] + ") " + words[i] : base_words[i]) + " - " + japDict[base_words[i]].Senses.First(a => a.Glosses.Any(b => b.Language == Language.English)).Glosses.First().Term + "\n";
                else
                    foreach (char c in base_words[i])
                        if (kanjiDict.ContainsKey(c.ToString()))
                        {
                            var kan = kanjiDict[c.ToString()];
                            f_defs += kan.Literal + " - " + kan.Meanings.First(a => a.Language == Language.English).Term + "\n";
                        }
            }

            richTextBox1.Invoke(new MethodInvoker(() => { richTextBox1.Text = f_defs; }));
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            if (Clipboard.ContainsText() && Clipboard.GetText() != prevClipboard)
            {
                prevClipboard = Clipboard.GetText();
                inputTextBox.Text = prevClipboard;
            }
        }

        private void PopoutFuriganaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (popoutFuriganaToolStripMenuItem.Checked)
            {
                panel1.Controls.Remove(browser);
                splitContainer3.Panel2Collapsed = true;
                popout = new PopoutBrowser
                {
                    TopMost = toolStripMenuItem1.Checked
                };
                popout.Controls.Add(browser);
                popout.FormClosing += Popout_FormClosing;
                toolStripMenuItem1.Enabled = true;
                popout.Show();
            }
            else
            {
                popout.Hide();
                toolStripMenuItem1.Enabled = false;
                popout.Controls.Remove(browser);
                panel1.Controls.Add(browser);
                splitContainer3.Panel2Collapsed = false;
            }
        }

        private void Popout_FormClosing(object sender, FormClosingEventArgs e)
        {
            popout.Controls.Remove(browser);
            panel1.Controls.Add(browser);
            splitContainer3.Panel2Collapsed = false;
            popoutFuriganaToolStripMenuItem.Checked = false;
        }

        private void ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            popout.TopMost = toolStripMenuItem1.Checked;
        }

        private void AlwaysOnTopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.TopMost = alwaysOnTopToolStripMenuItem.Checked;
        }
    }
}
