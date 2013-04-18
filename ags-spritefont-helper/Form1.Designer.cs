namespace AGSSpriteFontGen
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
            this.txtMetricsFile = new System.Windows.Forms.TextBox();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.butBrowse = new System.Windows.Forms.Button();
            this.butCopyClipboard = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.butGenCode = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtFont = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtMetricsFile
            // 
            this.txtMetricsFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMetricsFile.Location = new System.Drawing.Point(105, 12);
            this.txtMetricsFile.Name = "txtMetricsFile";
            this.txtMetricsFile.Size = new System.Drawing.Size(498, 20);
            this.txtMetricsFile.TabIndex = 0;
            // 
            // txtCode
            // 
            this.txtCode.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCode.Location = new System.Drawing.Point(15, 118);
            this.txtCode.Multiline = true;
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(667, 349);
            this.txtCode.TabIndex = 1;
            // 
            // butBrowse
            // 
            this.butBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butBrowse.Location = new System.Drawing.Point(609, 10);
            this.butBrowse.Name = "butBrowse";
            this.butBrowse.Size = new System.Drawing.Size(75, 23);
            this.butBrowse.TabIndex = 2;
            this.butBrowse.Text = "Browse";
            this.butBrowse.UseVisualStyleBackColor = true;
            this.butBrowse.Click += new System.EventHandler(this.butBrowse_Click);
            // 
            // butCopyClipboard
            // 
            this.butCopyClipboard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butCopyClipboard.Location = new System.Drawing.Point(15, 473);
            this.butCopyClipboard.Name = "butCopyClipboard";
            this.butCopyClipboard.Size = new System.Drawing.Size(149, 23);
            this.butCopyClipboard.TabIndex = 3;
            this.butCopyClipboard.Text = "Copy to clipboard";
            this.butCopyClipboard.UseVisualStyleBackColor = true;
            this.butCopyClipboard.Click += new System.EventHandler(this.butCopyClipboard_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Metrics File";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Code:";
            // 
            // butGenCode
            // 
            this.butGenCode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.butGenCode.Location = new System.Drawing.Point(15, 63);
            this.butGenCode.Name = "butGenCode";
            this.butGenCode.Size = new System.Drawing.Size(667, 36);
            this.butGenCode.TabIndex = 2;
            this.butGenCode.Text = "Generate AGSScript";
            this.butGenCode.UseVisualStyleBackColor = true;
            this.butGenCode.Click += new System.EventHandler(this.butGenCode_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Font To Replace";
            // 
            // txtFont
            // 
            this.txtFont.Location = new System.Drawing.Point(105, 37);
            this.txtFont.Name = "txtFont";
            this.txtFont.Size = new System.Drawing.Size(100, 20);
            this.txtFont.TabIndex = 7;
            this.txtFont.Text = "0";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(694, 501);
            this.Controls.Add(this.txtFont);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.butCopyClipboard);
            this.Controls.Add(this.butGenCode);
            this.Controls.Add(this.butBrowse);
            this.Controls.Add(this.txtCode);
            this.Controls.Add(this.txtMetricsFile);
            this.Name = "Form1";
            this.Text = "AGSSpriteFont Code Generator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtMetricsFile;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.Button butBrowse;
        private System.Windows.Forms.Button butCopyClipboard;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button butGenCode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtFont;
    }
}

