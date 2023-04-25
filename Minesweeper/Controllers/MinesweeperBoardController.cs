using Minesweeper.Controllers.CustomEventArgs;
using Minesweeper.Enums;
using Minesweeper.Models;
using Minesweeper.Utils.Helpers;
using Minesweeper.Utils.Position;
using Minesweeper.Views;
using Minesweeper.Views.Components;
using Minesweeper.Views.CustomEventArgs;
using Minesweeper.Views.Interfaces;
using GameState = Minesweeper.Enums.MinesweeperGameEnums.GameState;

// ReSharper disable MemberCanBePrivate.Global
#pragma warning disable IDE0017 // Simplify object initialization
#pragma warning disable IDE0019 // Use pattern matching
#pragma warning disable IDE0051 // Remove unused private members

namespace Minesweeper.Controllers;

public class MinesweeperBoardController
{
    private DateTime _gameStartTime = DateTime.UtcNow;
    private DateTime _gamePauseStartTime = DateTime.UtcNow;
    private List<TimeSpan> _gamePauseTimes = new();

    public MinesweeperBoardController() { }

    public GridModel? Model { get; private set; }

    public GridView? View { get; private set; }

    public GameState CurrentGameState { get; private set; } = GameState.Stopped;

    public Size BoardSize => new(Model?.Columns ?? 0, Model?.Rows ?? 0);

    public int MineCount { get; private set; }

    public int HintCount { get; private set; }

    public int UsedHintCount { get; private set; }

    public int CurrentFlagCount { get; private set; }

    public event EventHandler? ComponentUpdated;
    public event EventHandler? GameStateChanged;
    public event EventHandler<GameFinishedEventArgs>? GameFinished;

    public void NewBoard(Size boardSize, int mines, int hints)
    {
        _gameStartTime = DateTime.UtcNow;
        _gamePauseStartTime = DateTime.UtcNow;
        _gamePauseTimes = new List<TimeSpan>();

        CurrentGameState = GameState.Stopped;
        GameStateChanged?.Invoke(this, EventArgs.Empty);

        MineCount = mines;
        HintCount = hints;
        UsedHintCount = 0;

        View?.Dispose();

        Model = new GridModel(boardSize.Width, boardSize.Height);
        InitializeMinesweeperFields();

        View = new GridView(Model);

        View.Padding = new Padding(0);
        View.Margin = new Padding(0);
        View.MinimumSize = new Size(160, 160);
        View.AutoSize = true;
        View.Dock = DockStyle.Fill;

        View.ComponentMouseUp += ViewOnMouseRelease;

        CurrentFlagCount = 0;
        ComponentUpdated?.Invoke(this, EventArgs.Empty);
    }

    public TimeSpan GetCurrentGameTime()
    {
        // If the game is stopped, the timer should be zero
        if (CurrentGameState == GameState.Stopped) return TimeSpan.Zero;

        // Current game time without pauses
        TimeSpan gameTime = DateTime.UtcNow.Subtract(_gameStartTime);

        // Remove all times where the game was paused
        foreach (TimeSpan pauseTime in _gamePauseTimes)
            gameTime = gameTime.Subtract(pauseTime);

        // If the game is currently paused, remove the currently elapsed pause time
        if (CurrentGameState == GameState.Paused) gameTime = gameTime.Subtract(DateTime.UtcNow.Subtract(_gamePauseStartTime));

        return gameTime;
    }

    public void ResumeGame()
    {
        if (CurrentGameState != GameState.Paused) throw new InvalidOperationException("The game can't be resumed if it's currently not paused");

        TimeSpan pauseDiff = DateTime.UtcNow.Subtract(_gamePauseStartTime);
        _gamePauseTimes.Add(pauseDiff);

        CurrentGameState = GameState.Running;
        GameStateChanged?.Invoke(this, EventArgs.Empty);
    }

    public void PauseGame()
    {
        if (CurrentGameState != GameState.Running) throw new InvalidOperationException("The game can't be paused if it's currently not running");

        _gamePauseStartTime = DateTime.UtcNow;
        CurrentGameState = GameState.Paused;
        GameStateChanged?.Invoke(this, EventArgs.Empty);
    }

    private void CheckWonLost()
    {
        if (Model == null) return;  // No board was yet created

        if (IsMineVisible())  // Game over
        {
            // Reveal all bombs
            IEnumerable<MinesweeperField> enumerable = Model.GetEnumerable().OfType<MinesweeperField>();  // Get an Enumerator for all MinesweeperFields
            foreach (MinesweeperField field in enumerable) if (field.IsMine) field.Reveal();

            PauseGame();
            GameFinished?.Invoke(this, new GameFinishedEventArgs(MinesweeperGameEnums.GameWonLost.Lost));
        }

        else if (MatchFlagAndMine()) // Every mine was correctly flagged
        {
            // Reveal all remaining fields
            IEnumerable<MinesweeperField> enumerable = Model.GetEnumerable().OfType<MinesweeperField>();  // Get an Enumerator for all MinesweeperFields

            foreach (MinesweeperField field in enumerable)
            {
                if (field.FieldState == MinesweeperFieldEnums.State.Question) field.ToggleQuestion();  // Remove all question marks
                if (field.FieldState == MinesweeperFieldEnums.State.Hidden) field.Reveal();  // Reveal all hidden fields
            }

            PauseGame();
            GameFinished?.Invoke(this, new GameFinishedEventArgs(MinesweeperGameEnums.GameWonLost.Won));
        }
    }

    #region Minesweeper Fields

    private void InitializeMinesweeperFields()
    {
        if (Model == null) return;

        for (int c = 0; c < Model.Columns; c++)
            for (int r = 0; r < Model.Rows; r++)
                Model.Set(c, r, new MinesweeperField());
    }

    private void CountFlags()
    {
        if (Model == null) return;
        CurrentFlagCount = 0;

        foreach (IComponent? component in Model.GetEnumerable())
        {
            if (component is not MinesweeperField field) continue;
            if (field.FieldState is MinesweeperFieldEnums.State.Flag or MinesweeperFieldEnums.State.Tip) CurrentFlagCount++;
        }
    }

    private bool IsMineVisible()
    {
        if (Model == null) return false;  // No board was yet created

        IEnumerable<MinesweeperField> enumerable = Model.GetEnumerable().OfType<MinesweeperField>();  // Get an Enumerator for all MinesweeperFields
        return enumerable.Any(field => field.FieldState == MinesweeperFieldEnums.State.Mine);  // If any field has the state mine, return true
    }

    private bool MatchFlagAndMine()
    {
        if (Model == null) return false;  // No board was yet created

        IEnumerable<MinesweeperField> enumerable = Model.GetEnumerable().OfType<MinesweeperField>();  // Get an Enumerator for all MinesweeperFields

        return enumerable.All(field =>
        {
            if (field.IsMine)
                return field.FieldState is MinesweeperFieldEnums.State.Flag or MinesweeperFieldEnums.State.Tip;  // return true, if the field is a mine and it's correctly flagged

            return field.FieldState is not (MinesweeperFieldEnums.State.Flag or MinesweeperFieldEnums.State.Tip);  // return true, if the field is not a mine and it's not flagged
        });
    }

    public void RevealHint()
    {
        if (Model == null) return;  // No board was yet created
        if (CurrentGameState != GameState.Running) return;  // The game wasn't started yet
        if (HintCount - UsedHintCount <= 0) return;  // If no hints are available, return

        List<MinesweeperField> mines = new();
        List<MinesweeperField> minesEdge = new();

        for (int col = 0; col < Model.Columns; col++)
        {
            for (int row = 0; row < Model.Rows; row++)
            {
                MinesweeperField? field = Model.Get(col, row) as MinesweeperField;
                if (field == null || field.FieldState != MinesweeperFieldEnums.State.Hidden || !field.IsMine) continue;

                mines.Add(field);

                IReadOnlyList<MinesweeperField> fieldsAround = GetFieldsAround(new Point(col, row));
                bool revealed = fieldsAround.Any(f => f.FieldState == MinesweeperFieldEnums.State.Visible);
                if (revealed) minesEdge.Add(field);
            }
        }

        if (mines.Count <= 0) return;  // No mines to reveal

        List<MinesweeperField> possibleFields = minesEdge.Count > 0 ? minesEdge : mines;  // Select a list from where to take a mine (prefer the minesEdge list)
        Random rnd = new();

        MinesweeperField rndField = possibleFields[rnd.Next(possibleFields.Count)];
        rndField.RevealAsTip();  // Reveal a random mine
        UsedHintCount++;  // Increase the used hint count

        CountFlags();
        View?.UpdateComponents();
        View?.Invalidate();
        ComponentUpdated?.Invoke(this, EventArgs.Empty);

        CheckWonLost();
    }

    private void SpreadMines(Area ignoreArea)
    {
        if (Model == null) return;

        Random xRnd = new();
        Random yRnd = new();

        Size ignoreSize = ignoreArea.Size;

        if (MineCount > BoardSize.Width * BoardSize.Height - ignoreSize.Width * ignoreSize.Height)
            throw new ArgumentException("Unable to spawn all mines. The board is too small.");

        DateTime timeout = DateTime.UtcNow;

        for (int i = 0; i < MineCount; i++)
        {
            int x = xRnd.Next(0, BoardSize.Width);
            int y = yRnd.Next(0, BoardSize.Height);

            if (DateTime.UtcNow.Subtract(timeout).Seconds >= 3)
                throw new TimeoutException("Timeout while spawning all mines.");

            MinesweeperField? field = (MinesweeperField?)Model.Get(x, y);

            if (field == null || UtilsClass.IsPointInArea(new Point(x, y), ignoreArea) || field.IsMine)
            {
                i--;
                continue;
            }

            FieldSetMine(true, new Point(x, y));
        }
    }

    private void FieldSetMine(bool isMine, Point location)
    {
        MinesweeperField? field = (MinesweeperField?)Model?.Get(location.X, location.Y);
        if (field == null || isMine == field.IsMine) return;

        field.IsMine = isMine;

        IReadOnlyList<MinesweeperField> fields = GetFieldsAround(location);
        foreach (MinesweeperField f in fields) f.MineCount += isMine ? 1 : -1;
    }

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

    private void FieldRevealTraverse(MinesweeperField field, Location loc)
    {
        if (field.MineCount > 0 || field.IsMine) return;

        IReadOnlyCollection<Location> pos = GetLocationsAround(loc);

        foreach (Location l in pos)
        {
            MinesweeperField? f = (MinesweeperField?)Model?.Get(l.X, l.Y);

            if (f?.FieldState == MinesweeperFieldEnums.State.Hidden)
            {
                f.Reveal();
                FieldRevealTraverse(f, l);
            }
        }
    }

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

    public IReadOnlyList<MinesweeperField> GetFieldsAround(Point pos, bool includeCorners = true)
    {
        List<MinesweeperField> fields = new();
        Location loc = new(pos);

        foreach (Point point in GetLocationsAround(loc, includeCorners))
        {
            if (point.X < 0 || point.Y < 0 || point.X >= Model?.Columns || point.Y >= Model?.Rows) continue;
            MinesweeperField? field = (MinesweeperField?)Model?.Get(point.X, point.Y);
            if (field != null) fields.Add(field);
        }

        return fields.AsReadOnly();
    }

    #endregion

    #region Mouse

    private void ViewOnMouseRelease(object? sender, RenderMouseEventArgs e)
    {
        if (e.Component == null) return;  // If no component was specified ignore this click event
        if ((e.Component.MouseState & ComponentEnums.MouseState.Hover) == 0) return;  // If the mouse doesn't hover over this component ignore this click event

        if (CurrentGameState == GameState.Paused) return;  // If the game is currently paused ignore every click event
        if (CurrentGameState == GameState.Stopped && e.MouseButton != MouseButtons.Left) return;  // If the game is currently stopped ignore every click event if the mouse button isn't left click (Prevents the user from setting a flag if the game isn't running)

        if (CurrentGameState == GameState.Stopped)  // If the game is stopped, start it
        {
            _gameStartTime = DateTime.UtcNow;
            CurrentGameState = GameState.Running;
            GameStateChanged?.Invoke(this, EventArgs.Empty);
            SpreadMines(new Area(new Point(e.ComponentLocation.X - 2, e.ComponentLocation.Y - 2), new Size(5, 5)));  // ToDo: Handle timeout
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
            CountFlags();  // ToDo: Check check here if it's a flag and update the counter / No need to loop through every field??? What if the flag wasn't set?
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
}

#pragma warning restore IDE0017 // Simplify object initialization
#pragma warning restore IDE0019 // Use pattern matching
#pragma warning restore IDE0051 // Remove unused private members
