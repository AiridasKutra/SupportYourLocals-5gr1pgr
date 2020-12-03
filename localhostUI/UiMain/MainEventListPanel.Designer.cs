namespace localhostUI
{
    partial class MainEventListPanel
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
            this.mainPanel = new System.Windows.Forms.Panel();
            this.filterPanel = new System.Windows.Forms.Panel();
            this.showInvisibleEventsCheckBox = new System.Windows.Forms.CheckBox();
            this.searchButton = new System.Windows.Forms.Button();
            this.filterSearchTextBox = new System.Windows.Forms.TextBox();
            this.filterMaxDistanceValueLabel = new System.Windows.Forms.Label();
            this.filterMaxPriceValueLabel = new System.Windows.Forms.Label();
            this.filterMaxDistanceLabel = new System.Windows.Forms.Label();
            this.filterMaxDistanceSlider = new System.Windows.Forms.TrackBar();
            this.filterMaxPriceLabel = new System.Windows.Forms.Label();
            this.filterMaxPriceSlider = new System.Windows.Forms.TrackBar();
            this.filterDateSeparatorLabel = new System.Windows.Forms.Label();
            this.filterUpperDateSelector = new System.Windows.Forms.DateTimePicker();
            this.filterLowerDateSelector = new System.Windows.Forms.DateTimePicker();
            this.filterSportSelector = new System.Windows.Forms.ComboBox();
            this.eventGridPanel = new System.Windows.Forms.Panel();
            this.titleLabel = new System.Windows.Forms.Label();
            this.mainPanel.SuspendLayout();
            this.filterPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.filterMaxDistanceSlider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.filterMaxPriceSlider)).BeginInit();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.mainPanel.Controls.Add(this.filterPanel);
            this.mainPanel.Controls.Add(this.eventGridPanel);
            this.mainPanel.Controls.Add(this.titleLabel);
            this.mainPanel.Location = new System.Drawing.Point(8, 9);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(1000, 800);
            this.mainPanel.TabIndex = 0;
            // 
            // filterPanel
            // 
            this.filterPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.filterPanel.Controls.Add(this.showInvisibleEventsCheckBox);
            this.filterPanel.Controls.Add(this.searchButton);
            this.filterPanel.Controls.Add(this.filterSearchTextBox);
            this.filterPanel.Controls.Add(this.filterMaxDistanceValueLabel);
            this.filterPanel.Controls.Add(this.filterMaxPriceValueLabel);
            this.filterPanel.Controls.Add(this.filterMaxDistanceLabel);
            this.filterPanel.Controls.Add(this.filterMaxDistanceSlider);
            this.filterPanel.Controls.Add(this.filterMaxPriceLabel);
            this.filterPanel.Controls.Add(this.filterMaxPriceSlider);
            this.filterPanel.Controls.Add(this.filterDateSeparatorLabel);
            this.filterPanel.Controls.Add(this.filterUpperDateSelector);
            this.filterPanel.Controls.Add(this.filterLowerDateSelector);
            this.filterPanel.Controls.Add(this.filterSportSelector);
            this.filterPanel.Location = new System.Drawing.Point(150, 120);
            this.filterPanel.Name = "filterPanel";
            this.filterPanel.Size = new System.Drawing.Size(700, 194);
            this.filterPanel.TabIndex = 14;
            // 
            // showInvisibleEventsCheckBox
            // 
            this.showInvisibleEventsCheckBox.ForeColor = System.Drawing.Color.DimGray;
            this.showInvisibleEventsCheckBox.Location = new System.Drawing.Point(50, 99);
            this.showInvisibleEventsCheckBox.Name = "showInvisibleEventsCheckBox";
            this.showInvisibleEventsCheckBox.Size = new System.Drawing.Size(144, 26);
            this.showInvisibleEventsCheckBox.TabIndex = 13;
            this.showInvisibleEventsCheckBox.Text = "Show invisible";
            this.showInvisibleEventsCheckBox.UseVisualStyleBackColor = true;
            // 
            // searchButton
            // 
            this.searchButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(168)))), ((int)(((byte)(135)))));
            this.searchButton.FlatAppearance.BorderSize = 0;
            this.searchButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.searchButton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.searchButton.ForeColor = System.Drawing.Color.White;
            this.searchButton.Location = new System.Drawing.Point(300, 129);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(100, 30);
            this.searchButton.TabIndex = 12;
            this.searchButton.TabStop = false;
            this.searchButton.Text = "Search";
            this.searchButton.UseVisualStyleBackColor = false;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // filterSearchTextBox
            // 
            this.filterSearchTextBox.ForeColor = System.Drawing.Color.DimGray;
            this.filterSearchTextBox.Location = new System.Drawing.Point(200, 99);
            this.filterSearchTextBox.Name = "filterSearchTextBox";
            this.filterSearchTextBox.PlaceholderText = "Enter keywords";
            this.filterSearchTextBox.Size = new System.Drawing.Size(300, 26);
            this.filterSearchTextBox.TabIndex = 11;
            // 
            // filterMaxDistanceValueLabel
            // 
            this.filterMaxDistanceValueLabel.AutoSize = true;
            this.filterMaxDistanceValueLabel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.filterMaxDistanceValueLabel.ForeColor = System.Drawing.Color.DimGray;
            this.filterMaxDistanceValueLabel.Location = new System.Drawing.Point(586, 71);
            this.filterMaxDistanceValueLabel.Name = "filterMaxDistanceValueLabel";
            this.filterMaxDistanceValueLabel.Size = new System.Drawing.Size(51, 18);
            this.filterMaxDistanceValueLabel.TabIndex = 10;
            this.filterMaxDistanceValueLabel.Text = "0.0km";
            // 
            // filterMaxPriceValueLabel
            // 
            this.filterMaxPriceValueLabel.AutoSize = true;
            this.filterMaxPriceValueLabel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.filterMaxPriceValueLabel.ForeColor = System.Drawing.Color.DimGray;
            this.filterMaxPriceValueLabel.Location = new System.Drawing.Point(586, 40);
            this.filterMaxPriceValueLabel.Name = "filterMaxPriceValueLabel";
            this.filterMaxPriceValueLabel.Size = new System.Drawing.Size(39, 18);
            this.filterMaxPriceValueLabel.TabIndex = 9;
            this.filterMaxPriceValueLabel.Text = "0.0€";
            // 
            // filterMaxDistanceLabel
            // 
            this.filterMaxDistanceLabel.AutoSize = true;
            this.filterMaxDistanceLabel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.filterMaxDistanceLabel.ForeColor = System.Drawing.Color.DimGray;
            this.filterMaxDistanceLabel.Location = new System.Drawing.Point(346, 71);
            this.filterMaxDistanceLabel.Name = "filterMaxDistanceLabel";
            this.filterMaxDistanceLabel.Size = new System.Drawing.Size(100, 18);
            this.filterMaxDistanceLabel.TabIndex = 8;
            this.filterMaxDistanceLabel.Text = "Max distance";
            this.filterMaxDistanceLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // filterMaxDistanceSlider
            // 
            this.filterMaxDistanceSlider.AutoSize = false;
            this.filterMaxDistanceSlider.Location = new System.Drawing.Point(452, 70);
            this.filterMaxDistanceSlider.Maximum = 1000;
            this.filterMaxDistanceSlider.Name = "filterMaxDistanceSlider";
            this.filterMaxDistanceSlider.Size = new System.Drawing.Size(128, 23);
            this.filterMaxDistanceSlider.TabIndex = 7;
            this.filterMaxDistanceSlider.TickStyle = System.Windows.Forms.TickStyle.None;
            this.filterMaxDistanceSlider.Scroll += new System.EventHandler(this.filterMaxDistanceSlider_Scroll);
            // 
            // filterMaxPriceLabel
            // 
            this.filterMaxPriceLabel.AutoSize = true;
            this.filterMaxPriceLabel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.filterMaxPriceLabel.ForeColor = System.Drawing.Color.DimGray;
            this.filterMaxPriceLabel.Location = new System.Drawing.Point(346, 40);
            this.filterMaxPriceLabel.Name = "filterMaxPriceLabel";
            this.filterMaxPriceLabel.Size = new System.Drawing.Size(76, 18);
            this.filterMaxPriceLabel.TabIndex = 6;
            this.filterMaxPriceLabel.Text = "Max price";
            this.filterMaxPriceLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // filterMaxPriceSlider
            // 
            this.filterMaxPriceSlider.AutoSize = false;
            this.filterMaxPriceSlider.Location = new System.Drawing.Point(452, 39);
            this.filterMaxPriceSlider.Maximum = 1000;
            this.filterMaxPriceSlider.Name = "filterMaxPriceSlider";
            this.filterMaxPriceSlider.Size = new System.Drawing.Size(128, 23);
            this.filterMaxPriceSlider.TabIndex = 5;
            this.filterMaxPriceSlider.TickStyle = System.Windows.Forms.TickStyle.None;
            this.filterMaxPriceSlider.Scroll += new System.EventHandler(this.filterMaxPriceSlider_Scroll);
            // 
            // filterDateSeparatorLabel
            // 
            this.filterDateSeparatorLabel.AutoSize = true;
            this.filterDateSeparatorLabel.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.filterDateSeparatorLabel.Location = new System.Drawing.Point(172, 69);
            this.filterDateSeparatorLabel.Name = "filterDateSeparatorLabel";
            this.filterDateSeparatorLabel.Size = new System.Drawing.Size(23, 17);
            this.filterDateSeparatorLabel.TabIndex = 4;
            this.filterDateSeparatorLabel.Text = "—";
            // 
            // filterUpperDateSelector
            // 
            this.filterUpperDateSelector.CalendarForeColor = System.Drawing.Color.DimGray;
            this.filterUpperDateSelector.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.filterUpperDateSelector.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.filterUpperDateSelector.Location = new System.Drawing.Point(200, 67);
            this.filterUpperDateSelector.Name = "filterUpperDateSelector";
            this.filterUpperDateSelector.Size = new System.Drawing.Size(115, 26);
            this.filterUpperDateSelector.TabIndex = 3;
            // 
            // filterLowerDateSelector
            // 
            this.filterLowerDateSelector.CalendarFont = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.filterLowerDateSelector.CalendarForeColor = System.Drawing.Color.DimGray;
            this.filterLowerDateSelector.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.filterLowerDateSelector.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.filterLowerDateSelector.Location = new System.Drawing.Point(50, 67);
            this.filterLowerDateSelector.Name = "filterLowerDateSelector";
            this.filterLowerDateSelector.Size = new System.Drawing.Size(115, 26);
            this.filterLowerDateSelector.TabIndex = 2;
            // 
            // filterSportSelector
            // 
            this.filterSportSelector.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.filterSportSelector.ForeColor = System.Drawing.Color.DimGray;
            this.filterSportSelector.FormattingEnabled = true;
            this.filterSportSelector.Location = new System.Drawing.Point(50, 36);
            this.filterSportSelector.Name = "filterSportSelector";
            this.filterSportSelector.Size = new System.Drawing.Size(265, 26);
            this.filterSportSelector.TabIndex = 1;
            this.filterSportSelector.Text = "Sport";
            // 
            // eventGridPanel
            // 
            this.eventGridPanel.Location = new System.Drawing.Point(0, 350);
            this.eventGridPanel.Name = "eventGridPanel";
            this.eventGridPanel.Size = new System.Drawing.Size(1000, 309);
            this.eventGridPanel.TabIndex = 13;
            // 
            // titleLabel
            // 
            this.titleLabel.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.titleLabel.ForeColor = System.Drawing.Color.Gray;
            this.titleLabel.Location = new System.Drawing.Point(300, 40);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(400, 40);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "Current events";
            this.titleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MainEventListPanel
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1018, 820);
            this.Controls.Add(this.mainPanel);
            this.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Name = "MainEventListPanel";
            this.Text = "MainEventListPanel";
            this.mainPanel.ResumeLayout(false);
            this.filterPanel.ResumeLayout(false);
            this.filterPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.filterMaxDistanceSlider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.filterMaxPriceSlider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.ComboBox filterSportSelector;
        private System.Windows.Forms.DateTimePicker filterLowerDateSelector;
        private System.Windows.Forms.DateTimePicker filterUpperDateSelector;
        private System.Windows.Forms.Label filterDateSeparatorLabel;
        private System.Windows.Forms.TrackBar filterMaxPriceSlider;
        private System.Windows.Forms.Label filterMaxPriceLabel;
        private System.Windows.Forms.TrackBar filterMaxDistanceSlider;
        private System.Windows.Forms.Label filterMaxDistanceLabel;
        private System.Windows.Forms.Label filterMaxPriceValueLabel;
        private System.Windows.Forms.Label filterMaxDistanceValueLabel;
        private System.Windows.Forms.TextBox filterSearchTextBox;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.Panel eventGridPanel;
        private System.Windows.Forms.Panel filterPanel;
        private System.Windows.Forms.CheckBox showInvisibleEventsCheckBox;
    }
}