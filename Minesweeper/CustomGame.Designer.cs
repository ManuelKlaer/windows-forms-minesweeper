namespace Minesweeper
{
    partial class CustomGame
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomGame));
            mainTableLayout = new TableLayoutPanel();
            widthLabel = new Label();
            heightLabel = new Label();
            minesLabel = new Label();
            hintsLabel = new Label();
            heightNumericUpDown = new NumericUpDown();
            minesNumericUpDown = new NumericUpDown();
            hintsNumericUpDown = new NumericUpDown();
            widthNumericUpDown = new NumericUpDown();
            okButton = new Button();
            mainTableLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)heightNumericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)minesNumericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)hintsNumericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)widthNumericUpDown).BeginInit();
            SuspendLayout();
            // 
            // mainTableLayout
            // 
            mainTableLayout.AutoSize = true;
            mainTableLayout.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            mainTableLayout.ColumnCount = 2;
            mainTableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            mainTableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 70F));
            mainTableLayout.Controls.Add(widthLabel, 0, 0);
            mainTableLayout.Controls.Add(heightLabel, 0, 1);
            mainTableLayout.Controls.Add(minesLabel, 0, 2);
            mainTableLayout.Controls.Add(hintsLabel, 0, 3);
            mainTableLayout.Controls.Add(heightNumericUpDown, 1, 1);
            mainTableLayout.Controls.Add(minesNumericUpDown, 1, 2);
            mainTableLayout.Controls.Add(hintsNumericUpDown, 1, 3);
            mainTableLayout.Controls.Add(widthNumericUpDown, 1, 0);
            mainTableLayout.Controls.Add(okButton, 1, 4);
            mainTableLayout.Dock = DockStyle.Fill;
            mainTableLayout.Location = new Point(6, 6);
            mainTableLayout.Name = "mainTableLayout";
            mainTableLayout.RowCount = 5;
            mainTableLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            mainTableLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            mainTableLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            mainTableLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            mainTableLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            mainTableLayout.Size = new Size(272, 169);
            mainTableLayout.TabIndex = 0;
            // 
            // widthLabel
            // 
            widthLabel.AutoSize = true;
            widthLabel.Dock = DockStyle.Fill;
            widthLabel.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            widthLabel.Location = new Point(3, 3);
            widthLabel.Margin = new Padding(3);
            widthLabel.Name = "widthLabel";
            widthLabel.Size = new Size(75, 27);
            widthLabel.TabIndex = 0;
            widthLabel.Text = "Width:";
            widthLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // heightLabel
            // 
            heightLabel.AutoSize = true;
            heightLabel.Dock = DockStyle.Fill;
            heightLabel.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            heightLabel.Location = new Point(3, 36);
            heightLabel.Margin = new Padding(3);
            heightLabel.Name = "heightLabel";
            heightLabel.Size = new Size(75, 27);
            heightLabel.TabIndex = 1;
            heightLabel.Text = "Height:";
            heightLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // minesLabel
            // 
            minesLabel.AutoSize = true;
            minesLabel.Dock = DockStyle.Fill;
            minesLabel.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            minesLabel.Location = new Point(3, 69);
            minesLabel.Margin = new Padding(3);
            minesLabel.Name = "minesLabel";
            minesLabel.Size = new Size(75, 27);
            minesLabel.TabIndex = 2;
            minesLabel.Text = "Mines:";
            minesLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // hintsLabel
            // 
            hintsLabel.AutoSize = true;
            hintsLabel.Dock = DockStyle.Fill;
            hintsLabel.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            hintsLabel.Location = new Point(3, 102);
            hintsLabel.Margin = new Padding(3);
            hintsLabel.Name = "hintsLabel";
            hintsLabel.Size = new Size(75, 27);
            hintsLabel.TabIndex = 3;
            hintsLabel.Text = "Hints:";
            hintsLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // heightNumericUpDown
            // 
            heightNumericUpDown.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            heightNumericUpDown.BackColor = Color.White;
            heightNumericUpDown.BorderStyle = BorderStyle.FixedSingle;
            heightNumericUpDown.ForeColor = Color.Black;
            heightNumericUpDown.Location = new Point(84, 38);
            heightNumericUpDown.Maximum = new decimal(new int[] { 50, 0, 0, 0 });
            heightNumericUpDown.Minimum = new decimal(new int[] { 6, 0, 0, 0 });
            heightNumericUpDown.Name = "heightNumericUpDown";
            heightNumericUpDown.Size = new Size(185, 23);
            heightNumericUpDown.TabIndex = 5;
            heightNumericUpDown.TextAlign = HorizontalAlignment.Center;
            heightNumericUpDown.Value = new decimal(new int[] { 6, 0, 0, 0 });
            heightNumericUpDown.ValueChanged += HeightNumericUpDownValueChanged;
            // 
            // minesNumericUpDown
            // 
            minesNumericUpDown.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            minesNumericUpDown.BackColor = Color.White;
            minesNumericUpDown.BorderStyle = BorderStyle.FixedSingle;
            minesNumericUpDown.ForeColor = Color.Black;
            minesNumericUpDown.Location = new Point(84, 71);
            minesNumericUpDown.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            minesNumericUpDown.Name = "minesNumericUpDown";
            minesNumericUpDown.Size = new Size(185, 23);
            minesNumericUpDown.TabIndex = 6;
            minesNumericUpDown.TextAlign = HorizontalAlignment.Center;
            minesNumericUpDown.Value = new decimal(new int[] { 1, 0, 0, 0 });
            minesNumericUpDown.ValueChanged += MinesNumericUpDownValueChanged;
            // 
            // hintsNumericUpDown
            // 
            hintsNumericUpDown.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            hintsNumericUpDown.BackColor = Color.White;
            hintsNumericUpDown.BorderStyle = BorderStyle.FixedSingle;
            hintsNumericUpDown.ForeColor = Color.Black;
            hintsNumericUpDown.Location = new Point(84, 104);
            hintsNumericUpDown.Name = "hintsNumericUpDown";
            hintsNumericUpDown.Size = new Size(185, 23);
            hintsNumericUpDown.TabIndex = 7;
            hintsNumericUpDown.TextAlign = HorizontalAlignment.Center;
            // 
            // widthNumericUpDown
            // 
            widthNumericUpDown.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            widthNumericUpDown.BackColor = Color.White;
            widthNumericUpDown.BorderStyle = BorderStyle.FixedSingle;
            widthNumericUpDown.ForeColor = Color.Black;
            widthNumericUpDown.Location = new Point(84, 5);
            widthNumericUpDown.Maximum = new decimal(new int[] { 50, 0, 0, 0 });
            widthNumericUpDown.Minimum = new decimal(new int[] { 6, 0, 0, 0 });
            widthNumericUpDown.Name = "widthNumericUpDown";
            widthNumericUpDown.Size = new Size(185, 23);
            widthNumericUpDown.TabIndex = 4;
            widthNumericUpDown.TextAlign = HorizontalAlignment.Center;
            widthNumericUpDown.Value = new decimal(new int[] { 6, 0, 0, 0 });
            widthNumericUpDown.ValueChanged += WidthNumericUpDownValueChanged;
            // 
            // okButton
            // 
            okButton.Anchor = AnchorStyles.Right;
            okButton.AutoSize = true;
            okButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            okButton.DialogResult = DialogResult.OK;
            okButton.FlatStyle = FlatStyle.Flat;
            okButton.Location = new Point(241, 137);
            okButton.Name = "okButton";
            okButton.Size = new Size(28, 27);
            okButton.TabIndex = 8;
            okButton.Text = "✓";
            okButton.UseVisualStyleBackColor = true;
            // 
            // CustomGame
            // 
            AcceptButton = okButton;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BackColor = Color.White;
            ClientSize = new Size(284, 181);
            Controls.Add(mainTableLayout);
            ForeColor = Color.Black;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            MinimumSize = new Size(300, 220);
            Name = "CustomGame";
            Padding = new Padding(6);
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Custom";
            TopMost = true;
            mainTableLayout.ResumeLayout(false);
            mainTableLayout.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)heightNumericUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)minesNumericUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)hintsNumericUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)widthNumericUpDown).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TableLayoutPanel mainTableLayout;
        private Label widthLabel;
        private Label heightLabel;
        private Label minesLabel;
        private Label hintsLabel;
        public NumericUpDown widthNumericUpDown;
        public NumericUpDown heightNumericUpDown;
        public NumericUpDown minesNumericUpDown;
        public NumericUpDown hintsNumericUpDown;
        private Button okButton;
    }
}