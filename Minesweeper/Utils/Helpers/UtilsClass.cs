using Minesweeper.Utils.Position;

namespace Minesweeper.Utils.Helpers;

/// <summary>
///     A collection of useful utils.
/// </summary>
public static class UtilsClass
{
    /// <summary>
    ///     All characters that a valid hex string can contain.
    /// </summary>
    public static readonly string HexValues = "abcdef0123456789";

    /// <summary>
    ///     Check if a <see cref="Point" /> is in an <see cref="Area" />.
    /// </summary>
    /// <param name="point">The point to check.</param>
    /// <param name="area">The area.</param>
    /// <returns>
    ///     <see langword="true" /> if the <see cref="Point" /> is in the <see cref="Area" />; otherwise
    ///     <see langword="false" />.
    /// </returns>
    public static bool IsPointInArea(Point point, Area area)
    {
        return point.X >= area.StartPoint.X &&
               point.X <= area.EndPoint.X &&
               point.Y >= area.StartPoint.Y &&
               point.Y <= area.EndPoint.Y;
    }

    /// <summary>
    ///     Convert a <see cref="TimeSpan" /> to a string using the format HH:MM:SS or MM:SS.
    /// </summary>
    /// <param name="timeSpan">The time span.</param>
    /// <returns>A string containing the time span values.</returns>
    public static string FormatTimeSpan(TimeSpan timeSpan)
    {
        string formatTime = $"{timeSpan.Minutes:D2}:{timeSpan.Seconds:D2}";
        if (timeSpan.Hours > 0) formatTime = string.Concat($"{timeSpan.Hours:D2}:", formatTime);
        return formatTime;
    }

    /// <summary>
    ///     Convert a version string into separate version numbers.
    /// </summary>
    /// <param name="version">The version string to convert.</param>
    /// <returns>The version as separate version numbers.</returns>
    public static (int major, int minor, int patch) GetVersion(string version)
    {
        string[] versionSplit = version.Replace("v", "").Split('.');
        return (int.Parse(versionSplit[0]), int.Parse(versionSplit[1]), int.Parse(versionSplit[2]));
    }

    /// <summary>
    ///     Convert a <see cref="Color" /> to the hex format.
    /// </summary>
    /// <param name="c">The color to convert,</param>
    /// <returns>The hex color code.</returns>
    public static string ToHex(Color c) => $"#{c.R:X2}{c.G:X2}{c.B:X2}";

    /// <summary>
    ///     Change a <see cref="Color" /> brightness by the specified percent.
    /// </summary>
    /// <param name="c">The color to modify.</param>
    /// <param name="percent">
    ///     The percent. From <see langword="-1.0" /> to <see langword="0.0" /> darken; From
    ///     <see langword="0.0" /> to <see langword="1.0" /> lighten;
    /// </param>
    /// <returns>The same color with a new brightness value.</returns>
    public static Color ChangeColorBrightness(Color c, float percent)
    {
        Color reference = Color.White;

        int r = (int)Math.Round(c.R + reference.R * percent);
        int g = (int)Math.Round(c.G + reference.G * percent);
        int b = (int)Math.Round(c.B + reference.B * percent);

        r = r < 0 ? 0 : r;
        g = g < 0 ? 0 : g;
        b = b < 0 ? 0 : b;

        r = r > 255 ? 255 : r;
        g = g > 255 ? 255 : g;
        b = b > 255 ? 255 : b;

        return Color.FromArgb(c.A, r, g, b);
    }

    /// <summary>
    ///     Change a <see cref="Color" /> brightness by the specified percent. If the specified color is dark, the new color
    ///     gets lighter; Otherwise, the new color gets darker;
    /// </summary>
    /// <param name="c">The color to modify.</param>
    /// <param name="percent">The percent.</param>
    /// <returns>The same color with a new brightness value.</returns>
    public static Color ChangeColorBrightness2(Color c, float percent) => PerceivedBrightness(c) <= 140 ? ChangeColorBrightness(c, percent) : ChangeColorBrightness(c, -percent);
    // public static Color ChangeColorBrightness2(Color c, float percent) => PerceivedBrightness(c) <= 140 ? ControlPaint.Light(c, percent) : ControlPaint.Dark(c, percent);

    /// <summary>
    ///     Get the perceived color brightness to a human.
    /// </summary>
    /// <param name="c">The color to get the brightness from.</param>
    /// <returns>The perceived brightness; <see langword="0" /> black; <see langword="255" /> white;</returns>
    public static int PerceivedBrightness(Color c)
    {
        return (int)Math.Sqrt(
            c.R * c.R * 0.299 +
            c.G * c.G * 0.587 +
            c.B * c.B * 0.114);
    }

    /// <summary>
    ///     Get a black or white color based on the perceived brightness of the specified color.
    /// </summary>
    /// <param name="c">A color.</param>
    /// <returns>
    ///     <see cref="Color.White" /> if the perceived brightness is less than or equal to <see langword="140" />;
    ///     Otherwise <see cref="Color.Black" />.
    /// </returns>
    public static Color BlackOrWhite(Color c) => PerceivedBrightness(c) <= 140 ? Color.White : Color.Black;
}