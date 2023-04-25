using Minesweeper.Utils.Position;
using Minesweeper.Views.Interfaces;

namespace Minesweeper.Views.CustomEventArgs;

public class RenderMouseEventArgs : EventArgs
{
    public RenderMouseEventArgs(IComponent? component, Location componentLocation, MouseButtons mouseButton)
    {
        Component = component;
        ComponentLocation = componentLocation;
        MouseButton = mouseButton;
    }

    public IComponent? Component { get; }

    public Location ComponentLocation { get; }

    public MouseButtons MouseButton { get; }
}