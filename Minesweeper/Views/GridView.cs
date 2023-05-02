using Minesweeper.Models;
using Minesweeper.Models.Interfaces;
using Minesweeper.Views.Base;

namespace Minesweeper.Views;

/// <summary>
///     A grid view render that implements <see cref="RenderBase" />.
/// </summary>
public class GridView : RenderBase
{
    /// <summary>
    ///     Initialize a new instance of <see cref="GridView" />.
    /// </summary>
    /// <param name="model">The <see cref="IRenderModel" /> that holds all components that should be drawn to the screen.</param>
    public GridView(GridModel model) : base(model)
    {
    }

    /// <summary>
    ///     The number of columns this <see cref="GridView" /> has.
    /// </summary>
    public int Columns => Model.Columns;

    /// <summary>
    ///     The number of rows this <see cref="GridView" /> has.
    /// </summary>
    public int Rows => Model.Rows;
}