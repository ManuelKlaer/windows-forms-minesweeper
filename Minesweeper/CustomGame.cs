using System.ComponentModel;
using Minesweeper.Controllers;
using Minesweeper.Utils.Helpers;

namespace Minesweeper;

/// <summary>
///     Custom game dialog.
/// </summary>
public partial class CustomGame : Form
{
    /// <summary>
    ///     Initialize a new instance of <see cref="CustomGame" />.
    /// </summary>
    public CustomGame()
    {
        InitializeComponent();

        UpdateMinMax(); // Apply current min and max settings

        // Initialize Settings
        Properties.Settings.Default.PropertyChanged += SettingsChanged;
        SettingsChanged(this, new PropertyChangedEventArgs("None")); // Apply current settings

        // Initialize language
        LanguageController.LanguageChanged += LanguageChanged;
        LanguageChanged(null, EventArgs.Empty); // Apply current language
    }

    /// <summary>
    ///     Update min and max values.
    /// </summary>
    private void UpdateMinMax()
    {
        minesNumericUpDown.Maximum = (int)Math.Ceiling((double)widthNumericUpDown.Value * (double)heightNumericUpDown.Value * 0.2);
        hintsNumericUpDown.Maximum = (int)Math.Ceiling((double)minesNumericUpDown.Value * 0.3);
    }

    /// <summary>
    ///     Event that gets called when the value if WidthNumericUpDown changed.
    /// </summary>
    private void WidthNumericUpDownValueChanged(object sender, EventArgs e) => UpdateMinMax();

    /// <summary>
    ///     Event that gets called when the value if HeightNumericUpDown changed.
    /// </summary>
    private void HeightNumericUpDownValueChanged(object sender, EventArgs e) => UpdateMinMax();

    /// <summary>
    ///     Event that gets called when the value if MinesNumericUpDown changed.
    /// </summary>
    private void MinesNumericUpDownValueChanged(object sender, EventArgs e) => UpdateMinMax();

    /// <summary>
    ///     Event that gets called when a setting changed.
    /// </summary>
    private void SettingsChanged(object? sender, PropertyChangedEventArgs e)
    {
        // Apply colors
        BackColor = Properties.Settings.Default.BackgroundColor;
        ForeColor = UtilsClass.BlackOrWhite(BackColor);

        widthNumericUpDown.BackColor = BackColor;
        widthNumericUpDown.ForeColor = ForeColor;

        heightNumericUpDown.BackColor = BackColor;
        heightNumericUpDown.ForeColor = ForeColor;

        minesNumericUpDown.BackColor = BackColor;
        minesNumericUpDown.ForeColor = ForeColor;

        hintsNumericUpDown.BackColor = BackColor;
        hintsNumericUpDown.ForeColor = ForeColor;

        okButton.FlatAppearance.BorderColor = UtilsClass.ChangeColorBrightness2(BackColor, 0.1f);
    }

    /// <summary>
    ///     Event that gets called when the language changed.
    /// </summary>
    private void LanguageChanged(object? sender, EventArgs e)
    {
        Text = LanguageController.CurrentLanguageResource.AppTitleCustomGame;
        widthLabel.Text = LanguageController.CurrentLanguageResource.CustomWidth;
        heightLabel.Text = LanguageController.CurrentLanguageResource.CustomHeight;
        minesLabel.Text = LanguageController.CurrentLanguageResource.CustomMines;
        hintsLabel.Text = LanguageController.CurrentLanguageResource.CustomHints;
        okButton.Text = LanguageController.CurrentLanguageResource.AppConfirmButton;
    }
}