using Minesweeper.Controllers;
using Minesweeper.Utils.Helpers;
using System.ComponentModel;
using System.Globalization;

namespace Minesweeper
{
    public partial class Settings : Form
    {
        private readonly ToolTip _accentColorTextBoxTooltip = new();
        private readonly ToolTip _backgroundColorTextBoxTooltip = new();

        public Settings()
        {
            InitializeComponent();

            // Initialize / setup language combo box
            foreach (string language in LanguageController.AvailableLanguages)
            {
                CultureInfo culture = CultureInfo.GetCultureInfo(language);
                languageComboBox.Items.Add($"{culture.Name} - {culture.NativeName}");
            }

            // Initialize settings
            Properties.Settings.Default.PropertyChanged += SettingsChanged;
            SettingsChanged(this, new PropertyChangedEventArgs("None"));  // Apply current settings

            // Initialize language
            LanguageController.LanguageChanged += LanguageChanged;
            LanguageChanged(null, EventArgs.Empty);  // Apply current language
        }

        private void SettingsChanged(object? sender, PropertyChangedEventArgs e)
        {
            // Update setting boxes
            defaultPresetComboBox.SelectedIndex = Properties.Settings.Default.DefaultPreset;
            languageComboBox.SelectedIndex = Array.FindIndex(languageComboBox.Items.Cast<string>().ToArray(), d => d.Contains(LanguageController.CurrentLanguage));
            accentColorTextBox.Text = UtilsClass.ToHex(Properties.Settings.Default.AccentColor);
            backgroundColorTextBox.Text = UtilsClass.ToHex(Properties.Settings.Default.BackgroundColor);

            // Visual representation of the current accent color
            accentColorTextBox.BackColor = Properties.Settings.Default.AccentColor;
            accentColorTextBox.ForeColor = UtilsClass.BlackOrWhite(Properties.Settings.Default.AccentColor);

            // Visual representation of the current background color
            backgroundColorTextBox.BackColor = Properties.Settings.Default.BackgroundColor;
            backgroundColorTextBox.ForeColor = UtilsClass.BlackOrWhite(Properties.Settings.Default.BackgroundColor);

            // Apply background color
            BackColor = Properties.Settings.Default.BackgroundColor;
            ForeColor = UtilsClass.BlackOrWhite(BackColor);

            gameGroupBox.ForeColor = ForeColor;
            uiGroupBox.ForeColor = ForeColor;
            applicationGroupBox.ForeColor = ForeColor;

            defaultPresetComboBox.ForeColor = ForeColor;
            defaultPresetComboBox.BackColor = BackColor;

            languageComboBox.ForeColor = ForeColor;
            languageComboBox.BackColor = BackColor;

            showWelcomeButton.FlatAppearance.BorderColor = UtilsClass.ChangeColorBrightness2(BackColor, 0.1f);
            resetStatisticsButton.FlatAppearance.BorderColor = UtilsClass.ChangeColorBrightness2(BackColor, 0.1f);
            resetSettingsButton.FlatAppearance.BorderColor = UtilsClass.ChangeColorBrightness2(BackColor, 0.1f);
        }

        private void LanguageChanged(object? sender, EventArgs e)
        {
            // Form
            Text = LanguageController.CurrentLanguageResource.AppTitleSettings;

            // Game
            gameGroupBox.Text = LanguageController.CurrentLanguageResource.SettingsCategoryGame;
            defaultPresetLabel.Text = LanguageController.CurrentLanguageResource.SettingsDefaultPreset;
            defaultPresetComboBox.Items[0] = LanguageController.CurrentLanguageResource.PresetMini;
            defaultPresetComboBox.Items[1] = LanguageController.CurrentLanguageResource.PresetBeginner;
            defaultPresetComboBox.Items[2] = LanguageController.CurrentLanguageResource.PresetIntermediate;
            defaultPresetComboBox.Items[3] = LanguageController.CurrentLanguageResource.PresetExpert;

            // UI
            uiGroupBox.Text = LanguageController.CurrentLanguageResource.SettingsCategoryUI;
            accentColorLabel.Text = LanguageController.CurrentLanguageResource.SettingsAccentColor;
            _accentColorTextBoxTooltip.SetToolTip(accentColorTextBox, LanguageController.CurrentLanguageResource.SettingsTooltipColorChooser);
            backgroundColorLabel.Text = LanguageController.CurrentLanguageResource.SettingsBackgroundColor;
            _backgroundColorTextBoxTooltip.SetToolTip(backgroundColorTextBox, LanguageController.CurrentLanguageResource.SettingsTooltipColorChooser);
            languageLabel.Text = LanguageController.CurrentLanguageResource.SettingsLanguage;

            // Application
            applicationGroupBox.Text = LanguageController.CurrentLanguageResource.SettingsCategoryApp;
            showWelcomeLabel.Text = LanguageController.CurrentLanguageResource.SettingsShowWelcomeDialog;
            showWelcomeButton.Text = LanguageController.CurrentLanguageResource.SettingsButtonShow;
            resetStatisticsLabel.Text = LanguageController.CurrentLanguageResource.SettingsResetStatistics;
            resetStatisticsButton.Text = LanguageController.CurrentLanguageResource.SettingsButtonReset;
            resetSettingsLabel.Text = LanguageController.CurrentLanguageResource.SettingsResetSettings;
            resetSettingsButton.Text = LanguageController.CurrentLanguageResource.SettingsButtonReset;
        }

        private void SettingsFormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.Save();
            Properties.Statistics.Default.Save();
        }

        // --- Game --- //

        private void DefaultPresetComboBoxSelectedIndexChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.DefaultPreset = defaultPresetComboBox.SelectedIndex;
        }

        // --- UI --- //

        private void AccentColorTextBoxTextChanged(object sender, EventArgs e)
        {
            string newStr = accentColorTextBox.Text.Trim().ToLower().Replace("#", "");
            bool isHex = newStr.All(c => UtilsClass.HexValues.Contains(c));

            if (!isHex || newStr.Length is not 6) return;

            Properties.Settings.Default.AccentColor = ColorTranslator.FromHtml($"#{newStr}");
        }

        private void AccentColorTextBoxDoubleClick(object sender, EventArgs e)
        {
            colorChooserDialog.Color = Properties.Settings.Default.AccentColor;
            colorChooserDialog.ShowDialog();

            Properties.Settings.Default.AccentColor = colorChooserDialog.Color;
        }

        private void BackgroundColorTextBoxTextChanged(object sender, EventArgs e)
        {
            string newStr = backgroundColorTextBox.Text.Trim().ToLower().Replace("#", "");
            bool isHex = newStr.All(c => UtilsClass.HexValues.Contains(c));

            if (!isHex || newStr.Length is not 6) return;

            Properties.Settings.Default.BackgroundColor = ColorTranslator.FromHtml($"#{newStr}");
        }

        private void BackgroundColorTextBoxDoubleClick(object sender, EventArgs e)
        {
            colorChooserDialog.Color = Properties.Settings.Default.BackgroundColor;
            colorChooserDialog.ShowDialog();

            Properties.Settings.Default.BackgroundColor = colorChooserDialog.Color;
        }

        private void LanguageComboBoxSelectedIndexChanged(object sender, EventArgs e)
        {
            LanguageController.SetLanguage(LanguageController.AvailableLanguages[languageComboBox.SelectedIndex]);
            Properties.Settings.Default.Language = LanguageController.AvailableLanguages[languageComboBox.SelectedIndex];
        }

        // --- Application --- //

        private void ShowWelcomeButtonClick(object sender, EventArgs e)
        {
            Welcome welcome = new();
            welcome.ShowDialog();

            if (welcome.DialogResult == DialogResult.Continue)
            {
                Tutorial tutorial = new();
                tutorial.ShowDialog();
            }
        }

        private void ResetStatisticsButtonClick(object sender, EventArgs e)
        {
            Properties.Statistics.Default.Reset();
        }

        private void ResetSettingsButtonClick(object sender, EventArgs e)
        {
            // Reset all settings
            Properties.Settings.Default.Reset();

            // Apply default os language on reset
            LanguageController.ApplyOsLanguage();
            Properties.Settings.Default.Language = LanguageController.CurrentLanguage;

            // ToDo: Maybe add Option to only reset the user settings
            //Properties.Settings.Default.DefaultPreset = 0;
            //Properties.Settings.Default.AccentColor = Color.FromArgb(40, 26, 26);
            //Properties.Settings.Default.ShowedWelcomeDialog = false;
        }
    }
}
