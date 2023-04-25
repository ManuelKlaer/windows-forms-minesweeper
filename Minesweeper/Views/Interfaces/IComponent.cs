using Minesweeper.Enums;
using Minesweeper.Views.Base;

namespace Minesweeper.Views.Interfaces;

public interface IComponent
{
    public Padding Padding { get; set; }

    public Padding Margin { get; set; }

    public Color BackColor { get; set; }

    public ComponentEnums.MouseState MouseState { get; set; }

    public void OnMouseEnter(RenderBase parent, Point location)
    {
        MouseState |= ComponentEnums.MouseState.Hover;
    }

    public void OnMouseLeave(RenderBase parent, Point location)
    {
        MouseState &= ~ComponentEnums.MouseState.Hover;
    }

    public void OnMouseUp(RenderBase parent, Point location, MouseEventArgs e)
    {
        MouseState &= ~ComponentEnums.MouseState.Press;
    }

    public void OnMouseDown(RenderBase parent, Point location, MouseEventArgs e)
    {
        MouseState |= ComponentEnums.MouseState.Press;
    }

    public void Update(RenderBase parent, Point location);

    public void RevertColors();

    public void Paint(Rectangle clientRectangle, Graphics graphics);
}