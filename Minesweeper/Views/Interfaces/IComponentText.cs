namespace Minesweeper.Views.Interfaces;

public interface IComponentText : IComponent
{
    public string Text { get; set; }

    public Font Font { get; set; }

    public StringFormat TextFormat { get; set; }

    public Color ForeColor { get; set; }
}