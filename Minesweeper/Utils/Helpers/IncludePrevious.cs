namespace Minesweeper.Utils.Helpers;

public class IncludePrevious<T> where T : class
{
    public T Current;
    public T Previous;

    public IncludePrevious(T current) : this(current, ReflectionUtils.ReflectionClone(current)) { }

    public IncludePrevious(T current, T previous) => (Current, Previous) = (current, previous);

    public bool Equals() => ReflectionUtils.ReflectionEquals(Current, Previous);

    public void UpdatePrevious() => ReflectionUtils.ReflectionCopy(Current, ref Previous);

    public static implicit operator IncludePrevious<T>(T obj) => new(obj);
}