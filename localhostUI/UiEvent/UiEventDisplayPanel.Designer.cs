﻿namespace localhostUI.UiEvent
{
    partial class UiEventDisplayPanel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UiEventDisplayPanel));
            this.eventName = new System.Windows.Forms.Label();
            this.sportDisplayBar = new System.Windows.Forms.FlowLayoutPanel();
            this.teamDisplayBar = new System.Windows.Forms.FlowLayoutPanel();
            this.returnButton = new System.Windows.Forms.Button();
            this.showMapsButton = new System.Windows.Forms.Button();
            this.addressLabel = new System.Windows.Forms.Label();
            this.descriptionLabel = new System.Windows.Forms.Label();
            this.chatMessageTextBox = new System.Windows.Forms.TextBox();
            this.sendMessageButton = new System.Windows.Forms.Button();
            this.chatPanel = new System.Windows.Forms.Panel();
            this.picturePanel = new System.Windows.Forms.Panel();
            this.distanceLabel = new System.Windows.Forms.Label();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.mainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // eventName
            // 
            this.eventName.Font = new System.Drawing.Font("Arial Rounded MT Bold", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.eventName.Location = new System.Drawing.Point(82, 10);
            this.eventName.Name = "eventName";
            this.eventName.Size = new System.Drawing.Size(526, 29);
            this.eventName.TabIndex = 0;
            this.eventName.Text = "event name";
            this.eventName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // sportDisplayBar
            // 
            this.sportDisplayBar.Location = new System.Drawing.Point(8, 46);
            this.sportDisplayBar.Name = "sportDisplayBar";
            this.sportDisplayBar.Size = new System.Drawing.Size(600, 25);
            this.sportDisplayBar.TabIndex = 1;
            // 
            // teamDisplayBar
            // 
            this.teamDisplayBar.Location = new System.Drawing.Point(8, 76);
            this.teamDisplayBar.Name = "teamDisplayBar";
            this.teamDisplayBar.Size = new System.Drawing.Size(600, 25);
            this.teamDisplayBar.TabIndex = 2;
            // 
            // returnButton
            // 
            this.returnButton.Location = new System.Drawing.Point(8, 10);
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
            this.showMapsButton.Location = new System.Drawing.Point(8, 107);
            this.showMapsButton.Name = "showMapsButton";
            this.showMapsButton.Size = new System.Drawing.Size(35, 35);
            this.showMapsButton.TabIndex = 4;
            this.showMapsButton.UseVisualStyleBackColor = true;
            this.showMapsButton.Click += new System.EventHandler(this.ShowAddressButton_Click);
            // 
            // addressLabel
            // 
            this.addressLabel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.addressLabel.Location = new System.Drawing.Point(112, 107);
            this.addressLabel.Name = "addressLabel";
            this.addressLabel.Size = new System.Drawing.Size(496, 35);
            this.addressLabel.TabIndex = 5;
            this.addressLabel.Text = "Long address to test out";
            this.addressLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // descriptionLabel
            // 
            this.descriptionLabel.BackColor = System.Drawing.SystemColors.Window;
            this.descriptionLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.descriptionLabel.Location = new System.Drawing.Point(8, 146);
            this.descriptionLabel.Name = "descriptionLabel";
            this.descriptionLabel.Size = new System.Drawing.Size(356, 449);
            this.descriptionLabel.TabIndex = 6;
            this.descriptionLabel.Text = "Description";
            // 
            // chatMessageTextBox
            // 
            this.chatMessageTextBox.Location = new System.Drawing.Point(369, 572);
            this.chatMessageTextBox.MaxLength = 255;
            this.chatMessageTextBox.Name = "chatMessageTextBox";
            this.chatMessageTextBox.PlaceholderText = "Enter a message...";
            this.chatMessageTextBox.Size = new System.Drawing.Size(209, 23);
            this.chatMessageTextBox.TabIndex = 8;
            // 
            // sendMessageButton
            // 
            this.sendMessageButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.sendMessageButton.Location = new System.Drawing.Point(583, 572);
            this.sendMessageButton.Name = "sendMessageButton";
            this.sendMessageButton.Size = new System.Drawing.Size(25, 20);
            this.sendMessageButton.TabIndex = 9;
            this.sendMessageButton.Text = "»";
            this.sendMessageButton.UseVisualStyleBackColor = true;
            this.sendMessageButton.Click += new System.EventHandler(this.SendMessage_Click);
            // 
            // chatPanel
            // 
            this.chatPanel.BackColor = System.Drawing.Color.White;
            this.chatPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.chatPanel.Location = new System.Drawing.Point(369, 146);
            this.chatPanel.Name = "chatPanel";
            this.chatPanel.Size = new System.Drawing.Size(239, 420);
            this.chatPanel.TabIndex = 10;
            // 
            // picturePanel
            // 
            this.picturePanel.Location = new System.Drawing.Point(619, 0);
            this.picturePanel.Name = "picturePanel";
            this.picturePanel.Size = new System.Drawing.Size(256, 600);
            this.picturePanel.TabIndex = 11;
            // 
            // distanceLabel
            // 
            this.distanceLabel.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.distanceLabel.Location = new System.Drawing.Point(48, 107);
            this.distanceLabel.Name = "distanceLabel";
            this.distanceLabel.Size = new System.Drawing.Size(65, 35);
            this.distanceLabel.TabIndex = 12;
            this.distanceLabel.Text = "3.2km";
            this.distanceLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mainPanel
            // 
            this.mainPanel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.mainPanel.Controls.Add(this.sendMessageButton);
            this.mainPanel.Controls.Add(this.returnButton);
            this.mainPanel.Controls.Add(this.chatPanel);
            this.mainPanel.Controls.Add(this.picturePanel);
            this.mainPanel.Controls.Add(this.chatMessageTextBox);
            this.mainPanel.Controls.Add(this.distanceLabel);
            this.mainPanel.Controls.Add(this.eventName);
            this.mainPanel.Controls.Add(this.descriptionLabel);
            this.mainPanel.Controls.Add(this.sportDisplayBar);
            this.mainPanel.Controls.Add(this.teamDisplayBar);
            this.mainPanel.Controls.Add(this.addressLabel);
            this.mainPanel.Controls.Add(this.showMapsButton);
            this.mainPanel.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.mainPanel.Location = new System.Drawing.Point(10, 2);
            this.mainPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(1000, 600);
            this.mainPanel.TabIndex = 13;
            // 
            // UiEventDisplayPanel
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1013, 602);
            this.Controls.Add(this.mainPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "UiEventDisplayPanel";
            this.Text = "UiEventDisplay";
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
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
        private System.Windows.Forms.TextBox chatMessageTextBox;
        private System.Windows.Forms.Button sendMessageButton;
        private System.Windows.Forms.Panel chatPanel;
        private System.Windows.Forms.Panel picturePanel;
        private System.Windows.Forms.Label distanceLabel;
        private System.Windows.Forms.Panel mainPanel;
    }
}