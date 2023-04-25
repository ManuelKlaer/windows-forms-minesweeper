using Minesweeper.Controllers;
using Minesweeper.Utils.Helpers;
using System.ComponentModel;

namespace Minesweeper;

public partial class Statistics : Form
{
    private readonly MinesweeperStatisticsController _statisticsController;

    public Statistics()
    {
        InitializeComponent();

        _statisticsController = new MinesweeperStatisticsController(this);
        _statisticsController.PageChanged += PageChanged;
        _statisticsController.ShowPage(_statisticsController.CurrentPageIndex);  // Show current page at startup

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

        currentPageLabel.ForeColor = UtilsClass.ChangeColorBrightness2(ForeColor, 0.2f);

        nextPageButton.FlatAppearance.BorderColor = UtilsClass.ChangeColorBrightness2(BackColor, 0.1f);
        previousPageButton.FlatAppearance.BorderColor = UtilsClass.ChangeColorBrightness2(BackColor, 0.1f);
    }

    private void LanguageChanged(object? sender, EventArgs e)
    {
        Text = LanguageController.CurrentLanguageResource.AppTitleStatistics;
        nextPageButton.Text = LanguageController.CurrentLanguageResource.AppNextButton;
        previousPageButton.Text = LanguageController.CurrentLanguageResource.AppPreviousButton;
    }

    private void PageChanged(object? sender, EventArgs e)
    {
        currentPageLabel.Text = string.Format(LanguageController.CurrentLanguageResource.AppProgressText,
            _statisticsController.CurrentPage, _statisticsController.MaxPages);
    }

    private void NextPageButtonClick(object sender, EventArgs e) => _statisticsController.NextPage();

    private void PreviousPageButtonClick(object sender, EventArgs e) => _statisticsController.PreviousPage();
}
