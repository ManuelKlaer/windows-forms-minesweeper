using Minesweeper.Controllers.CustomEventArgs;
using Minesweeper.Enums;
using Minesweeper.Models;
using Minesweeper.Utils.Helpers;
using Minesweeper.Utils.Position;
using Minesweeper.Views;
using Minesweeper.Views.Components;
using Minesweeper.Views.CustomEventArgs;
using Minesweeper.Views.Interfaces;

// ReSharper disable MemberCanBePrivate.Global
#pragma warning disable IDE0051 // Remove unused private members
#pragma warning disable IDE0017 // Simplify object initialization
#pragma warning disable IDE0019 // Use pattern matching

namespace Minesweeper.Controllers;

/// <summary>
///     The main board controller that manages the game flow.
/// </summary>
public class MinesweeperBoardController
{
    // A DateTime object that stores the time when the game started.
    private DateTime _gameStartTime = DateTime.UtcNow;

    // A date time object that stores the time since the pause state is active.
    private DateTime _gamePauseStartTime = DateTime.UtcNow;

    // A TimeSpan List to store all pause durations. This is done to avoid any inaccuracy of the total game time.
    private List<TimeSpan> _gamePauseTimes = new();

    /// <summary>
    ///     The model that is used to store all MinesweeperField components.
    /// </summary>
    public GridModel? Model { get; private set; }

    /// <summary>
    ///     The view that is used to draw the game board.
    /// </summary>
    public GridView? View { get; private set; }

    /// <summary>
    ///     The current state of of the game.
    /// </summary>
    public MinesweeperGameEnums.GameState CurrentGameState { get; private set; } = MinesweeperGameEnums.GameState.Stopped;

    /// <summary>
    ///     The size of the game board.
    /// </summary>
    public Size BoardSize => new(Model?.Columns ?? 0, Model?.Rows ?? 0);

    /// <summary>
    ///     The total number of all mines.
    /// </summary>
    public int MineCount { get; private set; }

    /// <summary>
    ///     The total number of all hints.
    /// </summary>
    public int HintCount { get; private set; }

    /// <summary>
    ///     The number of the already used hints.
    /// </summary>
    public int UsedHintCount { get; private set; }

    /// <summary>
    ///     The number of the currently placed flags.
    /// </summary>
    public int CurrentFlagCount { get; private set; }

    /// <summary>
    ///     Event that gets called when the game board is redrawn.
    /// </summary>
    public event EventHandler? ComponentUpdated;

    /// <summary>
    ///     Event that gets called when the game state changed.
    /// </summary>
    public event EventHandler? GameStateChanged;

    /// <summary>
    ///     Event that gets called when a game ended.
    /// </summary>
    public event EventHandler<GameFinishedEventArgs>? GameFinished;

    /// <summary>
    ///     Create a new game board.
    /// </summary>
    /// <param name="boardSize">The board size.</param>
    /// <param name="mines">Total number of hidden mines to find.</param>
    /// <param name="hints">Total number of hints the player can use.</param>
    public void NewBoard(Size boardSize, int mines, int hints)
    {
        // Reset current game time
        _gameStartTime = DateTime.UtcNow;
        _gamePauseStartTime = DateTime.UtcNow;
        _gamePauseTimes = new List<TimeSpan>();

        // Reset game state
        CurrentGameState = MinesweeperGameEnums.GameState.Stopped;
        GameStateChanged?.Invoke(this, EventArgs.Empty);

        MineCount = mines;
        HintCount = hints;
        UsedHintCount = 0;

        // Cleanup old board
        View?.Dispose();

        // Create a new model to store the information
        Model = new GridModel(boardSize.Width, boardSize.Height);
        InitializeMinesweeperFields();

        // Create a new view to render the board
        View = new GridView(Model);

        View.Padding = new Padding(0);
        View.Margin = new Padding(0);
        View.MinimumSize = new Size(160, 160);
        View.AutoSize = true;
        View.Dock = DockStyle.Fill;

        View.ComponentMouseUp += ViewOnMouseRelease;

        // Reset flag counter
        CurrentFlagCount = 0;
        ComponentUpdated?.Invoke(this, EventArgs.Empty);
    }

    /// <summary>
    ///     Get the current game time.
    /// </summary>
    /// <returns>The current game time as a <see cref="TimeSpan" />.</returns>
    public TimeSpan GetCurrentGameTime()
    {
        // If the game is stopped, the timer should be zero
        if (CurrentGameState == MinesweeperGameEnums.GameState.Stopped) return TimeSpan.Zero;

        // Current game time without pauses
        TimeSpan gameTime = DateTime.UtcNow.Subtract(_gameStartTime);

        // Remove all times where the game was paused
        foreach (TimeSpan pauseTime in _gamePauseTimes)
            gameTime = gameTime.Subtract(pauseTime);

        // If the game is currently paused, remove the currently elapsed pause time
        if (CurrentGameState == MinesweeperGameEnums.GameState.Paused)
            gameTime = gameTime.Subtract(DateTime.UtcNow.Subtract(_gamePauseStartTime));

        return gameTime;
    }

    /// <summary>
    ///     Resume the game.
    /// </summary>
    /// <exception cref="InvalidOperationException">The game can't be resumed if it's currently not paused.</exception>
    public void ResumeGame()
    {
        if (CurrentGameState != MinesweeperGameEnums.GameState.Paused)
            throw new InvalidOperationException("The game can't be resumed if it's currently not paused.");

        // Calculate pause time and it to the history
        TimeSpan pauseDiff = DateTime.UtcNow.Subtract(_gamePauseStartTime);
        _gamePauseTimes.Add(pauseDiff);

        // Update the game state
        CurrentGameState = MinesweeperGameEnums.GameState.Running;
        GameStateChanged?.Invoke(this, EventArgs.Empty);
    }

    /// <summary>
    ///     Pause the game.
    /// </summary>
    /// <exception cref="InvalidOperationException">The game can't be paused if it's currently not running.</exception>
    public void PauseGame()
    {
        if (CurrentGameState != MinesweeperGameEnums.GameState.Running)
            throw new InvalidOperationException("The game can't be paused if it's currently not running.");

        // Save current time to calculate alter the pause time
        _gamePauseStartTime = DateTime.UtcNow;

        // Update the game state
        CurrentGameState = MinesweeperGameEnums.GameState.Paused;
        GameStateChanged?.Invoke(this, EventArgs.Empty);
    }

    /// <summary>
    ///     Check the current board to determine if the player lost or won.
    /// </summary>
    private void CheckWonLost()
    {
        if (Model == null) return; // No board was yet created

        if (IsMineVisible()) // Game over
        {
            // Reveal all bombs
            IEnumerable<MinesweeperField> enumerable = Model.GetEnumerable().OfType<MinesweeperField>(); // Get an Enumerator for all MinesweeperFields
            foreach (MinesweeperField field in enumerable)
                if (field.IsMine)
                    field.Reveal();

            PauseGame();
            GameFinished?.Invoke(this, new GameFinishedEventArgs(MinesweeperGameEnums.GameWonLost.Lost));
        }

        else if (MatchFlagAndMine()) // Every mine was correctly flagged
        {
            // Reveal all remaining fields
            IEnumerable<MinesweeperField> enumerable = Model.GetEnumerable().OfType<MinesweeperField>(); // Get an Enumerator for all MinesweeperFields

            foreach (MinesweeperField field in enumerable)
            {
                if (field.FieldState == MinesweeperFieldEnums.State.Question) field.ToggleQuestion(); // Remove all question marks
                if (field.FieldState == MinesweeperFieldEnums.State.Hidden) field.Reveal(); // Reveal all hidden fields
            }

            PauseGame();
            GameFinished?.Invoke(this, new GameFinishedEventArgs(MinesweeperGameEnums.GameWonLost.Won));
        }
    }

    #region Mouse

    /// <summary>
    ///     Listen for OnMouseRelease-Events
    /// </summary>
    /// <param name="sender">The RenderBase that draws the screen.</param>
    /// <param name="e"><see cref="RenderMouseEventArgs" />.</param>
    private void ViewOnMouseRelease(object? sender, RenderMouseEventArgs e)
    {
        if (e.Component == null) return; // If no component was specified ignore this click event
        if ((e.Component.MouseState & ComponentEnums.MouseState.Hover) == 0)
            return; // If the mouse doesn't hover over this component ignore this click event

        if (CurrentGameState == MinesweeperGameEnums.GameState.Paused)
            return; // If the game is currently paused ignore every click event
        if (CurrentGameState == MinesweeperGameEnums.GameState.Stopped && e.MouseButton != MouseButtons.Left)
            return; // If the game is currently stopped ignore every click event if the mouse button isn't left click (Prevents the user from setting a flag if the game isn't running)

        if (CurrentGameState == MinesweeperGameEnums.GameState.Stopped) // If the game is stopped, start it
        {
            _gameStartTime = DateTime.UtcNow; // Initialize game timer
            CurrentGameState = MinesweeperGameEnums.GameState.Running; // Update game state
            GameStateChanged?.Invoke(this, EventArgs.Empty);
            SpreadMines(new Area(new Point(e.ComponentLocation.X - 2, e.ComponentLocation.Y - 2),
                new Size(5, 5))); // Spread the mines if the user clicks for the first time  // ToDo: Handle timeout
        }

        MinesweeperField? field = e.Component as MinesweeperField;
        if (field == null) return;

        if (e.MouseButton == MouseButtons.Left)
        {
            field.Reveal();
            FieldRevealTraverse(field, e.ComponentLocation);
        }
        else if (e.MouseButton == MouseButtons.Right)
        {
            field.ToggleFlag();
            CountFlags();
        }
        else if (e.MouseButton == MouseButtons.Middle)
        {
            field.ToggleQuestion();
        }


        // Margins
        //for (int col = 0; col < Model?.Columns; col++)
        //    for (int row = 0; row < Model?.Rows; row++)
        //        FieldUpdateMargins(new Point(col, row));

        View?.UpdateComponents();
        View?.Invalidate();
        ComponentUpdated?.Invoke(this, EventArgs.Empty);

        CheckWonLost();
    }

    #endregion

    #region Minesweeper Fields

    /// <summary>
    ///     Initialize the model with <see cref="MinesweeperField" />s.
    /// </summary>
    private void InitializeMinesweeperFields()
    {
        if (Model == null) return;

        for (int c = 0; c < Model.Columns; c++)
            for (int r = 0; r < Model.Rows; r++)
                Model.Set(c, r, new MinesweeperField());
    }

    /// <summary>
    ///     Count the currently placed flags.
    /// </summary>
    private void CountFlags()
    {
        if (Model == null) return; // No board was yet created
        CurrentFlagCount = 0; // Reset the current flag counter

        foreach (IComponent? component in Model.GetEnumerable())
        {
            if (component is not MinesweeperField field) continue; // Skip the component if it isn't a MinesweeperField
            if (field.FieldState is MinesweeperFieldEnums.State.Flag or MinesweeperFieldEnums.State.Tip)
                CurrentFlagCount++;
        }
    }

    /// <summary>
    ///     Check if a mine is visible.
    /// </summary>
    /// <returns><see langword="true" /> if any mine is visible; otherwise <see langword="false" />.</returns>
    private bool IsMineVisible()
    {
        if (Model == null) return false; // No board was yet created

        IEnumerable<MinesweeperField> enumerable = Model.GetEnumerable().OfType<MinesweeperField>(); // Get an Enumerator for all MinesweeperFields
        return enumerable.Any(field => field.FieldState == MinesweeperFieldEnums.State.Mine); // If any field has the state mine, return true
    }

    /// <summary>
    ///     Check if the type flag and type mine match up.
    /// </summary>
    /// <returns><see langword="true" /> if all flags are only placed on a mine; otherwise <see langword="false" />.</returns>
    private bool MatchFlagAndMine()
    {
        if (Model == null) return false; // No board was yet created

        IEnumerable<MinesweeperField> enumerable = Model.GetEnumerable().OfType<MinesweeperField>(); // Get an Enumerator for all MinesweeperFields

        return enumerable.All(field =>
        {
            if (field.IsMine)
                return field.FieldState is MinesweeperFieldEnums.State.Flag or MinesweeperFieldEnums.State.Tip; // return true, if the field is a mine and it's correctly flagged

            return field.FieldState is not (MinesweeperFieldEnums.State.Flag or MinesweeperFieldEnums.State.Tip); // return true, if the field is not a mine and it's not flagged
        });
    }

    /// <summary>
    ///     Reveal a random mine on the board as a hint
    /// </summary>
    public void RevealHint()
    {
        if (Model == null) return; // No board was yet created
        if (CurrentGameState != MinesweeperGameEnums.GameState.Running) return; // The game wasn't started yet
        if (HintCount - UsedHintCount <= 0) return; // If no hints are available, return

        List<MinesweeperField> mines = new();
        List<MinesweeperField> minesEdge = new();

        for (int col = 0; col < Model.Columns; col++)
            for (int row = 0; row < Model.Rows; row++)
            {
                MinesweeperField? field = Model.Get(col, row) as MinesweeperField;
                if (field == null || field.FieldState != MinesweeperFieldEnums.State.Hidden || !field.IsMine) continue; // Check if it's a valid field

                mines.Add(field);

                IReadOnlyList<MinesweeperField> fieldsAround = GetFieldsAround(new Point(col, row));
                bool revealed = fieldsAround.Any(f => f.FieldState == MinesweeperFieldEnums.State.Visible); // Check if a field around a mine is revealed
                if (revealed) minesEdge.Add(field);
            }

        if (mines.Count <= 0) return; // No mines to reveal

        List<MinesweeperField> possibleFields = minesEdge.Count > 0 ? minesEdge : mines; // Select a list from where to take a mine (prefer the minesEdge list)
        Random rnd = new();

        MinesweeperField rndField = possibleFields[rnd.Next(possibleFields.Count)];
        rndField.RevealAsTip(); // Reveal a random mine
        UsedHintCount++; // Increase the used hint count

        CountFlags();
        View?.UpdateComponents();
        View?.Invalidate();
        ComponentUpdated?.Invoke(this, EventArgs.Empty);

        CheckWonLost();
    }

    /// <summary>
    ///     Spread mines on the board.
    /// </summary>
    /// <param name="ignoreArea">Area which is ignored and no mine placed in.</param>
    /// <exception cref="ArgumentException">Unable to spawn all mines. The board is too small.</exception>
    /// <exception cref="TimeoutException">Timeout while spawning all mines.</exception>
    private void SpreadMines(Area ignoreArea)
    {
        if (Model == null) return; // No board was yet created

        Random xRnd = new();
        Random yRnd = new();

        Size ignoreSize = ignoreArea.Size;

        if (MineCount > BoardSize.Width * BoardSize.Height - ignoreSize.Width * ignoreSize.Height) // Check if we have enough space for all mines
            throw new ArgumentException("Unable to spawn all mines. The board is too small.");

        DateTime timeout = DateTime.UtcNow;

        for (int i = 0; i < MineCount; i++)
        {
            int x = xRnd.Next(0, BoardSize.Width); // Choose a random location on the board
            int y = yRnd.Next(0, BoardSize.Height);

            if (DateTime.UtcNow.Subtract(timeout).Seconds >= 3) // Check if we are for more than 3 seconds in this loop
                throw new TimeoutException("Timeout while spawning all mines.");

            MinesweeperField? field = Model.Get(x, y) as MinesweeperField;

            if (field == null || UtilsClass.IsPointInArea(new Point(x, y), ignoreArea) || field.IsMine) // If the field is in the ignored area or is already a mines, ignore it
            {
                i--;
                continue;
            }

            FieldSetMine(true, new Point(x, y)); // Set the chosen field to a mine
        }
    }

    /// <summary>
    ///     Set a field's mine state and update the surrounding filed.
    /// </summary>
    /// <param name="isMine">Whether this field should be a mine or not.</param>
    /// <param name="location">The location of the field to modify.</param>
    private void FieldSetMine(bool isMine, Point location)
    {
        MinesweeperField? field = Model?.Get(location.X, location.Y) as MinesweeperField;
        if (field == null || isMine == field.IsMine) return;

        field.IsMine = isMine;

        IReadOnlyList<MinesweeperField> fields = GetFieldsAround(location);
        foreach (MinesweeperField f in fields) f.MineCount += isMine ? 1 : -1;
    }

    /// <summary>
    ///     Update margins of a field based on the surrounding fields.
    /// </summary>
    /// <param name="fieldLocation">The location of the field.</param>
    private void FieldUpdateMargins(Point fieldLocation)
    {
        if (Model == null) return;

        MinesweeperField? field = Model.Get(fieldLocation.X, fieldLocation.Y) as MinesweeperField;
        if (field == null) return;

        Padding newMargin = new(0);

        // Left
        if (fieldLocation.X - 1 >= 0)
        {
            MinesweeperField? left = Model.Get(fieldLocation.X - 1, fieldLocation.Y) as MinesweeperField;
            if (left?.FieldState != field.FieldState) newMargin.Left = 2;
        }

        // Up
        if (fieldLocation.Y - 1 >= 0)
        {
            MinesweeperField? up = Model.Get(fieldLocation.X, fieldLocation.Y - 1) as MinesweeperField;
            if (up?.FieldState != field.FieldState) newMargin.Top = 2;
        }

        // Right
        if (fieldLocation.X + 1 < Model.Columns)
        {
            MinesweeperField? right = Model.Get(fieldLocation.X + 1, fieldLocation.Y) as MinesweeperField;
            if (right?.FieldState != field.FieldState) newMargin.Right = 2;
        }

        // Down
        if (fieldLocation.Y + 1 < Model.Rows)
        {
            MinesweeperField? down = Model.Get(fieldLocation.X, fieldLocation.Y + 1) as MinesweeperField;
            if (down?.FieldState != field.FieldState) newMargin.Bottom = 2;
        }

        // Update margin of field
        field.Margin = newMargin;
    }

    /// <summary>
    ///     Reveal multiple field as long they don't have a number.
    /// </summary>
    /// <param name="field">The current field to reveal.</param>
    /// <param name="loc">The location of that field.</param>
    private void FieldRevealTraverse(MinesweeperField field, Location loc)
    {
        if (field.MineCount > 0 || field.IsMine) return; // If the field has a number or is a mine, ignore it

        IReadOnlyCollection<Location> pos = GetLocationsAround(loc); // Get all fields around this field

        foreach (Location l in pos)
        {
            MinesweeperField? f = Model?.Get(l.X, l.Y) as MinesweeperField;

            if (f?.FieldState == MinesweeperFieldEnums.State.Hidden) // If the field is still hidden, reveal it
            {
                f.Reveal();
                FieldRevealTraverse(f, l); // Reveal other fields around
            }
        }
    }

    /// <summary>
    ///     Get the coordinates of the fields around a field.
    /// </summary>
    /// <param name="location">The location in the middle.</param>
    /// <param name="includeCorners">Whether to include the corners.</param>
    /// <returns>A <see cref="IReadOnlyCollection{T}" /> with the coordinates.</returns>
    public IReadOnlyCollection<Location> GetLocationsAround(Location location, bool includeCorners = true)
    {
        List<Location> locations = new();

        if (Model == null) return locations;

        List<Point> points = new()
        {
            new Point(0, -1), // CenterUp
            new Point(1, 0), // CenterRight
            new Point(0, 1), // CenterDown
            new Point(-1, 0) // CenterLeft
        };

        if (includeCorners)
        {
            points.Add(new Point(1, -1)); // RightUp
            points.Add(new Point(1, 1)); // RightDown
            points.Add(new Point(-1, -1)); // LeftUp
            points.Add(new Point(-1, 1)); // LeftDown
        }

        foreach (Point point in points)
        {
            Location n = location + new Location(point);
            if (n.X < 0 || n.X >= Model?.Columns || n.Y < 0 || n.Y >= Model?.Rows) continue;
            locations.Add(n);
        }

        return locations.AsReadOnly();
    }

    /// <summary>
    ///     Get the field around a field.
    /// </summary>
    /// <param name="pos">The location of the field in the middle.</param>
    /// <param name="includeCorners">Whether to include the corners.</param>
    /// <returns></returns>
    public IReadOnlyList<MinesweeperField> GetFieldsAround(Point pos, bool includeCorners = true)
    {
        List<MinesweeperField> fields = new();
        Location loc = new(pos);

        foreach (Point point in GetLocationsAround(loc, includeCorners))
        {
            if (point.X < 0 || point.Y < 0 || point.X >= Model?.Columns || point.Y >= Model?.Rows)
                continue; // If the field would be outside of the board, ignore it
            if (Model?.Get(point.X, point.Y) is MinesweeperField field)
                fields.Add(field); // If the field is a valid field, add it to the output list
        }

        return fields.AsReadOnly();
    }

    #endregion
}

#pragma warning restore IDE0017 // Simplify object initialization
#pragma warning restore IDE0019 // Use pattern matching
#pragma warning restore IDE0051 // Remove unused private members