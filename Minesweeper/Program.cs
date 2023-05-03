using Minesweeper.Controllers;

namespace Minesweeper;

/// <summary>
///     The main entry point class for the application.
/// </summary>
internal static class Program
{
    /// <summary>
    ///     The main entry point for the application.
    /// </summary>
    [STAThread]
    private static void Main()
    {
        // Handle unhandled exceptions
        try
        {
            Run();
        }
        catch (Exception ex)
        {
            DialogResult res = MessageBox.Show($"{ex.Message}\n\nStacktrace:\n{ex.StackTrace}\n\n- Click yes to copy to clipboard", "Unhandled Exception", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
            if (res == DialogResult.Yes) Clipboard.SetText($"Unhandled Exception:\n\n{ex.Message}\n\nStacktrace:\n{ex.StackTrace}");
        }
    }

    /// <summary>
    ///     Run the application
    /// </summary>
    private static void Run()
    {
        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        ApplicationConfiguration.Initialize();

        // Detect user language if none was set
        if (string.IsNullOrEmpty(Properties.Settings.Default.Language))
        {
            LanguageController.ApplyOsLanguage();
            Properties.Settings.Default.Language = LanguageController.CurrentLanguage;
            Properties.Settings.Default.Save();
        }

        // Apply user selected language
        LanguageController.SetLanguage(Properties.Settings.Default.Language);

        // Run application
        Application.Run(new Minesweeper());
    }
}