namespace Minesweeper
{
    partial class Settings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Settings));
            mainTableLayout = new TableLayoutPanel();
            gameGroupBox = new GroupBox();
            gameTableLayout = new TableLayoutPanel();
            defaultPresetLabel = new Label();
            defaultPresetComboBox = new ComboBox();
            uiGroupBox = new GroupBox();
            uiTableLayout = new TableLayoutPanel();
            accentColorLabel = new Label();
            accentColorTextBox = new TextBox();
            backgroundColorLabel = new Label();
            backgroundColorTextBox = new TextBox();
            languageLabel = new Label();
            languageComboBox = new ComboBox();
            applicationGroupBox = new GroupBox();
            applicationTableLayout = new TableLayoutPanel();
            showWelcomeLabel = new Label();
            resetSettingsLabel = new Label();
            showWelcomeButton = new Button();
            resetSettingsButton = new Button();
            resetStatisticsLabel = new Label();
            resetStatisticsButton = new Button();
            colorChooserDialog = new ColorDialog();
            mainTableLayout.SuspendLayout();
            gameGroupBox.SuspendLayout();
            gameTableLayout.SuspendLayout();
            uiGroupBox.SuspendLayout();
            uiTableLayout.SuspendLayout();
            applicationGroupBox.SuspendLayout();
            applicationTableLayout.SuspendLayout();
            SuspendLayout();
            // 
            // mainTableLayout
            // 
            mainTableLayout.AutoSize = true;
            mainTableLayout.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            mainTableLayout.ColumnCount = 1;
            mainTableLayout.ColumnStyles.Add(new ColumnStyle());
            mainTableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            mainTableLayout.Controls.Add(gameGroupBox, 0, 0);
            mainTableLayout.Controls.Add(uiGroupBox, 0, 1);
            mainTableLayout.Controls.Add(applicationGroupBox, 0, 2);
            mainTableLayout.Dock = DockStyle.Fill;
            mainTableLayout.Location = new Point(6, 6);
            mainTableLayout.Name = "mainTableLayout";
            mainTableLayout.RowCount = 3;
            mainTableLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            mainTableLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            mainTableLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            mainTableLayout.Size = new Size(472, 409);
            mainTableLayout.TabIndex = 0;
            // 
            // gameGroupBox
            // 
            gameGroupBox.AutoSize = true;
            gameGroupBox.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            gameGroupBox.Controls.Add(gameTableLayout);
            gameGroupBox.Dock = DockStyle.Fill;
            gameGroupBox.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            gameGroupBox.Location = new Point(6, 6);
            gameGroupBox.Margin = new Padding(6);
            gameGroupBox.Name = "gameGroupBox";
            gameGroupBox.Size = new Size(460, 124);
            gameGroupBox.TabIndex = 0;
            gameGroupBox.TabStop = false;
            gameGroupBox.Text = "Game";
            // 
            // gameTableLayout
            // 
            gameTableLayout.AutoSize = true;
            gameTableLayout.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            gameTableLayout.ColumnCount = 2;
            gameTableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            gameTableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            gameTableLayout.Controls.Add(defaultPresetLabel, 0, 0);
            gameTableLayout.Controls.Add(defaultPresetComboBox, 1, 0);
            gameTableLayout.Dock = DockStyle.Fill;
            gameTableLayout.Location = new Point(3, 21);
            gameTableLayout.Name = "gameTableLayout";
            gameTableLayout.RowCount = 1;
            gameTableLayout.RowStyles.Add(new RowStyle());
            gameTableLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            gameTableLayout.Size = new Size(454, 100);
            gameTableLayout.TabIndex = 0;
            // 
            // defaultPresetLabel
            // 
            defaultPresetLabel.AutoSize = true;
            defaultPresetLabel.Dock = DockStyle.Fill;
            defaultPresetLabel.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            defaultPresetLabel.Location = new Point(3, 3);
            defaultPresetLabel.Margin = new Padding(3);
            defaultPresetLabel.Name = "defaultPresetLabel";
            defaultPresetLabel.Size = new Size(221, 94);
            defaultPresetLabel.TabIndex = 0;
            defaultPresetLabel.Text = "Default preset:";
            defaultPresetLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // defaultPresetComboBox
            // 
            defaultPresetComboBox.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            defaultPresetComboBox.AutoCompleteMode = AutoCompleteMode.Suggest;
            defaultPresetComboBox.AutoCompleteSource = AutoCompleteSource.ListItems;
            defaultPresetComboBox.BackColor = Color.White;
            defaultPresetComboBox.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            defaultPresetComboBox.ForeColor = Color.Black;
            defaultPresetComboBox.FormattingEnabled = true;
            defaultPresetComboBox.Items.AddRange(new object[] { "Mini", "Beginner", "Intermediate", "Expert" });
            defaultPresetComboBox.Location = new Point(230, 38);
            defaultPresetComboBox.Name = "defaultPresetComboBox";
            defaultPresetComboBox.Size = new Size(221, 23);
            defaultPresetComboBox.TabIndex = 1;
            defaultPresetComboBox.Text = "Mini";
            defaultPresetComboBox.SelectedIndexChanged += DefaultPresetComboBoxSelectedIndexChanged;
            // 
            // uiGroupBox
            // 
            uiGroupBox.AutoSize = true;
            uiGroupBox.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            uiGroupBox.Controls.Add(uiTableLayout);
            uiGroupBox.Dock = DockStyle.Fill;
            uiGroupBox.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            uiGroupBox.Location = new Point(6, 142);
            uiGroupBox.Margin = new Padding(6);
            uiGroupBox.Name = "uiGroupBox";
            uiGroupBox.Size = new Size(460, 124);
            uiGroupBox.TabIndex = 1;
            uiGroupBox.TabStop = false;
            uiGroupBox.Text = "UI";
            // 
            // uiTableLayout
            // 
            uiTableLayout.AutoSize = true;
            uiTableLayout.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            uiTableLayout.ColumnCount = 2;
            uiTableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            uiTableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            uiTableLayout.Controls.Add(accentColorLabel, 0, 0);
            uiTableLayout.Controls.Add(accentColorTextBox, 1, 0);
            uiTableLayout.Controls.Add(backgroundColorLabel, 0, 1);
            uiTableLayout.Controls.Add(backgroundColorTextBox, 1, 1);
            uiTableLayout.Controls.Add(languageLabel, 0, 2);
            uiTableLayout.Controls.Add(languageComboBox, 1, 2);
            uiTableLayout.Dock = DockStyle.Fill;
            uiTableLayout.Location = new Point(3, 21);
            uiTableLayout.Name = "uiTableLayout";
            uiTableLayout.RowCount = 3;
            uiTableLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            uiTableLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            uiTableLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            uiTableLayout.Size = new Size(454, 100);
            uiTableLayout.TabIndex = 0;
            // 
            // accentColorLabel
            // 
            accentColorLabel.AutoSize = true;
            accentColorLabel.Dock = DockStyle.Fill;
            accentColorLabel.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            accentColorLabel.Location = new Point(3, 3);
            accentColorLabel.Margin = new Padding(3);
            accentColorLabel.Name = "accentColorLabel";
            accentColorLabel.Size = new Size(221, 27);
            accentColorLabel.TabIndex = 0;
            accentColorLabel.Text = "Accent color:";
            accentColorLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // accentColorTextBox
            // 
            accentColorTextBox.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            accentColorTextBox.BackColor = Color.White;
            accentColorTextBox.BorderStyle = BorderStyle.FixedSingle;
            accentColorTextBox.CharacterCasing = CharacterCasing.Upper;
            accentColorTextBox.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            accentColorTextBox.ForeColor = Color.Black;
            accentColorTextBox.Location = new Point(230, 5);
            accentColorTextBox.MaxLength = 7;
            accentColorTextBox.Name = "accentColorTextBox";
            accentColorTextBox.PlaceholderText = "#000000";
            accentColorTextBox.Size = new Size(221, 23);
            accentColorTextBox.TabIndex = 2;
            accentColorTextBox.Text = "#281A1A";
            accentColorTextBox.WordWrap = false;
            accentColorTextBox.TextChanged += AccentColorTextBoxTextChanged;
            accentColorTextBox.DoubleClick += AccentColorTextBoxDoubleClick;
            // 
            // backgroundColorLabel
            // 
            backgroundColorLabel.AutoSize = true;
            backgroundColorLabel.Dock = DockStyle.Fill;
            backgroundColorLabel.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            backgroundColorLabel.Location = new Point(3, 36);
            backgroundColorLabel.Margin = new Padding(3);
            backgroundColorLabel.Name = "backgroundColorLabel";
            backgroundColorLabel.Size = new Size(221, 27);
            backgroundColorLabel.TabIndex = 2;
            backgroundColorLabel.Text = "Background color:";
            backgroundColorLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // backgroundColorTextBox
            // 
            backgroundColorTextBox.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            backgroundColorTextBox.BackColor = Color.White;
            backgroundColorTextBox.BorderStyle = BorderStyle.FixedSingle;
            backgroundColorTextBox.CharacterCasing = CharacterCasing.Upper;
            backgroundColorTextBox.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            backgroundColorTextBox.ForeColor = Color.Black;
            backgroundColorTextBox.Location = new Point(230, 38);
            backgroundColorTextBox.MaxLength = 7;
            backgroundColorTextBox.Name = "backgroundColorTextBox";
            backgroundColorTextBox.PlaceholderText = "#000000";
            backgroundColorTextBox.Size = new Size(221, 23);
            backgroundColorTextBox.TabIndex = 3;
            backgroundColorTextBox.Text = "#FFFFFF";
            backgroundColorTextBox.WordWrap = false;
            backgroundColorTextBox.TextChanged += BackgroundColorTextBoxTextChanged;
            backgroundColorTextBox.DoubleClick += BackgroundColorTextBoxDoubleClick;
            // 
            // languageLabel
            // 
            languageLabel.AutoSize = true;
            languageLabel.Dock = DockStyle.Fill;
            languageLabel.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            languageLabel.Location = new Point(3, 69);
            languageLabel.Margin = new Padding(3);
            languageLabel.Name = "languageLabel";
            languageLabel.Size = new Size(221, 28);
            languageLabel.TabIndex = 4;
            languageLabel.Text = "Language:";
            languageLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // languageComboBox
            // 
            languageComboBox.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            languageComboBox.AutoCompleteMode = AutoCompleteMode.Suggest;
            languageComboBox.AutoCompleteSource = AutoCompleteSource.ListItems;
            languageComboBox.BackColor = Color.White;
            languageComboBox.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            languageComboBox.ForeColor = Color.Black;
            languageComboBox.FormattingEnabled = true;
            languageComboBox.Location = new Point(230, 71);
            languageComboBox.Name = "languageComboBox";
            languageComboBox.Size = new Size(221, 23);
            languageComboBox.TabIndex = 4;
            languageComboBox.SelectedIndexChanged += LanguageComboBoxSelectedIndexChanged;
            // 
            // applicationGroupBox
            // 
            applicationGroupBox.AutoSize = true;
            applicationGroupBox.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            applicationGroupBox.Controls.Add(applicationTableLayout);
            applicationGroupBox.Dock = DockStyle.Fill;
            applicationGroupBox.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            applicationGroupBox.Location = new Point(6, 278);
            applicationGroupBox.Margin = new Padding(6);
            applicationGroupBox.Name = "applicationGroupBox";
            applicationGroupBox.Size = new Size(460, 125);
            applicationGroupBox.TabIndex = 2;
            applicationGroupBox.TabStop = false;
            applicationGroupBox.Text = "Application";
            // 
            // applicationTableLayout
            // 
            applicationTableLayout.AutoSize = true;
            applicationTableLayout.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            applicationTableLayout.ColumnCount = 2;
            applicationTableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            applicationTableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            applicationTableLayout.Controls.Add(showWelcomeLabel, 0, 0);
            applicationTableLayout.Controls.Add(resetSettingsLabel, 0, 2);
            applicationTableLayout.Controls.Add(showWelcomeButton, 1, 0);
            applicationTableLayout.Controls.Add(resetSettingsButton, 1, 2);
            applicationTableLayout.Controls.Add(resetStatisticsLabel, 0, 1);
            applicationTableLayout.Controls.Add(resetStatisticsButton, 1, 1);
            applicationTableLayout.Dock = DockStyle.Fill;
            applicationTableLayout.Location = new Point(3, 21);
            applicationTableLayout.Name = "applicationTableLayout";
            applicationTableLayout.RowCount = 3;
            applicationTableLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            applicationTableLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            applicationTableLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            applicationTableLayout.Size = new Size(454, 101);
            applicationTableLayout.TabIndex = 0;
            // 
            // showWelcomeLabel
            // 
            showWelcomeLabel.AutoSize = true;
            showWelcomeLabel.Dock = DockStyle.Fill;
            showWelcomeLabel.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            showWelcomeLabel.Location = new Point(3, 3);
            showWelcomeLabel.Margin = new Padding(3);
            showWelcomeLabel.Name = "showWelcomeLabel";
            showWelcomeLabel.Size = new Size(221, 27);
            showWelcomeLabel.TabIndex = 0;
            showWelcomeLabel.Text = "Show welcome dialog:";
            showWelcomeLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // resetSettingsLabel
            // 
            resetSettingsLabel.AutoSize = true;
            resetSettingsLabel.Dock = DockStyle.Fill;
            resetSettingsLabel.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            resetSettingsLabel.Location = new Point(3, 69);
            resetSettingsLabel.Margin = new Padding(3);
            resetSettingsLabel.Name = "resetSettingsLabel";
            resetSettingsLabel.Size = new Size(221, 29);
            resetSettingsLabel.TabIndex = 1;
            resetSettingsLabel.Text = "Reset settings:";
            resetSettingsLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // showWelcomeButton
            // 
            showWelcomeButton.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            showWelcomeButton.AutoSize = true;
            showWelcomeButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            showWelcomeButton.FlatStyle = FlatStyle.Flat;
            showWelcomeButton.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            showWelcomeButton.Location = new Point(230, 3);
            showWelcomeButton.Name = "showWelcomeButton";
            showWelcomeButton.Size = new Size(221, 27);
            showWelcomeButton.TabIndex = 5;
            showWelcomeButton.Text = "Show";
            showWelcomeButton.UseVisualStyleBackColor = true;
            showWelcomeButton.Click += ShowWelcomeButtonClick;
            // 
            // resetSettingsButton
            // 
            resetSettingsButton.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            resetSettingsButton.AutoSize = true;
            resetSettingsButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            resetSettingsButton.FlatStyle = FlatStyle.Flat;
            resetSettingsButton.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            resetSettingsButton.Location = new Point(230, 70);
            resetSettingsButton.Name = "resetSettingsButton";
            resetSettingsButton.Size = new Size(221, 27);
            resetSettingsButton.TabIndex = 7;
            resetSettingsButton.Text = "Reset";
            resetSettingsButton.UseVisualStyleBackColor = true;
            resetSettingsButton.Click += ResetSettingsButtonClick;
            // 
            // resetStatisticsLabel
            // 
            resetStatisticsLabel.AutoSize = true;
            resetStatisticsLabel.Dock = DockStyle.Fill;
            resetStatisticsLabel.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            resetStatisticsLabel.Location = new Point(3, 36);
            resetStatisticsLabel.Margin = new Padding(3);
            resetStatisticsLabel.Name = "resetStatisticsLabel";
            resetStatisticsLabel.Size = new Size(221, 27);
            resetStatisticsLabel.TabIndex = 4;
            resetStatisticsLabel.Text = "Reset statistics:";
            resetStatisticsLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // resetStatisticsButton
            // 
            resetStatisticsButton.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            resetStatisticsButton.AutoSize = true;
            resetStatisticsButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            resetStatisticsButton.FlatStyle = FlatStyle.Flat;
            resetStatisticsButton.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            resetStatisticsButton.Location = new Point(230, 36);
            resetStatisticsButton.Name = "resetStatisticsButton";
            resetStatisticsButton.Size = new Size(221, 27);
            resetStatisticsButton.TabIndex = 6;
            resetStatisticsButton.Text = "Reset";
            resetStatisticsButton.UseVisualStyleBackColor = true;
            resetStatisticsButton.Click += ResetStatisticsButtonClick;
            // 
            // colorChooserDialog
            // 
            colorChooserDialog.AnyColor = true;
            // 
            // Settings
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(484, 421);
            Controls.Add(mainTableLayout);
            ForeColor = Color.Black;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            MinimumSize = new Size(500, 460);
            Name = "Settings";
            Padding = new Padding(6);
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Settings";
            TopMost = true;
            FormClosing += SettingsFormClosing;
            mainTableLayout.ResumeLayout(false);
            mainTableLayout.PerformLayout();
            gameGroupBox.ResumeLayout(false);
            gameGroupBox.PerformLayout();
            gameTableLayout.ResumeLayout(false);
            gameTableLayout.PerformLayout();
            uiGroupBox.ResumeLayout(false);
            uiGroupBox.PerformLayout();
            uiTableLayout.ResumeLayout(false);
            uiTableLayout.PerformLayout();
            applicationGroupBox.ResumeLayout(false);
            applicationGroupBox.PerformLayout();
            applicationTableLayout.ResumeLayout(false);
            applicationTableLayout.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TableLayoutPanel mainTableLayout;
        private GroupBox gameGroupBox;
        private GroupBox uiGroupBox;
        private GroupBox applicationGroupBox;
        private TableLayoutPanel gameTableLayout;
        private TableLayoutPanel uiTableLayout;
        private TableLayoutPanel applicationTableLayout;
        private Label defaultPresetLabel;
        private Label accentColorLabel;
        private Label backgroundColorLabel;
        private Label showWelcomeLabel;
        private Label resetSettingsLabel;
        private ComboBox defaultPresetComboBox;
        private TextBox accentColorTextBox;
        private TextBox backgroundColorTextBox;
        private Button showWelcomeButton;
        private Button resetSettingsButton;
        private ColorDialog colorChooserDialog;
        private Label resetStatisticsLabel;
        private Button resetStatisticsButton;
        private Label languageLabel;
        private ComboBox languageComboBox;
    }
}