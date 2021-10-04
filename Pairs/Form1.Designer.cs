namespace Pairs
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
            this.SuspendLayout();
            // 
            // buttons
            //
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    button[i, j] = new System.Windows.Forms.Button();
                    this.button[i, j].Location = new System.Drawing.Point(j*70+10, i*70+10);
                    this.button[i, j].Name = x + "";
                    this.button[i, j].Size = new System.Drawing.Size(60,60);
                    this.button[i, j].Text = "card" + (j + i * n + 1);
                    this.button[i, j].UseVisualStyleBackColor = true;
                    this.button[i, j].Font = new System.Drawing.Font(System.Drawing.SystemFonts.CaptionFont.FontFamily,9,System.Drawing.FontStyle.Bold);
                    this.Controls.Add(this.button[i,j]);
                    this.button[i, j].Click += new System.EventHandler(this.button_Click);
                }
            }
            this.status = new System.Windows.Forms.Label();
            this.status.Location = new System.Drawing.Point(10, n * 70 + 10);
            this.status.Name = x + "";
            this.status.AutoSize = true;
            this.status.Text = "Click count:  0      |    Time: 00:00";
            this.Controls.Add(this.status);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.MaximumSize = new System.Drawing.Size(n * 70 + 30, n * 70 + 70);
            this.MinimumSize = new System.Drawing.Size(n * 70 + 30, n * 70 + 70);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ShowIcon = false;
            this.Name = "Pairs";
            this.Text = "Pairs";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        

        #endregion

        private System.Windows.Forms.Button[,] button = new System.Windows.Forms.Button[n,n];
        private System.Windows.Forms.Label status;
    }
}

