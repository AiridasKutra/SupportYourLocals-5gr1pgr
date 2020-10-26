namespace localhostUI
{
    partial class UiMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UiMain));
            this.profileTab = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.locationButton = new System.Windows.Forms.Button();
            this.profileManagerLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.userAdressBox = new System.Windows.Forms.TextBox();
            this.eventManagerTab = new System.Windows.Forms.TabPage();
            this.managerTabs = new System.Windows.Forms.TabControl();
            this.yourEventsTab = new System.Windows.Forms.TabPage();
            this.newEventTab = new System.Windows.Forms.TabPage();
            this.mapsBrowserButton = new System.Windows.Forms.Button();
            this.eventAdressBox = new System.Windows.Forms.TextBox();
            this.adressLabel = new System.Windows.Forms.Label();
            this.createEventButton = new System.Windows.Forms.Button();
            this.descriptionBox = new System.Windows.Forms.TextBox();
            this.priceBox = new System.Windows.Forms.NumericUpDown();
            this.sportBox = new System.Windows.Forms.ComboBox();
            this.dateBox = new System.Windows.Forms.DateTimePicker();
            this.nameBox = new System.Windows.Forms.TextBox();
            this.descriptionLabel = new System.Windows.Forms.Label();
            this.priceLabel = new System.Windows.Forms.Label();
            this.sportLabel = new System.Windows.Forms.Label();
            this.dateLabel = new System.Windows.Forms.Label();
            this.nameLabel = new System.Windows.Forms.Label();
            this.creatorHeader = new System.Windows.Forms.Label();
            this.addSportTab = new System.Windows.Forms.TabPage();
            this.removeButton = new System.Windows.Forms.Button();
            this.removeSportBox = new System.Windows.Forms.ComboBox();
            this.removeSportLabel = new System.Windows.Forms.Label();
            this.addButton = new System.Windows.Forms.Button();
            this.addSportBox = new System.Windows.Forms.TextBox();
            this.addSportLabel = new System.Windows.Forms.Label();
            this.currentEventsTab = new System.Windows.Forms.TabPage();
            this.CurrentEventsTable = new System.Windows.Forms.TableLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.menuTabs = new System.Windows.Forms.TabControl();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.profileTab.SuspendLayout();
            this.eventManagerTab.SuspendLayout();
            this.managerTabs.SuspendLayout();
            this.newEventTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.priceBox)).BeginInit();
            this.addSportTab.SuspendLayout();
            this.currentEventsTab.SuspendLayout();
            this.menuTabs.SuspendLayout();
            this.SuspendLayout();
            // 
            // profileTab
            // 
            this.profileTab.Controls.Add(this.button1);
            this.profileTab.Controls.Add(this.locationButton);
            this.profileTab.Controls.Add(this.profileManagerLabel);
            this.profileTab.Controls.Add(this.label1);
            this.profileTab.Controls.Add(this.userAdressBox);
            this.profileTab.Location = new System.Drawing.Point(4, 25);
            this.profileTab.Name = "profileTab";
            this.profileTab.Padding = new System.Windows.Forms.Padding(3);
            this.profileTab.Size = new System.Drawing.Size(692, 393);
            this.profileTab.TabIndex = 2;
            this.profileTab.Text = "Profile manager";
            this.profileTab.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.Location = new System.Drawing.Point(211, 97);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(42, 41);
            this.button1.TabIndex = 15;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.UserSearchMapsBrowser);
            // 
            // locationButton
            // 
            this.locationButton.Location = new System.Drawing.Point(23, 97);
            this.locationButton.Name = "locationButton";
            this.locationButton.Size = new System.Drawing.Size(182, 41);
            this.locationButton.TabIndex = 3;
            this.locationButton.Text = "Search coordinates";
            this.locationButton.UseVisualStyleBackColor = true;
            this.locationButton.Click += new System.EventHandler(this.SearchCoordinatesAsync);
            // 
            // profileManagerLabel
            // 
            this.profileManagerLabel.Font = new System.Drawing.Font("Comic Sans MS", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.profileManagerLabel.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.profileManagerLabel.Location = new System.Drawing.Point(20, 7);
            this.profileManagerLabel.Name = "profileManagerLabel";
            this.profileManagerLabel.Size = new System.Drawing.Size(254, 36);
            this.profileManagerLabel.TabIndex = 2;
            this.profileManagerLabel.Text = "Your profile";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "Your adress:";
            // 
            // userAdressBox
            // 
            this.userAdressBox.BackColor = System.Drawing.SystemColors.HighlightText;
            this.userAdressBox.Location = new System.Drawing.Point(122, 45);
            this.userAdressBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.userAdressBox.Name = "userAdressBox";
            this.userAdressBox.PlaceholderText = "Didlaukio g. 59";
            this.userAdressBox.Size = new System.Drawing.Size(644, 26);
            this.userAdressBox.TabIndex = 0;
            // 
            // eventManagerTab
            // 
            this.eventManagerTab.Controls.Add(this.managerTabs);
            this.eventManagerTab.Location = new System.Drawing.Point(4, 25);
            this.eventManagerTab.Name = "eventManagerTab";
            this.eventManagerTab.Padding = new System.Windows.Forms.Padding(3);
            this.eventManagerTab.Size = new System.Drawing.Size(692, 393);
            this.eventManagerTab.TabIndex = 1;
            this.eventManagerTab.Text = "Event manager";
            this.eventManagerTab.UseVisualStyleBackColor = true;
            // 
            // managerTabs
            // 
            this.managerTabs.Controls.Add(this.yourEventsTab);
            this.managerTabs.Controls.Add(this.newEventTab);
            this.managerTabs.Controls.Add(this.addSportTab);
            this.managerTabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.managerTabs.Location = new System.Drawing.Point(3, 3);
            this.managerTabs.Name = "managerTabs";
            this.managerTabs.SelectedIndex = 2;
            this.managerTabs.Size = new System.Drawing.Size(686, 387);
            this.managerTabs.TabIndex = 0;
            // 
            // yourEventsTab
            // 
            this.yourEventsTab.Location = new System.Drawing.Point(4, 28);
            this.yourEventsTab.Name = "yourEventsTab";
            this.yourEventsTab.Padding = new System.Windows.Forms.Padding(3);
            this.yourEventsTab.Size = new System.Drawing.Size(678, 355);
            this.yourEventsTab.TabIndex = 0;
            this.yourEventsTab.Text = "Manage your events";
            this.yourEventsTab.UseVisualStyleBackColor = true;
            // 
            // newEventTab
            // 
            this.newEventTab.Controls.Add(this.mapsBrowserButton);
            this.newEventTab.Controls.Add(this.eventAdressBox);
            this.newEventTab.Controls.Add(this.adressLabel);
            this.newEventTab.Controls.Add(this.createEventButton);
            this.newEventTab.Controls.Add(this.descriptionBox);
            this.newEventTab.Controls.Add(this.priceBox);
            this.newEventTab.Controls.Add(this.sportBox);
            this.newEventTab.Controls.Add(this.dateBox);
            this.newEventTab.Controls.Add(this.nameBox);
            this.newEventTab.Controls.Add(this.descriptionLabel);
            this.newEventTab.Controls.Add(this.priceLabel);
            this.newEventTab.Controls.Add(this.sportLabel);
            this.newEventTab.Controls.Add(this.dateLabel);
            this.newEventTab.Controls.Add(this.nameLabel);
            this.newEventTab.Controls.Add(this.creatorHeader);
            this.newEventTab.Location = new System.Drawing.Point(4, 28);
            this.newEventTab.Name = "newEventTab";
            this.newEventTab.Padding = new System.Windows.Forms.Padding(3);
            this.newEventTab.Size = new System.Drawing.Size(678, 355);
            this.newEventTab.TabIndex = 1;
            this.newEventTab.Text = "Create a new event";
            this.newEventTab.UseVisualStyleBackColor = true;
            // 
            // mapsBrowserButton
            // 
            this.mapsBrowserButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("mapsBrowserButton.BackgroundImage")));
            this.mapsBrowserButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.mapsBrowserButton.Location = new System.Drawing.Point(741, 183);
            this.mapsBrowserButton.Margin = new System.Windows.Forms.Padding(0);
            this.mapsBrowserButton.Name = "mapsBrowserButton";
            this.mapsBrowserButton.Size = new System.Drawing.Size(34, 34);
            this.mapsBrowserButton.TabIndex = 15;
            this.mapsBrowserButton.UseVisualStyleBackColor = true;
            this.mapsBrowserButton.Click += new System.EventHandler(this.SearchMapsBrowser);
            // 
            // eventAdressBox
            // 
            this.eventAdressBox.Location = new System.Drawing.Point(215, 138);
            this.eventAdressBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.eventAdressBox.Name = "eventAdressBox";
            this.eventAdressBox.PlaceholderText = "Baltojo tilto aikštynas, Upės gatvė, Vilnius";
            this.eventAdressBox.Size = new System.Drawing.Size(489, 26);
            this.eventAdressBox.TabIndex = 14;
            // 
            // adressLabel
            // 
            this.adressLabel.AutoSize = true;
            this.adressLabel.Location = new System.Drawing.Point(32, 138);
            this.adressLabel.Name = "adressLabel";
            this.adressLabel.Size = new System.Drawing.Size(59, 19);
            this.adressLabel.TabIndex = 13;
            this.adressLabel.Text = "Adress:";
            // 
            // createEventButton
            // 
            this.createEventButton.Location = new System.Drawing.Point(32, 322);
            this.createEventButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.createEventButton.Name = "createEventButton";
            this.createEventButton.Size = new System.Drawing.Size(120, 35);
            this.createEventButton.TabIndex = 12;
            this.createEventButton.Text = "Create";
            this.createEventButton.UseVisualStyleBackColor = true;
            this.createEventButton.Click += new System.EventHandler(this.CreateEvent);
            // 
            // descriptionBox
            // 
            this.descriptionBox.Location = new System.Drawing.Point(32, 192);
            this.descriptionBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.descriptionBox.Multiline = true;
            this.descriptionBox.Name = "descriptionBox";
            this.descriptionBox.PlaceholderText = "Input extra information about the event.";
            this.descriptionBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.descriptionBox.Size = new System.Drawing.Size(632, 119);
            this.descriptionBox.TabIndex = 11;
            // 
            // priceBox
            // 
            this.priceBox.DecimalPlaces = 2;
            this.priceBox.Location = new System.Drawing.Point(215, 110);
            this.priceBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.priceBox.Maximum = new decimal(new int[] {
            65373,
            0,
            0,
            0});
            this.priceBox.Name = "priceBox";
            this.priceBox.Size = new System.Drawing.Size(463, 26);
            this.priceBox.TabIndex = 10;
            // 
            // sportBox
            // 
            this.sportBox.FormattingEnabled = true;
            this.sportBox.Location = new System.Drawing.Point(215, 80);
            this.sportBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.sportBox.Name = "sportBox";
            this.sportBox.Size = new System.Drawing.Size(463, 27);
            this.sportBox.TabIndex = 9;
            // 
            // dateBox
            // 
            this.dateBox.Location = new System.Drawing.Point(215, 52);
            this.dateBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dateBox.Name = "dateBox";
            this.dateBox.Size = new System.Drawing.Size(463, 26);
            this.dateBox.TabIndex = 8;
            // 
            // nameBox
            // 
            this.nameBox.Location = new System.Drawing.Point(215, 24);
            this.nameBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.nameBox.Name = "nameBox";
            this.nameBox.PlaceholderText = "Pabradės \"Pabradai\" vs. \"MIF\'o \"Blaivininkai\"";
            this.nameBox.Size = new System.Drawing.Size(463, 26);
            this.nameBox.TabIndex = 7;
            // 
            // descriptionLabel
            // 
            this.descriptionLabel.AutoSize = true;
            this.descriptionLabel.Location = new System.Drawing.Point(32, 172);
            this.descriptionLabel.Name = "descriptionLabel";
            this.descriptionLabel.Size = new System.Drawing.Size(244, 19);
            this.descriptionLabel.TabIndex = 6;
            this.descriptionLabel.Text = "Description (additional information):";
            // 
            // priceLabel
            // 
            this.priceLabel.AutoSize = true;
            this.priceLabel.Location = new System.Drawing.Point(32, 110);
            this.priceLabel.Name = "priceLabel";
            this.priceLabel.Size = new System.Drawing.Size(151, 19);
            this.priceLabel.TabIndex = 5;
            this.priceLabel.Text = "Entry price (optional):";
            // 
            // sportLabel
            // 
            this.sportLabel.AutoSize = true;
            this.sportLabel.Location = new System.Drawing.Point(32, 80);
            this.sportLabel.Name = "sportLabel";
            this.sportLabel.Size = new System.Drawing.Size(47, 19);
            this.sportLabel.TabIndex = 4;
            this.sportLabel.Text = "Sport";
            // 
            // dateLabel
            // 
            this.dateLabel.AutoSize = true;
            this.dateLabel.Location = new System.Drawing.Point(32, 52);
            this.dateLabel.Name = "dateLabel";
            this.dateLabel.Size = new System.Drawing.Size(45, 19);
            this.dateLabel.TabIndex = 3;
            this.dateLabel.Text = "Date:";
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(32, 24);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(88, 19);
            this.nameLabel.TabIndex = 2;
            this.nameLabel.Text = "Event name:";
            // 
            // creatorHeader
            // 
            this.creatorHeader.AutoSize = true;
            this.creatorHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.creatorHeader.Location = new System.Drawing.Point(32, 3);
            this.creatorHeader.Name = "creatorHeader";
            this.creatorHeader.Size = new System.Drawing.Size(165, 19);
            this.creatorHeader.TabIndex = 1;
            this.creatorHeader.Text = "Input event information";
            // 
            // addSportTab
            // 
            this.addSportTab.Controls.Add(this.removeButton);
            this.addSportTab.Controls.Add(this.removeSportBox);
            this.addSportTab.Controls.Add(this.removeSportLabel);
            this.addSportTab.Controls.Add(this.addButton);
            this.addSportTab.Controls.Add(this.addSportBox);
            this.addSportTab.Controls.Add(this.addSportLabel);
            this.addSportTab.Location = new System.Drawing.Point(4, 28);
            this.addSportTab.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.addSportTab.Name = "addSportTab";
            this.addSportTab.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.addSportTab.Size = new System.Drawing.Size(678, 355);
            this.addSportTab.TabIndex = 2;
            this.addSportTab.Text = "Add Sport (placeholder)";
            this.addSportTab.UseVisualStyleBackColor = true;
            // 
            // removeButton
            // 
            this.removeButton.Location = new System.Drawing.Point(551, 91);
            this.removeButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(117, 24);
            this.removeButton.TabIndex = 5;
            this.removeButton.Text = "Remove";
            this.removeButton.UseVisualStyleBackColor = true;
            this.removeButton.Click += new System.EventHandler(this.RemoveSport);
            // 
            // removeSportBox
            // 
            this.removeSportBox.FormattingEnabled = true;
            this.removeSportBox.Location = new System.Drawing.Point(156, 91);
            this.removeSportBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.removeSportBox.Name = "removeSportBox";
            this.removeSportBox.Size = new System.Drawing.Size(390, 27);
            this.removeSportBox.TabIndex = 4;
            // 
            // removeSportLabel
            // 
            this.removeSportLabel.AutoSize = true;
            this.removeSportLabel.Location = new System.Drawing.Point(22, 91);
            this.removeSportLabel.Name = "removeSportLabel";
            this.removeSportLabel.Size = new System.Drawing.Size(102, 19);
            this.removeSportLabel.TabIndex = 3;
            this.removeSportLabel.Text = "Remove sport:";
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(551, 56);
            this.addButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(117, 23);
            this.addButton.TabIndex = 2;
            this.addButton.Text = "Add";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.AddSport);
            // 
            // addSportBox
            // 
            this.addSportBox.Location = new System.Drawing.Point(156, 56);
            this.addSportBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.addSportBox.Name = "addSportBox";
            this.addSportBox.PlaceholderText = "Sport";
            this.addSportBox.Size = new System.Drawing.Size(390, 26);
            this.addSportBox.TabIndex = 1;
            // 
            // addSportLabel
            // 
            this.addSportLabel.AutoSize = true;
            this.addSportLabel.Location = new System.Drawing.Point(22, 56);
            this.addSportLabel.Name = "addSportLabel";
            this.addSportLabel.Size = new System.Drawing.Size(110, 19);
            this.addSportLabel.TabIndex = 0;
            this.addSportLabel.Text = "Add sport type:";
            // 
            // currentEventsTab
            // 
            this.currentEventsTab.AutoScroll = true;
            this.currentEventsTab.Controls.Add(this.CurrentEventsTable);
            this.currentEventsTab.Controls.Add(this.label4);
            this.currentEventsTab.Controls.Add(this.dateTimePicker1);
            this.currentEventsTab.Controls.Add(this.comboBox1);
            this.currentEventsTab.Controls.Add(this.label3);
            this.currentEventsTab.Controls.Add(this.label2);
            this.currentEventsTab.Location = new System.Drawing.Point(4, 25);
            this.currentEventsTab.Name = "currentEventsTab";
            this.currentEventsTab.Padding = new System.Windows.Forms.Padding(3);
            this.currentEventsTab.Size = new System.Drawing.Size(692, 393);
            this.currentEventsTab.TabIndex = 0;
            this.currentEventsTab.Text = "Current events";
            this.currentEventsTab.UseVisualStyleBackColor = true;
            // 
            // CurrentEventsTable
            // 
            this.CurrentEventsTable.AutoSize = true;
            this.CurrentEventsTable.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.CurrentEventsTable.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.CurrentEventsTable.ColumnCount = 1;
            this.CurrentEventsTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.CurrentEventsTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.CurrentEventsTable.Location = new System.Drawing.Point(24, 166);
            this.CurrentEventsTable.Name = "CurrentEventsTable";
            this.CurrentEventsTable.RowCount = 1;
            this.CurrentEventsTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.CurrentEventsTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.CurrentEventsTable.Size = new System.Drawing.Size(2, 2);
            this.CurrentEventsTable.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 106);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 19);
            this.label4.TabIndex = 4;
            this.label4.Text = "Date";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(101, 104);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 26);
            this.dateTimePicker1.TabIndex = 3;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(101, 60);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 27);
            this.comboBox1.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 19);
            this.label3.TabIndex = 1;
            this.label3.Text = "Sport";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(317, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 19);
            this.label2.TabIndex = 0;
            this.label2.Text = "Filter";
            // 
            // menuTabs
            // 
            this.menuTabs.Controls.Add(this.currentEventsTab);
            this.menuTabs.Controls.Add(this.eventManagerTab);
            this.menuTabs.Controls.Add(this.profileTab);
            this.menuTabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.menuTabs.Font = new System.Drawing.Font("Comic Sans MS", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.menuTabs.ItemSize = new System.Drawing.Size(266, 21);
            this.menuTabs.Location = new System.Drawing.Point(0, 0);
            this.menuTabs.Name = "menuTabs";
            this.menuTabs.SelectedIndex = 0;
            this.menuTabs.Size = new System.Drawing.Size(700, 422);
            this.menuTabs.TabIndex = 0;
            this.menuTabs.SelectedIndexChanged += new System.EventHandler(this.menuTabs_SelectedIndexChanged);
            // 
            // UiMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 422);
            this.Controls.Add(this.menuTabs);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "UiMain";
            this.Text = "localhost";
            this.Load += new System.EventHandler(this.MainLoad);
            this.profileTab.ResumeLayout(false);
            this.profileTab.PerformLayout();
            this.eventManagerTab.ResumeLayout(false);
            this.managerTabs.ResumeLayout(false);
            this.newEventTab.ResumeLayout(false);
            this.newEventTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.priceBox)).EndInit();
            this.addSportTab.ResumeLayout(false);
            this.addSportTab.PerformLayout();
            this.currentEventsTab.ResumeLayout(false);
            this.currentEventsTab.PerformLayout();
            this.menuTabs.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage profileTab;
        private System.Windows.Forms.TabPage eventManagerTab;
        private System.Windows.Forms.TabControl managerTabs;
        private System.Windows.Forms.TabPage yourEventsTab;
        private System.Windows.Forms.TabPage newEventTab;
        private System.Windows.Forms.TabPage currentEventsTab;
        private System.Windows.Forms.TabControl menuTabs;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader Date;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Label creatorHeader;
        private System.Windows.Forms.Label descriptionLabel;
        private System.Windows.Forms.Label priceLabel;
        private System.Windows.Forms.Label sportLabel;
        private System.Windows.Forms.Label dateLabel;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.NumericUpDown priceBox;
        private System.Windows.Forms.ComboBox sportBox;
        private System.Windows.Forms.DateTimePicker dateBox;
        private System.Windows.Forms.TextBox nameBox;
        private System.Windows.Forms.TextBox descriptionBox;
        private System.Windows.Forms.Button createEventButton;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox userAdressBox;
        private System.Windows.Forms.Label profileManagerLabel;
        private System.Windows.Forms.TextBox eventAdressBox;
        private System.Windows.Forms.Label adressLabel;
        private System.Windows.Forms.TabPage addSportTab;
        private System.Windows.Forms.TextBox addSportBox;
        private System.Windows.Forms.Label addSportLabel;
        private System.Windows.Forms.Label removeSportLabel;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button removeButton;
        private System.Windows.Forms.ComboBox removeSportBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button locationButton;
        private System.Windows.Forms.Button mapsBrowserButton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TableLayoutPanel CurrentEventsTable;
    }
}