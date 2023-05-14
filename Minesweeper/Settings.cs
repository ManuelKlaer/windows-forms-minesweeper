using System.ComponentModel;
using System.Globalization;
using Microsoft.VisualBasic.Devices;
using Minesweeper.Controllers;
using Minesweeper.Utils.Helpers;

namespace Minesweeper;

/// <summary>
///     The settings dialog.
/// </summary>
public partial class Settings : Form
{
    // Tooltips
    private readonly ToolTip _accentColorTextBoxTooltip = new();
    private readonly ToolTip _backgroundColorTextBoxTooltip = new();

    /// <summary>
    ///     Initialize a new instance if <see cref="Settings" />.
    /// </summary>
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
        SettingsChanged(this, new PropertyChangedEventArgs("None")); // Apply current settings

        // Initialize language
        LanguageController.LanguageChanged += LanguageChanged;
        LanguageChanged(null, EventArgs.Empty); // Apply current language
    }

    /// <summary>
    ///     Event that gets called when a setting changed.
    /// </summary>
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

        // Apply colors
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

    /// <summary>
    ///     Event that gets called when the language changed.
    /// </summary>
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

    /// <summary>
    ///     Event that gets called when is dialog is closing.
    /// </summary>
    private void SettingsFormClosing(object sender, FormClosingEventArgs e)
    {
        // Save all settings
        Properties.Settings.Default.Save();
        Properties.Statistics.Default.Save();
    }

    // --- Game --- //

    /// <summary>
    ///     Event that gets called when the selected index of DefaultPresetComboBox changed.
    /// </summary>
    private void DefaultPresetComboBoxSelectedIndexChanged(object sender, EventArgs e)
    {
        Properties.Settings.Default.DefaultPreset = defaultPresetComboBox.SelectedIndex;
    }

    // --- UI --- //

    /// <summary>
    ///     Event that gets called when the text of the AccentColorTextBox changed.
    /// </summary>
    private void AccentColorTextBoxTextChanged(object sender, EventArgs e)
    {
        string newStr = accentColorTextBox.Text.Trim().ToLower().Replace("#", "");
        bool isHex = newStr.All(c => UtilsClass.HexValues.Contains(c));

        if (!isHex || newStr.Length is not 6) return;

        Properties.Settings.Default.AccentColor = ColorTranslator.FromHtml($"#{newStr}");
    }

    /// <summary>
    ///     Event that gets called when the the AccentColorTextBox is clicked.
    /// </summary>
    private void AccentColorTextBoxClick(object sender, EventArgs e)
    {
        if (ModifierKeys.HasFlag(Keys.Control)) return;

        colorChooserDialog.Color = Properties.Settings.Default.AccentColor;
        colorChooserDialog.ShowDialog();

        Properties.Settings.Default.AccentColor = colorChooserDialog.Color;
    }

    /// <summary>
    ///     Event that gets called when the text of the BackgroundColorTextBox changed.
    /// </summary>
    private void BackgroundColorTextBoxTextChanged(object sender, EventArgs e)
    {
        string newStr = backgroundColorTextBox.Text.Trim().ToLower().Replace("#", "");
        bool isHex = newStr.All(c => UtilsClass.HexValues.Contains(c));

        if (!isHex || newStr.Length is not 6) return;

        Properties.Settings.Default.BackgroundColor = ColorTranslator.FromHtml($"#{newStr}");
    }

    /// <summary>
    ///     Event that gets called when the the BackgroundColorTextBox is clicked.
    /// </summary>
    private void BackgroundColorTextBoxClick(object sender, EventArgs e)
    {
        if (ModifierKeys.HasFlag(Keys.Control)) return;

        colorChooserDialog.Color = Properties.Settings.Default.BackgroundColor;
        colorChooserDialog.ShowDialog();

        Properties.Settings.Default.BackgroundColor = colorChooserDialog.Color;
    }

    /// <summary>
    ///     Event that gets called when the selected index of LanguageComboBox changed.
    /// </summary>
    private void LanguageComboBoxSelectedIndexChanged(object sender, EventArgs e)
    {
        LanguageController.SetLanguage(LanguageController.AvailableLanguages[languageComboBox.SelectedIndex]);
        Properties.Settings.Default.Language = LanguageController.AvailableLanguages[languageComboBox.SelectedIndex];
    }

    // --- Application --- //

    /// <summary>
    ///     Events that gets called when the ShowWelcomeButton is clicked.
    /// </summary>
    private void ShowWelcomeButtonClick(object sender, EventArgs e)
    {
        // Open the welcome dialog
        Welcome welcome = new();
        welcome.ShowDialog();

        // Show the tutorial if the tutorial button was clicked
        if (welcome.DialogResult == DialogResult.Continue)
        {
            Tutorial tutorial = new();
            tutorial.ShowDialog();
        }
    }

    /// <summary>
    ///     Events that gets called when the ResetStatisticsButton is clicked.
    /// </summary>
    private void ResetStatisticsButtonClick(object sender, EventArgs e)
    {
        Properties.Statistics.Default.Reset();
    }

    /// <summary>
    ///     Events that gets called when the ResetSettingsButton is clicked.
    /// </summary>
    private void ResetSettingsButtonClick(object sender, EventArgs e)
    {
        // Reset all settings
        Properties.Settings.Default.Reset();

        // Apply current os language on reset
        LanguageController.ApplyOsLanguage();
        Properties.Settings.Default.Language = LanguageController.CurrentLanguage;
    }
}