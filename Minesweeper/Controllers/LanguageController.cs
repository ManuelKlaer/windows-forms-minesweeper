using System.Collections.Immutable;
using System.Globalization;
using System.Resources;
using Minesweeper.Properties.Languages;

// ReSharper disable MemberCanBePrivate.Global

namespace Minesweeper.Controllers;

/// <summary>
///     A custom language controller that handles the language files.
/// </summary>
public static class LanguageController
{
    // Link the language codes to the corresponding language resource file.
    private static readonly Dictionary<string, LanguageResource> ResourceManagers = new()
    {
        { new CultureInfo("en-US").Name, new LanguageResource(en_US.ResourceManager) },
        { new CultureInfo("de-DE").Name, new LanguageResource(de_DE.ResourceManager) }
    };

    /// <summary>
    ///     All available language codes.
    /// </summary>
    public static ImmutableArray<string> AvailableLanguages => ResourceManagers.Keys.ToImmutableArray();

    /// <summary>
    ///     The current language code.
    /// </summary>
    public static string CurrentLanguage { get; private set; } = AvailableLanguages[0];

    /// <summary>
    ///     The current language resource file that corresponds to the <see cref="CurrentLanguage" />.
    /// </summary>
    public static LanguageResource CurrentLanguageResource => ResourceManagers[CurrentLanguage];

    /// <summary>
    ///     Language changed event.
    /// </summary>
    public static event EventHandler? LanguageChanged;

    /// <summary>
    ///     Set a new language.
    /// </summary>
    /// <param name="language">The new language.</param>
    public static void SetLanguage(CultureInfo language) => SetLanguage(language.Name);

    /// <summary>
    ///     Set a new language code.
    /// </summary>
    /// <param name="language">The new language.</param>
    /// <exception cref="ArgumentException">The language code doesn't correspond to any language file.</exception>
    public static void SetLanguage(string language)
    {
        if (!AvailableLanguages.Contains(language))
            throw new ArgumentException($"The language code {language} doesn't correspond to any language file.", nameof(language));
        CurrentLanguage = language;
        LanguageChanged?.Invoke(null, EventArgs.Empty);
    }

    /// <summary>
    ///     Set the current language to the language reported by the operating system.
    /// </summary>
    public static void ApplyOsLanguage()
    {
        CultureInfo userLanguage = CultureInfo.CurrentCulture; // Get current OS language

        if (AvailableLanguages.Contains(userLanguage.Name)) // Check if this application supports the users language, if true use it
            SetLanguage(userLanguage);
        else if (AvailableLanguages.Any(l => l.Contains(userLanguage.TwoLetterISOLanguageName))) // Search for a similar language, if the same language isn't supported by this application
            SetLanguage(AvailableLanguages[Array.FindIndex(AvailableLanguages.ToArray(), l => l.Contains(userLanguage.TwoLetterISOLanguageName))]);
        else // If the users language isn't supported by this application, use a language that's supported.
            SetLanguage(AvailableLanguages[0]);
    }
}

/// <summary>
///     Language resource manager.
/// </summary>
public class LanguageResource
{
    // The resource manager of the resource file.
    private readonly ResourceManager _resourceManager;

    /// <summary>
    ///     Initialize a new language resource file.
    /// </summary>
    /// <param name="resourceManager">The resource manager of the resource file.</param>
    public LanguageResource(ResourceManager resourceManager) => _resourceManager = resourceManager;

    #region Language file attributes

    public string AppTitle => _resourceManager.GetString("AppTitle")!;
    public string AppCopyright => _resourceManager.GetString("AppCopyright")!;
    public string AppVersion => _resourceManager.GetString("AppVersion")!;
    public string AppEmoji => _resourceManager.GetString("AppEmoji")!;
    public string AppTitleWelcome => _resourceManager.GetString("AppTitleWelcome")!;
    public string AppTitleCustomGame => _resourceManager.GetString("AppTitleCustomGame")!;
    public string AppTitleEndResult => _resourceManager.GetString("AppTitleEndResult")!;
    public string AppTitleStatistics => _resourceManager.GetString("AppTitleStatistics")!;
    public string AppTitleSettings => _resourceManager.GetString("AppTitleSettings")!;
    public string AppTitleTutorial => _resourceManager.GetString("AppTitleTutorial")!;
    public string AppTitleAbout => _resourceManager.GetString("AppTitleAbout")!;
    public string AppTextEmoji => _resourceManager.GetString("AppTextEmoji")!;
    public string AppProgressText => _resourceManager.GetString("AppProgressText")!;
    public string AppProgressTextEmoji => _resourceManager.GetString("AppProgressTextEmoji")!;
    public string AppConfirmButton => _resourceManager.GetString("AppConfirmButton")!;
    public string AppNextButton => _resourceManager.GetString("AppNextButton")!;
    public string AppPreviousButton => _resourceManager.GetString("AppPreviousButton")!;
    public string AppConfirmNewGameTitle => _resourceManager.GetString("AppConfirmNewGameTitle")!;
    public string AppConfirmNewGameText => _resourceManager.GetString("AppConfirmNewGameText")!;
    public string AppConfirmExitTitle => _resourceManager.GetString("AppConfirmExitTitle")!;
    public string AppConfirmExitText => _resourceManager.GetString("AppConfirmExitText")!;
    public string EmojiBomb => _resourceManager.GetString("EmojiBomb")!;
    public string EmojiFlag => _resourceManager.GetString("EmojiFlag")!;
    public string EmojiQuestion => _resourceManager.GetString("EmojiQuestion")!;
    public string EmojiClock => _resourceManager.GetString("EmojiClock")!;
    public string EmojiLightBulb => _resourceManager.GetString("EmojiLightBulb")!;
    public string EmojiBoard => _resourceManager.GetString("EmojiBoard")!;
    public string EmojiKeyboard => _resourceManager.GetString("EmojiKeyboard")!;
    public string EmojiPerformance => _resourceManager.GetString("EmojiPerformance")!;
    public string EmojiPartyPopper => _resourceManager.GetString("EmojiPartyPopper")!;
    public string EmojiSwords => _resourceManager.GetString("EmojiSwords")!;
    public string EmojiHappy => _resourceManager.GetString("EmojiHappy")!;
    public string EmojiPlay => _resourceManager.GetString("EmojiPlay")!;
    public string EmojiPause => _resourceManager.GetString("EmojiPause")!;
    public string EmojiStop => _resourceManager.GetString("EmojiStop")!;
    public string GameWon => _resourceManager.GetString("GameWon")!;
    public string GameLost => _resourceManager.GetString("GameLost")!;
    public string MenuGame => _resourceManager.GetString("MenuGame")!;
    public string MenuStatistics => _resourceManager.GetString("MenuStatistics")!;
    public string MenuHelp => _resourceManager.GetString("MenuHelp")!;
    public string MenuNew => _resourceManager.GetString("MenuNew")!;
    public string MenuSave => _resourceManager.GetString("MenuSave")!;
    public string MenuLoad => _resourceManager.GetString("MenuLoad")!;
    public string MenuSettings => _resourceManager.GetString("MenuSettings")!;
    public string MenuExit => _resourceManager.GetString("MenuExit")!;
    public string MenuTutorial => _resourceManager.GetString("MenuTutorial")!;
    public string MenuAbout => _resourceManager.GetString("MenuAbout")!;
    public string PresetMini => _resourceManager.GetString("PresetMini")!;
    public string PresetBeginner => _resourceManager.GetString("PresetBeginner")!;
    public string PresetIntermediate => _resourceManager.GetString("PresetIntermediate")!;
    public string PresetExpert => _resourceManager.GetString("PresetExpert")!;
    public string PresetCustom => _resourceManager.GetString("PresetCustom")!;
    public string WelcomeText => _resourceManager.GetString("WelcomeText")!;
    public string WelcomeTutorialText => _resourceManager.GetString("WelcomeTutorialText")!;
    public string WelcomeStartPlayingText => _resourceManager.GetString("WelcomeStartPlayingText")!;
    public string WelcomeChosenLanguage => _resourceManager.GetString("WelcomeChosenLanguage")!;
    public string AboutViewOnGithub => _resourceManager.GetString("AboutViewOnGithub")!;
    public string CustomWidth => _resourceManager.GetString("CustomWidth")!;
    public string CustomHeight => _resourceManager.GetString("CustomHeight")!;
    public string CustomMines => _resourceManager.GetString("CustomMines")!;
    public string CustomHints => _resourceManager.GetString("CustomHints")!;
    public string TutorialPage1Title => _resourceManager.GetString("TutorialPage1Title")!;
    public string TutorialPage1Description => _resourceManager.GetString("TutorialPage1Description")!;
    public string TutorialPage2Title => _resourceManager.GetString("TutorialPage2Title")!;
    public string TutorialPage2Description => _resourceManager.GetString("TutorialPage2Description")!;
    public string TutorialPage3Title => _resourceManager.GetString("TutorialPage3Title")!;
    public string TutorialPage3Description => _resourceManager.GetString("TutorialPage3Description")!;
    public string TutorialPage4Title => _resourceManager.GetString("TutorialPage4Title")!;
    public string TutorialPage4Description => _resourceManager.GetString("TutorialPage4Description")!;
    public string TutorialPage5Title => _resourceManager.GetString("TutorialPage5Title")!;
    public string TutorialPage5Description => _resourceManager.GetString("TutorialPage5Description")!;
    public string TutorialPage6Title => _resourceManager.GetString("TutorialPage6Title")!;
    public string TutorialPage6Description => _resourceManager.GetString("TutorialPage6Description")!;
    public string TutorialPage7Title => _resourceManager.GetString("TutorialPage7Title")!;
    public string TutorialPage7Description => _resourceManager.GetString("TutorialPage7Description")!;
    public string TutorialPage8Title => _resourceManager.GetString("TutorialPage8Title")!;
    public string TutorialPage8Description => _resourceManager.GetString("TutorialPage8Description")!;
    public string TutorialPage9Title => _resourceManager.GetString("TutorialPage9Title")!;
    public string TutorialPage9Description => _resourceManager.GetString("TutorialPage9Description")!;
    public string TutorialPage10Title => _resourceManager.GetString("TutorialPage10Title")!;
    public string TutorialPage10Description => _resourceManager.GetString("TutorialPage10Description")!;
    public string TutorialPage11Title => _resourceManager.GetString("TutorialPage11Title")!;
    public string TutorialPage11Description => _resourceManager.GetString("TutorialPage11Description")!;
    public string TutorialPage12Title => _resourceManager.GetString("TutorialPage12Title")!;
    public string TutorialPage12Description => _resourceManager.GetString("TutorialPage12Description")!;
    public string StatisticsPageGeneral => _resourceManager.GetString("StatisticsPageGeneral")!;
    public string StatisticsCategoryGames => _resourceManager.GetString("StatisticsCategoryGames")!;
    public string StatisticsCategoryWon => _resourceManager.GetString("StatisticsCategoryWon")!;
    public string StatisticsCategoryLost => _resourceManager.GetString("StatisticsCategoryLost")!;
    public string StatisticsCategoryMines => _resourceManager.GetString("StatisticsCategoryMines")!;
    public string StatisticsCategoryTotalTime => _resourceManager.GetString("StatisticsCategoryTotalTime")!;
    public string StatisticsCategoryAverageTime => _resourceManager.GetString("StatisticsCategoryAverageTime")!;
    public string StatisticsCategoryShortestTime => _resourceManager.GetString("StatisticsCategoryShortestTime")!;
    public string StatisticsCategoryPerformance => _resourceManager.GetString("StatisticsCategoryPerformance")!;
    public string SettingsCategoryGame => _resourceManager.GetString("SettingsCategoryGame")!;
    public string SettingsCategoryUI => _resourceManager.GetString("SettingsCategoryUI")!;
    public string SettingsCategoryApp => _resourceManager.GetString("SettingsCategoryApp")!;
    public string SettingsDefaultPreset => _resourceManager.GetString("SettingsDefaultPreset")!;
    public string SettingsAccentColor => _resourceManager.GetString("SettingsAccentColor")!;
    public string SettingsBackgroundColor => _resourceManager.GetString("SettingsBackgroundColor")!;
    public string SettingsLanguage => _resourceManager.GetString("SettingsLanguage")!;
    public string SettingsShowWelcomeDialog => _resourceManager.GetString("SettingsShowWelcomeDialog")!;
    public string SettingsResetStatistics => _resourceManager.GetString("SettingsResetStatistics")!;
    public string SettingsResetSettings => _resourceManager.GetString("SettingsResetSettings")!;
    public string SettingsTooltipColorChooser => _resourceManager.GetString("SettingsTooltipColorChooser")!;
    public string SettingsButtonShow => _resourceManager.GetString("SettingsButtonShow")!;
    public string SettingsButtonReset => _resourceManager.GetString("SettingsButtonReset")!;

    #endregion
}