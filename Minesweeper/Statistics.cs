using System.ComponentModel;
using Minesweeper.Controllers;
using Minesweeper.Utils.Helpers;

namespace Minesweeper;

/// <summary>
///     Statistics dialog.
/// </summary>
public partial class Statistics : Form
{
    // The statistics controller
    private readonly MinesweeperStatisticsController _statisticsController;

    /// <summary>
    ///     Initialize a new instance of <see cref="Statistics" />.
    /// </summary>
    public Statistics()
    {
        InitializeComponent();

        // Create a new statistics controller
        _statisticsController = new MinesweeperStatisticsController(this);
        _statisticsController.PageChanged += PageChanged;
        _statisticsController.ShowPage(_statisticsController.CurrentPageIndex); // Show current page at startup

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

        currentPageLabel.ForeColor = UtilsClass.ChangeColorBrightness2(ForeColor, 0.2f);

        nextPageButton.FlatAppearance.BorderColor = UtilsClass.ChangeColorBrightness2(BackColor, 0.1f);
        previousPageButton.FlatAppearance.BorderColor = UtilsClass.ChangeColorBrightness2(BackColor, 0.1f);
    }

    /// <summary>
    ///     Event that gets called when the language changed.
    /// </summary>
    private void LanguageChanged(object? sender, EventArgs e)
    {
        Text = LanguageController.CurrentLanguageResource.AppTitleStatistics;
        nextPageButton.Text = LanguageController.CurrentLanguageResource.AppNextButton;
        previousPageButton.Text = LanguageController.CurrentLanguageResource.AppPreviousButton;
    }

    /// <summary>
    ///     Event that gets called when the statistics controller changed to a new page.
    /// </summary>
    private void PageChanged(object? sender, EventArgs e)
    {
        currentPageLabel.Text = string.Format(LanguageController.CurrentLanguageResource.AppProgressText, _statisticsController.CurrentPage, _statisticsController.MaxPages);
    }

    /// <summary>
    ///     Event that gets called when the NextPageButton is clicked.
    /// </summary>
    private void NextPageButtonClick(object sender, EventArgs e) => _statisticsController.NextPage();

    /// <summary>
    ///     Event that gets called when the PreviousPageButton is clicked.
    /// </summary>
    private void PreviousPageButtonClick(object sender, EventArgs e) => _statisticsController.PreviousPage();
}