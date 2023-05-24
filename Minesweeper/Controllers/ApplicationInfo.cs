namespace Minesweeper.Controllers;

public static class ApplicationInfo
{
    /// <summary>
    ///     Whether this application is installed in the "C:\Program Files\WindowsApps" directory.
    /// </summary>
    public static bool IsAppxPackage => Path.GetFullPath(Application.ExecutablePath)
        .StartsWith(Path.GetFullPath("C:\\Program Files\\WindowsApps\\"), StringComparison.OrdinalIgnoreCase);

    /// <summary>
    ///     Whether this application is located in a "WindowsApps" folder.
    /// </summary>
    public static bool MaybeAppxPackage => Path.GetFullPath(Application.ExecutablePath)
        .Contains("WindowsApps", StringComparison.OrdinalIgnoreCase);

    /// <summary>
    ///     The storage location based on whether this application is installed as an .appx package
    /// </summary>
    public static string StorageLocation => Path.GetFullPath(IsAppxPackage
        ? Path.Join(Environment.GetEnvironmentVariable("LOCALAPPDATA") ?? "C:\\", "ManuelKlaer\\Minesweeper\\")
        : Application.StartupPath);
}