namespace Minesweeper.Utils.Position;

/// <summary>
///     Represents an area using two points.
/// </summary>
public class Area
{
    /// <summary>
    ///     Initialize a new instance of <see cref="Area" />.
    /// </summary>
    /// <param name="start">The <see cref="Point" /> where the area starts.</param>
    /// <param name="end">The <see cref="Point" /> where the area ends.</param>
    public Area(Point start, Point end) => (StartPoint, EndPoint) = (start, end);

    /// <summary>
    ///     Initialize a new instance of <see cref="Area" />.
    /// </summary>
    /// <param name="start">The <see cref="Point" /> where the area starts.</param>
    /// <param name="size">The <see cref="System.Drawing.Size" /> of the area.</param>
    public Area(Point start, Size size) : this(start, new Point(start.X + size.Width - 1, start.Y + size.Height - 1))
    {
    }

    /// <summary>
    ///     Initialize a new instance of <see cref="Area" /> starting at the <see cref="Point" />(0, 0).
    /// </summary>
    /// <param name="size">The <see cref="System.Drawing.Size" /> of the area.</param>
    public Area(Size size) : this(new Point(0, 0), new Point(size.Width - 1, size.Height - 1))
    {
    }

    /// <summary>
    ///     The Start-<see cref="Point" /> of this area.
    /// </summary>
    public Point StartPoint { get; }

    /// <summary>
    ///     The End-<see cref="Point" /> of this area.
    /// </summary>
    public Point EndPoint { get; }

    /// <summary>
    ///     The <see cref="System.Drawing.Size" /> of this area.
    /// </summary>
    public Size Size => new(EndPoint.X - StartPoint.X + 1, EndPoint.Y - StartPoint.Y + 1);
}