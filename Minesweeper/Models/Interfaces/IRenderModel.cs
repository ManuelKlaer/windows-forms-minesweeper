using Minesweeper.Views.Interfaces;

namespace Minesweeper.Models.Interfaces;

/// <summary>
///     Interface for a model that stores the rendering information.
/// </summary>
public interface IRenderModel
{
    /// <summary>
    ///     The column count.
    /// </summary>
    public int Columns { get; }

    /// <summary>
    ///     The row count.
    /// </summary>
    public int Rows { get; }

    /// <summary>
    ///     Set / Change the <see cref="IComponent" /> at a specific location.
    /// </summary>
    /// <param name="col">The column where the <see cref="IComponent" /> should be placed.</param>
    /// <param name="row">The row where the <see cref="IComponent" /> should be placed.</param>
    /// <param name="component">The <see cref="IComponent" /> to place.</param>
    /// <exception cref="ArgumentOutOfRangeException">Column out of range.</exception>
    /// <exception cref="ArgumentOutOfRangeException">Row out of range.</exception>
    public void Set(int col, int row, IComponent component);

    /// <summary>
    ///     Get the <see cref="IComponent" /> from the specified location.
    /// </summary>
    /// <param name="col">The column of the <see cref="IComponent" />.</param>
    /// <param name="row">The row of the <see cref="IComponent" />.</param>
    /// <returns>The <see cref="IComponent" /> at that specified location if it exists; otherwise <see langword="null" />.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Column out of range.</exception>
    /// <exception cref="ArgumentOutOfRangeException">Row out of range.</exception>
    public IComponent? Get(int col, int row);

    /// <summary>
    ///     Get the position of a placed <see cref="IComponent" />.
    /// </summary>
    /// <param name="component">The <see cref="IComponent" />.</param>
    /// <returns>The location of the <see cref="IComponent" /> if it exists; otherwise <see langword="null" />.</returns>
    public Point? GetPos(IComponent component);

    /// <summary>
    ///     Get a <see cref="IEnumerable{T}" /> for this <see cref="IRenderModel" />.
    /// </summary>
    /// <returns>A <see cref="IEnumerable{T}" /> to enumerate this <see cref="IRenderModel" />.</returns>
    public IEnumerable<IComponent?> GetEnumerable();

    /// <summary>
    ///     Reset / clear this <see cref="IRenderModel" />.
    /// </summary>
    public void Reset();
}