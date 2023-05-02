using Minesweeper.Models.Interfaces;
using Minesweeper.Views;
using Minesweeper.Views.Interfaces;

namespace Minesweeper.Models;

/// <summary>
///     A <see cref="IRenderModel" /> for a <see cref="GridView" />.
/// </summary>
public class GridModel : IRenderModel
{
    // A private list to store all components
    private IComponent?[,] _components;

    /// <summary>
    ///     Initialize a new <see cref="GridModel" />.
    /// </summary>
    /// <param name="columns">The column count this model should have.</param>
    /// <param name="rows">The row count this model should have.</param>
    public GridModel(int columns, int rows)
    {
        Columns = columns;
        Rows = rows;
        _components = new IComponent[Columns, Rows];
    }

    /// <inheritdoc cref="IRenderModel.Columns" />
    public int Columns { get; }

    /// <inheritdoc cref="IRenderModel.Rows" />
    public int Rows { get; }

    /// <inheritdoc cref="IRenderModel.Set" />
    public void Set(int col, int row, IComponent component)
    {
        if (col < 0 || col >= _components.GetLength(0))
            throw new ArgumentOutOfRangeException(nameof(col),
                $"Column '{col}' out of range (0 - {_components.GetLength(0) - 1})");

        if (row < 0 || row >= _components.GetLength(1))
            throw new ArgumentOutOfRangeException(nameof(row),
                $"Row '{row}' out of range (0 - {_components.GetLength(1) - 1})");

        _components[col, row] = component;
    }

    /// <inheritdoc cref="IRenderModel.Get" />
    public IComponent? Get(int col, int row)
    {
        if (col < 0 || col >= _components.GetLength(0))
            throw new ArgumentOutOfRangeException(nameof(col),
                $"Column '{col}' out of range (0 - {_components.GetLength(0) - 1})");

        if (row < 0 || row >= _components.GetLength(1))
            throw new ArgumentOutOfRangeException(nameof(row),
                $"Row '{row}' out of range (0 - {_components.GetLength(1) - 1})");

        return _components[col, row];
    }

    /// <inheritdoc cref="IRenderModel.GetPos" />
    public Point? GetPos(IComponent component)
    {
        for (int c = 0; c < Columns; c++)
            for (int r = 0; r < Rows; r++)
                if (component == _components[c, r])
                    return new Point(c, r);

        return null;
    }

    /// <inheritdoc cref="IRenderModel.GetEnumerable" />
    public IEnumerable<IComponent?> GetEnumerable() => _components.Cast<IComponent?>().AsEnumerable();

    /// <inheritdoc cref="IRenderModel.Reset" />
    public void Reset() => _components = new IComponent[Columns, Rows];
}