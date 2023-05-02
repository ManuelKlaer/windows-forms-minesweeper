namespace Minesweeper.Controllers;

/// <summary>
///     Tutorial page controller.
/// </summary>
public class MinesweeperTutorialController
{
    // The tutorial form
    private readonly Tutorial _tutorialForm;

    // All pages
    private readonly Page[] _pages;

    // The current page index
    private int _currentPageIndex;

    /// <summary>
    ///     Initialize a new <see cref="MinesweeperTutorialController" />.
    /// </summary>
    /// <param name="tutorialForm">The tutorial form that's used to render the pages.</param>
    public MinesweeperTutorialController(Tutorial tutorialForm)
    {
        _tutorialForm = tutorialForm;

        // Create all pages
        _pages = new Page[]
        {
            new(LanguageController.CurrentLanguageResource.TutorialPage1Title,
                LanguageController.CurrentLanguageResource.EmojiBomb,
                LanguageController.CurrentLanguageResource.TutorialPage1Description),
            new(LanguageController.CurrentLanguageResource.TutorialPage2Title,
                LanguageController.CurrentLanguageResource.EmojiKeyboard,
                LanguageController.CurrentLanguageResource.TutorialPage2Description),
            new(LanguageController.CurrentLanguageResource.TutorialPage3Title,
                LanguageController.CurrentLanguageResource.EmojiKeyboard,
                LanguageController.CurrentLanguageResource.TutorialPage3Description),
            new(LanguageController.CurrentLanguageResource.TutorialPage4Title,
                LanguageController.CurrentLanguageResource.EmojiKeyboard,
                LanguageController.CurrentLanguageResource.TutorialPage4Description),
            new(LanguageController.CurrentLanguageResource.TutorialPage5Title,
                LanguageController.CurrentLanguageResource.EmojiBoard,
                LanguageController.CurrentLanguageResource.TutorialPage5Description),
            new(LanguageController.CurrentLanguageResource.TutorialPage6Title,
                LanguageController.CurrentLanguageResource.EmojiBoard,
                LanguageController.CurrentLanguageResource.TutorialPage6Description),
            new(LanguageController.CurrentLanguageResource.TutorialPage7Title,
                LanguageController.CurrentLanguageResource.EmojiBoard,
                LanguageController.CurrentLanguageResource.TutorialPage7Description),
            new(LanguageController.CurrentLanguageResource.TutorialPage8Title,
                LanguageController.CurrentLanguageResource.EmojiClock,
                LanguageController.CurrentLanguageResource.TutorialPage8Description),
            new(LanguageController.CurrentLanguageResource.TutorialPage9Title,
                LanguageController.CurrentLanguageResource.EmojiBomb,
                LanguageController.CurrentLanguageResource.TutorialPage9Description),
            new(LanguageController.CurrentLanguageResource.TutorialPage10Title,
                LanguageController.CurrentLanguageResource.EmojiLightBulb,
                LanguageController.CurrentLanguageResource.TutorialPage10Description),
            new(LanguageController.CurrentLanguageResource.TutorialPage11Title,
                LanguageController.CurrentLanguageResource.EmojiPause,
                LanguageController.CurrentLanguageResource.TutorialPage11Description),
            new(LanguageController.CurrentLanguageResource.TutorialPage12Title,
                LanguageController.CurrentLanguageResource.EmojiHappy,
                LanguageController.CurrentLanguageResource.TutorialPage12Description)
        };

        // Display the first site
        ShowPage(CurrentPageIndex);
    }

    /// <summary>
    ///     The index of the currently viewed page.
    /// </summary>
    public int CurrentPageIndex
    {
        get => _currentPageIndex;
        private set => _currentPageIndex = (value >= 0 ? value : value + MaxPages) % MaxPages;
    }

    /// <summary>
    ///     The page number of the currently visible page.
    /// </summary>
    public int CurrentPage => CurrentPageIndex + 1;

    /// <summary>
    ///     The total number of all pages.
    /// </summary>
    public int MaxPages => _pages.Length;

    /// <summary>
    ///     <see cref="EventHandler" /> that gets called when the page changed.
    /// </summary>
    public event EventHandler? PageChanged;

    /// <summary>
    ///     Switch to the next page.
    /// </summary>
    public void NextPage()
    {
        CurrentPageIndex++;
        ShowPage(CurrentPageIndex);
    }

    /// <summary>
    ///     Switch to the previous page.
    /// </summary>
    public void PreviousPage()
    {
        CurrentPageIndex--;
        ShowPage(CurrentPageIndex);
    }

    /// <summary>
    ///     Show a specific page base on it's index.
    /// </summary>
    /// <param name="pageIndex">The index of the page to display.</param>
    public void ShowPage(int pageIndex)
    {
        _pages[pageIndex].Show(_tutorialForm.titleLabel, _tutorialForm.imageLabel, _tutorialForm.textLabel);
        PageChanged?.Invoke(this, EventArgs.Empty);
    }

    /// <summary>
    ///     A presentation of a page.
    /// </summary>
    private class Page
    {
        // The emoji symbol of the page
        private readonly string _symbol;

        // The page text
        private readonly string _text;

        // The title of the page
        private readonly string _title;

        /// <summary>
        ///     Initialize a new <see cref="Page" />.
        /// </summary>
        /// <param name="title">The title of the page.</param>
        /// <param name="symbol">The emoji symbol of the page.</param>
        /// <param name="text">The text of the page.</param>
        public Page(string title, string symbol, string text)
        {
            _title = title;
            _symbol = symbol;
            _text = text;
        }

        /// <summary>
        ///     Show this page.
        /// </summary>
        /// <param name="title">A <see cref="Label" /> that's used to display the page title.</param>
        /// <param name="symbol">A <see cref="Label" /> that's used to display the emoji symbol.</param>
        /// <param name="text">A <see cref="Label" /> that's used to display the page text.</param>
        public void Show(Label title, Label symbol, Label text)
        {
            title.Text = _title;
            symbol.Text = _symbol;
            text.Text = _text;
        }
    }
}