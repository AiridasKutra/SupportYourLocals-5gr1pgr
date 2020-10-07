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
            this.noInternetIcon = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.noInternetIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // noInternetHeader
            // 
            this.noInternetHeader.AutoSize = true;
            this.noInternetHeader.Font = new System.Drawing.Font("Comic Sans MS", 28.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.noInternetHeader.Location = new System.Drawing.Point(-2, 271);
            this.noInternetHeader.Name = "noInternetHeader";
            this.noInternetHeader.Size = new System.Drawing.Size(772, 67);
            this.noInternetHeader.TabIndex = 1;
            this.noInternetHeader.Text = "No internet connection detected.";
            // 
            // noInternetDescription
            // 
            this.noInternetDescription.AutoSize = true;
            this.noInternetDescription.Location = new System.Drawing.Point(13, 342);
            this.noInternetDescription.Name = "noInternetDescription";
            this.noInternetDescription.Size = new System.Drawing.Size(629, 34);
            this.noInternetDescription.TabIndex = 2;
            this.noInternetDescription.Text = "Your computer cannot establish an internet connection that the program requires t" +
    "o work correctly.\r\nPlease fix your internet connection and restart the program.\r" +
    "\n";
            // 
            // noInternetIcon
            // 
            this.noInternetIcon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.noInternetIcon.Dock = System.Windows.Forms.DockStyle.Top;
            this.noInternetIcon.Image = ((System.Drawing.Image)(resources.GetObject("noInternetIcon.Image")));
            this.noInternetIcon.Location = new System.Drawing.Point(0, 0);
            this.noInternetIcon.Name = "noInternetIcon";
            this.noInternetIcon.Size = new System.Drawing.Size(800, 268);
            this.noInternetIcon.TabIndex = 0;
            this.noInternetIcon.TabStop = false;
            // 
            // noInternetMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.noInternetDescription);
            this.Controls.Add(this.noInternetHeader);
            this.Controls.Add(this.noInternetIcon);
            this.Name = "noInternetMain";
            this.Text = "localhost (No internet connection)";
            ((System.ComponentModel.ISupportInitialize)(this.noInternetIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label noInternetHeader;
        private System.Windows.Forms.Label noInternetDescription;
        private System.Windows.Forms.PictureBox noInternetIcon;
    }
}