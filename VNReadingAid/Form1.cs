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
using Wacton.Desu.Enums;
using Wacton.Desu.Japanese;
using Wacton.Desu.Romaji;
using NMeCab;
using Wacton.Desu.Kanji;

namespace VNReadingAid
{
    public partial class Form1 : Form
    {
        string[] filters = new string[] { "EOS\r", "\"" };
        string prevClipboard = "";
        Dictionary<string, IJapaneseEntry> japDict;
        Dictionary<string, IKanjiEntry> kanjiDict;
        MeCabTagger tagger;
        Transliterator transliterator;

        PopoutBrowser popout;
        DefinitionWindow defWindow;

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

            furiganaKanaLabel.SelectedTextChangedEvent += FuriganaKanaLabel_SelectedTextChangedEvent;
            furiganaRomajiLabel.SelectedTextChangedEvent += FuriganaKanaLabel_SelectedTextChangedEvent;
        }

        private void FuriganaKanaLabel_SelectedTextChangedEvent(string itext)
        {
            if (defWindow != null)
                defWindow.Hide();

            try
            {
                var words_base = tagger.Parse(itext).Split('\n');
                var base_words = words_base.Where(a => !filters.Contains(a.Split('\t')[0]) && !string.IsNullOrEmpty(a)).Select(a => a.Split('\t')[1].Split(',')[6]).ToArray();
                var kana = words_base.Where(a => !filters.Contains(a.Split('\t')[0]) && !string.IsNullOrEmpty(a)).Select(a => KanaConverter.KatakanaToHiragana(a.Split('\t')[1].Split(',')[7])).ToArray();
                var romaji = kana.Select(a => transliterator.GetRomaji(a)).ToArray();
                var words = words_base.Where(a => !filters.Contains(a.Split('\t')[0]) && !string.IsNullOrEmpty(a)).Select(a => a.Split('\t')[0]).ToArray();
                
                int i = 0;
                {
                    if (base_words[i].Trim() == "*")
                        base_words[i] = words[i];

                    if (japDict.ContainsKey(base_words[i]))
                    {
                        defWindow = new DefinitionWindow(base_words[i], words[i], romaji[i], japDict[base_words[i]].Senses.First(a => a.Glosses.Any(b => b.Language == Language.English)).Glosses.First().Term);
                        defWindow.Location = Cursor.Position;
                        defWindow.Show();
                    }
                    /*else
                        foreach (char c in base_words[i])
                            if (kanjiDict.ContainsKey(c.ToString()))
                            {
                                var kan = kanjiDict[c.ToString()];
                                f_defs += kan.Literal + " - " + kan.Meanings.First(a => a.Language == Language.English).Term + "\n";
                            }*/
                }
            }
            catch (Exception) { }
        }

        private void InputTextBox_TextChanged(object sender, EventArgs e)
        {

            transliterator = new Transliterator();
            string itext = inputTextBox.Text;
            var words_base = tagger.Parse(itext).Split('\n');
            var base_words = words_base.Where(a => !filters.Contains(a.Split('\t')[0]) && !string.IsNullOrEmpty(a)).Select(a => a.Split('\t')[1].Split(',')[6]).ToArray();
            var kana = words_base.Where(a => !filters.Contains(a.Split('\t')[0]) && !string.IsNullOrEmpty(a)).Select(a => KanaConverter.KatakanaToHiragana(a.Split('\t')[1].Split(',')[7])).ToArray();
            var romaji = kana.Select(a => transliterator.GetRomaji(a)).ToArray();
            var words = words_base.Where(a => !filters.Contains(a.Split('\t')[0]) && !string.IsNullOrEmpty(a)).Select(a => a.Split('\t')[0]).ToArray();


            furiganaRomajiLabel.SetText(words, romaji);
            furiganaKanaLabel.SetText(words, kana);
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            if (Clipboard.ContainsText() && Clipboard.GetText() != prevClipboard)
            {
                prevClipboard = Clipboard.GetText();
                inputTextBox.Text = prevClipboard;
            }
        }

        private void AlwaysOnTopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.TopMost = alwaysOnTopToolStripMenuItem.Checked;
        }

        private void ShowRomajiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            furiganaRomajiLabel.Visible = showRomajiToolStripMenuItem.Checked;
            splitContainer2.Panel1Collapsed = !showRomajiToolStripMenuItem.Checked;
        }

        private void ShowKanaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            furiganaKanaLabel.Visible = showKanaToolStripMenuItem.Checked;
            splitContainer2.Panel2Collapsed = !showKanaToolStripMenuItem.Checked;
        }
    }
}
