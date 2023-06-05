using Minesweeper.Utils.Helpers;

namespace Minesweeper.Models;

/// <summary>
///     Stores information about a application update.
/// </summary>
public class UpdateModel
{
    /// <summary>
    ///     The update id provided by GitHub.
    /// </summary>
    public required int Id { get; init; }

    /// <summary>
    ///     The update version.
    /// </summary>
    public required (int major, int minor, int patch) Version { get; init; }

    /// <summary>
    ///     The update name / title.
    /// </summary>
    public required string Name { get; init; }

    /// <summary>
    ///     The update text / body.
    /// </summary>
    public required string Body { get; init; }

    /// <summary>
    ///     The author of the update.
    /// </summary>
    public required string Author { get; init; }

    /// <summary>
    ///     Whether this update is a pre release.
    /// </summary>
    public required bool IsPreRelease { get; init; }

    /// <summary>
    ///     Whether this update is a draft.
    /// </summary>
    public required bool IsDraft { get; init; }

    /// <summary>
    ///     The update html url.
    /// </summary>
    public required string Url { get; init; }

    /// <summary>
    ///     The download url for the zip-Archive.
    /// </summary>
    public required string? DownloadPortableUrl { get; init; }

    /// <summary>
    ///     The download url for the appxbundle-Package
    /// </summary>
    public required string? DownloadInstallerUrl { get; init; }

    /// <summary>
    ///     Check if this update is newer than the current application version.
    /// </summary>
    /// <returns><see langword="true" /> if this update is newer; otherwise <see langword="false" />.</returns>
    public bool IsNewerVersion()
    {
        var (currentMajor, currentMinor, currentPatch) = UtilsClass.GetVersion(Application.ProductVersion);
        return currentMajor < Version.major || currentMinor < Version.minor || currentPatch < Version.patch;
    }
}