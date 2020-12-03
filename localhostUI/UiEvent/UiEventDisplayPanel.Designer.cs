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
            this.separator4 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.separator3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.separator2 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.separator1 = new System.Windows.Forms.Panel();
            this.mainPanel.SuspendLayout();
            this.separator4.SuspendLayout();
            this.separator3.SuspendLayout();
            this.separator2.SuspendLayout();
            this.SuspendLayout();
            // 
            // eventName
            // 
            this.eventName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.eventName.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.eventName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.eventName.Location = new System.Drawing.Point(40, 10);
            this.eventName.Name = "eventName";
            this.eventName.Size = new System.Drawing.Size(900, 30);
            this.eventName.TabIndex = 0;
            this.eventName.Text = "event name";
            this.eventName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // sportDisplayBar
            // 
            this.sportDisplayBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sportDisplayBar.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.sportDisplayBar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.sportDisplayBar.Location = new System.Drawing.Point(10, 50);
            this.sportDisplayBar.Name = "sportDisplayBar";
            this.sportDisplayBar.Size = new System.Drawing.Size(980, 25);
            this.sportDisplayBar.TabIndex = 1;
            // 
            // teamDisplayBar
            // 
            this.teamDisplayBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.teamDisplayBar.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.teamDisplayBar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.teamDisplayBar.Location = new System.Drawing.Point(10, 80);
            this.teamDisplayBar.Name = "teamDisplayBar";
            this.teamDisplayBar.Size = new System.Drawing.Size(980, 25);
            this.teamDisplayBar.TabIndex = 2;
            // 
            // returnButton
            // 
            this.returnButton.BackColor = System.Drawing.Color.Transparent;
            this.returnButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("returnButton.BackgroundImage")));
            this.returnButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.returnButton.FlatAppearance.BorderSize = 0;
            this.returnButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.returnButton.Location = new System.Drawing.Point(10, 12);
            this.returnButton.Name = "returnButton";
            this.returnButton.Size = new System.Drawing.Size(26, 26);
            this.returnButton.TabIndex = 3;
            this.returnButton.UseVisualStyleBackColor = false;
            this.returnButton.Click += new System.EventHandler(this.ReturnButton_Click);
            // 
            // showMapsButton
            // 
            this.showMapsButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("showMapsButton.BackgroundImage")));
            this.showMapsButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.showMapsButton.FlatAppearance.BorderSize = 0;
            this.showMapsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.showMapsButton.Location = new System.Drawing.Point(250, 124);
            this.showMapsButton.Name = "showMapsButton";
            this.showMapsButton.Size = new System.Drawing.Size(18, 18);
            this.showMapsButton.TabIndex = 4;
            this.showMapsButton.UseVisualStyleBackColor = true;
            this.showMapsButton.Click += new System.EventHandler(this.ShowAddressButton_Click);
            // 
            // addressLabel
            // 
            this.addressLabel.AutoSize = true;
            this.addressLabel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.addressLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.addressLabel.Location = new System.Drawing.Point(70, 124);
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
            this.descriptionLabel.Location = new System.Drawing.Point(10, 410);
            this.descriptionLabel.Name = "descriptionLabel";
            this.descriptionLabel.Size = new System.Drawing.Size(88, 18);
            this.descriptionLabel.TabIndex = 6;
            this.descriptionLabel.Text = "Description";
            // 
            // chatMessageTextBox
            // 
            this.chatMessageTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chatMessageTextBox.BackColor = System.Drawing.SystemColors.Control;
            this.chatMessageTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.chatMessageTextBox.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.chatMessageTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.chatMessageTextBox.Location = new System.Drawing.Point(10, 470);
            this.chatMessageTextBox.MaxLength = 255;
            this.chatMessageTextBox.Multiline = true;
            this.chatMessageTextBox.Name = "chatMessageTextBox";
            this.chatMessageTextBox.PlaceholderText = "Enter a message...";
            this.chatMessageTextBox.Size = new System.Drawing.Size(980, 80);
            this.chatMessageTextBox.TabIndex = 8;
            this.chatMessageTextBox.TextChanged += new System.EventHandler(this.chatMessageTextBox_TextChanged);
            // 
            // sendMessageButton
            // 
            this.sendMessageButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.sendMessageButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(168)))), ((int)(((byte)(135)))));
            this.sendMessageButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.sendMessageButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sendMessageButton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.sendMessageButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.sendMessageButton.Location = new System.Drawing.Point(910, 560);
            this.sendMessageButton.Name = "sendMessageButton";
            this.sendMessageButton.Size = new System.Drawing.Size(80, 36);
            this.sendMessageButton.TabIndex = 9;
            this.sendMessageButton.Text = "Submit";
            this.sendMessageButton.UseVisualStyleBackColor = false;
            this.sendMessageButton.Click += new System.EventHandler(this.SendMessage_Click);
            // 
            // chatPanel
            // 
            this.chatPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chatPanel.BackColor = System.Drawing.Color.White;
            this.chatPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.chatPanel.Location = new System.Drawing.Point(10, 610);
            this.chatPanel.Name = "chatPanel";
            this.chatPanel.Size = new System.Drawing.Size(980, 139);
            this.chatPanel.TabIndex = 10;
            // 
            // picturePanel
            // 
            this.picturePanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picturePanel.AutoScroll = true;
            this.picturePanel.Location = new System.Drawing.Point(10, 170);
            this.picturePanel.Name = "picturePanel";
            this.picturePanel.Size = new System.Drawing.Size(980, 200);
            this.picturePanel.TabIndex = 11;
            // 
            // distanceLabel
            // 
            this.distanceLabel.AutoSize = true;
            this.distanceLabel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.distanceLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.distanceLabel.Location = new System.Drawing.Point(10, 123);
            this.distanceLabel.Name = "distanceLabel";
            this.distanceLabel.Size = new System.Drawing.Size(54, 19);
            this.distanceLabel.TabIndex = 12;
            this.distanceLabel.Text = "3.2km";
            this.distanceLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mainPanel
            // 
            this.mainPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mainPanel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.mainPanel.Controls.Add(this.separator4);
            this.mainPanel.Controls.Add(this.separator3);
            this.mainPanel.Controls.Add(this.separator2);
            this.mainPanel.Controls.Add(this.separator1);
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
            this.mainPanel.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(1000, 761);
            this.mainPanel.TabIndex = 13;
            // 
            // separator4
            // 
            this.separator4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.separator4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
            this.separator4.Controls.Add(this.panel6);
            this.separator4.Location = new System.Drawing.Point(10, 450);
            this.separator4.Name = "separator4";
            this.separator4.Size = new System.Drawing.Size(980, 2);
            this.separator4.TabIndex = 17;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
            this.panel6.Location = new System.Drawing.Point(10, 280);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(980, 2);
            this.panel6.TabIndex = 15;
            // 
            // separator3
            // 
            this.separator3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.separator3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
            this.separator3.Controls.Add(this.panel4);
            this.separator3.Location = new System.Drawing.Point(10, 380);
            this.separator3.Name = "separator3";
            this.separator3.Size = new System.Drawing.Size(980, 2);
            this.separator3.TabIndex = 16;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
            this.panel4.Location = new System.Drawing.Point(10, 280);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(980, 2);
            this.panel4.TabIndex = 15;
            // 
            // separator2
            // 
            this.separator2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.separator2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
            this.separator2.Controls.Add(this.panel2);
            this.separator2.Location = new System.Drawing.Point(10, 160);
            this.separator2.Name = "separator2";
            this.separator2.Size = new System.Drawing.Size(980, 2);
            this.separator2.TabIndex = 14;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
            this.panel2.Location = new System.Drawing.Point(10, 280);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(980, 2);
            this.panel2.TabIndex = 15;
            // 
            // separator1
            // 
            this.separator1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
            this.separator1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.separator1.Location = new System.Drawing.Point(64, 122);
            this.separator1.Name = "separator1";
            this.separator1.Size = new System.Drawing.Size(2, 22);
            this.separator1.TabIndex = 13;
            // 
            // UiEventDisplayPanel
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1000, 761);
            this.Controls.Add(this.mainPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "UiEventDisplayPanel";
            this.Text = "UiEventDisplay";
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            this.separator4.ResumeLayout(false);
            this.separator3.ResumeLayout(false);
            this.separator2.ResumeLayout(false);
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
        private System.Windows.Forms.Panel separator1;
        private System.Windows.Forms.Panel ara;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel separator3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel separator2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel separator4;
    }
}