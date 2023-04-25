namespace Minesweeper
{
    partial class Welcome
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Welcome));
            mainTableLayout = new TableLayoutPanel();
            iconLabel = new Label();
            infoTableLayout = new TableLayoutPanel();
            titleLabel = new Label();
            controlTableLayout = new TableLayoutPanel();
            tutorialButton = new Button();
            playButton = new Button();
            chosenLanguageLabel = new Label();
            mainTableLayout.SuspendLayout();
            infoTableLayout.SuspendLayout();
            controlTableLayout.SuspendLayout();
            SuspendLayout();
            // 
            // mainTableLayout
            // 
            mainTableLayout.AutoSize = true;
            mainTableLayout.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            mainTableLayout.ColumnCount = 2;
            mainTableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            mainTableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            mainTableLayout.Controls.Add(iconLabel, 0, 0);
            mainTableLayout.Controls.Add(infoTableLayout, 1, 0);
            mainTableLayout.Controls.Add(chosenLanguageLabel, 0, 1);
            mainTableLayout.Dock = DockStyle.Fill;
            mainTableLayout.Location = new Point(6, 6);
            mainTableLayout.Name = "mainTableLayout";
            mainTableLayout.RowCount = 2;
            mainTableLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            mainTableLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            mainTableLayout.Size = new Size(372, 189);
            mainTableLayout.TabIndex = 0;
            // 
            // iconLabel
            // 
            iconLabel.AutoSize = true;
            iconLabel.Dock = DockStyle.Fill;
            iconLabel.Font = new Font("Segoe UI Emoji", 72F, FontStyle.Bold, GraphicsUnit.Point);
            iconLabel.Location = new Point(6, 0);
            iconLabel.Margin = new Padding(6, 0, 0, 6);
            iconLabel.Name = "iconLabel";
            iconLabel.Size = new Size(180, 153);
            iconLabel.TabIndex = 0;
            iconLabel.Text = "💣";
            iconLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // infoTableLayout
            // 
            infoTableLayout.AutoSize = true;
            infoTableLayout.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            infoTableLayout.ColumnCount = 1;
            infoTableLayout.ColumnStyles.Add(new ColumnStyle());
            infoTableLayout.Controls.Add(titleLabel, 0, 0);
            infoTableLayout.Controls.Add(controlTableLayout, 0, 1);
            infoTableLayout.Dock = DockStyle.Fill;
            infoTableLayout.Location = new Point(186, 6);
            infoTableLayout.Margin = new Padding(0, 6, 6, 6);
            infoTableLayout.Name = "infoTableLayout";
            infoTableLayout.RowCount = 2;
            infoTableLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 45F));
            infoTableLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 55F));
            infoTableLayout.Size = new Size(180, 147);
            infoTableLayout.TabIndex = 1;
            // 
            // titleLabel
            // 
            titleLabel.AutoSize = true;
            titleLabel.Dock = DockStyle.Fill;
            titleLabel.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            titleLabel.Location = new Point(3, 3);
            titleLabel.Margin = new Padding(3);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(174, 60);
            titleLabel.TabIndex = 0;
            titleLabel.Text = "Welcome";
            titleLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // controlTableLayout
            // 
            controlTableLayout.AutoSize = true;
            controlTableLayout.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            controlTableLayout.ColumnCount = 1;
            controlTableLayout.ColumnStyles.Add(new ColumnStyle());
            controlTableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            controlTableLayout.Controls.Add(tutorialButton, 0, 0);
            controlTableLayout.Controls.Add(playButton, 0, 1);
            controlTableLayout.Dock = DockStyle.Fill;
            controlTableLayout.Location = new Point(0, 66);
            controlTableLayout.Margin = new Padding(0);
            controlTableLayout.Name = "controlTableLayout";
            controlTableLayout.RowCount = 2;
            controlTableLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            controlTableLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            controlTableLayout.Size = new Size(180, 81);
            controlTableLayout.TabIndex = 1;
            // 
            // tutorialButton
            // 
            tutorialButton.Anchor = AnchorStyles.None;
            tutorialButton.AutoSize = true;
            tutorialButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tutorialButton.DialogResult = DialogResult.Continue;
            tutorialButton.FlatStyle = FlatStyle.Flat;
            tutorialButton.Location = new Point(60, 6);
            tutorialButton.Margin = new Padding(0);
            tutorialButton.Name = "tutorialButton";
            tutorialButton.Size = new Size(59, 27);
            tutorialButton.TabIndex = 0;
            tutorialButton.Text = "Tutorial";
            tutorialButton.UseVisualStyleBackColor = true;
            // 
            // playButton
            // 
            playButton.Anchor = AnchorStyles.None;
            playButton.AutoSize = true;
            playButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            playButton.DialogResult = DialogResult.Cancel;
            playButton.FlatStyle = FlatStyle.Flat;
            playButton.Location = new Point(47, 47);
            playButton.Margin = new Padding(0);
            playButton.Name = "playButton";
            playButton.Size = new Size(85, 27);
            playButton.TabIndex = 1;
            playButton.Text = "Start playing";
            playButton.UseVisualStyleBackColor = true;
            // 
            // chosenLanguageLabel
            // 
            chosenLanguageLabel.AutoSize = true;
            mainTableLayout.SetColumnSpan(chosenLanguageLabel, 2);
            chosenLanguageLabel.Dock = DockStyle.Fill;
            chosenLanguageLabel.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point);
            chosenLanguageLabel.Location = new Point(4, 162);
            chosenLanguageLabel.Margin = new Padding(4, 3, 4, 3);
            chosenLanguageLabel.Name = "chosenLanguageLabel";
            chosenLanguageLabel.Size = new Size(364, 24);
            chosenLanguageLabel.TabIndex = 2;
            chosenLanguageLabel.Text = "Language automatically chosen: English (United States)";
            chosenLanguageLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Welcome
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(384, 201);
            Controls.Add(mainTableLayout);
            ForeColor = Color.Black;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            MinimizeBox = false;
            MinimumSize = new Size(400, 240);
            Name = "Welcome";
            Padding = new Padding(6);
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Welcome to Minesweeper";
            TopMost = true;
            mainTableLayout.ResumeLayout(false);
            mainTableLayout.PerformLayout();
            infoTableLayout.ResumeLayout(false);
            infoTableLayout.PerformLayout();
            controlTableLayout.ResumeLayout(false);
            controlTableLayout.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TableLayoutPanel mainTableLayout;
        private Label iconLabel;
        private TableLayoutPanel infoTableLayout;
        private Label titleLabel;
        private TableLayoutPanel controlTableLayout;
        private Button tutorialButton;
        private Button playButton;
        private Label chosenLanguageLabel;
    }
}