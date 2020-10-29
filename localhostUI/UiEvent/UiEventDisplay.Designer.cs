namespace localhostUI.UiEvent
{
    partial class UiEventDisplay
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UiEventDisplay));
            this.eventName = new System.Windows.Forms.Label();
            this.sportDisplayBar = new System.Windows.Forms.FlowLayoutPanel();
            this.teamDisplayBar = new System.Windows.Forms.FlowLayoutPanel();
            this.returnButton = new System.Windows.Forms.Button();
            this.showMapsButton = new System.Windows.Forms.Button();
            this.addressLabel = new System.Windows.Forms.Label();
            this.descriptionLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // eventName
            // 
            this.eventName.Font = new System.Drawing.Font("Comic Sans MS", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.eventName.Location = new System.Drawing.Point(110, 23);
            this.eventName.Name = "eventName";
            this.eventName.Size = new System.Drawing.Size(480, 29);
            this.eventName.TabIndex = 0;
            this.eventName.Text = "event name";
            this.eventName.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // sportDisplayBar
            // 
            this.sportDisplayBar.Location = new System.Drawing.Point(35, 68);
            this.sportDisplayBar.Name = "sportDisplayBar";
            this.sportDisplayBar.Size = new System.Drawing.Size(630, 25);
            this.sportDisplayBar.TabIndex = 1;
            // 
            // teamDisplayBar
            // 
            this.teamDisplayBar.Location = new System.Drawing.Point(35, 99);
            this.teamDisplayBar.Name = "teamDisplayBar";
            this.teamDisplayBar.Size = new System.Drawing.Size(630, 25);
            this.teamDisplayBar.TabIndex = 2;
            // 
            // returnButton
            // 
            this.returnButton.Location = new System.Drawing.Point(35, 23);
            this.returnButton.Name = "returnButton";
            this.returnButton.Size = new System.Drawing.Size(69, 29);
            this.returnButton.TabIndex = 3;
            this.returnButton.Text = "Go back";
            this.returnButton.UseVisualStyleBackColor = true;
            this.returnButton.Click += new System.EventHandler(this.ReturnButton_Click);
            // 
            // showMapsButton
            // 
            this.showMapsButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("showMapsButton.BackgroundImage")));
            this.showMapsButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.showMapsButton.Location = new System.Drawing.Point(35, 130);
            this.showMapsButton.Name = "showMapsButton";
            this.showMapsButton.Size = new System.Drawing.Size(35, 35);
            this.showMapsButton.TabIndex = 4;
            this.showMapsButton.UseVisualStyleBackColor = true;
            this.showMapsButton.Click += new System.EventHandler(this.ShowAddressButton_Click);
            // 
            // addressLabel
            // 
            this.addressLabel.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.addressLabel.Location = new System.Drawing.Point(76, 130);
            this.addressLabel.Name = "addressLabel";
            this.addressLabel.Size = new System.Drawing.Size(250, 35);
            this.addressLabel.TabIndex = 5;
            this.addressLabel.Text = "Long address to test out";
            this.addressLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // descriptionLabel
            // 
            this.descriptionLabel.BackColor = System.Drawing.SystemColors.Window;
            this.descriptionLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.descriptionLabel.Location = new System.Drawing.Point(35, 168);
            this.descriptionLabel.Name = "descriptionLabel";
            this.descriptionLabel.Size = new System.Drawing.Size(427, 165);
            this.descriptionLabel.TabIndex = 6;
            this.descriptionLabel.Text = "Description";
            // 
            // UiEventDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 422);
            this.Controls.Add(this.descriptionLabel);
            this.Controls.Add(this.addressLabel);
            this.Controls.Add(this.showMapsButton);
            this.Controls.Add(this.returnButton);
            this.Controls.Add(this.teamDisplayBar);
            this.Controls.Add(this.sportDisplayBar);
            this.Controls.Add(this.eventName);
            this.Name = "UiEventDisplay";
            this.Text = "UiEventDisplay";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label eventName;
        private System.Windows.Forms.FlowLayoutPanel sportDisplayBar;
        private System.Windows.Forms.FlowLayoutPanel teamDisplayBar;
        private System.Windows.Forms.Button returnButton;
        private System.Windows.Forms.Button showMapsButton;
        private System.Windows.Forms.Label addressLabel;
        private System.Windows.Forms.Label descriptionLabel;
    }
}