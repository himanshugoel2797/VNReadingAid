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
        bool browserInited = false, scriptLoaded = false;
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
            
            var settings = new CefSettings();
            settings.CachePath = "Cache";
            settings.RegisterScheme(new CefCustomScheme
            {
                SchemeName = "localfolder",
                DomainName = "data",   
                SchemeHandlerFactory = new FolderSchemeHandlerFactory(rootFolder: Environment.CurrentDirectory)
            });
            
            Cef.Initialize(settings);
            browser = new ChromiumWebBrowser("localfolder://data/translator.html");
            
            panel1.Controls.Add(browser);
            browser.Refresh();
            browser.FrameLoadEnd += Browser_FrameLoadEnd;
        }

        private void Browser_FrameLoadEnd(object sender, FrameLoadEndEventArgs e)
        {
            //if (!browserInited && !scriptLoaded)
            //    browser.LoadHtml(Properties.Resources.translator, $"file://{Environment.CurrentDirectory}");
            //if (browserInited && !scriptLoaded)
                scriptLoaded = true;
            browserInited = true;
        }

        private async void inputTextBox_TextChanged(object sender, EventArgs e)
        {
            while (!scriptLoaded)
            {
                await Task.Delay(1000);
            }
            string itext = inputTextBox.Text;
            var words = tagger.Parse(itext).Split('\n').Select(a => a.Split('\t')[0]).ToArray();

            var task = await browser.EvaluateScriptAsync("translate_furigana", itext, "x-large");
            

            string f_defs = "";
            for (int i = 0; i < words.Length; i++)
                if (japDict.ContainsKey(words[i]))
                    f_defs += words[i] + " - " + japDict[words[i]].Senses.First(a => a.Glosses.Any(b => b.Language == Language.English)).Glosses.First().Term + "\n";
                else
                    foreach (char c in words[i])
                        if (kanjiDict.ContainsKey(c.ToString()))
                        {
                            var kan = kanjiDict[c.ToString()];
                            f_defs += kan.Literal + " - " + kan.Meanings.First(a => a.Language == Language.English).Term + "\n";
                        }

            richTextBox1.Invoke(new MethodInvoker(() => { richTextBox1.Text = f_defs; }));
        }
        
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Clipboard.ContainsText())
                if (Clipboard.GetText() != prevClipboard)
                {
                    prevClipboard = Clipboard.GetText();
                    inputTextBox.Text = prevClipboard;
                }
        }

        private void popoutFuriganaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (popoutFuriganaToolStripMenuItem.Checked)
            {
                panel1.Controls.Remove(browser);
                splitContainer3.Panel2Collapsed = true;
                popout = new PopoutBrowser();
                popout.TopMost = toolStripMenuItem1.Checked;
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

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            popout.TopMost = toolStripMenuItem1.Checked;
        }

        private void alwaysOnTopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.TopMost = alwaysOnTopToolStripMenuItem.Checked;
        }
    }
}
