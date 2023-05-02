using System.ComponentModel;
using Minesweeper.Controllers;
using Minesweeper.Utils.Helpers;

namespace Minesweeper;

/// <summary>
///     Tutorial dialog
/// </summary>
public partial class Tutorial : Form
{
    private MinesweeperTutorialController? _tutorialController;

    /// <summary>
    ///     Create a new tutorial dialog form.
    /// </summary>
    public Tutorial()
    {
        InitializeComponent();

        // Initialize settings
        Properties.Settings.Default.PropertyChanged += SettingsChanged;
        SettingsChanged(this, new PropertyChangedEventArgs("None")); // Apply current settings

        // Initialize language
        LanguageController.LanguageChanged += LanguageChanged;
        LanguageChanged(null, EventArgs.Empty); // Apply current language (Also initializes the controller)
    }

    /// <summary>
    ///     Create a new tutorial controller.
    /// </summary>
    private void NewTutorialController()
    {
        int? currentPage =
            _tutorialController?.CurrentPageIndex; // Save the current page if the controller is recreated

        _tutorialController = new MinesweeperTutorialController(this);
        _tutorialController.PageChanged += PageChanged;
        _tutorialController.ShowPage(currentPage ?? _tutorialController.CurrentPageIndex); // Show current page if available, otherwise show the fist one
    }

    /// <summary>
    ///     Listen for setting changes.
    /// </summary>
    private void SettingsChanged(object? sender, PropertyChangedEventArgs e)
    {
        // Apply background color
        BackColor = Properties.Settings.Default.BackgroundColor;
        ForeColor = UtilsClass.BlackOrWhite(BackColor);

        currentPageLabel.ForeColor = UtilsClass.ChangeColorBrightness2(ForeColor, 0.2f);

        nextButton.FlatAppearance.BorderColor = UtilsClass.ChangeColorBrightness2(BackColor, 0.1f);
        previousButton.FlatAppearance.BorderColor = UtilsClass.ChangeColorBrightness2(BackColor, 0.1f);
    }

    /// <summary>
    ///     Listen for language changes.
    /// </summary>
    private void LanguageChanged(object? sender, EventArgs e)
    {
        // Initialize tutorial controller
        NewTutorialController();

        // Update text
        Text = LanguageController.CurrentLanguageResource.AppTitleTutorial;
        nextButton.Text = LanguageController.CurrentLanguageResource.AppNextButton;
        previousButton.Text = LanguageController.CurrentLanguageResource.AppPreviousButton;
    }

    /// <summary>
    ///     Listen for page changes.
    /// </summary>
    private void PageChanged(object? sender, EventArgs e)
    {
        // Update current page counter if the page was changed
        currentPageLabel.Text = string.Format(LanguageController.CurrentLanguageResource.AppProgressText,
            _tutorialController?.CurrentPage,
            _tutorialController?.MaxPages);
    }

    /// <summary>
    ///     Next page, when the next button was pressed.
    /// </summary>
    private void NextButtonClick(object sender, EventArgs e) => _tutorialController?.NextPage();

    /// <summary>
    ///     Previous page, if the previous button was pressed.
    /// </summary>
    private void PreviousButtonClick(object sender, EventArgs e) => _tutorialController?.PreviousPage();
}