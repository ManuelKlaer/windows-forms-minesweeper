using Minesweeper.Controllers;
using Minesweeper.Enums;
using Minesweeper.Utils.Helpers;
using Minesweeper.Views.Base;

// ReSharper disable MemberCanBePrivate.Global

namespace Minesweeper.Views.Components;

/// <summary>
///     The Minesweeper field.
/// </summary>
public class MinesweeperField : Button
{
    /// <summary>
    ///     Initialize a new instance of <see cref="MinesweeperField" />.
    /// </summary>
    public MinesweeperField()
    {
        TextFormat.LineAlignment = StringAlignment.Center;
        TextFormat.Alignment = StringAlignment.Center;
        TextFormat.FormatFlags = StringFormatFlags.NoClip;
    }

    /// <summary>
    ///     The current state of this <see cref="MinesweeperField" />.
    /// </summary>
    public MinesweeperFieldEnums.State FieldState { get; private set; } = MinesweeperFieldEnums.State.Hidden;

    /// <summary>
    ///     Whether this <see cref="MinesweeperField" /> is a mine.
    /// </summary>
    public bool IsMine { get; set; }

    /// <summary>
    ///     The number of mines around this <see cref="MinesweeperField" />.
    /// </summary>
    public int MineCount { get; set; }

    /// <summary>
    ///     Toggle this field between the states <see cref="MinesweeperFieldEnums.State.Flag" /> and
    ///     <see cref="MinesweeperFieldEnums.State.Hidden" />.
    /// </summary>
    public void ToggleFlag()
    {
        if (FieldState == MinesweeperFieldEnums.State.Hidden) FieldState = MinesweeperFieldEnums.State.Flag;
        else if (FieldState == MinesweeperFieldEnums.State.Flag) FieldState = MinesweeperFieldEnums.State.Hidden;
    }

    /// <summary>
    ///     Toggle this field between the states <see cref="MinesweeperFieldEnums.State.Question" /> and
    ///     <see cref="MinesweeperFieldEnums.State.Hidden" />.
    /// </summary>
    public void ToggleQuestion()
    {
        if (FieldState == MinesweeperFieldEnums.State.Hidden) FieldState = MinesweeperFieldEnums.State.Question;
        else if (FieldState == MinesweeperFieldEnums.State.Question) FieldState = MinesweeperFieldEnums.State.Hidden;
    }

    /// <summary>
    ///     Reveals this field. Sets the state to <see cref="MinesweeperFieldEnums.State.Visible" /> or
    ///     <see cref="MinesweeperFieldEnums.State.Mine" />.
    /// </summary>
    public void Reveal()
    {
        if (FieldState == MinesweeperFieldEnums.State.Hidden)
            FieldState = IsMine ? MinesweeperFieldEnums.State.Mine : MinesweeperFieldEnums.State.Visible;
    }

    /// <summary>
    ///     Reveals this field as a tip. Sets the state to <see cref="MinesweeperFieldEnums.State.Tip" /> if this
    ///     <see cref="MinesweeperField" /> is a mine.
    /// </summary>
    public void RevealAsTip()
    {
        if (FieldState == MinesweeperFieldEnums.State.Hidden && IsMine) FieldState = MinesweeperFieldEnums.State.Tip;
    }

    /// <inheritdoc cref="Button.Update" />
    public override void Update(RenderBase parent, Point location)
    {
        // Change colors depending on the current field state.
        if (FieldState == MinesweeperFieldEnums.State.Hidden)
        {
            Text = "";
            BackColor = Properties.Settings.Default.AccentColor;
            ForeColor = UtilsClass.BlackOrWhite(Properties.Settings.Default.AccentColor);
            HoverColor = UtilsClass.ChangeColorBrightness2(BackColor, 0.05f);
            PressedColor = UtilsClass.ChangeColorBrightness2(BackColor, 0.1f);
        }
        else if (FieldState == MinesweeperFieldEnums.State.Flag)
        {
            Text = LanguageController.CurrentLanguageResource.EmojiFlag;
            BackColor = UtilsClass.ChangeColorBrightness2(Properties.Settings.Default.AccentColor, 0.1f);
            ForeColor = UtilsClass.BlackOrWhite(BackColor);
            HoverColor = UtilsClass.ChangeColorBrightness2(BackColor, 0.05f);
            PressedColor = UtilsClass.ChangeColorBrightness2(BackColor, 0.1f);
        }
        else if (FieldState == MinesweeperFieldEnums.State.Question)
        {
            Text = LanguageController.CurrentLanguageResource.EmojiQuestion;
            BackColor = UtilsClass.ChangeColorBrightness2(Properties.Settings.Default.AccentColor, 0.1f);
            ForeColor = UtilsClass.BlackOrWhite(BackColor);
            HoverColor = UtilsClass.ChangeColorBrightness2(BackColor, 0.05f);
            PressedColor = UtilsClass.ChangeColorBrightness2(BackColor, 0.1f);
        }
        else if (FieldState == MinesweeperFieldEnums.State.Mine)
        {
            Text = LanguageController.CurrentLanguageResource.EmojiBomb;
            BackColor = Color.FromArgb(204, 0, 0);
            ForeColor = UtilsClass.BlackOrWhite(BackColor);
            HoverColor = UtilsClass.ChangeColorBrightness2(BackColor, 0.05f);
            PressedColor = UtilsClass.ChangeColorBrightness2(BackColor, 0.1f);
        }
        else if (FieldState == MinesweeperFieldEnums.State.Tip)
        {
            Text = LanguageController.CurrentLanguageResource.EmojiBomb;
            BackColor = Properties.Settings.Default.AccentColor;
            ForeColor = UtilsClass.ChangeColorBrightness2(Properties.Settings.Default.AccentColor, 0.2f);
            HoverColor = UtilsClass.ChangeColorBrightness2(BackColor, 0.05f);
            PressedColor = UtilsClass.ChangeColorBrightness2(BackColor, 0.1f);
        }
        else if (FieldState == MinesweeperFieldEnums.State.Visible)
        {
            Text = MineCount <= 0 ? "" : MineCount.ToString();
            BackColor = (location.X + location.Y) % 2 == 0 ? Properties.Settings.Default.BackgroundColor : UtilsClass.ChangeColorBrightness2(Properties.Settings.Default.BackgroundColor, 0.02f);
            ForeColor = UtilsClass.BlackOrWhite(BackColor);
            HoverColor = UtilsClass.ChangeColorBrightness2(Properties.Settings.Default.BackgroundColor, 0.05f);
            PressedColor = UtilsClass.ChangeColorBrightness2(Properties.Settings.Default.BackgroundColor, 0.1f);
        }

        base.Update(parent, location);
    }

    /// <inheritdoc cref="Button.Paint" />
    public override void Paint(Rectangle clientRectangle, Graphics graphics)
    {
        // Update the font to dynamically scale the text size
        Font = new Font("Segoe UI Emoji",
            Math.Max(12, Math.Min(clientRectangle.Width - 10, clientRectangle.Height - 26)), GraphicsUnit.Pixel);

        // Draw this component
        base.Paint(clientRectangle, graphics);
    }
}