namespace RAR.Framework.Database.TestingTools
{
    partial class frmMain
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
            this.cmd0 = new System.Windows.Forms.Button();
            this.cmd1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmd0
            // 
            this.cmd0.Location = new System.Drawing.Point(381, 12);
            this.cmd0.Name = "cmd0";
            this.cmd0.Size = new System.Drawing.Size(147, 52);
            this.cmd0.TabIndex = 0;
            this.cmd0.Text = "SelectService";
            this.cmd0.UseVisualStyleBackColor = true;
            this.cmd0.Click += new System.EventHandler(this.cmd0_Click);
            // 
            // cmd1
            // 
            this.cmd1.Location = new System.Drawing.Point(381, 70);
            this.cmd1.Name = "cmd1";
            this.cmd1.Size = new System.Drawing.Size(147, 52);
            this.cmd1.TabIndex = 1;
            this.cmd1.Text = "InsertService";
            this.cmd1.UseVisualStyleBackColor = true;
            this.cmd1.Click += new System.EventHandler(this.cmd1_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(540, 396);
            this.Controls.Add(this.cmd1);
            this.Controls.Add(this.cmd0);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Testing Tools";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cmd0;
        private System.Windows.Forms.Button cmd1;
    }
}

