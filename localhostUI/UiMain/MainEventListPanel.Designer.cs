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
            this.eventGridPanel = new System.Windows.Forms.Panel();
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
            this.titleLabel = new System.Windows.Forms.Label();
            this.mainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.filterMaxDistanceSlider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.filterMaxPriceSlider)).BeginInit();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.mainPanel.Controls.Add(this.eventGridPanel);
            this.mainPanel.Controls.Add(this.searchButton);
            this.mainPanel.Controls.Add(this.filterSearchTextBox);
            this.mainPanel.Controls.Add(this.filterMaxDistanceValueLabel);
            this.mainPanel.Controls.Add(this.filterMaxPriceValueLabel);
            this.mainPanel.Controls.Add(this.filterMaxDistanceLabel);
            this.mainPanel.Controls.Add(this.filterMaxDistanceSlider);
            this.mainPanel.Controls.Add(this.filterMaxPriceLabel);
            this.mainPanel.Controls.Add(this.filterMaxPriceSlider);
            this.mainPanel.Controls.Add(this.filterDateSeparatorLabel);
            this.mainPanel.Controls.Add(this.filterUpperDateSelector);
            this.mainPanel.Controls.Add(this.filterLowerDateSelector);
            this.mainPanel.Controls.Add(this.filterSportSelector);
            this.mainPanel.Controls.Add(this.titleLabel);
            this.mainPanel.Location = new System.Drawing.Point(8, 9);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(1000, 800);
            this.mainPanel.TabIndex = 0;
            // 
            // eventGridPanel
            // 
            this.eventGridPanel.Location = new System.Drawing.Point(0, 250);
            this.eventGridPanel.Name = "eventGridPanel";
            this.eventGridPanel.Size = new System.Drawing.Size(1000, 400);
            this.eventGridPanel.TabIndex = 13;
            // 
            // searchButton
            // 
            this.searchButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(168)))), ((int)(((byte)(135)))));
            this.searchButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.searchButton.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.searchButton.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.searchButton.Location = new System.Drawing.Point(450, 186);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(100, 30);
            this.searchButton.TabIndex = 12;
            this.searchButton.TabStop = false;
            this.searchButton.Text = "Search";
            this.searchButton.UseVisualStyleBackColor = false;
            // 
            // filterSearchTextBox
            // 
            this.filterSearchTextBox.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.filterSearchTextBox.Location = new System.Drawing.Point(350, 155);
            this.filterSearchTextBox.Name = "filterSearchTextBox";
            this.filterSearchTextBox.PlaceholderText = "Enter keywords";
            this.filterSearchTextBox.Size = new System.Drawing.Size(300, 25);
            this.filterSearchTextBox.TabIndex = 11;
            // 
            // filterMaxDistanceValueLabel
            // 
            this.filterMaxDistanceValueLabel.AutoSize = true;
            this.filterMaxDistanceValueLabel.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.filterMaxDistanceValueLabel.Location = new System.Drawing.Point(732, 128);
            this.filterMaxDistanceValueLabel.Name = "filterMaxDistanceValueLabel";
            this.filterMaxDistanceValueLabel.Size = new System.Drawing.Size(48, 17);
            this.filterMaxDistanceValueLabel.TabIndex = 10;
            this.filterMaxDistanceValueLabel.Text = "0.0km";
            // 
            // filterMaxPriceValueLabel
            // 
            this.filterMaxPriceValueLabel.AutoSize = true;
            this.filterMaxPriceValueLabel.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.filterMaxPriceValueLabel.Location = new System.Drawing.Point(732, 97);
            this.filterMaxPriceValueLabel.Name = "filterMaxPriceValueLabel";
            this.filterMaxPriceValueLabel.Size = new System.Drawing.Size(36, 17);
            this.filterMaxPriceValueLabel.TabIndex = 9;
            this.filterMaxPriceValueLabel.Text = "0.0€";
            // 
            // filterMaxDistanceLabel
            // 
            this.filterMaxDistanceLabel.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.filterMaxDistanceLabel.Location = new System.Drawing.Point(492, 124);
            this.filterMaxDistanceLabel.Name = "filterMaxDistanceLabel";
            this.filterMaxDistanceLabel.Size = new System.Drawing.Size(100, 25);
            this.filterMaxDistanceLabel.TabIndex = 8;
            this.filterMaxDistanceLabel.Text = "Max distance";
            this.filterMaxDistanceLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // filterMaxDistanceSlider
            // 
            this.filterMaxDistanceSlider.AutoSize = false;
            this.filterMaxDistanceSlider.Location = new System.Drawing.Point(598, 126);
            this.filterMaxDistanceSlider.Maximum = 1000;
            this.filterMaxDistanceSlider.Name = "filterMaxDistanceSlider";
            this.filterMaxDistanceSlider.Size = new System.Drawing.Size(128, 23);
            this.filterMaxDistanceSlider.TabIndex = 7;
            this.filterMaxDistanceSlider.TickStyle = System.Windows.Forms.TickStyle.None;
            // 
            // filterMaxPriceLabel
            // 
            this.filterMaxPriceLabel.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.filterMaxPriceLabel.Location = new System.Drawing.Point(492, 93);
            this.filterMaxPriceLabel.Name = "filterMaxPriceLabel";
            this.filterMaxPriceLabel.Size = new System.Drawing.Size(100, 25);
            this.filterMaxPriceLabel.TabIndex = 6;
            this.filterMaxPriceLabel.Text = "Max price";
            this.filterMaxPriceLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // filterMaxPriceSlider
            // 
            this.filterMaxPriceSlider.AutoSize = false;
            this.filterMaxPriceSlider.Location = new System.Drawing.Point(598, 95);
            this.filterMaxPriceSlider.Maximum = 1000;
            this.filterMaxPriceSlider.Name = "filterMaxPriceSlider";
            this.filterMaxPriceSlider.Size = new System.Drawing.Size(128, 23);
            this.filterMaxPriceSlider.TabIndex = 5;
            this.filterMaxPriceSlider.TickStyle = System.Windows.Forms.TickStyle.None;
            // 
            // filterDateSeparatorLabel
            // 
            this.filterDateSeparatorLabel.AutoSize = true;
            this.filterDateSeparatorLabel.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.filterDateSeparatorLabel.Location = new System.Drawing.Point(344, 126);
            this.filterDateSeparatorLabel.Name = "filterDateSeparatorLabel";
            this.filterDateSeparatorLabel.Size = new System.Drawing.Size(23, 17);
            this.filterDateSeparatorLabel.TabIndex = 4;
            this.filterDateSeparatorLabel.Text = "—";
            // 
            // filterUpperDateSelector
            // 
            this.filterUpperDateSelector.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.filterUpperDateSelector.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.filterUpperDateSelector.Location = new System.Drawing.Point(372, 124);
            this.filterUpperDateSelector.Name = "filterUpperDateSelector";
            this.filterUpperDateSelector.Size = new System.Drawing.Size(100, 25);
            this.filterUpperDateSelector.TabIndex = 3;
            // 
            // filterLowerDateSelector
            // 
            this.filterLowerDateSelector.CalendarFont = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.filterLowerDateSelector.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.filterLowerDateSelector.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.filterLowerDateSelector.Location = new System.Drawing.Point(237, 124);
            this.filterLowerDateSelector.Name = "filterLowerDateSelector";
            this.filterLowerDateSelector.Size = new System.Drawing.Size(100, 25);
            this.filterLowerDateSelector.TabIndex = 2;
            // 
            // filterSportSelector
            // 
            this.filterSportSelector.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.filterSportSelector.ForeColor = System.Drawing.Color.Black;
            this.filterSportSelector.FormattingEnabled = true;
            this.filterSportSelector.Location = new System.Drawing.Point(237, 93);
            this.filterSportSelector.Name = "filterSportSelector";
            this.filterSportSelector.Size = new System.Drawing.Size(235, 25);
            this.filterSportSelector.TabIndex = 1;
            this.filterSportSelector.Text = "Sport";
            // 
            // titleLabel
            // 
            this.titleLabel.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.titleLabel.Location = new System.Drawing.Point(400, 15);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(200, 30);
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
            this.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Name = "MainEventListPanel";
            this.Text = "MainEventListPanel";
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
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
    }
}