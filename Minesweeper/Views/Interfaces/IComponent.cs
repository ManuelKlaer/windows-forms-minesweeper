using Minesweeper.Enums;
using Minesweeper.Models.Interfaces;
using Minesweeper.Views.Base;

namespace Minesweeper.Views.Interfaces;

/// <summary>
///     The interface for a component.
/// </summary>
public interface IComponent
{
    /// <summary>
    ///     The padding of this <see cref="IComponent" />.
    /// </summary>
    public Padding Padding { get; set; }

    /// <summary>
    ///     The margin of this <see cref="IComponent" />.
    /// </summary>
    public Padding Margin { get; set; }

    /// <summary>
    ///     The background color for this <see cref="IComponent" />.
    /// </summary>
    public Color BackColor { get; set; }

    /// <summary>
    ///     The current mouse state of this <see cref="IComponent" />.
    /// </summary>
    public ComponentEnums.MouseState MouseState { get; set; }

    /// <summary>
    ///     Event that gets called when the mouse enters this component.
    /// </summary>
    /// <param name="parent">The <see cref="RenderBase" /> that's rendering this <see cref="IComponent" />.</param>
    /// <param name="location">The location of this <see cref="IComponent" /> in the <see cref="IRenderModel" />.</param>
    public void OnMouseEnter(RenderBase parent, Point location)
    {
        MouseState |= ComponentEnums.MouseState.Hover;
    }

    /// <summary>
    ///     Event that gets called when the mouse leaves this component.
    /// </summary>
    /// <param name="parent">The <see cref="RenderBase" /> that's rendering this <see cref="IComponent" />.</param>
    /// <param name="location">The location of this <see cref="IComponent" /> in the <see cref="IRenderModel" />.</param>
    public void OnMouseLeave(RenderBase parent, Point location)
    {
        MouseState &= ~ComponentEnums.MouseState.Hover;
    }

    /// <summary>
    ///     Event that gets called when a mouse button is released.
    /// </summary>
    /// <param name="parent">The <see cref="RenderBase" /> that's rendering this <see cref="IComponent" />.</param>
    /// <param name="location">The location of this <see cref="IComponent" /> in the <see cref="IRenderModel" />.</param>
    /// <param name="e">The <see cref="MouseEventArgs" /> provided from the mouse.</param>
    public void OnMouseUp(RenderBase parent, Point location, MouseEventArgs e)
    {
        MouseState &= ~ComponentEnums.MouseState.Press;
    }

    /// <summary>
    ///     Event that gets called when a mouse button pressed down.
    /// </summary>
    /// <param name="parent">The <see cref="RenderBase" /> that's rendering this <see cref="IComponent" />.</param>
    /// <param name="location">The location of this <see cref="IComponent" /> in the <see cref="IRenderModel" />.</param>
    /// <param name="e">The <see cref="MouseEventArgs" /> provided from the mouse.</param>
    public void OnMouseDown(RenderBase parent, Point location, MouseEventArgs e)
    {
        MouseState |= ComponentEnums.MouseState.Press;
    }

    /// <summary>
    ///     Update this <see cref="IComponent" />.
    /// </summary>
    /// <param name="parent">The <see cref="RenderBase" /> that's rendering this <see cref="IComponent" />.</param>
    /// <param name="location">The location of this <see cref="IComponent" /> in the <see cref="IRenderModel" />.</param>
    public void Update(RenderBase parent, Point location);

    /// <summary>
    ///     Reset all colors to the default values.
    /// </summary>
    public void RevertColors();

    /// <summary>
    ///     Render this <see cref="IComponent" /> to the screen.
    /// </summary>
    /// <param name="clientRectangle">The client <see cref="Rectangle" /> of this <see cref="IComponent" />.</param>
    /// <param name="graphics">The <see cref="Graphics" /> object to draw this <see cref="IComponent" /> onto.</param>
    public void Paint(Rectangle clientRectangle, Graphics graphics);
}