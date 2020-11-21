namespace localhostUI.NoInternetConnection
{
    partial class noInternetMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(noInternetMain));
            this.noInternetHeader = new System.Windows.Forms.Label();
            this.noInternetDescription = new System.Windows.Forms.Label();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.noInternetPicture = new System.Windows.Forms.PictureBox();
            this.refreshButton = new System.Windows.Forms.Button();
            this.mainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.noInternetPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // noInternetHeader
            // 
            this.noInternetHeader.AutoSize = true;
            this.noInternetHeader.Font = new System.Drawing.Font("Comic Sans MS", 37F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.noInternetHeader.Location = new System.Drawing.Point(0, 379);
            this.noInternetHeader.Name = "noInternetHeader";
            this.noInternetHeader.Size = new System.Drawing.Size(999, 87);
            this.noInternetHeader.TabIndex = 1;
            this.noInternetHeader.Text = "No internet connection detected.";
            // 
            // noInternetDescription
            // 
            this.noInternetDescription.AutoSize = true;
            this.noInternetDescription.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.noInternetDescription.Location = new System.Drawing.Point(15, 466);
            this.noInternetDescription.Name = "noInternetDescription";
            this.noInternetDescription.Size = new System.Drawing.Size(969, 60);
            this.noInternetDescription.TabIndex = 2;
            this.noInternetDescription.Text = "Your computer cannot establish an internet connection that the program requires t" +
    "o work correctly.\r\nPlease fix your internet connection and try again.";
            // 
            // mainPanel
            // 
            this.mainPanel.Controls.Add(this.refreshButton);
            this.mainPanel.Controls.Add(this.noInternetPicture);
            this.mainPanel.Controls.Add(this.noInternetHeader);
            this.mainPanel.Controls.Add(this.noInternetDescription);
            this.mainPanel.Location = new System.Drawing.Point(38, 2);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(1000, 800);
            this.mainPanel.TabIndex = 3;
            // 
            // noInternetPicture
            // 
            this.noInternetPicture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.noInternetPicture.Image = ((System.Drawing.Image)(resources.GetObject("noInternetPicture.Image")));
            this.noInternetPicture.Location = new System.Drawing.Point(315, 23);
            this.noInternetPicture.Name = "noInternetPicture";
            this.noInternetPicture.Size = new System.Drawing.Size(353, 353);
            this.noInternetPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.noInternetPicture.TabIndex = 3;
            this.noInternetPicture.TabStop = false;
            // 
            // refreshButton
            // 
            this.refreshButton.Location = new System.Drawing.Point(447, 545);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(96, 41);
            this.refreshButton.TabIndex = 4;
            this.refreshButton.Text = "Refresh";
            this.refreshButton.UseVisualStyleBackColor = true;
            this.refreshButton.Click += new System.EventHandler(this.Refresh);
            // 
            // noInternetMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1082, 803);
            this.Controls.Add(this.mainPanel);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "noInternetMain";
            this.Text = "localhost (No internet connection)";
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.noInternetPicture)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label noInternetHeader;
        private System.Windows.Forms.Label noInternetDescription;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Button refreshButton;
        private System.Windows.Forms.PictureBox noInternetPicture;
    }
}