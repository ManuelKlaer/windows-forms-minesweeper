using Minesweeper.Utils.Helpers;
using Minesweeper.Utils.Position;
using Minesweeper.Models.Interfaces;
using Minesweeper.Views.CustomEventArgs;
using Minesweeper.Views.Interfaces;

// ReSharper disable VirtualMemberCallInConstructor
// ReSharper disable MemberCanBeProtected.Global
// ReSharper disable MemberCanBePrivate.Global

namespace Minesweeper.Views.Base;

public abstract class RenderBase : Control
{
    protected readonly IncludePrevious<SizeT<int>> ClientRectangleSize = new SizeT<int>(0, 0);
    protected readonly SizeT<double> ComponentSizePercent = new(0, 0);
    protected readonly SizeT<double> ComponentSize = new(0, 0);

    protected readonly IncludePrevious<Location> MouseHoverComponent = new Location(-1, -1);
    protected readonly Location MousePressComponent = new(-1, -1);

    protected Bitmap? Buffer;
    protected Graphics? Graphics;

    public event EventHandler<RenderMouseEventArgs>? ComponentMouseUp;

    protected RenderBase(IRenderModel model)
    {
        Model = model;

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

    public IRenderModel Model { get; protected set; }

    protected virtual void UpdateDimensions()
    {
        ClientRectangleSize.UpdatePrevious();
        ClientRectangleSize.Current.Set(ClientRectangle.Width, ClientRectangle.Height);
        ComponentSize.Set(ClientRectangleSize.Current.Width * ComponentSizePercent.Width, ClientRectangleSize.Current.Height * ComponentSizePercent.Height);
    }

    public void RevertComponentsColors()
    {
        for (int c = 0; c < Model.Columns; c++)
        {
            for (int r = 0; r < Model.Rows; r++)
            {
                IComponent? component = Model.Get(c, r);
                component?.RevertColors();
            }
        }
    }

    public void UpdateComponents()
    {
        for (int c = 0; c < Model.Columns; c++)
        {
            for (int r = 0; r < Model.Rows; r++)
            {
                IComponent? component = Model.Get(c, r);
                component?.Update(this, new Point(c, r));
            }
        }
    }

    public new void Dispose()  // ToDo: More thing to dispose
    {
        Buffer = null;
        Graphics = null;
        Model = null!;

        base.Dispose();
    }

    protected override void OnClientSizeChanged(EventArgs e)
    {
        UpdateDimensions();
        base.OnClientSizeChanged(e);
    }

    #region Mouse

    protected override void OnMouseMove(MouseEventArgs e)
    {
        MouseHoverComponent.UpdatePrevious();
        MouseHoverComponent.Current.X = (int)Math.Floor(e.X / ComponentSize.Width);
        MouseHoverComponent.Current.Y = (int)Math.Floor(e.Y / ComponentSize.Height);

        if (MouseHoverComponent.Current.X != MouseHoverComponent.Previous.X ||
            MouseHoverComponent.Current.Y != MouseHoverComponent.Previous.Y)
        {
            if (MouseHoverComponent.Previous is { X: >= 0, Y: >= 0 } && MouseHoverComponent.Previous.X < Model.Columns && MouseHoverComponent.Previous.Y < Model.Rows)
            {
                IComponent? cPrev = Model.Get(MouseHoverComponent.Previous.X, MouseHoverComponent.Previous.Y);
                cPrev?.OnMouseLeave(this, MouseHoverComponent.Previous);
            }

            if (MouseHoverComponent.Current is { X: >= 0, Y: >= 0 } && MouseHoverComponent.Current.X < Model.Columns && MouseHoverComponent.Current.Y < Model.Rows)
            {
                IComponent? cCur = Model.Get(MouseHoverComponent.Current.X, MouseHoverComponent.Current.Y);
                cCur?.OnMouseEnter(this, MouseHoverComponent.Current);
            }

            Invalidate();
        }

        base.OnMouseMove(e);
    }

    protected override void OnMouseLeave(EventArgs e)
    {
        MouseHoverComponent.UpdatePrevious();
        MouseHoverComponent.Current.X = -1;
        MouseHoverComponent.Current.Y = -1;

        if (MouseHoverComponent.Previous.X < 0 || MouseHoverComponent.Previous.Y < 0 || MouseHoverComponent.Previous.X >= Model.Columns || MouseHoverComponent.Previous.Y >= Model.Rows) return;

        IComponent? cPrev = Model.Get(MouseHoverComponent.Previous.X, MouseHoverComponent.Previous.Y);
        cPrev?.OnMouseLeave(this, MouseHoverComponent.Previous);

        base.OnMouseLeave(e);
        Invalidate();
    }

    protected override void OnMouseUp(MouseEventArgs e)
    {
        if (MousePressComponent.X < 0 || MousePressComponent.Y < 0 || MousePressComponent.X >= Model.Columns || MousePressComponent.Y >= Model.Rows) return;

        IComponent? cCur = Model.Get(MousePressComponent.X, MousePressComponent.Y);

        cCur?.OnMouseUp(this, MousePressComponent, e);
        ComponentMouseUp?.Invoke(this, new RenderMouseEventArgs(cCur, MousePressComponent, e.Button));

        MousePressComponent.X = -1;
        MousePressComponent.Y = -1;

        base.OnMouseUp(e);
        Invalidate();
    }

    protected override void OnMouseDown(MouseEventArgs e)
    {
        if (MouseHoverComponent.Current.X < 0 || MouseHoverComponent.Current.Y < 0 || MouseHoverComponent.Current.X >= Model.Columns || MouseHoverComponent.Current.Y >= Model.Rows) return;

        MousePressComponent.X = MouseHoverComponent.Current.X;
        MousePressComponent.Y = MouseHoverComponent.Current.Y;

        IComponent? cCur = Model.Get(MousePressComponent.X, MousePressComponent.Y);
        cCur?.OnMouseDown(this, MousePressComponent, e);

        base.OnMouseDown(e);
        Invalidate();
    }

    #endregion

    #region Paint

    protected override void OnPaint(PaintEventArgs e)
    {
        if (ClientRectangleSize.Current.Width != ClientRectangleSize.Previous.Width ||
            ClientRectangleSize.Current.Height != ClientRectangleSize.Previous.Height)
        {
            // Clean up
            Graphics?.Dispose();
            Buffer?.Dispose();

            // Create a graphics object for the buffer
            Buffer = new Bitmap(ClientRectangleSize.Current.Width, ClientRectangleSize.Current.Height);
            Graphics = Graphics.FromImage(Buffer);

            // ToDo: Create new fonts???

            ClientRectangleSize.UpdatePrevious();
        }

        if (Buffer == null || Graphics == null) return;

        UpdateComponents();

        // Background-Color
        Graphics.FillRectangle(new SolidBrush(BackColor), ClientRectangle);

        // Draw components
        Rectangle componentRectangle = new(0, 0, (int)Math.Ceiling(ComponentSize.Width), (int)Math.Ceiling(ComponentSize.Height));

        for (int col = 0; col < Model.Columns; col++)
        {
            for (int row = 0; row < Model.Rows; row++)
            {
                componentRectangle.X = (int)Math.Ceiling(col * ComponentSize.Width);
                componentRectangle.Y = (int)Math.Ceiling(row * ComponentSize.Height);

                IComponent? component = Model.Get(col, row);
                component?.Paint(componentRectangle, Graphics);
            }
        }

        // Render the buffer to the screen
        e.Graphics.DrawImageUnscaled(Buffer, 0, 0);

        base.OnPaint(e);
    }

    #endregion
}