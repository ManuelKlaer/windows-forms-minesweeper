using System.Globalization;
using Minesweeper.Controllers;

namespace Minesweeper
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
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
}