namespace Minesweeper.Utils.Helpers;

/// <summary>
///     Add a previous state to a variable. Used reflection to create a copy of the current variable.
/// </summary>
/// <typeparam name="T">The type of the variable.</typeparam>
public class IncludePrevious<T> where T : class
{
    /// <summary>
    ///     The current variable state.
    /// </summary>
    public T Current;

    /// <summary>
    ///     The previous state of the variable.
    /// </summary>
    public T Previous;

    /// <summary>
    ///     Initialize a new <see cref="IncludePrevious{T}" /> instance.
    /// </summary>
    /// <param name="current">The current state of the variable.</param>
    public IncludePrevious(T current) : this(current, ReflectionUtils.ReflectionClone(current))
    {
    }

    /// <summary>
    ///     Initialize a new <see cref="IncludePrevious{T}" /> instance.
    /// </summary>
    /// <param name="current">The current state of the variable.</param>
    /// <param name="previous">The previous state of the variable.</param>
    public IncludePrevious(T current, T previous) => (Current, Previous) = (current, previous);

    /// <summary>
    ///     Check using reflection whether the current and previous state are equals.
    /// </summary>
    /// <returns></returns>
    public bool Equals() => ReflectionUtils.ReflectionEquals(Current, Previous);

    /// <summary>
    ///     Create a copy of the current variable state and save it to the previous state.
    /// </summary>
    public void UpdatePrevious() => ReflectionUtils.ReflectionCopy(Current, ref Previous);

    /// <summary>
    ///     Automatically convert the current variable to the <see cref="IncludePrevious{T}" /> type to include the previous
    ///     state.
    /// </summary>
    /// <param name="obj">The current variable.</param>
    public static implicit operator IncludePrevious<T>(T obj) => new(obj);
}