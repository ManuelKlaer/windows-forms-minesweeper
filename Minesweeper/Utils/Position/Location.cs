namespace Minesweeper.Utils.Position;

/// <summary>
///     Represents an ordered pair of x and y coordinates that define a point in a two-dimensional plane.
///     (This is a copy of <see cref="Point" />, but using a class instead of a struct.)
/// </summary>
public class Location
{
    /// <summary>
    ///     Creates a new empty instance of the <see cref='Location' /> class.
    /// </summary>
    public Location()
    {
    }

    /// <summary>
    ///     Initializes a new instance of the <see cref='Location' /> class with the specified coordinates.
    /// </summary>
    public Location(int x, int y) => (X, Y) = (x, y);

    /// <summary>
    ///     Initializes a new instance of the <see cref='Location' /> class from a <see cref='Point' /> .
    /// </summary>
    /// <param name="point"></param>
    public Location(Point point) : this(point.X, point.Y)
    {
    }

    /// <summary>
    ///     Initializes a new instance of the <see cref='Location' /> class from a <see cref='Size' /> .
    /// </summary>
    /// <param name="size"></param>
    public Location(Size size) : this(size.Width, size.Height)
    {
    }

    /// <summary>
    ///     Creates a new empty instance of the <see cref='Location' /> class.
    /// </summary>
    public static Location Empty => new();

    /// <summary>
    ///     Gets a value indicating whether this <see cref='Location' /> is empty.
    /// </summary>
    public bool IsEmpty => X == 0 && Y == 0;

    /// <summary>
    ///     Gets the x-coordinate of this <see cref='Location' />.
    /// </summary>
    public int X { get; set; }

    /// <summary>
    ///     Gets the y-coordinate of this <see cref='Location' />.
    /// </summary>
    public int Y { get; set; }

    /// <summary>
    ///     Creates a <see cref='Point' /> with the coordinates of the specified <see cref='Location' /> .
    /// </summary>
    /// <param name="loc"></param>
    public static implicit operator Point(Location loc) => new(loc.X, loc.Y);

    /// <summary>
    ///     Creates a <see cref='Size' /> with the coordinates of the specified <see cref='Location' /> .
    /// </summary>
    /// <param name="loc"></param>
    public static explicit operator Size(Location loc) => new(loc.X, loc.Y);

    /// <summary>
    ///     Translates a <see cref='Location' /> by a given <see cref='Location' /> .
    /// </summary>
    public static Location operator +(Location pos1, Location pos2) => Add(pos1, pos2);

    /// <summary>
    ///     Translates a <see cref='Location' /> by a given <see cref='Size' /> .
    /// </summary>
    public static Location operator +(Location pos, Size size) => Add(pos, size);

    /// <summary>
    ///     Translates a <see cref='Location' /> by the negative of a given <see cref='Location' /> .
    /// </summary>
    public static Location operator -(Location pos1, Location pos2) => Subtract(pos1, pos2);

    /// <summary>
    ///     Translates a <see cref='Location' /> by the negative of a given <see cref='Size' /> .
    /// </summary>
    public static Location operator -(Location pos, Size size) => Subtract(pos, size);

    /// <summary>
    ///     Compares two <see cref='Location' /> objects. The result specifies whether the values of the
    ///     <see cref='Location.X' /> and <see cref='Location.Y' /> properties of the two
    ///     <see cref='Location' /> objects are equal.
    /// </summary>
    public static bool operator ==(Location left, Location right) => left.X == right.X && left.Y == right.Y;

    /// <summary>
    ///     Compares two <see cref='Location' /> objects. The result specifies whether the values of the
    ///     <see cref='Location.X' /> or <see cref='Location.Y' /> properties of the two
    ///     <see cref='Location' />  objects are unequal.
    /// </summary>
    public static bool operator !=(Location left, Location right) => !(left == right);

    /// <summary>
    ///     Translates a <see cref='Location' /> by a given <see cref='Location' /> .
    /// </summary>
    public static Location Add(Location pos1, Location pos2) => new(pos1.X + pos2.X, pos1.Y + pos2.Y);

    /// <summary>
    ///     Translates a <see cref='Location' /> by a given <see cref='Size' /> .
    /// </summary>
    public static Location Add(Location pos, Size size) => new(pos.X + size.Width, pos.Y + size.Height);

    /// <summary>
    ///     Translates a <see cref='Location' /> by the negative of a given <see cref='Location' /> .
    /// </summary>
    public static Location Subtract(Location pos1, Location pos2) => new(pos1.X - pos2.X, pos1.Y - pos2.Y);

    /// <summary>
    ///     Translates a <see cref='Location' /> by the negative of a given <see cref='Size' /> .
    /// </summary>
    public static Location Subtract(Location pos, Size size) => new(pos.X - size.Width, pos.Y - size.Height);

    /// <summary>
    ///     Specifies whether this <see cref='Location' /> contains the same coordinates as the specified <see cref='object' />
    ///     .
    /// </summary>
    public override bool Equals(object? obj) => obj is Location location && Equals(location);

    /// <summary>
    ///     Specifies whether this <see cref='Location' /> contains the same coordinates as the specified
    ///     <see cref='Location' />.
    /// </summary>
    public bool Equals(Location other) => this == other;

    /// <summary>
    ///     Returns a hash code.
    /// </summary>
    public override int GetHashCode() => HashCode.Combine(X, Y);

    /// <summary>
    ///     Converts this <see cref='Location' /> to a human readable string.
    /// </summary>
    public override string ToString() => $"{{X={X},Y={Y}}}";
}