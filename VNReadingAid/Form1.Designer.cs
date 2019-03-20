namespace VNReadingAid
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.inputTextBox = new System.Windows.Forms.RichTextBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fIleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.alwaysOnTopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.showRomajiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showKanaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.furiganaRomajiLabel = new VNReadingAid.FuriganaLabel();
            this.furiganaKanaLabel = new VNReadingAid.FuriganaLabel();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // inputTextBox
            // 
            this.inputTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.inputTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inputTextBox.Location = new System.Drawing.Point(0, 0);
            this.inputTextBox.Name = "inputTextBox";
            this.inputTextBox.Size = new System.Drawing.Size(479, 49);
            this.inputTextBox.TabIndex = 0;
            this.inputTextBox.Text = "";
            this.inputTextBox.TextChanged += new System.EventHandler(this.InputTextBox_TextChanged);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.inputTextBox);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(479, 285);
            this.splitContainer1.SplitterDistance = 49;
            this.splitContainer1.TabIndex = 4;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 32;
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fIleToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(479, 24);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fIleToolStripMenuItem
            // 
            this.fIleToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.alwaysOnTopToolStripMenuItem,
            this.toolStripSeparator1,
            this.showRomajiToolStripMenuItem,
            this.showKanaToolStripMenuItem});
            this.fIleToolStripMenuItem.Name = "fIleToolStripMenuItem";
            this.fIleToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fIleToolStripMenuItem.Text = "File";
            this.fIleToolStripMenuItem.Click += new System.EventHandler(this.AlwaysOnTopToolStripMenuItem_Click);
            // 
            // alwaysOnTopToolStripMenuItem
            // 
            this.alwaysOnTopToolStripMenuItem.CheckOnClick = true;
            this.alwaysOnTopToolStripMenuItem.Name = "alwaysOnTopToolStripMenuItem";
            this.alwaysOnTopToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.alwaysOnTopToolStripMenuItem.Text = "Always on top";
            this.alwaysOnTopToolStripMenuItem.CheckedChanged += new System.EventHandler(this.AlwaysOnTopToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(177, 6);
            // 
            // showRomajiToolStripMenuItem
            // 
            this.showRomajiToolStripMenuItem.Checked = true;
            this.showRomajiToolStripMenuItem.CheckOnClick = true;
            this.showRomajiToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showRomajiToolStripMenuItem.Name = "showRomajiToolStripMenuItem";
            this.showRomajiToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.showRomajiToolStripMenuItem.Text = "Show Romaji";
            this.showRomajiToolStripMenuItem.Click += new System.EventHandler(this.ShowRomajiToolStripMenuItem_Click);
            // 
            // showKanaToolStripMenuItem
            // 
            this.showKanaToolStripMenuItem.Checked = true;
            this.showKanaToolStripMenuItem.CheckOnClick = true;
            this.showKanaToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showKanaToolStripMenuItem.Name = "showKanaToolStripMenuItem";
            this.showKanaToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.showKanaToolStripMenuItem.Text = "Show Kana";
            this.showKanaToolStripMenuItem.Click += new System.EventHandler(this.ShowKanaToolStripMenuItem_Click);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.furiganaRomajiLabel);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.furiganaKanaLabel);
            this.splitContainer2.Size = new System.Drawing.Size(479, 232);
            this.splitContainer2.SplitterDistance = 107;
            this.splitContainer2.TabIndex = 0;
            // 
            // furiganaRomajiLabel
            // 
            this.furiganaRomajiLabel.BackColor = System.Drawing.Color.White;
            this.furiganaRomajiLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.furiganaRomajiLabel.Furigana = null;
            this.furiganaRomajiLabel.Location = new System.Drawing.Point(0, 0);
            this.furiganaRomajiLabel.Name = "furiganaRomajiLabel";
            this.furiganaRomajiLabel.Size = new System.Drawing.Size(479, 107);
            this.furiganaRomajiLabel.TabIndex = 0;
            this.furiganaRomajiLabel.Words = null;
            // 
            // furiganaKanaLabel
            // 
            this.furiganaKanaLabel.BackColor = System.Drawing.Color.White;
            this.furiganaKanaLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.furiganaKanaLabel.Furigana = null;
            this.furiganaKanaLabel.Location = new System.Drawing.Point(0, 0);
            this.furiganaKanaLabel.Name = "furiganaKanaLabel";
            this.furiganaKanaLabel.Size = new System.Drawing.Size(479, 121);
            this.furiganaKanaLabel.TabIndex = 1;
            this.furiganaKanaLabel.Words = null;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(479, 309);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.Text = "VN Reading Aid";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox inputTextBox;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fIleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem alwaysOnTopToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem showRomajiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showKanaToolStripMenuItem;
        private FuriganaLabel furiganaRomajiLabel;
        private FuriganaLabel furiganaKanaLabel;
        private System.Windows.Forms.SplitContainer splitContainer2;
    }
}

