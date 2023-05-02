using Minesweeper.Models.Interfaces;
using Minesweeper.Utils.Helpers;
using Minesweeper.Utils.Position;
using Minesweeper.Views.CustomEventArgs;
using Minesweeper.Views.Interfaces;

// ReSharper disable VirtualMemberCallInConstructor
// ReSharper disable MemberCanBeProtected.Global
// ReSharper disable MemberCanBePrivate.Global

namespace Minesweeper.Views.Base;

/// <summary>
///     A basic implementation of a grid based custom renderer.
/// </summary>
public abstract class RenderBase : Control
{
    // Current and the previous client rectangle size
    protected readonly IncludePrevious<SizeT<int>> ClientRectangleSize = new SizeT<int>(0, 0);

    // Current component size calculated (percent * client size)
    protected readonly SizeT<double> ComponentSize = new(0, 0);

    // Current component size percent
    protected readonly SizeT<double> ComponentSizePercent = new(0, 0);

    // Current mouse hovered component location
    protected readonly IncludePrevious<Location> MouseHoverComponent = new Location(-1, -1);

    // Current mouse press component location
    protected readonly Location MousePressComponent = new(-1, -1);

    // Graphic bitmap buffer
    protected Bitmap? Buffer;
    protected Graphics? Graphics;

    /// <summary>
    ///     Initialize a new instance of <see cref="RenderBase" />.
    /// </summary>
    /// <param name="model">The <see cref="IRenderModel" /> that holds all components that should be drawn to the screen.</param>
    protected RenderBase(IRenderModel model)
    {
        Model = model;

        // Calculate component size percentage
        ComponentSizePercent.Set(1.0 / Model.Columns, 1.0 / Model.Rows);

        SetStyle(ControlStyles.AllPaintingInWmPaint, true);
        SetStyle(ControlStyles.UserPaint, true);
        SetStyle(ControlStyles.DoubleBuffer, true);
        SetStyle(ControlStyles.ResizeRedraw, true);

        UpdateDimensions();
        UpdateComponents();
        RevertComponentsColors();
        Invalidate();
    }

    /// <summary>
    ///     The <see cref="IRenderModel" /> that holds all components that should be drawn to screen.
    /// </summary>
    public IRenderModel Model { get; protected set; }

    /// <summary>
    ///     Event that gets called when the mouse button is released.
    /// </summary>
    public event EventHandler<RenderMouseEventArgs>? ComponentMouseUp;

    /// <summary>
    ///     Update client and component size rectangles.
    /// </summary>
    protected virtual void UpdateDimensions()
    {
        ClientRectangleSize.UpdatePrevious();
        ClientRectangleSize.Current.Set(ClientRectangle.Width, ClientRectangle.Height);
        ComponentSize.Set(ClientRectangleSize.Current.Width * ComponentSizePercent.Width, ClientRectangleSize.Current.Height * ComponentSizePercent.Height);
    }

    /// <summary>
    ///     Reset all components colors.
    /// </summary>
    public void RevertComponentsColors()
    {
        for (int c = 0; c < Model.Columns; c++)
            for (int r = 0; r < Model.Rows; r++)
            {
                IComponent? component = Model.Get(c, r);
                component?.RevertColors();
            }
    }

    /// <summary>
    ///     Update all components.
    /// </summary>
    public void UpdateComponents()
    {
        for (int c = 0; c < Model.Columns; c++)
            for (int r = 0; r < Model.Rows; r++)
            {
                IComponent? component = Model.Get(c, r);
                component?.Update(this, new Point(c, r));
            }
    }

    /// <summary>
    ///     Dispose / delete this object.
    /// </summary>
    public new void Dispose()
    {
        Buffer = null;
        Graphics = null;
        Model = null!;

        base.Dispose();
    }

    /// <summary>
    ///     Event that gets called when the client size changes.
    /// </summary>
    /// <param name="e"></param>
    protected override void OnClientSizeChanged(EventArgs e)
    {
        UpdateDimensions();
        base.OnClientSizeChanged(e);
    }

    #region Paint

    /// <summary>
    ///     Event that gets called when this component should be drawn.
    /// </summary>
    /// <param name="e"></param>
    protected override void OnPaint(PaintEventArgs e)
    {
        // If the client size changed, we need to recreate the buffer
        if (ClientRectangleSize.Current.Width != ClientRectangleSize.Previous.Width ||
            ClientRectangleSize.Current.Height != ClientRectangleSize.Previous.Height)
        {
            // Clean up
            Graphics?.Dispose();
            Buffer?.Dispose();

            // Create a graphics object for the buffer
            Buffer = new Bitmap(ClientRectangleSize.Current.Width, ClientRectangleSize.Current.Height);
            Graphics = Graphics.FromImage(Buffer);

            ClientRectangleSize.UpdatePrevious();
        }

        // If there's no buffer, we can't draw anything
        if (Buffer == null || Graphics == null) return;

        // Update all components
        UpdateComponents();

        // Fill in the Background-Color
        Graphics.FillRectangle(new SolidBrush(BackColor), ClientRectangle);

        // Draw all components
        Rectangle componentRectangle = new(0, 0, (int)Math.Ceiling(ComponentSize.Width),
            (int)Math.Ceiling(ComponentSize.Height));

        for (int col = 0; col < Model.Columns; col++)
            for (int row = 0; row < Model.Rows; row++)
            {
                componentRectangle.X = (int)Math.Ceiling(col * ComponentSize.Width);
                componentRectangle.Y = (int)Math.Ceiling(row * ComponentSize.Height);

                IComponent? component = Model.Get(col, row);
                component?.Paint(componentRectangle, Graphics);
            }

        // Render the buffer to the screen
        e.Graphics.DrawImageUnscaled(Buffer, 0, 0);

        base.OnPaint(e);
    }

    #endregion

    #region Mouse

    /// <summary>
    ///     Event that gets called when the mouse is moved.
    /// </summary>
    /// <param name="e"></param>
    protected override void OnMouseMove(MouseEventArgs e)
    {
        // Calculate current mouse hovering component position
        MouseHoverComponent.UpdatePrevious();
        MouseHoverComponent.Current.X = (int)Math.Floor(e.X / ComponentSize.Width);
        MouseHoverComponent.Current.Y = (int)Math.Floor(e.Y / ComponentSize.Height);

        // If the hovered component changed, we need to update all components with that have a state change
        if (MouseHoverComponent.Current.X != MouseHoverComponent.Previous.X ||
            MouseHoverComponent.Current.Y != MouseHoverComponent.Previous.Y)
        {
            if (MouseHoverComponent.Previous is { X: >= 0, Y: >= 0 } &&
                MouseHoverComponent.Previous.X < Model.Columns && MouseHoverComponent.Previous.Y < Model.Rows)
            {
                IComponent? cPrev = Model.Get(MouseHoverComponent.Previous.X, MouseHoverComponent.Previous.Y);
                cPrev?.OnMouseLeave(this, MouseHoverComponent.Previous);
            }

            if (MouseHoverComponent.Current is { X: >= 0, Y: >= 0 } && MouseHoverComponent.Current.X < Model.Columns &&
                MouseHoverComponent.Current.Y < Model.Rows)
            {
                IComponent? cCur = Model.Get(MouseHoverComponent.Current.X, MouseHoverComponent.Current.Y);
                cCur?.OnMouseEnter(this, MouseHoverComponent.Current);
            }

            // Redraw
            Invalidate();
        }

        base.OnMouseMove(e);
    }

    /// <summary>
    ///     Event that gets called when the mouse leaves this renderer.
    /// </summary>
    /// <param name="e"></param>
    protected override void OnMouseLeave(EventArgs e)
    {
        // Reset current mouse hovering component position.
        MouseHoverComponent.UpdatePrevious();
        MouseHoverComponent.Current.X = -1;
        MouseHoverComponent.Current.Y = -1;

        if (MouseHoverComponent.Previous.X < 0 || MouseHoverComponent.Previous.Y < 0 ||
            MouseHoverComponent.Previous.X >= Model.Columns || MouseHoverComponent.Previous.Y >= Model.Rows) return;

        // Inform the previous component about this change
        IComponent? cPrev = Model.Get(MouseHoverComponent.Previous.X, MouseHoverComponent.Previous.Y);
        cPrev?.OnMouseLeave(this, MouseHoverComponent.Previous);

        base.OnMouseLeave(e);

        // Redraw
        Invalidate();
    }

    /// <summary>
    ///     Event that gets called when a mouse button is released.
    /// </summary>
    /// <param name="e"></param>
    protected override void OnMouseUp(MouseEventArgs e)
    {
        if (MousePressComponent.X < 0 || MousePressComponent.Y < 0 || MousePressComponent.X >= Model.Columns ||
            MousePressComponent.Y >= Model.Rows) return;

        // Inform the component about this change
        IComponent? cCur = Model.Get(MousePressComponent.X, MousePressComponent.Y);
        cCur?.OnMouseUp(this, MousePressComponent, e);

        // Invoke the component mouse up event handler
        ComponentMouseUp?.Invoke(this, new RenderMouseEventArgs(cCur, MousePressComponent, e.Button));

        // Reset mouse pressed component.
        MousePressComponent.X = -1;
        MousePressComponent.Y = -1;

        base.OnMouseUp(e);

        // Redraw
        Invalidate();
    }

    /// <summary>
    ///     Event that gets called when a mouse button is pressed.
    /// </summary>
    /// <param name="e"></param>
    protected override void OnMouseDown(MouseEventArgs e)
    {
        if (MouseHoverComponent.Current.X < 0 || MouseHoverComponent.Current.Y < 0 ||
            MouseHoverComponent.Current.X >= Model.Columns || MouseHoverComponent.Current.Y >= Model.Rows) return;

        // Update current mouse pressed component.
        MousePressComponent.X = MouseHoverComponent.Current.X;
        MousePressComponent.Y = MouseHoverComponent.Current.Y;

        // Inform the component about this change
        IComponent? cCur = Model.Get(MousePressComponent.X, MousePressComponent.Y);
        cCur?.OnMouseDown(this, MousePressComponent, e);

        base.OnMouseDown(e);

        // Redraw
        Invalidate();
    }

    #endregion
}