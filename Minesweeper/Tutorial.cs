using Minesweeper.Controllers;
using Minesweeper.Utils.Helpers;
using System.ComponentModel;

namespace Minesweeper;

public partial class Tutorial : Form
{
    private readonly MinesweeperTutorialController _tutorialController;

    public Tutorial()
    {
        InitializeComponent();

        _tutorialController = new MinesweeperTutorialController(this);
        _tutorialController.PageChanged += PageChanged;
        _tutorialController.ShowPage(_tutorialController.CurrentPageIndex);  // Show current page at startup

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

        nextButton.FlatAppearance.BorderColor = UtilsClass.ChangeColorBrightness2(BackColor, 0.1f);
        previousButton.FlatAppearance.BorderColor = UtilsClass.ChangeColorBrightness2(BackColor, 0.1f);
    }

    private void LanguageChanged(object? sender, EventArgs e)  // ToDo: New tutorial controller on language change
    {
        Text = LanguageController.CurrentLanguageResource.AppTitleTutorial;
        nextButton.Text = LanguageController.CurrentLanguageResource.AppNextButton;
        previousButton.Text = LanguageController.CurrentLanguageResource.AppPreviousButton;
    }

    private void PageChanged(object? sender, EventArgs e)
    {
        currentPageLabel.Text = string.Format(LanguageController.CurrentLanguageResource.AppProgressText,
            _tutorialController.CurrentPage, _tutorialController.MaxPages);
    }

    private void NextButtonClick(object sender, EventArgs e) => _tutorialController.NextPage();

    private void PreviousButtonClick(object sender, EventArgs e) => _tutorialController.PreviousPage();
}
