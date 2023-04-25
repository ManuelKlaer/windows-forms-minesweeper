namespace Minesweeper
{
    partial class EndResult
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EndResult));
            mainTableLayout = new TableLayoutPanel();
            infoTableLayout = new TableLayoutPanel();
            timerLabel = new Label();
            hintsLabel = new Label();
            titleLabel = new Label();
            mainTableLayout.SuspendLayout();
            infoTableLayout.SuspendLayout();
            SuspendLayout();
            // 
            // mainTableLayout
            // 
            mainTableLayout.AutoSize = true;
            mainTableLayout.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            mainTableLayout.ColumnCount = 1;
            mainTableLayout.ColumnStyles.Add(new ColumnStyle());
            mainTableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            mainTableLayout.Controls.Add(infoTableLayout, 0, 1);
            mainTableLayout.Controls.Add(titleLabel, 0, 0);
            mainTableLayout.Dock = DockStyle.Fill;
            mainTableLayout.Location = new Point(0, 0);
            mainTableLayout.Name = "mainTableLayout";
            mainTableLayout.RowCount = 2;
            mainTableLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            mainTableLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            mainTableLayout.Size = new Size(364, 161);
            mainTableLayout.TabIndex = 0;
            // 
            // infoTableLayout
            // 
            infoTableLayout.AutoSize = true;
            infoTableLayout.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            infoTableLayout.ColumnCount = 2;
            infoTableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            infoTableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            infoTableLayout.Controls.Add(timerLabel, 0, 0);
            infoTableLayout.Controls.Add(hintsLabel, 1, 0);
            infoTableLayout.Dock = DockStyle.Fill;
            infoTableLayout.Location = new Point(0, 80);
            infoTableLayout.Margin = new Padding(0);
            infoTableLayout.Name = "infoTableLayout";
            infoTableLayout.RowCount = 1;
            infoTableLayout.RowStyles.Add(new RowStyle());
            infoTableLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            infoTableLayout.Size = new Size(364, 81);
            infoTableLayout.TabIndex = 0;
            // 
            // timerLabel
            // 
            timerLabel.AutoSize = true;
            timerLabel.Dock = DockStyle.Fill;
            timerLabel.Font = new Font("Segoe UI Emoji", 12F, FontStyle.Regular, GraphicsUnit.Point);
            timerLabel.Location = new Point(3, 3);
            timerLabel.Margin = new Padding(3);
            timerLabel.Name = "timerLabel";
            timerLabel.Size = new Size(176, 75);
            timerLabel.TabIndex = 0;
            timerLabel.Text = "00:00";
            timerLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // hintsLabel
            // 
            hintsLabel.AutoSize = true;
            hintsLabel.Dock = DockStyle.Fill;
            hintsLabel.Font = new Font("Segoe UI Emoji", 12F, FontStyle.Regular, GraphicsUnit.Point);
            hintsLabel.Location = new Point(185, 3);
            hintsLabel.Margin = new Padding(3);
            hintsLabel.Name = "hintsLabel";
            hintsLabel.Size = new Size(176, 75);
            hintsLabel.TabIndex = 1;
            hintsLabel.Text = "0";
            hintsLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // titleLabel
            // 
            titleLabel.AutoSize = true;
            titleLabel.Dock = DockStyle.Fill;
            titleLabel.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            titleLabel.Location = new Point(3, 3);
            titleLabel.Margin = new Padding(3);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(358, 74);
            titleLabel.TabIndex = 1;
            titleLabel.Text = "You lost :(";
            titleLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // EndResult
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(364, 161);
            Controls.Add(mainTableLayout);
            ForeColor = Color.Black;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            MinimumSize = new Size(380, 200);
            Name = "EndResult";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "End result";
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
        private TableLayoutPanel infoTableLayout;
        public Label titleLabel;
        public Label timerLabel;
        public Label hintsLabel;
    }
}