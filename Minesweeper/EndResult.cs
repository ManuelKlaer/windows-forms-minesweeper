using Minesweeper.Controllers;
using Minesweeper.Utils.Helpers;
using System.ComponentModel;

namespace Minesweeper;

public partial class EndResult : Form
{
    public EndResult()
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
    }

    private void LanguageChanged(object? sender, EventArgs e)
    {
        Text = LanguageController.CurrentLanguageResource.AppTitleEndResult;
    }
}