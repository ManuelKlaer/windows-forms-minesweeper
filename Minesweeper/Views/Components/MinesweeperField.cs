using Minesweeper.Controllers;
using Minesweeper.Utils.Helpers;
using Minesweeper.Views.Base;
using State = Minesweeper.Enums.MinesweeperFieldEnums.State;

// ReSharper disable MemberCanBePrivate.Global

namespace Minesweeper.Views.Components;

public class MinesweeperField : Button
{
    /// <summary>
    ///     Initialize a new <see cref="MinesweeperField" />.
    /// </summary>
    public MinesweeperField()
    {
        TextFormat.LineAlignment = StringAlignment.Center;
        TextFormat.Alignment = StringAlignment.Center;
        TextFormat.FormatFlags = StringFormatFlags.NoClip;
    }

    public State FieldState { get; private set; } = State.Hidden;

    public bool IsMine { get; set; }

    public int MineCount { get; set; }

    /// <summary>
    ///     Toggle this field between the states <see cref="State.Flag" /> and <see cref="State.Hidden" />.
    /// </summary>
    public void ToggleFlag()
    {
        if (FieldState == State.Hidden) FieldState = State.Flag;
        else if (FieldState == State.Flag) FieldState = State.Hidden;
    }

    /// <summary>
    ///     Toggle this field between the states <see cref="State.Question" /> and <see cref="State.Hidden" />.
    /// </summary>
    public void ToggleQuestion()
    {
        if (FieldState == State.Hidden) FieldState = State.Question;
        else if (FieldState == State.Question) FieldState = State.Hidden;
    }

    /// <summary>
    ///     Reveals this field. Sets the state to <see cref="State.Visible" /> or <see cref="State.Mine" />.
    /// </summary>
    public void Reveal()
    {
        if (FieldState == State.Hidden) FieldState = IsMine ? State.Mine : State.Visible;
    }

    /// <summary>
    ///     Reveals this field as a tip. Sets the state to <see cref="State.Tip" /> if this <see cref="MinesweeperField"/> is a mine.
    /// </summary>
    public void RevealAsTip()
    {
        if (FieldState == State.Hidden && IsMine) FieldState = State.Tip;
    }

    public override void Update(RenderBase parent, Point location)
    {
        if (FieldState == State.Hidden)
        {
            Text = "";
            BackColor = Properties.Settings.Default.AccentColor;
            ForeColor = UtilsClass.BlackOrWhite(Properties.Settings.Default.AccentColor);
            HoverColor = UtilsClass.ChangeColorBrightness2(BackColor, 0.05f);
            PressedColor = UtilsClass.ChangeColorBrightness2(BackColor, 0.1f);
        }
        else if (FieldState == State.Flag)
        {
            Text = LanguageController.CurrentLanguageResource.EmojiFlag;
            BackColor = UtilsClass.ChangeColorBrightness2(Properties.Settings.Default.AccentColor, 0.1f);
            ForeColor = UtilsClass.BlackOrWhite(BackColor);
            HoverColor = UtilsClass.ChangeColorBrightness2(BackColor, 0.05f);
            PressedColor = UtilsClass.ChangeColorBrightness2(BackColor, 0.1f);
        }
        else if (FieldState == State.Question)
        {
            Text = LanguageController.CurrentLanguageResource.EmojiQuestion;
            BackColor = UtilsClass.ChangeColorBrightness2(Properties.Settings.Default.AccentColor, 0.1f);
            ForeColor = UtilsClass.BlackOrWhite(BackColor);
            HoverColor = UtilsClass.ChangeColorBrightness2(BackColor, 0.05f);
            PressedColor = UtilsClass.ChangeColorBrightness2(BackColor, 0.1f);
        }
        else if (FieldState == State.Mine)
        {
            Text = LanguageController.CurrentLanguageResource.EmojiBomb;
            BackColor = Color.FromArgb(204, 0, 0);
            ForeColor = UtilsClass.BlackOrWhite(BackColor);
            HoverColor = UtilsClass.ChangeColorBrightness2(BackColor, 0.05f);
            PressedColor = UtilsClass.ChangeColorBrightness2(BackColor, 0.1f);
        }
        else if (FieldState == State.Tip)
        {
            Text = LanguageController.CurrentLanguageResource.EmojiBomb;
            BackColor = Properties.Settings.Default.AccentColor;
            ForeColor = UtilsClass.ChangeColorBrightness2(Properties.Settings.Default.AccentColor, 0.2f);
            HoverColor = UtilsClass.ChangeColorBrightness2(BackColor, 0.05f);
            PressedColor = UtilsClass.ChangeColorBrightness2(BackColor, 0.1f);
        }
        else if (FieldState == State.Visible)
        {
            Text = MineCount <= 0 ? "" : MineCount.ToString();
            BackColor = (location.X + location.Y) % 2 == 0 ? Properties.Settings.Default.BackgroundColor : UtilsClass.ChangeColorBrightness2(Properties.Settings.Default.BackgroundColor, 0.02f);
            ForeColor = UtilsClass.BlackOrWhite(BackColor);
            HoverColor = UtilsClass.ChangeColorBrightness2(Properties.Settings.Default.BackgroundColor, 0.05f);
            PressedColor = UtilsClass.ChangeColorBrightness2(Properties.Settings.Default.BackgroundColor, 0.1f);
        }

        base.Update(parent, location);
    }

    public override void Paint(Rectangle clientRectangle, Graphics graphics)
    {
        Font = new Font("Segoe UI Emoji", Math.Max(12, Math.Min(clientRectangle.Width - 10, clientRectangle.Height - 26)), GraphicsUnit.Pixel);
        base.Paint(clientRectangle, graphics);
    }
}
