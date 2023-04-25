using Minesweeper.Views.Interfaces;

namespace Minesweeper.Models.Interfaces;

public interface IRenderModel
{
    public int Columns { get; }

    public int Rows { get; }

    public void Set(int col, int row, IComponent component);

    public IComponent? Get(int col, int row);

    public Point? GetPos(IComponent component);

    public IEnumerable<IComponent?> GetEnumerable();

    public void Reset();
}