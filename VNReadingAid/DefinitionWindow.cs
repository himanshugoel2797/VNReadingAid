using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VNReadingAid
{
    public partial class DefinitionWindow : Form
    {
        public DefinitionWindow()
        {
            InitializeComponent();
        }

        public DefinitionWindow(string word, string realWord, string romaji, string def) : this()
        {
            if (word != realWord)
                wordLbl.Text = realWord + " (" + word + ")";
            else
                wordLbl.Text = realWord;

            romajiLbl.Text = romaji;
            defLbl.Text = def;
        }

        private void DefinitionWindow_Load(object sender, EventArgs e)
        {

        }
    }
}
