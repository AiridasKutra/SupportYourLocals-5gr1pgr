namespace localhostUI.NoDatabaseConnection
{
    partial class NoDatabaseMain
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
            this.noDatabaseConnectionHeader = new System.Windows.Forms.Label();
            this.noDatabaseConnectionDescription = new System.Windows.Forms.Label();
            this.continueOffline = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // noDatabaseConnectionHeader
            // 
            this.noDatabaseConnectionHeader.AutoSize = true;
            this.noDatabaseConnectionHeader.Font = new System.Drawing.Font("Comic Sans MS", 28.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.noDatabaseConnectionHeader.Location = new System.Drawing.Point(-2, 254);
            this.noDatabaseConnectionHeader.Name = "noDatabaseConnectionHeader";
            this.noDatabaseConnectionHeader.Size = new System.Drawing.Size(513, 53);
            this.noDatabaseConnectionHeader.TabIndex = 0;
            this.noDatabaseConnectionHeader.Text = "Can\'t connect to the server";
            // 
            // noDatabaseConnectionDescription
            // 
            this.noDatabaseConnectionDescription.AutoSize = true;
            this.noDatabaseConnectionDescription.Location = new System.Drawing.Point(11, 321);
            this.noDatabaseConnectionDescription.Name = "noDatabaseConnectionDescription";
            this.noDatabaseConnectionDescription.Size = new System.Drawing.Size(342, 30);
            this.noDatabaseConnectionDescription.TabIndex = 1;
            this.noDatabaseConnectionDescription.Text = "A connection to the server cannot be established.\r\nYou can still use the offline " +
    "mode by pressing the button below.";
            // 
            // continueOffline
            // 
            this.continueOffline.Location = new System.Drawing.Point(11, 372);
            this.continueOffline.Name = "continueOffline";
            this.continueOffline.Size = new System.Drawing.Size(75, 23);
            this.continueOffline.TabIndex = 2;
            this.continueOffline.Text = "Continue";
            this.continueOffline.UseVisualStyleBackColor = true;
            this.continueOffline.Click += new System.EventHandler(this.button1_Click);
            // 
            // NoDatabaseMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 422);
            this.Controls.Add(this.continueOffline);
            this.Controls.Add(this.noDatabaseConnectionDescription);
            this.Controls.Add(this.noDatabaseConnectionHeader);
            this.Name = "NoDatabaseMain";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label noDatabaseConnectionHeader;
        private System.Windows.Forms.Label noDatabaseConnectionDescription;
        private System.Windows.Forms.Button continueOffline;
    }
}