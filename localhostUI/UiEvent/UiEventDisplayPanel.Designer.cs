namespace localhostUI.UiEvent
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
            this.separatorPanel4 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.separatorPanel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.separatorPanel2 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.separatorPanel1 = new System.Windows.Forms.Panel();
            this.commentsPanel = new System.Windows.Forms.Panel();
            this.mainPanel.SuspendLayout();
            this.separatorPanel4.SuspendLayout();
            this.separatorPanel3.SuspendLayout();
            this.separatorPanel2.SuspendLayout();
            this.commentsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // eventName
            // 
            this.eventName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.eventName.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.eventName.ForeColor = System.Drawing.Color.Gray;
            this.eventName.Location = new System.Drawing.Point(100, 40);
            this.eventName.Name = "eventName";
            this.eventName.Size = new System.Drawing.Size(800, 120);
            this.eventName.TabIndex = 0;
            this.eventName.Text = "event name";
            this.eventName.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // returnButton
            // 
            this.returnButton.BackColor = System.Drawing.Color.WhiteSmoke;
            this.returnButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("returnButton.BackgroundImage")));
            this.returnButton.FlatAppearance.BorderSize = 0;
            this.returnButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.returnButton.Location = new System.Drawing.Point(40, 40);
            this.returnButton.Name = "returnButton";
            this.returnButton.Size = new System.Drawing.Size(40, 40);
            this.returnButton.TabIndex = 3;
            this.returnButton.UseVisualStyleBackColor = false;
            this.returnButton.Click += new System.EventHandler(this.ReturnButton_Click);
            this.returnButton.MouseEnter += new System.EventHandler(this.returnButton_MouseEnter);
            this.returnButton.MouseLeave += new System.EventHandler(this.returnButton_MouseLeave);
            // 
            // showMapsButton
            // 
            this.showMapsButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("showMapsButton.BackgroundImage")));
            this.showMapsButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.showMapsButton.FlatAppearance.BorderSize = 0;
            this.showMapsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.showMapsButton.Location = new System.Drawing.Point(271, 190);
            this.showMapsButton.Name = "showMapsButton";
            this.showMapsButton.Size = new System.Drawing.Size(26, 26);
            this.showMapsButton.TabIndex = 4;
            this.showMapsButton.UseVisualStyleBackColor = true;
            this.showMapsButton.Click += new System.EventHandler(this.ShowAddressButton_Click);
            this.showMapsButton.MouseEnter += new System.EventHandler(this.showMapsButton_MouseEnter);
            this.showMapsButton.MouseLeave += new System.EventHandler(this.showMapsButton_MouseLeave);
            // 
            // addressLabel
            // 
            this.addressLabel.AutoSize = true;
            this.addressLabel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.addressLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.addressLabel.Location = new System.Drawing.Point(80, 193);
            this.addressLabel.Name = "addressLabel";
            this.addressLabel.Size = new System.Drawing.Size(175, 18);
            this.addressLabel.TabIndex = 5;
            this.addressLabel.Text = "Long address to test out";
            this.addressLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // descriptionLabel
            // 
            this.descriptionLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.descriptionLabel.AutoSize = true;
            this.descriptionLabel.BackColor = System.Drawing.Color.Transparent;
            this.descriptionLabel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.descriptionLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.descriptionLabel.Location = new System.Drawing.Point(20, 476);
            this.descriptionLabel.MaximumSize = new System.Drawing.Size(960, 1500);
            this.descriptionLabel.Name = "descriptionLabel";
            this.descriptionLabel.Size = new System.Drawing.Size(88, 18);
            this.descriptionLabel.TabIndex = 6;
            this.descriptionLabel.Text = "Description";
            // 
            // chatMessageTextBox
            // 
            this.chatMessageTextBox.BackColor = System.Drawing.SystemColors.Control;
            this.chatMessageTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.chatMessageTextBox.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.chatMessageTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.chatMessageTextBox.Location = new System.Drawing.Point(0, 0);
            this.chatMessageTextBox.MaxLength = 255;
            this.chatMessageTextBox.Multiline = true;
            this.chatMessageTextBox.Name = "chatMessageTextBox";
            this.chatMessageTextBox.PlaceholderText = "Enter a comment";
            this.chatMessageTextBox.Size = new System.Drawing.Size(960, 80);
            this.chatMessageTextBox.TabIndex = 8;
            this.chatMessageTextBox.TextChanged += new System.EventHandler(this.chatMessageTextBox_TextChanged);
            // 
            // sendMessageButton
            // 
            this.sendMessageButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(168)))), ((int)(((byte)(135)))));
            this.sendMessageButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.sendMessageButton.FlatAppearance.BorderSize = 0;
            this.sendMessageButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sendMessageButton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.sendMessageButton.ForeColor = System.Drawing.Color.White;
            this.sendMessageButton.Location = new System.Drawing.Point(860, 86);
            this.sendMessageButton.Name = "sendMessageButton";
            this.sendMessageButton.Size = new System.Drawing.Size(100, 35);
            this.sendMessageButton.TabIndex = 9;
            this.sendMessageButton.Text = "Submit";
            this.sendMessageButton.UseVisualStyleBackColor = false;
            this.sendMessageButton.Click += new System.EventHandler(this.SendMessage_Click);
            // 
            // chatPanel
            // 
            this.chatPanel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.chatPanel.Location = new System.Drawing.Point(0, 127);
            this.chatPanel.Name = "chatPanel";
            this.chatPanel.Size = new System.Drawing.Size(960, 139);
            this.chatPanel.TabIndex = 10;
            // 
            // picturePanel
            // 
            this.picturePanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picturePanel.AutoScroll = true;
            this.picturePanel.Location = new System.Drawing.Point(20, 240);
            this.picturePanel.Name = "picturePanel";
            this.picturePanel.Size = new System.Drawing.Size(960, 197);
            this.picturePanel.TabIndex = 11;
            // 
            // distanceLabel
            // 
            this.distanceLabel.AutoSize = true;
            this.distanceLabel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.distanceLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.distanceLabel.Location = new System.Drawing.Point(20, 193);
            this.distanceLabel.Name = "distanceLabel";
            this.distanceLabel.Size = new System.Drawing.Size(54, 19);
            this.distanceLabel.TabIndex = 12;
            this.distanceLabel.Text = "3.2km";
            this.distanceLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mainPanel
            // 
            this.mainPanel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.mainPanel.Controls.Add(this.commentsPanel);
            this.mainPanel.Controls.Add(this.separatorPanel4);
            this.mainPanel.Controls.Add(this.separatorPanel3);
            this.mainPanel.Controls.Add(this.separatorPanel2);
            this.mainPanel.Controls.Add(this.separatorPanel1);
            this.mainPanel.Controls.Add(this.returnButton);
            this.mainPanel.Controls.Add(this.picturePanel);
            this.mainPanel.Controls.Add(this.distanceLabel);
            this.mainPanel.Controls.Add(this.eventName);
            this.mainPanel.Controls.Add(this.descriptionLabel);
            this.mainPanel.Controls.Add(this.addressLabel);
            this.mainPanel.Controls.Add(this.showMapsButton);
            this.mainPanel.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.mainPanel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(1000, 961);
            this.mainPanel.TabIndex = 13;
            // 
            // separatorPanel4
            // 
            this.separatorPanel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.separatorPanel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
            this.separatorPanel4.Controls.Add(this.panel6);
            this.separatorPanel4.Location = new System.Drawing.Point(20, 517);
            this.separatorPanel4.Name = "separatorPanel4";
            this.separatorPanel4.Size = new System.Drawing.Size(960, 1);
            this.separatorPanel4.TabIndex = 17;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
            this.panel6.Location = new System.Drawing.Point(10, 280);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(980, 2);
            this.panel6.TabIndex = 15;
            // 
            // separatorPanel3
            // 
            this.separatorPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.separatorPanel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
            this.separatorPanel3.Controls.Add(this.panel4);
            this.separatorPanel3.Location = new System.Drawing.Point(20, 447);
            this.separatorPanel3.Name = "separatorPanel3";
            this.separatorPanel3.Size = new System.Drawing.Size(960, 1);
            this.separatorPanel3.TabIndex = 16;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
            this.panel4.Location = new System.Drawing.Point(10, 280);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(980, 2);
            this.panel4.TabIndex = 15;
            // 
            // separatorPanel2
            // 
            this.separatorPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.separatorPanel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
            this.separatorPanel2.Controls.Add(this.panel2);
            this.separatorPanel2.Location = new System.Drawing.Point(20, 230);
            this.separatorPanel2.Name = "separatorPanel2";
            this.separatorPanel2.Size = new System.Drawing.Size(960, 1);
            this.separatorPanel2.TabIndex = 14;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
            this.panel2.Location = new System.Drawing.Point(10, 280);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(980, 2);
            this.panel2.TabIndex = 15;
            // 
            // separatorPanel1
            // 
            this.separatorPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
            this.separatorPanel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.separatorPanel1.Location = new System.Drawing.Point(74, 192);
            this.separatorPanel1.Name = "separatorPanel1";
            this.separatorPanel1.Size = new System.Drawing.Size(1, 22);
            this.separatorPanel1.TabIndex = 13;
            // 
            // commentsPanel
            // 
            this.commentsPanel.Controls.Add(this.sendMessageButton);
            this.commentsPanel.Controls.Add(this.chatPanel);
            this.commentsPanel.Controls.Add(this.chatMessageTextBox);
            this.commentsPanel.Location = new System.Drawing.Point(20, 527);
            this.commentsPanel.Name = "commentsPanel";
            this.commentsPanel.Size = new System.Drawing.Size(960, 285);
            this.commentsPanel.TabIndex = 18;
            // 
            // UiEventDisplayPanel
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1000, 961);
            this.Controls.Add(this.mainPanel);
            this.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "UiEventDisplayPanel";
            this.Text = "UiEventDisplay";
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            this.separatorPanel4.ResumeLayout(false);
            this.separatorPanel3.ResumeLayout(false);
            this.separatorPanel2.ResumeLayout(false);
            this.commentsPanel.ResumeLayout(false);
            this.commentsPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label eventName;
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
        private System.Windows.Forms.Panel separatorPanel1;
        private System.Windows.Forms.Panel ara;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel separatorPanel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel separatorPanel2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel separatorPanel4;
        private System.Windows.Forms.Panel commentsPanel;
    }
}