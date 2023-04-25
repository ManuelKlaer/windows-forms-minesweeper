namespace Minesweeper
{
    partial class Tutorial
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Tutorial));
            mainTableLayout = new TableLayoutPanel();
            imageLabel = new Label();
            textTableLayout = new TableLayoutPanel();
            titleLabel = new Label();
            textLabel = new Label();
            controlsTableLayout = new TableLayoutPanel();
            previousButton = new Button();
            nextButton = new Button();
            currentPageLabel = new Label();
            mainTableLayout.SuspendLayout();
            textTableLayout.SuspendLayout();
            controlsTableLayout.SuspendLayout();
            SuspendLayout();
            // 
            // mainTableLayout
            // 
            mainTableLayout.AutoSize = true;
            mainTableLayout.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            mainTableLayout.ColumnCount = 2;
            mainTableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            mainTableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            mainTableLayout.Controls.Add(imageLabel, 0, 0);
            mainTableLayout.Controls.Add(textTableLayout, 1, 0);
            mainTableLayout.Dock = DockStyle.Fill;
            mainTableLayout.Location = new Point(0, 0);
            mainTableLayout.Name = "mainTableLayout";
            mainTableLayout.RowCount = 1;
            mainTableLayout.RowStyles.Add(new RowStyle());
            mainTableLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            mainTableLayout.Size = new Size(534, 261);
            mainTableLayout.TabIndex = 0;
            // 
            // imageLabel
            // 
            imageLabel.AutoSize = true;
            imageLabel.Dock = DockStyle.Fill;
            imageLabel.Font = new Font("Segoe UI Emoji", 72F, FontStyle.Bold, GraphicsUnit.Point);
            imageLabel.Location = new Point(6, 0);
            imageLabel.Margin = new Padding(6, 0, 0, 6);
            imageLabel.Name = "imageLabel";
            imageLabel.Size = new Size(261, 255);
            imageLabel.TabIndex = 0;
            imageLabel.Text = "?";
            imageLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // textTableLayout
            // 
            textTableLayout.AutoSize = true;
            textTableLayout.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            textTableLayout.ColumnCount = 1;
            textTableLayout.ColumnStyles.Add(new ColumnStyle());
            textTableLayout.Controls.Add(titleLabel, 0, 0);
            textTableLayout.Controls.Add(textLabel, 0, 1);
            textTableLayout.Controls.Add(controlsTableLayout, 0, 2);
            textTableLayout.Dock = DockStyle.Fill;
            textTableLayout.Location = new Point(267, 10);
            textTableLayout.Margin = new Padding(0, 10, 10, 10);
            textTableLayout.Name = "textTableLayout";
            textTableLayout.RowCount = 3;
            textTableLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            textTableLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            textTableLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            textTableLayout.Size = new Size(257, 241);
            textTableLayout.TabIndex = 1;
            // 
            // titleLabel
            // 
            titleLabel.AutoSize = true;
            titleLabel.Dock = DockStyle.Fill;
            titleLabel.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            titleLabel.Location = new Point(0, 0);
            titleLabel.Margin = new Padding(0);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(257, 50);
            titleLabel.TabIndex = 0;
            titleLabel.Text = "Title";
            titleLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // textLabel
            // 
            textLabel.Dock = DockStyle.Fill;
            textLabel.Location = new Point(0, 50);
            textLabel.Margin = new Padding(0);
            textLabel.Name = "textLabel";
            textLabel.Size = new Size(257, 161);
            textLabel.TabIndex = 1;
            textLabel.Text = "Description";
            textLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // controlsTableLayout
            // 
            controlsTableLayout.AutoSize = true;
            controlsTableLayout.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            controlsTableLayout.ColumnCount = 3;
            controlsTableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            controlsTableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            controlsTableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            controlsTableLayout.Controls.Add(previousButton, 0, 0);
            controlsTableLayout.Controls.Add(nextButton, 2, 0);
            controlsTableLayout.Controls.Add(currentPageLabel, 1, 0);
            controlsTableLayout.Dock = DockStyle.Fill;
            controlsTableLayout.Location = new Point(0, 211);
            controlsTableLayout.Margin = new Padding(0);
            controlsTableLayout.Name = "controlsTableLayout";
            controlsTableLayout.RowCount = 1;
            controlsTableLayout.RowStyles.Add(new RowStyle());
            controlsTableLayout.Size = new Size(257, 30);
            controlsTableLayout.TabIndex = 2;
            // 
            // previousButton
            // 
            previousButton.AutoSize = true;
            previousButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            previousButton.FlatStyle = FlatStyle.Flat;
            previousButton.Location = new Point(0, 0);
            previousButton.Margin = new Padding(0);
            previousButton.Name = "previousButton";
            previousButton.Size = new Size(27, 27);
            previousButton.TabIndex = 1;
            previousButton.Text = "<";
            previousButton.UseVisualStyleBackColor = true;
            previousButton.Click += PreviousButtonClick;
            // 
            // nextButton
            // 
            nextButton.Anchor = AnchorStyles.Right;
            nextButton.AutoSize = true;
            nextButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            nextButton.FlatStyle = FlatStyle.Flat;
            nextButton.Location = new Point(230, 1);
            nextButton.Margin = new Padding(0);
            nextButton.Name = "nextButton";
            nextButton.Size = new Size(27, 27);
            nextButton.TabIndex = 0;
            nextButton.Text = ">";
            nextButton.UseVisualStyleBackColor = true;
            nextButton.Click += NextButtonClick;
            // 
            // currentPageLabel
            // 
            currentPageLabel.AutoSize = true;
            currentPageLabel.Dock = DockStyle.Fill;
            currentPageLabel.Location = new Point(85, 0);
            currentPageLabel.Margin = new Padding(0);
            currentPageLabel.Name = "currentPageLabel";
            currentPageLabel.Size = new Size(85, 30);
            currentPageLabel.TabIndex = 2;
            currentPageLabel.Text = "0 / 0";
            currentPageLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Tutorial
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(534, 261);
            Controls.Add(mainTableLayout);
            ForeColor = Color.Black;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            MinimumSize = new Size(550, 300);
            Name = "Tutorial";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "How to play?";
            TopMost = true;
            mainTableLayout.ResumeLayout(false);
            mainTableLayout.PerformLayout();
            textTableLayout.ResumeLayout(false);
            textTableLayout.PerformLayout();
            controlsTableLayout.ResumeLayout(false);
            controlsTableLayout.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TableLayoutPanel mainTableLayout;
        private TableLayoutPanel textTableLayout;
        private TableLayoutPanel controlsTableLayout;
        private Button nextButton;
        private Button previousButton;
        public Label imageLabel;
        public Label titleLabel;
        public Label textLabel;
        private Label currentPageLabel;
    }
}