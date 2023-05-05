using System.ComponentModel;
using System.Diagnostics;
using Minesweeper.Controllers;
using Minesweeper.Utils.Helpers;

namespace Minesweeper;

/// <summary>
///     About dialog.
/// </summary>
public partial class About : Form
{
    /// <summary>
    ///     Initialize a new instance of <see cref="About" />.
    /// </summary>
    public About()
    {
        InitializeComponent();

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
        // Apply colors
        BackColor = Properties.Settings.Default.BackgroundColor;
        ForeColor = UtilsClass.BlackOrWhite(BackColor);

        copyrightLabel.ForeColor = UtilsClass.ChangeColorBrightness2(ForeColor, 0.2f);
        githubLabel.ForeColor = UtilsClass.ChangeColorBrightness2(ForeColor, 0.2f);
    }

    /// <summary>
    ///     Event that gets called when the language changed.
    /// </summary>
    private void LanguageChanged(object? sender, EventArgs e)
    {
        Text = LanguageController.CurrentLanguageResource.AppTitleAbout;
        titleLabel.Text = LanguageController.CurrentLanguageResource.AppTitle;
        iconLabel.Text = LanguageController.CurrentLanguageResource.AppEmoji;
        copyrightLabel.Text = LanguageController.CurrentLanguageResource.AppCopyright;
        versionLabel.Text = string.Format(LanguageController.CurrentLanguageResource.AppVersion, Application.ProductVersion);
        githubLabel.Text = LanguageController.CurrentLanguageResource.AboutViewOnGithub;
    }

    /// <summary>
    ///     Event that gets called when GithubLabel is clicked.
    /// </summary>
    private void GithubLabelClick(object sender, EventArgs e)
    {
        // Create a new shell process
        ProcessStartInfo psInfo = new()
        {
            FileName = "https://github.com/ManuelKlaer/windows-forms-minesweeper",
            UseShellExecute = true
        };

        // Start the shell process to open the url
        Process.Start(psInfo);
    }
}