using Minesweeper.Models;
using Minesweeper.Views.Base;

namespace Minesweeper.Views;

public class GridView : RenderBase
{
    public GridView(GridModel model) : base(model) { }

    public int Columns => Model.Columns;

    public int Rows => Model.Rows;
}