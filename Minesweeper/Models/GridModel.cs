using Minesweeper.Models.Interfaces;
using Minesweeper.Views.Interfaces;

namespace Minesweeper.Models;

public class GridModel : IRenderModel
{
    private IComponent?[,] _components;

    public GridModel(int columns, int rows)
    {
        Columns = columns;
        Rows = rows;
        _components = new IComponent[Columns, Rows];
    }

    public int Columns { get; }
    public int Rows { get; }

    public void Set(int col, int row, IComponent component)
    {
        if (col < 0 || col >= _components.GetLength(0))
            throw new ArgumentOutOfRangeException(nameof(col), $"Column '{col}' out of range (0 - {_components.GetLength(0) - 1})");

        if (row < 0 || row >= _components.GetLength(1))
            throw new ArgumentOutOfRangeException(nameof(row), $"Row '{row}' out of range (0 - {_components.GetLength(1) - 1})");

        _components[col, row] = component;
    }

    public IComponent? Get(int col, int row)
    {
        if (col < 0 || col >= _components.GetLength(0))
            throw new ArgumentOutOfRangeException(nameof(col), $"Column '{col}' out of range (0 - {_components.GetLength(0) - 1})");

        if (row < 0 || row >= _components.GetLength(1))
            throw new ArgumentOutOfRangeException(nameof(row), $"Row '{row}' out of range (0 - {_components.GetLength(1) - 1})");

        return _components[col, row];
    }

    public Point? GetPos(IComponent component)
    {
        for (int c = 0; c < Columns; c++)
            for (int r = 0; r < Rows; r++)
                if (component == _components[r, c])
                    return new Point(r, c);

        return null;
    }

    public IEnumerable<IComponent?> GetEnumerable() => _components.Cast<IComponent?>().AsEnumerable();

    public void Reset() => _components = new IComponent[Columns, Rows];
}