using Minesweeper.Controllers;
using Minesweeper.Utils.Helpers;
using System.ComponentModel;

namespace Minesweeper
{
    public partial class CustomGame : Form
    {
        public CustomGame()
        {
            InitializeComponent();

            UpdateMinMax();  // Apply current min and max settings

            // Initialize Settings
            Properties.Settings.Default.PropertyChanged += SettingsChanged;
            SettingsChanged(this, new PropertyChangedEventArgs("None"));  // Apply current settings

            // Initialize language
            LanguageController.LanguageChanged += LanguageChanged;
            LanguageChanged(null, EventArgs.Empty);  // Apply current language
        }

        private void UpdateMinMax()
        {
            minesNumericUpDown.Maximum = (int)Math.Ceiling((double)widthNumericUpDown.Value * (double)heightNumericUpDown.Value * 0.2);
            hintsNumericUpDown.Maximum = (int)Math.Ceiling((double)minesNumericUpDown.Value * 0.3);
        }
        private void WidthNumericUpDownValueChanged(object sender, EventArgs e) => UpdateMinMax();

        private void HeightNumericUpDownValueChanged(object sender, EventArgs e) => UpdateMinMax();

        private void MinesNumericUpDownValueChanged(object sender, EventArgs e) => UpdateMinMax();

        private void SettingsChanged(object? sender, PropertyChangedEventArgs e)
        {
            // Apply background color
            BackColor = Properties.Settings.Default.BackgroundColor;
            ForeColor = UtilsClass.BlackOrWhite(BackColor);

            widthNumericUpDown.BackColor = BackColor;
            widthNumericUpDown.ForeColor = ForeColor;

            heightNumericUpDown.BackColor = BackColor;
            heightNumericUpDown.ForeColor = ForeColor;

            minesNumericUpDown.BackColor = BackColor;
            minesNumericUpDown.ForeColor = ForeColor;

            hintsNumericUpDown.BackColor = BackColor;
            hintsNumericUpDown.ForeColor = ForeColor;

            okButton.FlatAppearance.BorderColor = UtilsClass.ChangeColorBrightness2(BackColor, 0.1f);
        }

        private void LanguageChanged(object? sender, EventArgs e)
        {
            Text = LanguageController.CurrentLanguageResource.AppTitleCustomGame;
            widthLabel.Text = LanguageController.CurrentLanguageResource.CustomWidth;
            heightLabel.Text = LanguageController.CurrentLanguageResource.CustomHeight;
            minesLabel.Text = LanguageController.CurrentLanguageResource.CustomMines;
            hintsLabel.Text = LanguageController.CurrentLanguageResource.CustomHints;
            okButton.Text = LanguageController.CurrentLanguageResource.AppConfirmButton;
        }
    }
}
