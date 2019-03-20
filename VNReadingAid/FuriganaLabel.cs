using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VNReadingAid
{
    public partial class FuriganaLabel : UserControl
    {
        public string[] Words { get; set; }
        public string[] Furigana { get; set; }

        private string prevSelectedText;
        public string SelectedText { get; private set; }

        public delegate void SelectedTextChangedEventHandler(string text);
        public event SelectedTextChangedEventHandler SelectedTextChangedEvent;

        public FuriganaLabel()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
        }

        public void SetText(string[] words, string[] furigana)
        {
            this.Words = words;
            this.Furigana = furigana;
            Invalidate();
        }

        private void Draw(Graphics g, Font font_name, string[] words, string[] furigana)
        {
            var f_word = new Font(font_name.FontFamily, 12);
            var f_furi = new Font(font_name.FontFamily, 8.5f);

            int x_pos = 3;
            int y_pos = 3;

            Brush TxtBrush = new SolidBrush(ForeColor);
            Brush highlightTxtBrush = SystemBrushes.HighlightText;

            for (int i = 0; i < words.Length; i++)
            {
                var sz_word = g.MeasureString(words[i], f_word);
                var sz_furi = g.MeasureString(furigana[i], f_furi);

                var fmt = new StringFormat()
                {
                    FormatFlags = StringFormatFlags.DirectionVertical,
                };
                var characterRanges = new CharacterRange[words[i].Length];
                for (int j = 0; j < words[i].Length; j++)
                    characterRanges[j] = new CharacterRange(j, 1);
                fmt.SetMeasurableCharacterRanges(characterRanges);

                var sz_c_word = g.MeasureCharacterRanges(words[i], f_word, new RectangleF(x_pos, y_pos + sz_furi.Height, sz_word.Width, sz_word.Height), fmt);

                if (words[i].All(a => a < 128) | furigana[i] != words[i])
                    g.DrawString(furigana[i], f_furi, TxtBrush, (int)sz_c_word[0].GetBounds(g).X, y_pos);

                if (words[i].All(a => a >= 128))
                    for (int j = 0; j < sz_c_word.Length; j++)
                    {
                        var bnds = sz_c_word[j].GetBounds(g);

                        var brush = TxtBrush;
                        if (textIsSelected | selectingText)
                            if (Math.Min(startPos.X, curPos.X) <= bnds.X + bnds.Width / 2 && Math.Max(curPos.X, startPos.X) >= bnds.X + bnds.Width / 2 && Math.Min(startPos.Y, curPos.Y) <= bnds.Y && Math.Max(curPos.Y, startPos.Y) >= bnds.Y + bnds.Height)
                            {
                                brush = highlightTxtBrush;
                                g.FillRectangle(SystemBrushes.Highlight, bnds);
                                SelectedText += words[i][j];
                            }

                        g.DrawString(words[i][j].ToString(), f_word, brush, bnds.X, bnds.Y);
                    }


                x_pos += (int)Math.Max(sz_word.Width, sz_furi.Width);
                if (x_pos >= this.Width)
                {
                    x_pos = 0;
                    y_pos += (int)(sz_furi.Height + sz_word.Height + 3);
                }
            }

            if (SelectedText != prevSelectedText)
                SelectedTextChangedEvent?.Invoke(SelectedText);
        }

        private void FuriganaLabel_Paint(object sender, PaintEventArgs e)
        {
            if (Words != null && Furigana != null) Draw(e.Graphics, this.Font, Words, Furigana);
        }

        #region Handle Selection Mouse Events
        bool selectingText = false;
        bool textIsSelected = false;
        Point startPos, curPos;
        private void FuriganaLabel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && !selectingText && !textIsSelected)
            {
                selectingText = true;
                startPos = e.Location;
            }
            else if (textIsSelected)
            {
                startPos = Point.Empty;
                curPos = Point.Empty;
                textIsSelected = false;
                prevSelectedText = "";
                SelectedText = "";
                Invalidate();
                SelectedTextChangedEvent?.Invoke("");
            }
        }

        private void FuriganaLabel_MouseUp(object sender, MouseEventArgs e)
        {
            if (selectingText)
            {
                selectingText = false;
                textIsSelected = true;
            }
        }

        private void FuriganaLabel_MouseMove(object sender, MouseEventArgs e)
        {
            if (selectingText)
            {
                curPos = e.Location;
                prevSelectedText = SelectedText;
                SelectedText = "";
                Invalidate();
            }
        }
        #endregion
    }
}
