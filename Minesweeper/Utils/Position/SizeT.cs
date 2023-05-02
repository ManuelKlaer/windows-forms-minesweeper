namespace Minesweeper.Utils.Position;

/// <summary>
///     Represents the size of a rectangular region with an ordered pair of width and height.
/// </summary>
public class SizeT<T>
{
    /// <summary>
    ///     Initializes a new empty instance of the <see cref="SizeT{T}" /> class.
    /// </summary>
    public SizeT() { }

    /// <summary>
    ///     Initializes a new instance of the <see cref="SizeT{T}" /> class from the specified dimensions.
    /// </summary>
    public SizeT(T width, T height) => (Width, Height) = (width, height);

    /// <summary>
    ///     Tests whether this <see cref='SizeT{T}' /> has no width and height defined.
    /// </summary>
    public bool IsEmpty => Width == null && Height == null;

    /// <summary>
    ///     Represents the horizontal component of this <see cref='SizeT{T}' />.
    /// </summary>
    public T? Width { get; set; }

    /// <summary>
    ///     Represents the vertical component of this <see cref='SizeT{T}' />.
    /// </summary>
    public T? Height { get; set; }

    /// <summary>
    ///     Updates the dimensions of this <see cref="SizeT{T}" />
    /// </summary>
    public void Set(T? width, T? height) => (Width, Height) = (width, height);

    /// <summary>
    ///     Returns a hash code.
    /// </summary>
    public override int GetHashCode() => HashCode.Combine(Width, Height);

    /// <summary>
    ///     Creates a human-readable string that represents this <see cref='SizeT{T}' />.
    /// </summary>
    public override string ToString() => $"{{Width={Width}, Height={Height}}}";

    /// <summary>
    ///     Converts the specified <see cref='SizeT{T}' /> to a <see cref='Size' />.
    /// </summary>
    /// <returns>A new instance of <see cref="Size" />.</returns>
    public static Size AsSize(SizeT<int> sizeT) => new(sizeT.Width, sizeT.Height);

    /// <summary>
    ///     Converts the specified <see cref='SizeT{T}' /> to a <see cref='SizeF' />.
    /// </summary>
    /// <returns>A new instance of <see cref="SizeF" />.</returns>
    public static SizeF AsSize(SizeT<float> sizeT) => new(sizeT.Width, sizeT.Height);

    /// <summary>
    ///     Converts the specified <see cref='SizeT{T}' /> to a <see cref='SizeF' />.
    /// </summary>
    /// <returns>
    ///     A new instance of <see cref="SizeF" /> with <see cref="Width" /> and <see cref="Height" /> cast to a <see cref="float" />.
    /// </returns>
    public static SizeF AsSize(SizeT<double> sizeT) => new((float)sizeT.Width, (float)sizeT.Height);
}