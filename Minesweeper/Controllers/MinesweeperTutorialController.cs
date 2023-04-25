namespace Minesweeper.Controllers;

public class MinesweeperTutorialController
{
    private readonly Tutorial _tutorialForm;

    private readonly Page[] _pages;
    private int _currentPageIndex;

    public MinesweeperTutorialController(Tutorial tutorialForm)
    {
        _tutorialForm = tutorialForm;

        // Create all pages
        _pages = new Page[]
        {
            new(LanguageController.CurrentLanguageResource.TutorialPage1Title, LanguageController.CurrentLanguageResource.EmojiBomb, LanguageController.CurrentLanguageResource.TutorialPage1Description),
            new(LanguageController.CurrentLanguageResource.TutorialPage2Title, LanguageController.CurrentLanguageResource.EmojiKeyboard, LanguageController.CurrentLanguageResource.TutorialPage2Description),
            new(LanguageController.CurrentLanguageResource.TutorialPage3Title, LanguageController.CurrentLanguageResource.EmojiKeyboard, LanguageController.CurrentLanguageResource.TutorialPage3Description),
            new(LanguageController.CurrentLanguageResource.TutorialPage4Title, LanguageController.CurrentLanguageResource.EmojiKeyboard, LanguageController.CurrentLanguageResource.TutorialPage4Description),
            new(LanguageController.CurrentLanguageResource.TutorialPage5Title, LanguageController.CurrentLanguageResource.EmojiBoard, LanguageController.CurrentLanguageResource.TutorialPage5Description),
            new(LanguageController.CurrentLanguageResource.TutorialPage6Title, LanguageController.CurrentLanguageResource.EmojiBoard, LanguageController.CurrentLanguageResource.TutorialPage6Description),
            new(LanguageController.CurrentLanguageResource.TutorialPage7Title, LanguageController.CurrentLanguageResource.EmojiBoard, LanguageController.CurrentLanguageResource.TutorialPage7Description),
            new(LanguageController.CurrentLanguageResource.TutorialPage8Title, LanguageController.CurrentLanguageResource.EmojiClock, LanguageController.CurrentLanguageResource.TutorialPage8Description),
            new(LanguageController.CurrentLanguageResource.TutorialPage9Title, LanguageController.CurrentLanguageResource.EmojiBomb, LanguageController.CurrentLanguageResource.TutorialPage9Description),
            new(LanguageController.CurrentLanguageResource.TutorialPage10Title, LanguageController.CurrentLanguageResource.EmojiLightBulb, LanguageController.CurrentLanguageResource.TutorialPage10Description),
            new(LanguageController.CurrentLanguageResource.TutorialPage11Title, LanguageController.CurrentLanguageResource.EmojiPause, LanguageController.CurrentLanguageResource.TutorialPage11Description),
            new(LanguageController.CurrentLanguageResource.TutorialPage12Title, LanguageController.CurrentLanguageResource.EmojiHappy, LanguageController.CurrentLanguageResource.TutorialPage12Description),
        };

        // Display the first site
        ShowPage(CurrentPageIndex);
    }

    public int CurrentPageIndex
    {
        get => _currentPageIndex;
        private set => _currentPageIndex = (value >= 0 ? value : value + MaxPages) % MaxPages;
    }

    public int CurrentPage => CurrentPageIndex + 1;

    public int MaxPages => _pages.Length;

    public event EventHandler? PageChanged;

    public void NextPage()
    {
        CurrentPageIndex++;
        ShowPage(CurrentPageIndex);
    }

    public void PreviousPage()
    {
        CurrentPageIndex--;
        ShowPage(CurrentPageIndex);
    }

    public void ShowPage(int pageIndex)
    {
        _pages[pageIndex].Show(_tutorialForm.titleLabel, _tutorialForm.imageLabel, _tutorialForm.textLabel);
        PageChanged?.Invoke(this, EventArgs.Empty);
    }

    private class Page
    {
        private readonly string _title;
        private readonly string _symbol;
        private readonly string _text;

        public Page(string title, string symbol, string text)
        {
            _title = title;
            _symbol = symbol;
            _text = text;
        }

        public void Show(Label title, Label symbol, Label text)
        {
            title.Text = _title;
            symbol.Text = _symbol;
            text.Text = _text;
        }
    }
}