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
            this.thumbnailLinkBox = new System.Windows.Forms.TextBox();
            this.imageLinkBox = new System.Windows.Forms.TextBox();
            this.addThumbnailButton = new System.Windows.Forms.Button();
            this.addPhotoButton = new System.Windows.Forms.Button();
            this.finishResultLabel = new System.Windows.Forms.Label();
            this.deleteEventButton = new System.Windows.Forms.Button();
            this.photoPanel = new System.Windows.Forms.Panel();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.timeTextBox = new System.Windows.Forms.TextBox();
            this.timeLabel = new System.Windows.Forms.Label();
            this.pictureInfoLabel = new System.Windows.Forms.Label();
            this.returnButton = new System.Windows.Forms.Button();
            this.separatorPanel3 = new System.Windows.Forms.Panel();
            this.separatorPanel1 = new System.Windows.Forms.Panel();
            this.tagsTextBox = new System.Windows.Forms.TextBox();
            this.tagsLabel = new System.Windows.Forms.Label();
            this.separatorPanel2 = new System.Windows.Forms.Panel();
            this.thumbnailPanel = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.priceBox)).BeginInit();
            this.mainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // headerLabel
            // 
            this.headerLabel.Font = new System.Drawing.Font("Arial", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.headerLabel.ForeColor = System.Drawing.Color.Gray;
            this.headerLabel.Location = new System.Drawing.Point(300, 40);
            this.headerLabel.Name = "headerLabel";
            this.headerLabel.Size = new System.Drawing.Size(400, 40);
            this.headerLabel.TabIndex = 1;
            this.headerLabel.Text = "Input event information";
            this.headerLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dateLabel
            // 
            this.dateLabel.AutoSize = true;
            this.dateLabel.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dateLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(74)))), ((int)(((byte)(74)))));
            this.dateLabel.Location = new System.Drawing.Point(20, 160);
            this.dateLabel.Name = "dateLabel";
            this.dateLabel.Size = new System.Drawing.Size(58, 23);
            this.dateLabel.TabIndex = 3;
            this.dateLabel.Text = "Date:";
            // 
            // sportLabel
            // 
            this.sportLabel.AutoSize = true;
            this.sportLabel.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.sportLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(74)))), ((int)(((byte)(74)))));
            this.sportLabel.Location = new System.Drawing.Point(20, 200);
            this.sportLabel.Name = "sportLabel";
            this.sportLabel.Size = new System.Drawing.Size(64, 23);
            this.sportLabel.TabIndex = 4;
            this.sportLabel.Text = "Sport:";
            // 
            // priceLabel
            // 
            this.priceLabel.AutoSize = true;
            this.priceLabel.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.priceLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(74)))), ((int)(((byte)(74)))));
            this.priceLabel.Location = new System.Drawing.Point(20, 240);
            this.priceLabel.Name = "priceLabel";
            this.priceLabel.Size = new System.Drawing.Size(111, 23);
            this.priceLabel.TabIndex = 5;
            this.priceLabel.Text = "Entry price:";
            // 
            // descriptionLabel
            // 
            this.descriptionLabel.AutoSize = true;
            this.descriptionLabel.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.descriptionLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(74)))), ((int)(((byte)(74)))));
            this.descriptionLabel.Location = new System.Drawing.Point(20, 676);
            this.descriptionLabel.Name = "descriptionLabel";
            this.descriptionLabel.Size = new System.Drawing.Size(114, 23);
            this.descriptionLabel.TabIndex = 6;
            this.descriptionLabel.Text = "Description:";
            // 
            // eventNameBox
            // 
            this.eventNameBox.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.eventNameBox.Location = new System.Drawing.Point(150, 121);
            this.eventNameBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.eventNameBox.MaximumSize = new System.Drawing.Size(1000, 1000);
            this.eventNameBox.MaxLength = 150;
            this.eventNameBox.Name = "eventNameBox";
            this.eventNameBox.PlaceholderText = "Pabradės \"Pabradai\" vs. \"MIF\'o \"Blaivininkai\"";
            this.eventNameBox.Size = new System.Drawing.Size(517, 26);
            this.eventNameBox.TabIndex = 0;
            // 
            // dateBox
            // 
            this.dateBox.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dateBox.Location = new System.Drawing.Point(150, 161);
            this.dateBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dateBox.Name = "dateBox";
            this.dateBox.Size = new System.Drawing.Size(384, 26);
            this.dateBox.TabIndex = 1;
            // 
            // eventNameLabel
            // 
            this.eventNameLabel.AutoSize = true;
            this.eventNameLabel.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.eventNameLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(74)))), ((int)(((byte)(74)))));
            this.eventNameLabel.Location = new System.Drawing.Point(20, 120);
            this.eventNameLabel.Name = "eventNameLabel";
            this.eventNameLabel.Size = new System.Drawing.Size(119, 23);
            this.eventNameLabel.TabIndex = 2;
            this.eventNameLabel.Text = "Event name:";
            // 
            // sportBox
            // 
            this.sportBox.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.sportBox.FormattingEnabled = true;
            this.sportBox.Location = new System.Drawing.Point(150, 201);
            this.sportBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.sportBox.Name = "sportBox";
            this.sportBox.Size = new System.Drawing.Size(517, 26);
            this.sportBox.TabIndex = 3;
            // 
            // descriptionBox
            // 
            this.descriptionBox.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.descriptionBox.Location = new System.Drawing.Point(20, 704);
            this.descriptionBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.descriptionBox.MaxLength = 1000;
            this.descriptionBox.Multiline = true;
            this.descriptionBox.Name = "descriptionBox";
            this.descriptionBox.PlaceholderText = "Input extra information about the event.";
            this.descriptionBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.descriptionBox.Size = new System.Drawing.Size(960, 132);
            this.descriptionBox.TabIndex = 11;
            // 
            // finishButton
            // 
            this.finishButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(168)))), ((int)(((byte)(135)))));
            this.finishButton.FlatAppearance.BorderSize = 0;
            this.finishButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.finishButton.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.finishButton.ForeColor = System.Drawing.Color.White;
            this.finishButton.Location = new System.Drawing.Point(20, 840);
            this.finishButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.finishButton.Name = "finishButton";
            this.finishButton.Size = new System.Drawing.Size(150, 45);
            this.finishButton.TabIndex = 12;
            this.finishButton.Text = "[Create/Edit]";
            this.finishButton.UseVisualStyleBackColor = false;
            // 
            // addressLabel
            // 
            this.addressLabel.AutoSize = true;
            this.addressLabel.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.addressLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(74)))), ((int)(((byte)(74)))));
            this.addressLabel.Location = new System.Drawing.Point(20, 280);
            this.addressLabel.Name = "addressLabel";
            this.addressLabel.Size = new System.Drawing.Size(78, 23);
            this.addressLabel.TabIndex = 13;
            this.addressLabel.Text = "Adress:";
            // 
            // addressBox
            // 
            this.addressBox.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.addressBox.Location = new System.Drawing.Point(150, 281);
            this.addressBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.addressBox.MaxLength = 256;
            this.addressBox.Name = "addressBox";
            this.addressBox.PlaceholderText = "Baltojo tilto aikštynas, Vilnius";
            this.addressBox.Size = new System.Drawing.Size(484, 26);
            this.addressBox.TabIndex = 5;
            // 
            // checkAddressButton
            // 
            this.checkAddressButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("checkAddressButton.BackgroundImage")));
            this.checkAddressButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.checkAddressButton.FlatAppearance.BorderSize = 0;
            this.checkAddressButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkAddressButton.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.checkAddressButton.ForeColor = System.Drawing.SystemColors.Window;
            this.checkAddressButton.Location = new System.Drawing.Point(641, 281);
            this.checkAddressButton.Margin = new System.Windows.Forms.Padding(0);
            this.checkAddressButton.Name = "checkAddressButton";
            this.checkAddressButton.Size = new System.Drawing.Size(26, 26);
            this.checkAddressButton.TabIndex = 15;
            this.checkAddressButton.UseVisualStyleBackColor = true;
            this.checkAddressButton.Click += new System.EventHandler(this.SearchMapsBrowser);
            this.checkAddressButton.MouseEnter += new System.EventHandler(this.checkAddressButton_MouseEnter);
            this.checkAddressButton.MouseLeave += new System.EventHandler(this.checkAddressButton_MouseLeave);
            // 
            // priceBox
            // 
            this.priceBox.DecimalPlaces = 2;
            this.priceBox.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.priceBox.Location = new System.Drawing.Point(150, 241);
            this.priceBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.priceBox.Maximum = new decimal(new int[] {
            65373,
            0,
            0,
            0});
            this.priceBox.Name = "priceBox";
            this.priceBox.Size = new System.Drawing.Size(517, 26);
            this.priceBox.TabIndex = 4;
            // 
            // thumbnailLinkBox
            // 
            this.thumbnailLinkBox.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.thumbnailLinkBox.Location = new System.Drawing.Point(20, 612);
            this.thumbnailLinkBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.thumbnailLinkBox.MaxLength = 256;
            this.thumbnailLinkBox.Name = "thumbnailLinkBox";
            this.thumbnailLinkBox.PlaceholderText = "Thumbnail link";
            this.thumbnailLinkBox.Size = new System.Drawing.Size(150, 26);
            this.thumbnailLinkBox.TabIndex = 7;
            // 
            // imageLinkBox
            // 
            this.imageLinkBox.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.imageLinkBox.Location = new System.Drawing.Point(801, 612);
            this.imageLinkBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.imageLinkBox.MaxLength = 256;
            this.imageLinkBox.Name = "imageLinkBox";
            this.imageLinkBox.PlaceholderText = "Image link";
            this.imageLinkBox.Size = new System.Drawing.Size(150, 26);
            this.imageLinkBox.TabIndex = 9;
            // 
            // addThumbnailButton
            // 
            this.addThumbnailButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("addThumbnailButton.BackgroundImage")));
            this.addThumbnailButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.addThumbnailButton.FlatAppearance.BorderSize = 0;
            this.addThumbnailButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addThumbnailButton.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.addThumbnailButton.Location = new System.Drawing.Point(174, 612);
            this.addThumbnailButton.Margin = new System.Windows.Forms.Padding(0);
            this.addThumbnailButton.Name = "addThumbnailButton";
            this.addThumbnailButton.Size = new System.Drawing.Size(26, 26);
            this.addThumbnailButton.TabIndex = 8;
            this.addThumbnailButton.UseVisualStyleBackColor = true;
            this.addThumbnailButton.Click += new System.EventHandler(this.AddThumbnail);
            this.addThumbnailButton.MouseEnter += new System.EventHandler(this.addThumbnailButton_MouseEnter);
            this.addThumbnailButton.MouseLeave += new System.EventHandler(this.addThumbnailButton_MouseLeave);
            // 
            // addPhotoButton
            // 
            this.addPhotoButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("addPhotoButton.BackgroundImage")));
            this.addPhotoButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.addPhotoButton.FlatAppearance.BorderSize = 0;
            this.addPhotoButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addPhotoButton.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.addPhotoButton.Location = new System.Drawing.Point(954, 612);
            this.addPhotoButton.Margin = new System.Windows.Forms.Padding(0);
            this.addPhotoButton.Name = "addPhotoButton";
            this.addPhotoButton.Size = new System.Drawing.Size(26, 26);
            this.addPhotoButton.TabIndex = 10;
            this.addPhotoButton.UseVisualStyleBackColor = true;
            this.addPhotoButton.Click += new System.EventHandler(this.AddPhoto);
            this.addPhotoButton.MouseEnter += new System.EventHandler(this.addPhotoButton_MouseEnter);
            this.addPhotoButton.MouseLeave += new System.EventHandler(this.addPhotoButton_MouseLeave);
            // 
            // finishResultLabel
            // 
            this.finishResultLabel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.finishResultLabel.Location = new System.Drawing.Point(176, 853);
            this.finishResultLabel.Name = "finishResultLabel";
            this.finishResultLabel.Size = new System.Drawing.Size(200, 20);
            this.finishResultLabel.TabIndex = 17;
            // 
            // deleteEventButton
            // 
            this.deleteEventButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(168)))), ((int)(((byte)(135)))));
            this.deleteEventButton.FlatAppearance.BorderSize = 0;
            this.deleteEventButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deleteEventButton.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.deleteEventButton.ForeColor = System.Drawing.Color.White;
            this.deleteEventButton.Location = new System.Drawing.Point(830, 840);
            this.deleteEventButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.deleteEventButton.Name = "deleteEventButton";
            this.deleteEventButton.Size = new System.Drawing.Size(150, 45);
            this.deleteEventButton.TabIndex = 13;
            this.deleteEventButton.Text = "[Delete/Draft]";
            this.deleteEventButton.UseVisualStyleBackColor = false;
            // 
            // photoPanel
            // 
            this.photoPanel.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.photoPanel.Location = new System.Drawing.Point(220, 411);
            this.photoPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.photoPanel.Name = "photoPanel";
            this.photoPanel.Size = new System.Drawing.Size(760, 197);
            this.photoPanel.TabIndex = 19;
            this.photoPanel.Click += new System.EventHandler(this.ShowPhotoBox);
            // 
            // mainPanel
            // 
            this.mainPanel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.mainPanel.Controls.Add(this.timeTextBox);
            this.mainPanel.Controls.Add(this.timeLabel);
            this.mainPanel.Controls.Add(this.pictureInfoLabel);
            this.mainPanel.Controls.Add(this.returnButton);
            this.mainPanel.Controls.Add(this.separatorPanel3);
            this.mainPanel.Controls.Add(this.separatorPanel1);
            this.mainPanel.Controls.Add(this.tagsTextBox);
            this.mainPanel.Controls.Add(this.tagsLabel);
            this.mainPanel.Controls.Add(this.separatorPanel2);
            this.mainPanel.Controls.Add(this.thumbnailPanel);
            this.mainPanel.Controls.Add(this.deleteEventButton);
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
            this.mainPanel.Controls.Add(this.imageLinkBox);
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
            this.mainPanel.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.mainPanel.Location = new System.Drawing.Point(31, 11);
            this.mainPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(1000, 906);
            this.mainPanel.TabIndex = 20;
            // 
            // timeTextBox
            // 
            this.timeTextBox.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.timeTextBox.Location = new System.Drawing.Point(604, 161);
            this.timeTextBox.Name = "timeTextBox";
            this.timeTextBox.PlaceholderText = "14:51";
            this.timeTextBox.Size = new System.Drawing.Size(63, 26);
            this.timeTextBox.TabIndex = 2;
            this.timeTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // timeLabel
            // 
            this.timeLabel.AutoSize = true;
            this.timeLabel.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.timeLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(74)))), ((int)(((byte)(74)))));
            this.timeLabel.Location = new System.Drawing.Point(540, 160);
            this.timeLabel.Name = "timeLabel";
            this.timeLabel.Size = new System.Drawing.Size(58, 23);
            this.timeLabel.TabIndex = 3;
            this.timeLabel.Text = "Time:";
            // 
            // pictureInfoLabel
            // 
            this.pictureInfoLabel.AutoSize = true;
            this.pictureInfoLabel.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.pictureInfoLabel.Location = new System.Drawing.Point(20, 382);
            this.pictureInfoLabel.Name = "pictureInfoLabel";
            this.pictureInfoLabel.Size = new System.Drawing.Size(680, 16);
            this.pictureInfoLabel.TabIndex = 26;
            this.pictureInfoLabel.Text = "Enter a link into a field below and click the + button to add an image or thumbna" +
    "il. Double click a photo to remove it";
            // 
            // returnButton
            // 
            this.returnButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("returnButton.BackgroundImage")));
            this.returnButton.FlatAppearance.BorderSize = 0;
            this.returnButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.returnButton.Location = new System.Drawing.Point(40, 40);
            this.returnButton.Name = "returnButton";
            this.returnButton.Size = new System.Drawing.Size(40, 40);
            this.returnButton.TabIndex = 25;
            this.returnButton.UseVisualStyleBackColor = true;
            this.returnButton.Click += new System.EventHandler(this.returnButton_Click);
            this.returnButton.MouseEnter += new System.EventHandler(this.returnButton_MouseEnter);
            this.returnButton.MouseLeave += new System.EventHandler(this.returnButton_MouseLeave);
            // 
            // separatorPanel3
            // 
            this.separatorPanel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.separatorPanel3.Location = new System.Drawing.Point(20, 659);
            this.separatorPanel3.Name = "separatorPanel3";
            this.separatorPanel3.Size = new System.Drawing.Size(960, 1);
            this.separatorPanel3.TabIndex = 24;
            // 
            // separatorPanel1
            // 
            this.separatorPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.separatorPanel1.Location = new System.Drawing.Point(20, 368);
            this.separatorPanel1.Name = "separatorPanel1";
            this.separatorPanel1.Size = new System.Drawing.Size(960, 1);
            this.separatorPanel1.TabIndex = 24;
            // 
            // tagsTextBox
            // 
            this.tagsTextBox.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tagsTextBox.Location = new System.Drawing.Point(150, 321);
            this.tagsTextBox.MaxLength = 50;
            this.tagsTextBox.Name = "tagsTextBox";
            this.tagsTextBox.PlaceholderText = "Tags, separated by spaces";
            this.tagsTextBox.Size = new System.Drawing.Size(516, 26);
            this.tagsTextBox.TabIndex = 6;
            // 
            // tagsLabel
            // 
            this.tagsLabel.AutoSize = true;
            this.tagsLabel.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tagsLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(74)))), ((int)(((byte)(74)))));
            this.tagsLabel.Location = new System.Drawing.Point(20, 320);
            this.tagsLabel.Name = "tagsLabel";
            this.tagsLabel.Size = new System.Drawing.Size(58, 23);
            this.tagsLabel.TabIndex = 22;
            this.tagsLabel.Text = "Tags:";
            // 
            // separatorPanel2
            // 
            this.separatorPanel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(164)))), ((int)(((byte)(164)))));
            this.separatorPanel2.Location = new System.Drawing.Point(209, 411);
            this.separatorPanel2.Name = "separatorPanel2";
            this.separatorPanel2.Size = new System.Drawing.Size(1, 180);
            this.separatorPanel2.TabIndex = 21;
            // 
            // thumbnailPanel
            // 
            this.thumbnailPanel.Location = new System.Drawing.Point(20, 411);
            this.thumbnailPanel.Name = "thumbnailPanel";
            this.thumbnailPanel.Size = new System.Drawing.Size(180, 180);
            this.thumbnailPanel.TabIndex = 20;
            this.thumbnailPanel.Click += new System.EventHandler(this.ShowThumbnailBox);
            // 
            // EventEditorPanel
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1055, 971);
            this.Controls.Add(this.mainPanel);
            this.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
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
        private System.Windows.Forms.TextBox thumbnailLinkBox;
        private System.Windows.Forms.TextBox imageLinkBox;
        private System.Windows.Forms.Button addThumbnailButton;
        private System.Windows.Forms.Button addPhotoButton;
        private System.Windows.Forms.Label finishResultLabel;
        private System.Windows.Forms.Button deleteEventButton;
        private System.Windows.Forms.Panel photoPanel;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Panel thumbnailPanel;
        private System.Windows.Forms.Panel separatorPanel2;
        private System.Windows.Forms.Panel separatorPanel1;
        private System.Windows.Forms.TextBox tagsTextBox;
        private System.Windows.Forms.Label tagsLabel;
        private System.Windows.Forms.Panel separatorPanel3;
        private System.Windows.Forms.Button returnButton;
        private System.Windows.Forms.Label pictureInfoLabel;
        private System.Windows.Forms.TextBox timeTextBox;
        private System.Windows.Forms.Label timeLabel;
    }
}