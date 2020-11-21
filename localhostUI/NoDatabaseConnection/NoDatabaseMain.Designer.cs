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
            this.mainPanel = new System.Windows.Forms.Panel();
            this.mainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // noDatabaseConnectionHeader
            // 
            this.noDatabaseConnectionHeader.AutoSize = true;
            this.noDatabaseConnectionHeader.Font = new System.Drawing.Font("Comic Sans MS", 44F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.noDatabaseConnectionHeader.Location = new System.Drawing.Point(-4, 203);
            this.noDatabaseConnectionHeader.Name = "noDatabaseConnectionHeader";
            this.noDatabaseConnectionHeader.Size = new System.Drawing.Size(1004, 103);
            this.noDatabaseConnectionHeader.TabIndex = 0;
            this.noDatabaseConnectionHeader.Text = "Can\'t connect to the server";
            // 
            // noDatabaseConnectionDescription
            // 
            this.noDatabaseConnectionDescription.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.noDatabaseConnectionDescription.AutoSize = true;
            this.noDatabaseConnectionDescription.Font = new System.Drawing.Font("Segoe UI", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.noDatabaseConnectionDescription.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.noDatabaseConnectionDescription.Location = new System.Drawing.Point(127, 328);
            this.noDatabaseConnectionDescription.Name = "noDatabaseConnectionDescription";
            this.noDatabaseConnectionDescription.Size = new System.Drawing.Size(831, 50);
            this.noDatabaseConnectionDescription.TabIndex = 1;
            this.noDatabaseConnectionDescription.Text = "A connection to the server cannot be established.\r\n";
            this.noDatabaseConnectionDescription.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // continueOffline
            // 
            this.continueOffline.Location = new System.Drawing.Point(427, 400);
            this.continueOffline.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.continueOffline.Name = "continueOffline";
            this.continueOffline.Size = new System.Drawing.Size(129, 77);
            this.continueOffline.TabIndex = 2;
            this.continueOffline.Text = "Refresh";
            this.continueOffline.UseVisualStyleBackColor = true;
            this.continueOffline.Click += new System.EventHandler(this.refresh);
            // 
            // mainPanel
            // 
            this.mainPanel.Controls.Add(this.noDatabaseConnectionHeader);
            this.mainPanel.Controls.Add(this.continueOffline);
            this.mainPanel.Controls.Add(this.noDatabaseConnectionDescription);
            this.mainPanel.Location = new System.Drawing.Point(38, 2);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(1000, 800);
            this.mainPanel.TabIndex = 3;
            // 
            // NoDatabaseMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1082, 803);
            this.Controls.Add(this.mainPanel);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "NoDatabaseMain";
            this.Text = "Form1";
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label noDatabaseConnectionHeader;
        private System.Windows.Forms.Label noDatabaseConnectionDescription;
        private System.Windows.Forms.Button continueOffline;
        private System.Windows.Forms.Panel mainPanel;
    }
}