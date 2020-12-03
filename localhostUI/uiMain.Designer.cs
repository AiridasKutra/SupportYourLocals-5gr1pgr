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
            this.button2 = new System.Windows.Forms.Button();
            this.usernameChangeResultLabel = new System.Windows.Forms.Label();
            this.changeUsernameButton = new System.Windows.Forms.Button();
            this.usernameBox = new System.Windows.Forms.TextBox();
            this.changeNameLabel = new System.Windows.Forms.Label();
            this.addressResultLabel = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.locationButton = new System.Windows.Forms.Button();
            this.profileManagerLabel = new System.Windows.Forms.Label();
            this.changeAddressLabel = new System.Windows.Forms.Label();
            this.userAdressBox = new System.Windows.Forms.TextBox();
            this.currentEventsTab = new System.Windows.Forms.TabPage();
            this.filterDistanceValueLabel = new System.Windows.Forms.Label();
            this.filterDistanceSlider = new System.Windows.Forms.TrackBar();
            this.filterDistanceLabel = new System.Windows.Forms.Label();
            this.searchButton = new System.Windows.Forms.Button();
            this.filterDateSepratorLabel = new System.Windows.Forms.Label();
            this.filterEndDate = new System.Windows.Forms.DateTimePicker();
            this.filterPriceValueLabel = new System.Windows.Forms.Label();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.filterButton = new System.Windows.Forms.Button();
            this.filterPriceSlider = new System.Windows.Forms.TrackBar();
            this.filterPriceLabel = new System.Windows.Forms.Label();
            this.CurrentEventsTable = new System.Windows.Forms.TableLayoutPanel();
            this.filterDateLabel = new System.Windows.Forms.Label();
            this.filterStartDate = new System.Windows.Forms.DateTimePicker();
            this.filterSportSelector = new System.Windows.Forms.ComboBox();
            this.filterSportLabel = new System.Windows.Forms.Label();
            this.currentEventsTitleLabel = new System.Windows.Forms.Label();
            this.menuTabs = new System.Windows.Forms.TabControl();
            this.eventManagerTabNew = new System.Windows.Forms.TabPage();
            this.emanagerDraftsLabel = new System.Windows.Forms.Label();
            this.emanagerDraftsPanel = new System.Windows.Forms.Panel();
            this.emanagerMyEventsPanel = new System.Windows.Forms.Panel();
            this.emanagerMyEventsLabel = new System.Windows.Forms.Label();
            this.emanagerCreateEventButton = new System.Windows.Forms.Button();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.contentPanel = new System.Windows.Forms.Panel();
            this.bannerPanel = new System.Windows.Forms.Panel();
            this.overlayPicturePanel = new System.Windows.Forms.Panel();
            this.profileTab.SuspendLayout();
            this.currentEventsTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.filterDistanceSlider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.filterPriceSlider)).BeginInit();
            this.menuTabs.SuspendLayout();
            this.eventManagerTabNew.SuspendLayout();
            this.SuspendLayout();
            // 
            // profileTab
            // 
            this.profileTab.BackColor = System.Drawing.SystemColors.Control;
            this.profileTab.Controls.Add(this.button2);
            this.profileTab.Controls.Add(this.usernameChangeResultLabel);
            this.profileTab.Controls.Add(this.changeUsernameButton);
            this.profileTab.Controls.Add(this.usernameBox);
            this.profileTab.Controls.Add(this.changeNameLabel);
            this.profileTab.Controls.Add(this.addressResultLabel);
            this.profileTab.Controls.Add(this.button1);
            this.profileTab.Controls.Add(this.locationButton);
            this.profileTab.Controls.Add(this.profileManagerLabel);
            this.profileTab.Controls.Add(this.changeAddressLabel);
            this.profileTab.Controls.Add(this.userAdressBox);
            this.profileTab.Location = new System.Drawing.Point(4, 25);
            this.profileTab.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.profileTab.Name = "profileTab";
            this.profileTab.Padding = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.profileTab.Size = new System.Drawing.Size(805, 572);
            this.profileTab.TabIndex = 2;
            this.profileTab.Text = "Profile manager";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(665, 124);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(107, 33);
            this.button2.TabIndex = 21;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Visible = false;
            this.button2.Click += new System.EventHandler(this.FormattAdressButton);
            // 
            // usernameChangeResultLabel
            // 
            this.usernameChangeResultLabel.AutoSize = true;
            this.usernameChangeResultLabel.Location = new System.Drawing.Point(339, 272);
            this.usernameChangeResultLabel.Name = "usernameChangeResultLabel";
            this.usernameChangeResultLabel.Size = new System.Drawing.Size(0, 17);
            this.usernameChangeResultLabel.TabIndex = 20;
            // 
            // changeUsernameButton
            // 
            this.changeUsernameButton.Location = new System.Drawing.Point(26, 232);
            this.changeUsernameButton.Name = "changeUsernameButton";
            this.changeUsernameButton.Size = new System.Drawing.Size(173, 42);
            this.changeUsernameButton.TabIndex = 19;
            this.changeUsernameButton.Text = "Change username";
            this.changeUsernameButton.UseVisualStyleBackColor = true;
            this.changeUsernameButton.Click += new System.EventHandler(this.ChangeUsername);
            // 
            // usernameBox
            // 
            this.usernameBox.Location = new System.Drawing.Point(170, 185);
            this.usernameBox.Name = "usernameBox";
            this.usernameBox.PlaceholderText = "User";
            this.usernameBox.Size = new System.Drawing.Size(602, 25);
            this.usernameBox.TabIndex = 18;
            // 
            // changeNameLabel
            // 
            this.changeNameLabel.AutoSize = true;
            this.changeNameLabel.Location = new System.Drawing.Point(26, 188);
            this.changeNameLabel.Name = "changeNameLabel";
            this.changeNameLabel.Size = new System.Drawing.Size(111, 17);
            this.changeNameLabel.TabIndex = 17;
            this.changeNameLabel.Text = "Your username:";
            // 
            // addressResultLabel
            // 
            this.addressResultLabel.AutoSize = true;
            this.addressResultLabel.Location = new System.Drawing.Point(339, 124);
            this.addressResultLabel.Name = "addressResultLabel";
            this.addressResultLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.addressResultLabel.Size = new System.Drawing.Size(0, 17);
            this.addressResultLabel.TabIndex = 16;
            // 
            // button1
            // 
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.Location = new System.Drawing.Point(206, 116);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(41, 41);
            this.button1.TabIndex = 15;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.UserSearchMapsBrowser);
            // 
            // locationButton
            // 
            this.locationButton.Location = new System.Drawing.Point(26, 114);
            this.locationButton.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.locationButton.Name = "locationButton";
            this.locationButton.Size = new System.Drawing.Size(173, 42);
            this.locationButton.TabIndex = 3;
            this.locationButton.Text = "Change address";
            this.locationButton.UseVisualStyleBackColor = true;
            this.locationButton.Click += new System.EventHandler(this.ChangeUserAddress);
            // 
            // profileManagerLabel
            // 
            this.profileManagerLabel.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.profileManagerLabel.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.profileManagerLabel.Location = new System.Drawing.Point(26, 15);
            this.profileManagerLabel.Name = "profileManagerLabel";
            this.profileManagerLabel.Size = new System.Drawing.Size(155, 33);
            this.profileManagerLabel.TabIndex = 2;
            this.profileManagerLabel.Text = "Your profile";
            // 
            // changeAddressLabel
            // 
            this.changeAddressLabel.AutoSize = true;
            this.changeAddressLabel.Location = new System.Drawing.Point(26, 71);
            this.changeAddressLabel.Name = "changeAddressLabel";
            this.changeAddressLabel.Size = new System.Drawing.Size(90, 17);
            this.changeAddressLabel.TabIndex = 1;
            this.changeAddressLabel.Text = "Your adress:";
            // 
            // userAdressBox
            // 
            this.userAdressBox.BackColor = System.Drawing.SystemColors.HighlightText;
            this.userAdressBox.Location = new System.Drawing.Point(170, 68);
            this.userAdressBox.Name = "userAdressBox";
            this.userAdressBox.PlaceholderText = "Didlaukio g. 59";
            this.userAdressBox.Size = new System.Drawing.Size(602, 25);
            this.userAdressBox.TabIndex = 0;
            // 
            // currentEventsTab
            // 
            this.currentEventsTab.AutoScroll = true;
            this.currentEventsTab.BackColor = System.Drawing.SystemColors.Control;
            this.currentEventsTab.Controls.Add(this.filterDistanceValueLabel);
            this.currentEventsTab.Controls.Add(this.filterDistanceSlider);
            this.currentEventsTab.Controls.Add(this.filterDistanceLabel);
            this.currentEventsTab.Controls.Add(this.searchButton);
            this.currentEventsTab.Controls.Add(this.filterDateSepratorLabel);
            this.currentEventsTab.Controls.Add(this.filterEndDate);
            this.currentEventsTab.Controls.Add(this.filterPriceValueLabel);
            this.currentEventsTab.Controls.Add(this.searchTextBox);
            this.currentEventsTab.Controls.Add(this.filterButton);
            this.currentEventsTab.Controls.Add(this.filterPriceSlider);
            this.currentEventsTab.Controls.Add(this.filterPriceLabel);
            this.currentEventsTab.Controls.Add(this.CurrentEventsTable);
            this.currentEventsTab.Controls.Add(this.filterDateLabel);
            this.currentEventsTab.Controls.Add(this.filterStartDate);
            this.currentEventsTab.Controls.Add(this.filterSportSelector);
            this.currentEventsTab.Controls.Add(this.filterSportLabel);
            this.currentEventsTab.Controls.Add(this.currentEventsTitleLabel);
            this.currentEventsTab.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.currentEventsTab.Location = new System.Drawing.Point(4, 25);
            this.currentEventsTab.Name = "currentEventsTab";
            this.currentEventsTab.Padding = new System.Windows.Forms.Padding(3);
            this.currentEventsTab.Size = new System.Drawing.Size(805, 572);
            this.currentEventsTab.TabIndex = 0;
            this.currentEventsTab.Text = "Current events";
            // 
            // filterDistanceValueLabel
            // 
            this.filterDistanceValueLabel.AutoSize = true;
            this.filterDistanceValueLabel.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.filterDistanceValueLabel.Location = new System.Drawing.Point(698, 92);
            this.filterDistanceValueLabel.Name = "filterDistanceValueLabel";
            this.filterDistanceValueLabel.Size = new System.Drawing.Size(48, 17);
            this.filterDistanceValueLabel.TabIndex = 10;
            this.filterDistanceValueLabel.Text = "0.0km";
            // 
            // filterDistanceSlider
            // 
            this.filterDistanceSlider.AutoSize = false;
            this.filterDistanceSlider.Location = new System.Drawing.Point(559, 88);
            this.filterDistanceSlider.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.filterDistanceSlider.Maximum = 1000;
            this.filterDistanceSlider.Name = "filterDistanceSlider";
            this.filterDistanceSlider.Size = new System.Drawing.Size(133, 26);
            this.filterDistanceSlider.TabIndex = 7;
            this.filterDistanceSlider.TickStyle = System.Windows.Forms.TickStyle.None;
            this.filterDistanceSlider.Scroll += new System.EventHandler(this.filterDistanceSlider_Scroll);
            // 
            // filterDistanceLabel
            // 
            this.filterDistanceLabel.AutoSize = true;
            this.filterDistanceLabel.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.filterDistanceLabel.Location = new System.Drawing.Point(443, 91);
            this.filterDistanceLabel.Name = "filterDistanceLabel";
            this.filterDistanceLabel.Size = new System.Drawing.Size(93, 17);
            this.filterDistanceLabel.TabIndex = 15;
            this.filterDistanceLabel.Text = "Max distance";
            // 
            // searchButton
            // 
            this.searchButton.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.searchButton.Location = new System.Drawing.Point(351, 224);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(102, 33);
            this.searchButton.TabIndex = 14;
            this.searchButton.Text = "Search";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // filterDateSepratorLabel
            // 
            this.filterDateSepratorLabel.AutoSize = true;
            this.filterDateSepratorLabel.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.filterDateSepratorLabel.Location = new System.Drawing.Point(238, 86);
            this.filterDateSepratorLabel.Name = "filterDateSepratorLabel";
            this.filterDateSepratorLabel.Size = new System.Drawing.Size(21, 20);
            this.filterDateSepratorLabel.TabIndex = 13;
            this.filterDateSepratorLabel.Text = "—";
            // 
            // filterEndDate
            // 
            this.filterEndDate.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.filterEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.filterEndDate.Location = new System.Drawing.Point(266, 86);
            this.filterEndDate.Name = "filterEndDate";
            this.filterEndDate.Size = new System.Drawing.Size(131, 25);
            this.filterEndDate.TabIndex = 12;
            // 
            // filterPriceValueLabel
            // 
            this.filterPriceValueLabel.AutoSize = true;
            this.filterPriceValueLabel.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.filterPriceValueLabel.Location = new System.Drawing.Point(698, 58);
            this.filterPriceValueLabel.Name = "filterPriceValueLabel";
            this.filterPriceValueLabel.Size = new System.Drawing.Size(36, 17);
            this.filterPriceValueLabel.TabIndex = 10;
            this.filterPriceValueLabel.Text = "0.0€";
            // 
            // searchTextBox
            // 
            this.searchTextBox.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.searchTextBox.Location = new System.Drawing.Point(245, 189);
            this.searchTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.Size = new System.Drawing.Size(314, 25);
            this.searchTextBox.TabIndex = 9;
            // 
            // filterButton
            // 
            this.filterButton.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.filterButton.Location = new System.Drawing.Point(351, 120);
            this.filterButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.filterButton.Name = "filterButton";
            this.filterButton.Size = new System.Drawing.Size(102, 31);
            this.filterButton.TabIndex = 8;
            this.filterButton.Text = "Filter";
            this.filterButton.UseVisualStyleBackColor = true;
            this.filterButton.Click += new System.EventHandler(this.filterButton_Click);
            // 
            // filterPriceSlider
            // 
            this.filterPriceSlider.AutoSize = false;
            this.filterPriceSlider.Location = new System.Drawing.Point(559, 54);
            this.filterPriceSlider.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.filterPriceSlider.Maximum = 1000;
            this.filterPriceSlider.Name = "filterPriceSlider";
            this.filterPriceSlider.Size = new System.Drawing.Size(133, 26);
            this.filterPriceSlider.TabIndex = 7;
            this.filterPriceSlider.TickStyle = System.Windows.Forms.TickStyle.None;
            this.filterPriceSlider.Scroll += new System.EventHandler(this.filterPriceSlider_Scroll);
            // 
            // filterPriceLabel
            // 
            this.filterPriceLabel.AutoSize = true;
            this.filterPriceLabel.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.filterPriceLabel.Location = new System.Drawing.Point(443, 58);
            this.filterPriceLabel.Name = "filterPriceLabel";
            this.filterPriceLabel.Size = new System.Drawing.Size(70, 17);
            this.filterPriceLabel.TabIndex = 6;
            this.filterPriceLabel.Text = "Max price";
            // 
            // CurrentEventsTable
            // 
            this.CurrentEventsTable.AutoSize = true;
            this.CurrentEventsTable.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.CurrentEventsTable.ColumnCount = 2;
            this.CurrentEventsTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.CurrentEventsTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.CurrentEventsTable.Location = new System.Drawing.Point(30, 278);
            this.CurrentEventsTable.Name = "CurrentEventsTable";
            this.CurrentEventsTable.RowCount = 1;
            this.CurrentEventsTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.CurrentEventsTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.CurrentEventsTable.Size = new System.Drawing.Size(0, 0);
            this.CurrentEventsTable.TabIndex = 5;
            // 
            // filterDateLabel
            // 
            this.filterDateLabel.AutoSize = true;
            this.filterDateLabel.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.filterDateLabel.Location = new System.Drawing.Point(27, 91);
            this.filterDateLabel.Name = "filterDateLabel";
            this.filterDateLabel.Size = new System.Drawing.Size(39, 17);
            this.filterDateLabel.TabIndex = 4;
            this.filterDateLabel.Text = "Date";
            // 
            // filterStartDate
            // 
            this.filterStartDate.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.filterStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.filterStartDate.Location = new System.Drawing.Point(101, 86);
            this.filterStartDate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.filterStartDate.Name = "filterStartDate";
            this.filterStartDate.Size = new System.Drawing.Size(131, 25);
            this.filterStartDate.TabIndex = 3;
            // 
            // filterSportSelector
            // 
            this.filterSportSelector.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.filterSportSelector.FormattingEnabled = true;
            this.filterSportSelector.Location = new System.Drawing.Point(101, 51);
            this.filterSportSelector.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.filterSportSelector.Name = "filterSportSelector";
            this.filterSportSelector.Size = new System.Drawing.Size(297, 25);
            this.filterSportSelector.TabIndex = 2;
            // 
            // filterSportLabel
            // 
            this.filterSportLabel.AutoSize = true;
            this.filterSportLabel.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.filterSportLabel.Location = new System.Drawing.Point(27, 56);
            this.filterSportLabel.Name = "filterSportLabel";
            this.filterSportLabel.Size = new System.Drawing.Size(43, 17);
            this.filterSportLabel.TabIndex = 1;
            this.filterSportLabel.Text = "Sport";
            // 
            // currentEventsTitleLabel
            // 
            this.currentEventsTitleLabel.AutoSize = true;
            this.currentEventsTitleLabel.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.currentEventsTitleLabel.Location = new System.Drawing.Point(326, 17);
            this.currentEventsTitleLabel.Name = "currentEventsTitleLabel";
            this.currentEventsTitleLabel.Size = new System.Drawing.Size(133, 22);
            this.currentEventsTitleLabel.TabIndex = 0;
            this.currentEventsTitleLabel.Text = "Current events";
            // 
            // menuTabs
            // 
            this.menuTabs.Controls.Add(this.currentEventsTab);
            this.menuTabs.Controls.Add(this.eventManagerTabNew);
            this.menuTabs.Controls.Add(this.profileTab);
            this.menuTabs.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.menuTabs.ItemSize = new System.Drawing.Size(266, 21);
            this.menuTabs.Location = new System.Drawing.Point(2300, 0);
            this.menuTabs.Name = "menuTabs";
            this.menuTabs.SelectedIndex = 0;
            this.menuTabs.Size = new System.Drawing.Size(813, 601);
            this.menuTabs.TabIndex = 0;
            this.menuTabs.Visible = false;
            this.menuTabs.SelectedIndexChanged += new System.EventHandler(this.menuTabs_SelectedIndexChanged);
            // 
            // eventManagerTabNew
            // 
            this.eventManagerTabNew.Controls.Add(this.emanagerDraftsLabel);
            this.eventManagerTabNew.Controls.Add(this.emanagerDraftsPanel);
            this.eventManagerTabNew.Controls.Add(this.emanagerMyEventsPanel);
            this.eventManagerTabNew.Controls.Add(this.emanagerMyEventsLabel);
            this.eventManagerTabNew.Controls.Add(this.emanagerCreateEventButton);
            this.eventManagerTabNew.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.eventManagerTabNew.Location = new System.Drawing.Point(4, 25);
            this.eventManagerTabNew.Name = "eventManagerTabNew";
            this.eventManagerTabNew.Size = new System.Drawing.Size(805, 572);
            this.eventManagerTabNew.TabIndex = 3;
            this.eventManagerTabNew.Text = "Event manager";
            // 
            // emanagerDraftsLabel
            // 
            this.emanagerDraftsLabel.AutoSize = true;
            this.emanagerDraftsLabel.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.emanagerDraftsLabel.Location = new System.Drawing.Point(423, 92);
            this.emanagerDraftsLabel.Name = "emanagerDraftsLabel";
            this.emanagerDraftsLabel.Size = new System.Drawing.Size(66, 22);
            this.emanagerDraftsLabel.TabIndex = 3;
            this.emanagerDraftsLabel.Text = "Drafts";
            // 
            // emanagerDraftsPanel
            // 
            this.emanagerDraftsPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.emanagerDraftsPanel.Location = new System.Drawing.Point(423, 146);
            this.emanagerDraftsPanel.Name = "emanagerDraftsPanel";
            this.emanagerDraftsPanel.Size = new System.Drawing.Size(343, 388);
            this.emanagerDraftsPanel.TabIndex = 2;
            // 
            // emanagerMyEventsPanel
            // 
            this.emanagerMyEventsPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.emanagerMyEventsPanel.Location = new System.Drawing.Point(35, 146);
            this.emanagerMyEventsPanel.Name = "emanagerMyEventsPanel";
            this.emanagerMyEventsPanel.Size = new System.Drawing.Size(343, 388);
            this.emanagerMyEventsPanel.TabIndex = 2;
            // 
            // emanagerMyEventsLabel
            // 
            this.emanagerMyEventsLabel.AutoSize = true;
            this.emanagerMyEventsLabel.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.emanagerMyEventsLabel.Location = new System.Drawing.Point(33, 92);
            this.emanagerMyEventsLabel.Name = "emanagerMyEventsLabel";
            this.emanagerMyEventsLabel.Size = new System.Drawing.Size(105, 22);
            this.emanagerMyEventsLabel.TabIndex = 1;
            this.emanagerMyEventsLabel.Text = "My events";
            // 
            // emanagerCreateEventButton
            // 
            this.emanagerCreateEventButton.Location = new System.Drawing.Point(33, 31);
            this.emanagerCreateEventButton.Name = "emanagerCreateEventButton";
            this.emanagerCreateEventButton.Size = new System.Drawing.Size(174, 33);
            this.emanagerCreateEventButton.TabIndex = 0;
            this.emanagerCreateEventButton.Text = "Create new event";
            this.emanagerCreateEventButton.UseVisualStyleBackColor = true;
            this.emanagerCreateEventButton.Click += new System.EventHandler(this.emanagerCreateNewEventButton_Click);
            // 
            // contentPanel
            // 
            this.contentPanel.Location = new System.Drawing.Point(270, 126);
            this.contentPanel.Name = "contentPanel";
            this.contentPanel.Size = new System.Drawing.Size(926, 105);
            this.contentPanel.TabIndex = 1;
            // 
            // bannerPanel
            // 
            this.bannerPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(168)))), ((int)(((byte)(135)))));
            this.bannerPanel.Location = new System.Drawing.Point(0, 0);
            this.bannerPanel.Name = "bannerPanel";
            this.bannerPanel.Size = new System.Drawing.Size(100, 100);
            this.bannerPanel.TabIndex = 2;
            // 
            // overlayPicturePanel
            // 
            this.overlayPicturePanel.Location = new System.Drawing.Point(32, 126);
            this.overlayPicturePanel.Name = "overlayPicturePanel";
            this.overlayPicturePanel.Size = new System.Drawing.Size(112, 104);
            this.overlayPicturePanel.TabIndex = 3;
            this.overlayPicturePanel.Visible = false;
            // 
            // UiMain
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.ClientSize = new System.Drawing.Size(1445, 772);
            this.Controls.Add(this.overlayPicturePanel);
            this.Controls.Add(this.bannerPanel);
            this.Controls.Add(this.contentPanel);
            this.Controls.Add(this.menuTabs);
            this.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "UiMain";
            this.Text = "localhost";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SaveToFile);
            this.Load += new System.EventHandler(this.MainLoad);
            this.ResizeEnd += new System.EventHandler(this.UiMain_Resize);
            this.Resize += new System.EventHandler(this.UiMain_Resize);
            this.profileTab.ResumeLayout(false);
            this.profileTab.PerformLayout();
            this.currentEventsTab.ResumeLayout(false);
            this.currentEventsTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.filterDistanceSlider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.filterPriceSlider)).EndInit();
            this.menuTabs.ResumeLayout(false);
            this.eventManagerTabNew.ResumeLayout(false);
            this.eventManagerTabNew.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage profileTab;
        private System.Windows.Forms.TabPage currentEventsTab;
        private System.Windows.Forms.TabControl menuTabs;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader Date;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Label changeAddressLabel;
        private System.Windows.Forms.TextBox userAdressBox;
        private System.Windows.Forms.Label profileManagerLabel;
        private System.Windows.Forms.Label filterDateLabel;
        private System.Windows.Forms.DateTimePicker filterStartDate;
        private System.Windows.Forms.ComboBox filterSportSelector;
        private System.Windows.Forms.Label filterSportLabel;
        private System.Windows.Forms.Label currentEventsTitleLabel;
        private System.Windows.Forms.Button locationButton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TableLayoutPanel CurrentEventsTable;
        private System.Windows.Forms.Label addressResultLabel;
        private System.Windows.Forms.Label changeNameLabel;
        private System.Windows.Forms.Button changeUsernameButton;
        private System.Windows.Forms.TextBox usernameBox;
        private System.Windows.Forms.Label usernameChangeResultLabel;
        private System.Windows.Forms.Button filterButton;
        private System.Windows.Forms.TrackBar filterPriceSlider;
        private System.Windows.Forms.Label filterPriceLabel;
        private System.Windows.Forms.TextBox searchTextBox;
        private System.Windows.Forms.Label filterPriceValueLabel;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DateTimePicker filterEndDate;
        private System.Windows.Forms.Label filterDateSepratorLabel;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.Label filterDistanceLabel;
        private System.Windows.Forms.Label nceLabel;
        private System.Windows.Forms.TrackBar filterDistanceSlider;
        private System.Windows.Forms.Label filterDistanceValueLabel;
        private System.Windows.Forms.TabPage eventManagerTabNew;
        private System.Windows.Forms.Label emanagerDraftsLabel;
        private System.Windows.Forms.Panel emanagerDraftsPanel;
        private System.Windows.Forms.Panel emanagerMyEventsPanel;
        private System.Windows.Forms.Label emanagerMyEventsLabel;
        private System.Windows.Forms.Button emanagerCreateEventButton;
        private System.Windows.Forms.Panel contentPanel;
        private System.Windows.Forms.Panel bannerPanel;
        private System.Windows.Forms.Panel overlayPicturePanel;
    }
}