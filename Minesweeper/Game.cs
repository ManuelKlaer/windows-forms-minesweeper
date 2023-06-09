﻿using System.ComponentModel;
using Minesweeper.Controllers;
using Minesweeper.Controllers.CustomEventArgs;
using Minesweeper.Enums;
using Minesweeper.Properties;
using Minesweeper.Utils.Helpers;

namespace Minesweeper;

/// <summary>
///     The main game window.
/// </summary>
public partial class Minesweeper : Form
{
    // Current game board controller
    private readonly MinesweeperBoardController _gameBoard = new();

    // Currently selected preset
    private string _currentGamePreset = "Mini";

    /// <summary>
    ///     Initialize the form window.
    /// </summary>
    public Minesweeper()
    {
        InitializeComponent();

        // Hide save and load from the menu strip because there currently not implemented
        menuStrip_Game_Load.Enabled = false;
        menuStrip_Game.DropDownItems.RemoveAt(2); // Remove load
        menuStrip_Game_Save.Enabled = false;
        menuStrip_Game.DropDownItems.RemoveAt(1); // Remove save

        // Setup keyboard shortcuts because the designer doesn't register them correctly
        menuStrip_Game_New.ShortcutKeys = Keys.Control | Keys.N;
        menuStrip_Game_Save.ShortcutKeys = Keys.Control | Keys.S;
        menuStrip_Game_Load.ShortcutKeys = Keys.Control | Keys.L;
        menuStrip_Game_Settings.ShortcutKeys = Keys.Control | Keys.I;
        menuStrip_Game_Exit.ShortcutKeys = Keys.Control | Keys.Q;
        menuStrip_Statistics.ShortcutKeys = Keys.Control | Keys.Alt | Keys.S;
        menuStrip_Help_Tutorial.ShortcutKeys = Keys.F1;
        menuStrip_Help_About.ShortcutKeys = Keys.Control | Keys.Alt | Keys.A;

        // Setup the game board
        _gameBoard.ComponentUpdated += GameBoardComponentUpdated;
        _gameBoard.GameFinished += GameBoardGameFinished;
        _gameBoard.GameStateChanged += GameBoardGameStateChanged;
        GameBoardGameStateChanged(this, EventArgs.Empty); // Update it once to set the default icon

        TimerUpdateGameTimeTick(this, EventArgs.Empty); // Update the timer once to set the default value

        // Initialize settings
        Properties.Settings.Default.PropertyChanged += SettingsChanged;
        SettingsChanged(this, new PropertyChangedEventArgs("None")); // Apply current settings

        // Initialize language
        LanguageController.LanguageChanged += LanguageChanged;
        LanguageChanged(null, EventArgs.Empty); // Apply current language
    }

    /// <summary>
    ///     Event that gets called when the window has finished loading.
    /// </summary>
    private void Minesweeper_Load(object sender, EventArgs e)
    {
        // Generate default game board base on the user settings
        switch (Properties.Settings.Default.DefaultPreset)
        {
            case 0:
                MenuStripGameNewMiniClick(this, EventArgs.Empty);
                break;

            case 1:
                MenuStripGameNewBeginnerClick(this, EventArgs.Empty);
                break;

            case 2:
                MenuStripGameNewIntermediateClick(this, EventArgs.Empty);
                break;

            case 3:
                MenuStripGameNewExpertClick(this, EventArgs.Empty);
                break;
        }
    }

    /// <summary>
    ///     Event that gets called when the windows looses focus.
    /// </summary>
    private void Minesweeper_Deactivated(object? sender, EventArgs e)
    {
        // Pause the currently running game
        if (_gameBoard.CurrentGameState == MinesweeperGameEnums.GameState.Running) _gameBoard.PauseGame();
    }

    /// <summary>
    ///     Event that gets called when this windows is opened.
    /// </summary>
    private void Minesweeper_Shown(object sender, EventArgs e)
    {
        // Show welcome dialog if it's the first start
        if (!Properties.Settings.Default.ShowedWelcomeDialog)
        {
            Welcome welcome = new();
            welcome.ShowDialog();

            // Show the tutorial if the tutorial button was pressed
            if (welcome.DialogResult == DialogResult.Continue) MenuStripHelpTutorialClick(this, EventArgs.Empty);

            Properties.Settings.Default.ShowedWelcomeDialog = true;
            Properties.Settings.Default.Save();
        }
    }

    /// <summary>
    ///     Create a new minesweeper game board.
    /// </summary>
    /// <param name="size">The size of the game board.</param>
    /// <param name="mines">The number of hidden mines on the board.</param>
    /// <param name="hints">The max number of usable hints.</param>
    /// <param name="gamePresetName">The name of the preset that was used.</param>
    private void NewGameBoard(Size size, int mines, int hints, string gamePresetName)
    {
        // Show a confirm dialog if a game is still running
        if (_gameBoard.CurrentGameState != MinesweeperGameEnums.GameState.Stopped)
        {
            if (_gameBoard.CurrentGameState == MinesweeperGameEnums.GameState.Running) _gameBoard.PauseGame();
            DialogResult res = MessageBox.Show(LanguageController.CurrentLanguageResource.AppConfirmNewGameText, LanguageController.CurrentLanguageResource.AppConfirmNewGameTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.No) return;
        }

        // Update the preset name
        _currentGamePreset = gamePresetName;

        // Remove the currently used game board from the window
        mainTableLayout.SuspendLayout();
        if (_gameBoard.View != null) mainTableLayout.Controls.Remove(_gameBoard.View);

        // Create a new game board
        _gameBoard.NewBoard(size, mines, hints);
        if (_gameBoard.View == null) return;

        // Add the game board to the window
        mainTableLayout.Controls.Add(_gameBoard.View, 0, 1);
        mainTableLayout.ResumeLayout();

        // Update the timer to reset it
        TimerUpdateGameTimeTick(this, EventArgs.Empty);
    }

    /// <summary>
    ///     Event that gets called when something changed on the game board.
    /// </summary>
    private void GameBoardComponentUpdated(object? sender, EventArgs e)
    {
        // Update flag counter
        gameOverview_RemainingMines.Text = string.Format(LanguageController.CurrentLanguageResource.AppProgressTextEmoji, LanguageController.CurrentLanguageResource.EmojiBomb, _gameBoard.CurrentFlagCount, _gameBoard.MineCount);

        // Update hint counter
        gameOverview_Hints.Text = string.Format(LanguageController.CurrentLanguageResource.AppTextEmoji, LanguageController.CurrentLanguageResource.EmojiLightBulb, _gameBoard.HintCount - _gameBoard.UsedHintCount);
    }

    /// <summary>
    ///     Event that gets called when the game controller reports that the game has ended.
    /// </summary>
    private void GameBoardGameFinished(object? sender, GameFinishedEventArgs e)
    {
        // Get current game time
        TimeSpan gameTime = _gameBoard.GetCurrentGameTime();

        // Update and save statistics
        StatisticPerType statistics = new(_currentGamePreset, Properties.Statistics.Default);

        if (e.WonLostState == MinesweeperGameEnums.GameWonLost.Won) statistics.GamesWon += 1;
        if (e.WonLostState == MinesweeperGameEnums.GameWonLost.Lost) statistics.GamesLost += 1;
        statistics.TotalMines += _gameBoard.MineCount;
        statistics.TotalTime = statistics.TotalTime.Add(gameTime);
        if ((statistics.ShortTime > gameTime || statistics.ShortTime.Nanoseconds <= 0) && e.WonLostState == MinesweeperGameEnums.GameWonLost.Won) statistics.ShortTime = gameTime;

        Properties.Statistics.Default.Save();

        // Show end result dialog
        EndResult endResult = new();
        string victory = string.Format(LanguageController.CurrentLanguageResource.AppTextEmoji, LanguageController.CurrentLanguageResource.EmojiPartyPopper, LanguageController.CurrentLanguageResource.GameWon);
        string defeat = string.Format(LanguageController.CurrentLanguageResource.AppTextEmoji, LanguageController.CurrentLanguageResource.EmojiSwords, LanguageController.CurrentLanguageResource.GameLost);
        endResult.titleLabel.Text = e.WonLostState == MinesweeperGameEnums.GameWonLost.Won ? victory : defeat;
        endResult.timerLabel.Text = string.Format(LanguageController.CurrentLanguageResource.AppTextEmoji, LanguageController.CurrentLanguageResource.EmojiClock, UtilsClass.FormatTimeSpan(gameTime));
        endResult.hintsLabel.Text = string.Format(LanguageController.CurrentLanguageResource.AppTextEmoji, LanguageController.CurrentLanguageResource.EmojiLightBulb, _gameBoard.UsedHintCount);
        endResult.ShowDialog();

        // Create a new empty game board to skip the dialog message
        _gameBoard.NewBoard(new Size(1, 1), 0, 0);

        // Create a new game board using the previous preset size
        switch (_currentGamePreset)
        {
            case "Mini":
                MenuStripGameNewMiniClick(this, EventArgs.Empty);
                break;
            case "Beginner":
                MenuStripGameNewBeginnerClick(this, EventArgs.Empty);
                break;
            case "Intermediate":
                MenuStripGameNewIntermediateClick(this, EventArgs.Empty);
                break;
            case "Expert":
                MenuStripGameNewExpertClick(this, EventArgs.Empty);
                break;
            case "Custom":
                MenuStripGameNewCustomClick(this, EventArgs.Empty);
                break;
        }
    }

    /// <summary>
    ///     Event that gets called when the game state changes.
    /// </summary>
    private void GameBoardGameStateChanged(object? sender, EventArgs e)
    {
        // Change the icon based on the current state
        if (_gameBoard.CurrentGameState == MinesweeperGameEnums.GameState.Stopped)
            gameOverview_ResumePause.Text = LanguageController.CurrentLanguageResource.EmojiStop;
        if (_gameBoard.CurrentGameState == MinesweeperGameEnums.GameState.Paused)
            gameOverview_ResumePause.Text = LanguageController.CurrentLanguageResource.EmojiPlay;
        if (_gameBoard.CurrentGameState == MinesweeperGameEnums.GameState.Running)
            gameOverview_ResumePause.Text = LanguageController.CurrentLanguageResource.EmojiPause;
    }

    /// <summary>
    ///     Event that gets called when the timer executes an update.
    /// </summary>
    private void TimerUpdateGameTimeTick(object sender, EventArgs e)
    {
        gameOverview_Timer.Text = string.Format(LanguageController.CurrentLanguageResource.AppTextEmoji, LanguageController.CurrentLanguageResource.EmojiClock, UtilsClass.FormatTimeSpan(_gameBoard.GetCurrentGameTime()));
    }

    /// <summary>
    ///     Event that gets called when this windows is closing.
    /// </summary>
    private void MinesweeperFormClosing(object sender, FormClosingEventArgs e)
    {
        // If the user closes this window and a game is currently running
        if (e.CloseReason == CloseReason.UserClosing &&
            _gameBoard.CurrentGameState != MinesweeperGameEnums.GameState.Stopped)
        {
            // Pause the currently running game
            if (_gameBoard.CurrentGameState == MinesweeperGameEnums.GameState.Running) _gameBoard.PauseGame();

            // Ask the user if they really want to quit
            DialogResult res = MessageBox.Show(LanguageController.CurrentLanguageResource.AppConfirmExitText, LanguageController.CurrentLanguageResource.AppConfirmExitTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.No) e.Cancel = true;
        }
    }

    /// <summary>
    ///     Event that gets called when a setting changed.
    /// </summary>
    private void SettingsChanged(object? sender, PropertyChangedEventArgs e)
    {
        // Apply colors
        _gameBoard.View?.UpdateComponents();
        _gameBoard.View?.Invalidate();

        BackColor = Properties.Settings.Default.BackgroundColor;
        ForeColor = UtilsClass.BlackOrWhite(BackColor);

        menuStrip.BackColor = BackColor;
        menuStrip.ForeColor = ForeColor;
    }

    /// <summary>
    ///     Event that gets called when the language changed.
    /// </summary>
    private void LanguageChanged(object? sender, EventArgs e)
    {
        Text = LanguageController.CurrentLanguageResource.AppTitle;

        // MenuStrip
        menuStrip_Game.Text = LanguageController.CurrentLanguageResource.MenuGame;
        menuStrip_Statistics.Text = LanguageController.CurrentLanguageResource.MenuStatistics;
        menuStrip_Help.Text = LanguageController.CurrentLanguageResource.MenuHelp;

        menuStrip_Game_New.Text = LanguageController.CurrentLanguageResource.MenuNew;
        menuStrip_Game_Save.Text = LanguageController.CurrentLanguageResource.MenuSave;
        menuStrip_Game_Load.Text = LanguageController.CurrentLanguageResource.MenuLoad;
        menuStrip_Game_Settings.Text = LanguageController.CurrentLanguageResource.MenuSettings;
        menuStrip_Game_Exit.Text = LanguageController.CurrentLanguageResource.MenuExit;

        menuStrip_Game_New_Mini.Text = LanguageController.CurrentLanguageResource.PresetMini;
        menuStrip_Game_New_Beginner.Text = LanguageController.CurrentLanguageResource.PresetBeginner;
        menuStrip_Game_New_Intermediate.Text = LanguageController.CurrentLanguageResource.PresetIntermediate;
        menuStrip_Game_New_Expert.Text = LanguageController.CurrentLanguageResource.PresetExpert;
        menuStrip_Game_New_Custom.Text = LanguageController.CurrentLanguageResource.PresetCustom;

        menuStrip_Help_Tutorial.Text = LanguageController.CurrentLanguageResource.MenuTutorial;
        menuStrip_Help_About.Text = LanguageController.CurrentLanguageResource.MenuAbout;

        // GameBoard
        _gameBoard.View?.UpdateComponents();
        _gameBoard.View?.Invalidate();

        GameBoardGameStateChanged(this, EventArgs.Empty); // Update play / pause symbols
        TimerUpdateGameTimeTick(this, EventArgs.Empty); // Update timer symbol
        GameBoardComponentUpdated(this, EventArgs.Empty); // Update flag counter and hints symbols
    }

    #region menuStrip

    /// <summary>
    ///     Event that gets called when MenuStripGameNewMini was clicked.
    /// </summary>
    private void MenuStripGameNewMiniClick(object sender, EventArgs e) => NewGameBoard(new Size(6, 6), 3, 1, "Mini");

    /// <summary>
    ///     Event that gets called when MenuStripGameNewBeginner was clicked.
    /// </summary>
    private void MenuStripGameNewBeginnerClick(object sender, EventArgs e) => NewGameBoard(new Size(9, 9), 10, 3, "Beginner");

    /// <summary>
    ///     Event that gets called when MenuStripGameNewIntermediate was clicked.
    /// </summary>
    private void MenuStripGameNewIntermediateClick(object sender, EventArgs e) => NewGameBoard(new Size(16, 16), 40, 9, "Intermediate");

    /// <summary>
    ///     Event that gets called when MenuStripGameNewExpert was clicked.
    /// </summary>
    private void MenuStripGameNewExpertClick(object sender, EventArgs e) => NewGameBoard(new Size(24, 24), 99, 18, "Expert");

    /// <summary>
    ///     Event that gets called when MenuStripGameNewCustom was clicked.
    /// </summary>
    private void MenuStripGameNewCustomClick(object sender, EventArgs e)
    {
        // Pause the game
        if (_gameBoard.CurrentGameState == MinesweeperGameEnums.GameState.Running) _gameBoard.PauseGame();

        // Show the custom game dialog
        CustomGame customGame = new();
        customGame.ShowDialog();

        // Create a new game board if the user confirmed
        if (customGame.DialogResult == DialogResult.OK)
            NewGameBoard(new Size((int)customGame.widthNumericUpDown.Value, (int)customGame.heightNumericUpDown.Value), (int)customGame.minesNumericUpDown.Value, (int)customGame.hintsNumericUpDown.Value, "Custom");
    }

    /// <summary>
    ///     Event that gets called when MenuStripGameSettings was clicked.
    /// </summary>
    private void MenuStripGameSettingsClick(object sender, EventArgs e)
    {
        // Pause the game
        if (_gameBoard.CurrentGameState == MinesweeperGameEnums.GameState.Running) _gameBoard.PauseGame();

        // Open settings dialog
        Settings settings = new();
        settings.ShowDialog();
    }

    /// <summary>
    ///     Event that gets called when MenuStripGameExit was clicked.
    /// </summary>
    private void MenuStripGameExitClick(object sender, EventArgs e) => Close();

    /// <summary>
    ///     Event that gets called when MenuStripStatistics was clicked.
    /// </summary>
    private void MenuStripStatisticsClick(object sender, EventArgs e)
    {
        // Pause the game
        if (_gameBoard.CurrentGameState == MinesweeperGameEnums.GameState.Running) _gameBoard.PauseGame();

        // Open statistics dialog.
        Statistics statistics = new();
        statistics.ShowDialog();
    }

    /// <summary>
    ///     Event that gets called when MenuStripHelpTutorial was clicked.
    /// </summary>
    private void MenuStripHelpTutorialClick(object sender, EventArgs e)
    {
        // Pause the game
        if (_gameBoard.CurrentGameState == MinesweeperGameEnums.GameState.Running) _gameBoard.PauseGame();

        // Open tutorial dialog
        Tutorial tutorial = new();
        tutorial.ShowDialog();
    }

    /// <summary>
    ///     Event that gets called when MenuStripHelpAbout was clicked.
    /// </summary>
    private void MenuStripHelpAboutClick(object sender, EventArgs e)
    {
        // Pause the game
        if (_gameBoard.CurrentGameState == MinesweeperGameEnums.GameState.Running) _gameBoard.PauseGame();

        // Show about dialog
        About about = new();
        about.ShowDialog();
    }

    #endregion

    #region gameOverview

    /// <summary>
    ///     Event that gets called when GameOverviewResumePause was clicked.
    /// </summary>
    private void GameOverviewResumePauseClick(object sender, EventArgs e)
    {
        // Switch game state
        if (_gameBoard.CurrentGameState == MinesweeperGameEnums.GameState.Paused) _gameBoard.ResumeGame();
        else if (_gameBoard.CurrentGameState == MinesweeperGameEnums.GameState.Running) _gameBoard.PauseGame();
    }

    /// <summary>
    ///     Event that gets called when GameOverviewHints was clicked.
    /// </summary>
    private void GameOverviewHintsClick(object sender, EventArgs e) => _gameBoard.RevealHint();

    #endregion
}