namespace Minesweeper
{
    partial class About
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(About));
            mainTableLayout = new TableLayoutPanel();
            iconLabel = new Label();
            infoTableLayout = new TableLayoutPanel();
            titleLabel = new Label();
            copyrightLabel = new Label();
            githubLabel = new Label();
            mainTableLayout.SuspendLayout();
            infoTableLayout.SuspendLayout();
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
            mainTableLayout.Dock = DockStyle.Fill;
            mainTableLayout.Location = new Point(0, 0);
            mainTableLayout.Name = "mainTableLayout";
            mainTableLayout.RowCount = 1;
            mainTableLayout.RowStyles.Add(new RowStyle());
            mainTableLayout.Size = new Size(364, 161);
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
            iconLabel.Size = new Size(176, 155);
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
            infoTableLayout.Controls.Add(copyrightLabel, 0, 1);
            infoTableLayout.Controls.Add(githubLabel, 0, 2);
            infoTableLayout.Dock = DockStyle.Fill;
            infoTableLayout.Location = new Point(182, 0);
            infoTableLayout.Margin = new Padding(0);
            infoTableLayout.Name = "infoTableLayout";
            infoTableLayout.RowCount = 3;
            infoTableLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 40F));
            infoTableLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 60F));
            infoTableLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            infoTableLayout.Size = new Size(182, 161);
            infoTableLayout.TabIndex = 1;
            // 
            // titleLabel
            // 
            titleLabel.AutoSize = true;
            titleLabel.Dock = DockStyle.Fill;
            titleLabel.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            titleLabel.Location = new Point(0, 10);
            titleLabel.Margin = new Padding(0, 10, 10, 0);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(172, 42);
            titleLabel.TabIndex = 0;
            titleLabel.Text = "Minesweeper";
            titleLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // copyrightLabel
            // 
            copyrightLabel.AutoSize = true;
            copyrightLabel.Dock = DockStyle.Fill;
            copyrightLabel.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            copyrightLabel.ForeColor = Color.DimGray;
            copyrightLabel.Location = new Point(0, 52);
            copyrightLabel.Margin = new Padding(0, 0, 10, 0);
            copyrightLabel.Name = "copyrightLabel";
            copyrightLabel.Size = new Size(172, 78);
            copyrightLabel.TabIndex = 1;
            copyrightLabel.Text = "© Manuel Klär\r\n© Max Mitterböck";
            copyrightLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // githubLabel
            // 
            githubLabel.AutoSize = true;
            githubLabel.Cursor = Cursors.Hand;
            githubLabel.Dock = DockStyle.Fill;
            githubLabel.Font = new Font("Segoe UI", 9F, FontStyle.Italic | FontStyle.Underline, GraphicsUnit.Point);
            githubLabel.Location = new Point(0, 130);
            githubLabel.Margin = new Padding(0, 0, 10, 10);
            githubLabel.Name = "githubLabel";
            githubLabel.Size = new Size(172, 21);
            githubLabel.TabIndex = 2;
            githubLabel.Text = "View this project on GitHub";
            githubLabel.TextAlign = ContentAlignment.MiddleCenter;
            githubLabel.Click += GithubLabelClick;
            // 
            // About
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BackColor = Color.White;
            ClientSize = new Size(364, 161);
            Controls.Add(mainTableLayout);
            ForeColor = Color.Black;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            MinimumSize = new Size(380, 200);
            Name = "About";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "About";
            TopMost = true;
            mainTableLayout.ResumeLayout(false);
            mainTableLayout.PerformLayout();
            infoTableLayout.ResumeLayout(false);
            infoTableLayout.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TableLayoutPanel mainTableLayout;
        private Label iconLabel;
        private TableLayoutPanel infoTableLayout;
        private Label titleLabel;
        private Label copyrightLabel;
        private Label githubLabel;
    }
}