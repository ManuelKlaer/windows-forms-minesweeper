using Minesweeper.Models.Interfaces;
using Minesweeper.Utils.Position;
using Minesweeper.Views.Base;
using Minesweeper.Views.Interfaces;

namespace Minesweeper.Views.CustomEventArgs;

/// <summary>
///     Event args for the <see cref="RenderBase" /> to provide the current mouse state as well as the component location
///     and component itself.
/// </summary>
public class RenderMouseEventArgs : EventArgs
{
    /// <summary>
    ///     Initialize a new instance of <see cref="RenderMouseEventArgs" />.
    /// </summary>
    /// <param name="component">A <see cref="IComponent" />.</param>
    /// <param name="componentLocation">The location of the <see cref="IComponent" /> in the <see cref="IRenderModel" />.</param>
    /// <param name="mouseButton">The current mouse button that changed.</param>
    public RenderMouseEventArgs(IComponent? component, Location componentLocation, MouseButtons mouseButton)
    {
        Component = component;
        ComponentLocation = componentLocation;
        MouseButton = mouseButton;
    }

    /// <summary>
    ///     The <see cref="IComponent" />.
    /// </summary>
    public IComponent? Component { get; }

    /// <summary>
    ///     The location of the <see cref="Component" /> in the <see cref="IRenderModel" />.
    /// </summary>
    public Location ComponentLocation { get; }

    /// <summary>
    ///     The current mouse button that changed.
    /// </summary>
    public MouseButtons MouseButton { get; }
}