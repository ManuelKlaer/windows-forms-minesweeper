namespace Minesweeper
{
    partial class Statistics
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Statistics));
            mainTableLayout = new TableLayoutPanel();
            titleLabel = new Label();
            controlsTableLayout = new TableLayoutPanel();
            previousPageButton = new Button();
            nextPageButton = new Button();
            currentPageLabel = new Label();
            infoTableLayout = new TableLayoutPanel();
            totalGamesLabel = new Label();
            gamesWonLabel = new Label();
            gamesLostLabel = new Label();
            totalTimeLabel = new Label();
            avgTimeLabel = new Label();
            shortTimeLabel = new Label();
            totalMinesLabel = new Label();
            performanceLabel = new Label();
            mainTableLayout.SuspendLayout();
            controlsTableLayout.SuspendLayout();
            infoTableLayout.SuspendLayout();
            SuspendLayout();
            // 
            // mainTableLayout
            // 
            mainTableLayout.AutoSize = true;
            mainTableLayout.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            mainTableLayout.ColumnCount = 1;
            mainTableLayout.ColumnStyles.Add(new ColumnStyle());
            mainTableLayout.Controls.Add(titleLabel, 0, 0);
            mainTableLayout.Controls.Add(controlsTableLayout, 0, 2);
            mainTableLayout.Controls.Add(infoTableLayout, 0, 1);
            mainTableLayout.Dock = DockStyle.Fill;
            mainTableLayout.Location = new Point(0, 0);
            mainTableLayout.Name = "mainTableLayout";
            mainTableLayout.RowCount = 3;
            mainTableLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
            mainTableLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            mainTableLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            mainTableLayout.Size = new Size(464, 281);
            mainTableLayout.TabIndex = 0;
            // 
            // titleLabel
            // 
            titleLabel.AutoSize = true;
            titleLabel.Dock = DockStyle.Fill;
            titleLabel.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            titleLabel.Location = new Point(3, 3);
            titleLabel.Margin = new Padding(3);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(458, 54);
            titleLabel.TabIndex = 0;
            titleLabel.Text = "Title";
            titleLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // controlsTableLayout
            // 
            controlsTableLayout.AutoSize = true;
            controlsTableLayout.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            controlsTableLayout.ColumnCount = 3;
            controlsTableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            controlsTableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            controlsTableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            controlsTableLayout.Controls.Add(previousPageButton, 0, 0);
            controlsTableLayout.Controls.Add(nextPageButton, 2, 0);
            controlsTableLayout.Controls.Add(currentPageLabel, 1, 0);
            controlsTableLayout.Dock = DockStyle.Fill;
            controlsTableLayout.Location = new Point(0, 241);
            controlsTableLayout.Margin = new Padding(0);
            controlsTableLayout.Name = "controlsTableLayout";
            controlsTableLayout.Padding = new Padding(6, 0, 6, 0);
            controlsTableLayout.RowCount = 1;
            controlsTableLayout.RowStyles.Add(new RowStyle());
            controlsTableLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            controlsTableLayout.Size = new Size(464, 40);
            controlsTableLayout.TabIndex = 1;
            // 
            // previousPageButton
            // 
            previousPageButton.Anchor = AnchorStyles.Left;
            previousPageButton.AutoSize = true;
            previousPageButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            previousPageButton.FlatStyle = FlatStyle.Flat;
            previousPageButton.Location = new Point(6, 6);
            previousPageButton.Margin = new Padding(0);
            previousPageButton.Name = "previousPageButton";
            previousPageButton.Size = new Size(27, 27);
            previousPageButton.TabIndex = 0;
            previousPageButton.Text = "<";
            previousPageButton.UseVisualStyleBackColor = true;
            previousPageButton.Click += PreviousPageButtonClick;
            // 
            // nextPageButton
            // 
            nextPageButton.Anchor = AnchorStyles.Right;
            nextPageButton.AutoSize = true;
            nextPageButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            nextPageButton.FlatStyle = FlatStyle.Flat;
            nextPageButton.Location = new Point(431, 6);
            nextPageButton.Margin = new Padding(0);
            nextPageButton.Name = "nextPageButton";
            nextPageButton.Size = new Size(27, 27);
            nextPageButton.TabIndex = 1;
            nextPageButton.Text = ">";
            nextPageButton.UseVisualStyleBackColor = true;
            nextPageButton.Click += NextPageButtonClick;
            // 
            // currentPageLabel
            // 
            currentPageLabel.AutoSize = true;
            currentPageLabel.Dock = DockStyle.Fill;
            currentPageLabel.Location = new Point(156, 0);
            currentPageLabel.Margin = new Padding(0);
            currentPageLabel.Name = "currentPageLabel";
            currentPageLabel.Size = new Size(150, 40);
            currentPageLabel.TabIndex = 2;
            currentPageLabel.Text = "0 / 0";
            currentPageLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // infoTableLayout
            // 
            infoTableLayout.AutoSize = true;
            infoTableLayout.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            infoTableLayout.ColumnCount = 2;
            infoTableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            infoTableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            infoTableLayout.Controls.Add(totalGamesLabel, 0, 0);
            infoTableLayout.Controls.Add(gamesWonLabel, 0, 1);
            infoTableLayout.Controls.Add(gamesLostLabel, 0, 2);
            infoTableLayout.Controls.Add(totalTimeLabel, 1, 0);
            infoTableLayout.Controls.Add(avgTimeLabel, 1, 1);
            infoTableLayout.Controls.Add(shortTimeLabel, 1, 2);
            infoTableLayout.Controls.Add(totalMinesLabel, 0, 3);
            infoTableLayout.Controls.Add(performanceLabel, 1, 3);
            infoTableLayout.Dock = DockStyle.Fill;
            infoTableLayout.Location = new Point(0, 60);
            infoTableLayout.Margin = new Padding(0);
            infoTableLayout.Name = "infoTableLayout";
            infoTableLayout.Padding = new Padding(12, 0, 12, 0);
            infoTableLayout.RowCount = 4;
            infoTableLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            infoTableLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            infoTableLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            infoTableLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            infoTableLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            infoTableLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            infoTableLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            infoTableLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            infoTableLayout.Size = new Size(464, 181);
            infoTableLayout.TabIndex = 2;
            // 
            // totalGamesLabel
            // 
            totalGamesLabel.AutoSize = true;
            totalGamesLabel.Dock = DockStyle.Fill;
            totalGamesLabel.Location = new Point(15, 3);
            totalGamesLabel.Margin = new Padding(3);
            totalGamesLabel.Name = "totalGamesLabel";
            totalGamesLabel.Size = new Size(214, 39);
            totalGamesLabel.TabIndex = 0;
            totalGamesLabel.Text = "TOTAL_GAMES";
            totalGamesLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // gamesWonLabel
            // 
            gamesWonLabel.AutoSize = true;
            gamesWonLabel.Dock = DockStyle.Fill;
            gamesWonLabel.Location = new Point(15, 48);
            gamesWonLabel.Margin = new Padding(3);
            gamesWonLabel.Name = "gamesWonLabel";
            gamesWonLabel.Size = new Size(214, 39);
            gamesWonLabel.TabIndex = 1;
            gamesWonLabel.Text = "GAMES_WON";
            gamesWonLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // gamesLostLabel
            // 
            gamesLostLabel.AutoSize = true;
            gamesLostLabel.Dock = DockStyle.Fill;
            gamesLostLabel.Location = new Point(15, 93);
            gamesLostLabel.Margin = new Padding(3);
            gamesLostLabel.Name = "gamesLostLabel";
            gamesLostLabel.Size = new Size(214, 39);
            gamesLostLabel.TabIndex = 2;
            gamesLostLabel.Text = "GAMES_LOST";
            gamesLostLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // totalTimeLabel
            // 
            totalTimeLabel.AutoSize = true;
            totalTimeLabel.Dock = DockStyle.Fill;
            totalTimeLabel.Location = new Point(235, 3);
            totalTimeLabel.Margin = new Padding(3);
            totalTimeLabel.Name = "totalTimeLabel";
            totalTimeLabel.Size = new Size(214, 39);
            totalTimeLabel.TabIndex = 3;
            totalTimeLabel.Text = "TOTAL_TIME";
            totalTimeLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // avgTimeLabel
            // 
            avgTimeLabel.AutoSize = true;
            avgTimeLabel.Dock = DockStyle.Fill;
            avgTimeLabel.Location = new Point(235, 48);
            avgTimeLabel.Margin = new Padding(3);
            avgTimeLabel.Name = "avgTimeLabel";
            avgTimeLabel.Size = new Size(214, 39);
            avgTimeLabel.TabIndex = 4;
            avgTimeLabel.Text = "AVG_TIME";
            avgTimeLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // shortTimeLabel
            // 
            shortTimeLabel.AutoSize = true;
            shortTimeLabel.Dock = DockStyle.Fill;
            shortTimeLabel.Location = new Point(235, 93);
            shortTimeLabel.Margin = new Padding(3);
            shortTimeLabel.Name = "shortTimeLabel";
            shortTimeLabel.Size = new Size(214, 39);
            shortTimeLabel.TabIndex = 5;
            shortTimeLabel.Text = "SHORT_TIME";
            shortTimeLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // totalMinesLabel
            // 
            totalMinesLabel.AutoSize = true;
            totalMinesLabel.Dock = DockStyle.Fill;
            totalMinesLabel.Location = new Point(15, 138);
            totalMinesLabel.Margin = new Padding(3);
            totalMinesLabel.Name = "totalMinesLabel";
            totalMinesLabel.Size = new Size(214, 40);
            totalMinesLabel.TabIndex = 6;
            totalMinesLabel.Text = "TOTAL_MINES";
            totalMinesLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // performanceLabel
            // 
            performanceLabel.AutoSize = true;
            performanceLabel.Dock = DockStyle.Fill;
            performanceLabel.Location = new Point(235, 138);
            performanceLabel.Margin = new Padding(3);
            performanceLabel.Name = "performanceLabel";
            performanceLabel.Size = new Size(214, 40);
            performanceLabel.TabIndex = 7;
            performanceLabel.Text = "PERFORMANCE";
            performanceLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Statistics
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(464, 281);
            Controls.Add(mainTableLayout);
            ForeColor = Color.Black;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            MinimumSize = new Size(480, 320);
            Name = "Statistics";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Statistics";
            TopMost = true;
            mainTableLayout.ResumeLayout(false);
            mainTableLayout.PerformLayout();
            controlsTableLayout.ResumeLayout(false);
            controlsTableLayout.PerformLayout();
            infoTableLayout.ResumeLayout(false);
            infoTableLayout.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TableLayoutPanel mainTableLayout;
        private TableLayoutPanel controlsTableLayout;
        private Button previousPageButton;
        private Button nextPageButton;
        private Label currentPageLabel;
        public Label titleLabel;
        private TableLayoutPanel infoTableLayout;
        public Label totalGamesLabel;
        public Label gamesWonLabel;
        public Label gamesLostLabel;
        public Label totalTimeLabel;
        public Label avgTimeLabel;
        public Label shortTimeLabel;
        public Label totalMinesLabel;
        public Label performanceLabel;
    }
}