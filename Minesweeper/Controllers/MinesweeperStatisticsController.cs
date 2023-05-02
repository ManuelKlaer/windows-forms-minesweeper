using Minesweeper.Properties;
using Minesweeper.Utils.Helpers;

namespace Minesweeper.Controllers;

/// <summary>
///     Statistics page controller.
/// </summary>
public class MinesweeperStatisticsController
{
    // The statistics form.
    private readonly Statistics _statisticsForm;

    // All pages
    private readonly string[] _pages;

    // All translated page titles
    private readonly string[] _translatedPages;

    // Current page.
    private int _currentPageIndex;

    /// <summary>
    ///     Initialize a new <see cref="MinesweeperStatisticsController" />.
    /// </summary>
    /// <param name="statisticsForm">The statistics form to render the page.</param>
    public MinesweeperStatisticsController(Statistics statisticsForm)
    {
        _statisticsForm = statisticsForm;

        // Create all pages
        _pages = new[]
        {
            "General",
            "Mini",
            "Beginner",
            "Intermediate",
            "Expert",
            "Custom"
        };

        // Translated page titles
        _translatedPages = new[]
        {
            LanguageController.CurrentLanguageResource.StatisticsPageGeneral,
            LanguageController.CurrentLanguageResource.PresetMini,
            LanguageController.CurrentLanguageResource.PresetBeginner,
            LanguageController.CurrentLanguageResource.PresetIntermediate,
            LanguageController.CurrentLanguageResource.PresetExpert,
            LanguageController.CurrentLanguageResource.PresetCustom
        };

        // Display the first page
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
        // Get the statistics
        StatisticPerType? stats = null;

        if (StatisticPerType.StatisticPrefixes.Contains(_pages[pageIndex]))
            stats = new StatisticPerType(_pages[pageIndex], Properties.Statistics.Default);

        // Display the page title
        _statisticsForm.titleLabel.Text = _translatedPages[pageIndex];

        // Get the statistic values
        int gamesWon = stats?.GamesWon ?? 0;
        int gamesLost = stats?.GamesLost ?? 0;
        int totalMines = stats?.TotalMines ?? 0;
        TimeSpan totalTime = stats?.TotalTime ?? TimeSpan.Zero;
        TimeSpan shortTime = stats?.ShortTime ?? TimeSpan.Zero;

        // If the page is general sum up all statistic values
        if (_pages[pageIndex] == "General")
            foreach (string statisticPrefix in StatisticPerType.StatisticPrefixes)
            {
                StatisticPerType s = new(statisticPrefix, Properties.Statistics.Default);

                gamesWon += s.GamesWon;
                gamesLost += s.GamesLost;
                totalMines += s.TotalMines;
                totalTime = totalTime.Add(s.TotalTime);
                if (shortTime.TotalNanoseconds <= 0 || (s.ShortTime.TotalNanoseconds > 0 && s.ShortTime < shortTime))
                    shortTime = s.ShortTime;
            }

        // Calculate extra values
        int totalGames = gamesWon + gamesLost;
        TimeSpan avgTime = totalGames == 0 ? TimeSpan.Zero : totalTime.Divide(totalGames);
        double performance = totalGames == 0 ? 0 : (double)gamesWon / totalGames;

        // Display the statistics
        _statisticsForm.totalGamesLabel.Text = string.Format(
            LanguageController.CurrentLanguageResource.StatisticsCategoryGames,
            LanguageController.CurrentLanguageResource.EmojiBoard, totalGames);
        _statisticsForm.gamesWonLabel.Text =
            string.Format(LanguageController.CurrentLanguageResource.StatisticsCategoryWon,
                LanguageController.CurrentLanguageResource.EmojiPartyPopper, gamesWon);
        _statisticsForm.gamesLostLabel.Text =
            string.Format(LanguageController.CurrentLanguageResource.StatisticsCategoryLost,
                LanguageController.CurrentLanguageResource.EmojiSwords, gamesLost);
        _statisticsForm.totalMinesLabel.Text = string.Format(
            LanguageController.CurrentLanguageResource.StatisticsCategoryMines,
            LanguageController.CurrentLanguageResource.EmojiBomb, totalMines);
        _statisticsForm.totalTimeLabel.Text =
            string.Format(LanguageController.CurrentLanguageResource.StatisticsCategoryTotalTime,
                LanguageController.CurrentLanguageResource.EmojiClock, UtilsClass.FormatTimeSpan(totalTime));
        _statisticsForm.avgTimeLabel.Text =
            string.Format(LanguageController.CurrentLanguageResource.StatisticsCategoryAverageTime,
                LanguageController.CurrentLanguageResource.EmojiClock, UtilsClass.FormatTimeSpan(avgTime));
        _statisticsForm.shortTimeLabel.Text =
            string.Format(LanguageController.CurrentLanguageResource.StatisticsCategoryShortestTime,
                LanguageController.CurrentLanguageResource.EmojiClock, UtilsClass.FormatTimeSpan(shortTime));
        _statisticsForm.performanceLabel.Text = string.Format(
            LanguageController.CurrentLanguageResource.StatisticsCategoryPerformance,
            LanguageController.CurrentLanguageResource.EmojiPerformance, Math.Round(performance * 100));

        PageChanged?.Invoke(this, EventArgs.Empty);
    }
}