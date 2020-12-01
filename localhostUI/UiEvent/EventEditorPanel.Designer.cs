namespace localhostUI.UiEvent
{
    partial class EventEditorPanel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EventEditorPanel));
            this.headerLabel = new System.Windows.Forms.Label();
            this.dateLabel = new System.Windows.Forms.Label();
            this.sportLabel = new System.Windows.Forms.Label();
            this.priceLabel = new System.Windows.Forms.Label();
            this.descriptionLabel = new System.Windows.Forms.Label();
            this.eventNameBox = new System.Windows.Forms.TextBox();
            this.dateBox = new System.Windows.Forms.DateTimePicker();
            this.eventNameLabel = new System.Windows.Forms.Label();
            this.sportBox = new System.Windows.Forms.ComboBox();
            this.descriptionBox = new System.Windows.Forms.TextBox();
            this.finishButton = new System.Windows.Forms.Button();
            this.addressLabel = new System.Windows.Forms.Label();
            this.addressBox = new System.Windows.Forms.TextBox();
            this.checkAddressButton = new System.Windows.Forms.Button();
            this.priceBox = new System.Windows.Forms.NumericUpDown();
            this.thumbnailLabel = new System.Windows.Forms.Label();
            this.thumbnailLinkBox = new System.Windows.Forms.TextBox();
            this.addPhotosLabel = new System.Windows.Forms.Label();
            this.imagineLinkBox = new System.Windows.Forms.TextBox();
            this.addThumbnailButton = new System.Windows.Forms.Button();
            this.addPhotoButton = new System.Windows.Forms.Button();
            this.finishResultLabel = new System.Windows.Forms.Label();
            this.deleteEventButton = new System.Windows.Forms.Button();
            this.photoPanel = new System.Windows.Forms.Panel();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.splitterPanel = new System.Windows.Forms.Panel();
            this.thumbnailPanel = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.priceBox)).BeginInit();
            this.mainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // headerLabel
            // 
            this.headerLabel.AutoSize = true;
            this.headerLabel.Font = new System.Drawing.Font("Arial Narrow", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.headerLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(74)))), ((int)(((byte)(74)))));
            this.headerLabel.Location = new System.Drawing.Point(355, 8);
            this.headerLabel.Name = "headerLabel";
            this.headerLabel.Size = new System.Drawing.Size(261, 31);
            this.headerLabel.TabIndex = 1;
            this.headerLabel.Text = "Input event information";
            // 
            // dateLabel
            // 
            this.dateLabel.AutoSize = true;
            this.dateLabel.Font = new System.Drawing.Font("Arial Narrow", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.dateLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(74)))), ((int)(((byte)(74)))));
            this.dateLabel.Location = new System.Drawing.Point(16, 125);
            this.dateLabel.Name = "dateLabel";
            this.dateLabel.Size = new System.Drawing.Size(50, 24);
            this.dateLabel.TabIndex = 3;
            this.dateLabel.Text = "Date:";
            // 
            // sportLabel
            // 
            this.sportLabel.AutoSize = true;
            this.sportLabel.Font = new System.Drawing.Font("Arial Narrow", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.sportLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(74)))), ((int)(((byte)(74)))));
            this.sportLabel.Location = new System.Drawing.Point(16, 172);
            this.sportLabel.Name = "sportLabel";
            this.sportLabel.Size = new System.Drawing.Size(57, 24);
            this.sportLabel.TabIndex = 4;
            this.sportLabel.Text = "Sport:";
            // 
            // priceLabel
            // 
            this.priceLabel.AutoSize = true;
            this.priceLabel.Font = new System.Drawing.Font("Arial Narrow", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.priceLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(74)))), ((int)(((byte)(74)))));
            this.priceLabel.Location = new System.Drawing.Point(16, 220);
            this.priceLabel.Name = "priceLabel";
            this.priceLabel.Size = new System.Drawing.Size(99, 24);
            this.priceLabel.TabIndex = 5;
            this.priceLabel.Text = "Entry price:";
            // 
            // descriptionLabel
            // 
            this.descriptionLabel.AutoSize = true;
            this.descriptionLabel.Font = new System.Drawing.Font("Arial Narrow", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.descriptionLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(74)))), ((int)(((byte)(74)))));
            this.descriptionLabel.Location = new System.Drawing.Point(12, 490);
            this.descriptionLabel.Name = "descriptionLabel";
            this.descriptionLabel.Size = new System.Drawing.Size(103, 24);
            this.descriptionLabel.TabIndex = 6;
            this.descriptionLabel.Text = "Description:";
            // 
            // eventNameBox
            // 
            this.eventNameBox.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.eventNameBox.Location = new System.Drawing.Point(155, 69);
            this.eventNameBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.eventNameBox.MaximumSize = new System.Drawing.Size(1000, 1000);
            this.eventNameBox.Name = "eventNameBox";
            this.eventNameBox.PlaceholderText = "Pabradės \"Pabradai\" vs. \"MIF\'o \"Blaivininkai\"";
            this.eventNameBox.Size = new System.Drawing.Size(517, 30);
            this.eventNameBox.TabIndex = 0;
            // 
            // dateBox
            // 
            this.dateBox.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dateBox.Location = new System.Drawing.Point(155, 120);
            this.dateBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dateBox.Name = "dateBox";
            this.dateBox.Size = new System.Drawing.Size(517, 30);
            this.dateBox.TabIndex = 1;
            // 
            // eventNameLabel
            // 
            this.eventNameLabel.AutoSize = true;
            this.eventNameLabel.Font = new System.Drawing.Font("Arial Narrow", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.eventNameLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(74)))), ((int)(((byte)(74)))));
            this.eventNameLabel.Location = new System.Drawing.Point(16, 72);
            this.eventNameLabel.Name = "eventNameLabel";
            this.eventNameLabel.Size = new System.Drawing.Size(101, 24);
            this.eventNameLabel.TabIndex = 2;
            this.eventNameLabel.Text = "Event name";
            // 
            // sportBox
            // 
            this.sportBox.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.sportBox.FormattingEnabled = true;
            this.sportBox.Location = new System.Drawing.Point(155, 166);
            this.sportBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.sportBox.Name = "sportBox";
            this.sportBox.Size = new System.Drawing.Size(517, 31);
            this.sportBox.TabIndex = 2;
            // 
            // descriptionBox
            // 
            this.descriptionBox.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.descriptionBox.Location = new System.Drawing.Point(13, 516);
            this.descriptionBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.descriptionBox.Multiline = true;
            this.descriptionBox.Name = "descriptionBox";
            this.descriptionBox.PlaceholderText = "Input extra information about the event.";
            this.descriptionBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.descriptionBox.Size = new System.Drawing.Size(970, 153);
            this.descriptionBox.TabIndex = 7;
            // 
            // finishButton
            // 
            this.finishButton.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.finishButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(74)))), ((int)(((byte)(74)))));
            this.finishButton.Location = new System.Drawing.Point(12, 673);
            this.finishButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.finishButton.Name = "finishButton";
            this.finishButton.Size = new System.Drawing.Size(120, 45);
            this.finishButton.TabIndex = 8;
            this.finishButton.Text = "[Create/Edit]";
            this.finishButton.UseVisualStyleBackColor = true;
            // 
            // addressLabel
            // 
            this.addressLabel.AutoSize = true;
            this.addressLabel.Font = new System.Drawing.Font("Arial Narrow", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.addressLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(74)))), ((int)(((byte)(74)))));
            this.addressLabel.Location = new System.Drawing.Point(16, 267);
            this.addressLabel.Name = "addressLabel";
            this.addressLabel.Size = new System.Drawing.Size(69, 24);
            this.addressLabel.TabIndex = 13;
            this.addressLabel.Text = "Adress:";
            // 
            // addressBox
            // 
            this.addressBox.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.addressBox.Location = new System.Drawing.Point(155, 261);
            this.addressBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.addressBox.Name = "addressBox";
            this.addressBox.PlaceholderText = "Baltojo tilto aikštynas, Vilnius";
            this.addressBox.Size = new System.Drawing.Size(484, 30);
            this.addressBox.TabIndex = 4;
            // 
            // checkAddressButton
            // 
            this.checkAddressButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("checkAddressButton.BackgroundImage")));
            this.checkAddressButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.checkAddressButton.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.checkAddressButton.ForeColor = System.Drawing.SystemColors.Window;
            this.checkAddressButton.Location = new System.Drawing.Point(642, 261);
            this.checkAddressButton.Margin = new System.Windows.Forms.Padding(0);
            this.checkAddressButton.Name = "checkAddressButton";
            this.checkAddressButton.Size = new System.Drawing.Size(30, 30);
            this.checkAddressButton.TabIndex = 15;
            this.checkAddressButton.UseVisualStyleBackColor = true;
            this.checkAddressButton.Click += new System.EventHandler(this.SearchMapsBrowser);
            // 
            // priceBox
            // 
            this.priceBox.DecimalPlaces = 2;
            this.priceBox.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.priceBox.Location = new System.Drawing.Point(155, 214);
            this.priceBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.priceBox.Maximum = new decimal(new int[] {
            65373,
            0,
            0,
            0});
            this.priceBox.Name = "priceBox";
            this.priceBox.Size = new System.Drawing.Size(517, 30);
            this.priceBox.TabIndex = 3;
            // 
            // thumbnailLabel
            // 
            this.thumbnailLabel.AutoSize = true;
            this.thumbnailLabel.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.thumbnailLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(74)))), ((int)(((byte)(74)))));
            this.thumbnailLabel.Location = new System.Drawing.Point(12, 751);
            this.thumbnailLabel.Name = "thumbnailLabel";
            this.thumbnailLabel.Size = new System.Drawing.Size(105, 20);
            this.thumbnailLabel.TabIndex = 13;
            this.thumbnailLabel.Text = "Thumbnail link:";
            // 
            // thumbnailLinkBox
            // 
            this.thumbnailLinkBox.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.thumbnailLinkBox.Location = new System.Drawing.Point(123, 745);
            this.thumbnailLinkBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.thumbnailLinkBox.Name = "thumbnailLinkBox";
            this.thumbnailLinkBox.PlaceholderText = "https://address.com/image.png";
            this.thumbnailLinkBox.Size = new System.Drawing.Size(433, 25);
            this.thumbnailLinkBox.TabIndex = 5;
            // 
            // addPhotosLabel
            // 
            this.addPhotosLabel.AutoSize = true;
            this.addPhotosLabel.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.addPhotosLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(74)))), ((int)(((byte)(74)))));
            this.addPhotosLabel.Location = new System.Drawing.Point(13, 780);
            this.addPhotosLabel.Name = "addPhotosLabel";
            this.addPhotosLabel.Size = new System.Drawing.Size(84, 20);
            this.addPhotosLabel.TabIndex = 13;
            this.addPhotosLabel.Text = "Add photos:";
            // 
            // imagineLinkBox
            // 
            this.imagineLinkBox.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.imagineLinkBox.Location = new System.Drawing.Point(104, 778);
            this.imagineLinkBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.imagineLinkBox.Name = "imagineLinkBox";
            this.imagineLinkBox.PlaceholderText = "https://address.com/image.png";
            this.imagineLinkBox.Size = new System.Drawing.Size(433, 25);
            this.imagineLinkBox.TabIndex = 6;
            // 
            // addThumbnailButton
            // 
            this.addThumbnailButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.addThumbnailButton.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.addThumbnailButton.Location = new System.Drawing.Point(952, 747);
            this.addThumbnailButton.Margin = new System.Windows.Forms.Padding(0);
            this.addThumbnailButton.Name = "addThumbnailButton";
            this.addThumbnailButton.Size = new System.Drawing.Size(48, 25);
            this.addThumbnailButton.TabIndex = 15;
            this.addThumbnailButton.Text = "Add";
            this.addThumbnailButton.UseVisualStyleBackColor = true;
            this.addThumbnailButton.Click += new System.EventHandler(this.AddThumbnail);
            // 
            // addPhotoButton
            // 
            this.addPhotoButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.addPhotoButton.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.addPhotoButton.Location = new System.Drawing.Point(952, 772);
            this.addPhotoButton.Margin = new System.Windows.Forms.Padding(0);
            this.addPhotoButton.Name = "addPhotoButton";
            this.addPhotoButton.Size = new System.Drawing.Size(48, 25);
            this.addPhotoButton.TabIndex = 15;
            this.addPhotoButton.Text = "Add";
            this.addPhotoButton.UseVisualStyleBackColor = true;
            this.addPhotoButton.Click += new System.EventHandler(this.AddPhoto);
            // 
            // finishResultLabel
            // 
            this.finishResultLabel.AutoSize = true;
            this.finishResultLabel.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.finishResultLabel.Location = new System.Drawing.Point(155, 401);
            this.finishResultLabel.Name = "finishResultLabel";
            this.finishResultLabel.Size = new System.Drawing.Size(0, 20);
            this.finishResultLabel.TabIndex = 17;
            // 
            // deleteEventButton
            // 
            this.deleteEventButton.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.deleteEventButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(74)))), ((int)(((byte)(74)))));
            this.deleteEventButton.Location = new System.Drawing.Point(863, 673);
            this.deleteEventButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.deleteEventButton.Name = "deleteEventButton";
            this.deleteEventButton.Size = new System.Drawing.Size(120, 45);
            this.deleteEventButton.TabIndex = 9;
            this.deleteEventButton.Text = "[Delete/Draft]";
            this.deleteEventButton.UseVisualStyleBackColor = true;
            // 
            // photoPanel
            // 
            this.photoPanel.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.photoPanel.Location = new System.Drawing.Point(231, 307);
            this.photoPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.photoPanel.Name = "photoPanel";
            this.photoPanel.Size = new System.Drawing.Size(752, 205);
            this.photoPanel.TabIndex = 19;
            // 
            // mainPanel
            // 
            this.mainPanel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.mainPanel.Controls.Add(this.splitterPanel);
            this.mainPanel.Controls.Add(this.thumbnailPanel);
            this.mainPanel.Controls.Add(this.deleteEventButton);
            this.mainPanel.Controls.Add(this.thumbnailLabel);
            this.mainPanel.Controls.Add(this.addPhotosLabel);
            this.mainPanel.Controls.Add(this.addressLabel);
            this.mainPanel.Controls.Add(this.descriptionBox);
            this.mainPanel.Controls.Add(this.priceLabel);
            this.mainPanel.Controls.Add(this.addThumbnailButton);
            this.mainPanel.Controls.Add(this.sportLabel);
            this.mainPanel.Controls.Add(this.addPhotoButton);
            this.mainPanel.Controls.Add(this.dateLabel);
            this.mainPanel.Controls.Add(this.descriptionLabel);
            this.mainPanel.Controls.Add(this.checkAddressButton);
            this.mainPanel.Controls.Add(this.finishButton);
            this.mainPanel.Controls.Add(this.imagineLinkBox);
            this.mainPanel.Controls.Add(this.headerLabel);
            this.mainPanel.Controls.Add(this.eventNameLabel);
            this.mainPanel.Controls.Add(this.thumbnailLinkBox);
            this.mainPanel.Controls.Add(this.eventNameBox);
            this.mainPanel.Controls.Add(this.dateBox);
            this.mainPanel.Controls.Add(this.sportBox);
            this.mainPanel.Controls.Add(this.priceBox);
            this.mainPanel.Controls.Add(this.addressBox);
            this.mainPanel.Controls.Add(this.photoPanel);
            this.mainPanel.Controls.Add(this.finishResultLabel);
            this.mainPanel.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.mainPanel.Location = new System.Drawing.Point(37, 1);
            this.mainPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(1000, 800);
            this.mainPanel.TabIndex = 20;
            // 
            // splitterPanel
            // 
            this.splitterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(164)))), ((int)(((byte)(164)))));
            this.splitterPanel.Location = new System.Drawing.Point(224, 302);
            this.splitterPanel.Name = "splitterPanel";
            this.splitterPanel.Size = new System.Drawing.Size(1, 190);
            this.splitterPanel.TabIndex = 21;
            // 
            // thumbnailPanel
            // 
            this.thumbnailPanel.Location = new System.Drawing.Point(16, 307);
            this.thumbnailPanel.Name = "thumbnailPanel";
            this.thumbnailPanel.Size = new System.Drawing.Size(202, 180);
            this.thumbnailPanel.TabIndex = 20;
            // 
            // EventEditorPanel
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1055, 812);
            this.Controls.Add(this.mainPanel);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "EventEditorPanel";
            this.Load += new System.EventHandler(this.EventEditor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.priceBox)).EndInit();
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label headerLabel;
        private System.Windows.Forms.Label dateLabel;
        private System.Windows.Forms.Label sportLabel;
        private System.Windows.Forms.Label priceLabel;
        private System.Windows.Forms.Label descriptionLabel;
        private System.Windows.Forms.TextBox eventNameBox;
        private System.Windows.Forms.DateTimePicker dateBox;
        private System.Windows.Forms.Label eventNameLabel;
        private System.Windows.Forms.ComboBox sportBox;
        private System.Windows.Forms.TextBox descriptionBox;
        private System.Windows.Forms.Button finishButton;
        private System.Windows.Forms.Label addressLabel;
        private System.Windows.Forms.TextBox addressBox;
        private System.Windows.Forms.Button checkAddressButton;
        private System.Windows.Forms.NumericUpDown priceBox;
        private System.Windows.Forms.Label thumbnailLabel;
        private System.Windows.Forms.TextBox thumbnailLinkBox;
        private System.Windows.Forms.Label addPhotosLabel;
        private System.Windows.Forms.TextBox imagineLinkBox;
        private System.Windows.Forms.Button addThumbnailButton;
        private System.Windows.Forms.Button addPhotoButton;
        private System.Windows.Forms.Label finishResultLabel;
        private System.Windows.Forms.Button deleteEventButton;
        private System.Windows.Forms.Panel photoPanel;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Panel thumbnailPanel;
        private System.Windows.Forms.Panel splitterPanel;
    }
}