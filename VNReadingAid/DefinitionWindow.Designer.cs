namespace VNReadingAid
{
    partial class DefinitionWindow
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
            this.wordLbl = new System.Windows.Forms.Label();
            this.romajiLbl = new System.Windows.Forms.Label();
            this.defLbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // wordLbl
            // 
            this.wordLbl.AutoSize = true;
            this.wordLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.wordLbl.Location = new System.Drawing.Point(13, 13);
            this.wordLbl.Name = "wordLbl";
            this.wordLbl.Size = new System.Drawing.Size(51, 20);
            this.wordLbl.TabIndex = 0;
            this.wordLbl.Text = "label1";
            // 
            // romajiLbl
            // 
            this.romajiLbl.AutoSize = true;
            this.romajiLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.romajiLbl.Location = new System.Drawing.Point(14, 33);
            this.romajiLbl.Name = "romajiLbl";
            this.romajiLbl.Size = new System.Drawing.Size(46, 17);
            this.romajiLbl.TabIndex = 1;
            this.romajiLbl.Text = "label2";
            // 
            // defLbl
            // 
            this.defLbl.AutoSize = true;
            this.defLbl.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.defLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.defLbl.Location = new System.Drawing.Point(14, 59);
            this.defLbl.Name = "defLbl";
            this.defLbl.Size = new System.Drawing.Size(46, 17);
            this.defLbl.TabIndex = 2;
            this.defLbl.Text = "label3";
            // 
            // DefinitionWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(394, 89);
            this.Controls.Add(this.defLbl);
            this.Controls.Add(this.romajiLbl);
            this.Controls.Add(this.wordLbl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DefinitionWindow";
            this.Padding = new System.Windows.Forms.Padding(0, 0, 0, 4);
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "DefinitionWindow";
            this.Load += new System.EventHandler(this.DefinitionWindow_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label wordLbl;
        private System.Windows.Forms.Label romajiLbl;
        private System.Windows.Forms.Label defLbl;
    }
}