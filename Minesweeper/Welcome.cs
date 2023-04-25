using Minesweeper.Controllers;
using Minesweeper.Utils.Helpers;
using System.ComponentModel;
using System.Globalization;

namespace Minesweeper;

public partial class Welcome : Form
{
    public Welcome()
    {
        InitializeComponent();

        // Initialize settings
        Properties.Settings.Default.PropertyChanged += SettingsChanged;
        SettingsChanged(this, new PropertyChangedEventArgs("None"));  // Apply current settings

        // Initialize language
        LanguageController.LanguageChanged += LanguageChanged;
        LanguageChanged(null, EventArgs.Empty);  // Apply current language
    }

    private void SettingsChanged(object? sender, PropertyChangedEventArgs e)
    {
        // Apply background color
        BackColor = Properties.Settings.Default.BackgroundColor;
        ForeColor = UtilsClass.BlackOrWhite(BackColor);

        tutorialButton.FlatAppearance.BorderColor = UtilsClass.ChangeColorBrightness2(BackColor, 0.1f);
        playButton.FlatAppearance.BorderColor = UtilsClass.ChangeColorBrightness2(BackColor, 0.1f);

        chosenLanguageLabel.ForeColor = UtilsClass.ChangeColorBrightness2(ForeColor, 0.2f);
    }

    private void LanguageChanged(object? sender, EventArgs e)
    {
        Text = string.Format(LanguageController.CurrentLanguageResource.AppTitleWelcome, LanguageController.CurrentLanguageResource.AppTitle);
        titleLabel.Text = LanguageController.CurrentLanguageResource.WelcomeText;
        iconLabel.Text = LanguageController.CurrentLanguageResource.AppEmoji;

        tutorialButton.Text = LanguageController.CurrentLanguageResource.WelcomeTutorialText;
        playButton.Text = LanguageController.CurrentLanguageResource.WelcomeStartPlayingText;

        chosenLanguageLabel.Text = string.Format(LanguageController.CurrentLanguageResource.WelcomeChosenLanguage, CultureInfo.GetCultureInfo(LanguageController.CurrentLanguage).NativeName);
    }
}