using Minesweeper.Controllers;
using System.Runtime;

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
        // Handle all unhandled exceptions
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
        // Show a notification when this application may be installed as an .appx application
        if (!ApplicationInfo.IsAppxPackage && ApplicationInfo.MaybeAppxPackage)
        {
            MessageBox.Show("The application is located in a 'WindowsApps' folder, but it couldn't be determined if it is an .appx application.", "Installation type", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Create storage directory if it doesn't exist
        if (!Directory.Exists(ApplicationInfo.StorageLocation))
            Directory.CreateDirectory(ApplicationInfo.StorageLocation);

        // Change current working directory to storage location
        Directory.SetCurrentDirectory(ApplicationInfo.StorageLocation);

        // Configure Startup Profile to improve startup performance
        // https://blogs.msdn.microsoft.com/dotnet/2012/10/18/an-easy-solution-for-improving-app-launch-performance/
        ProfileOptimization.SetProfileRoot(ApplicationInfo.StorageLocation);
        ProfileOptimization.StartProfile("minesweeper.profile");

        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        ApplicationConfiguration.Initialize();

        // Detect user language if none was set or if it's invalid
        if (string.IsNullOrEmpty(Properties.Settings.Default.Language) || !LanguageController.AvailableLanguages.Contains(Properties.Settings.Default.Language))
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