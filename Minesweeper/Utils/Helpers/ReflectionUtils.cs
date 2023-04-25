using System.Reflection;

namespace Minesweeper.Utils.Helpers;

public static class ReflectionUtils
{
    public static PropertyInfo[] GetProperties<T>()
    {
        return typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
    }

    public static bool ReflectionEquals<T>(T obj1, T obj2)
    {
        foreach (PropertyInfo propInfo in GetProperties<T>())
        {
            if (!propInfo.CanRead) continue;

            object? val = propInfo.GetValue(obj1);
            if (val == null) continue;

            if (!val.Equals(propInfo.GetValue(obj2))) return false;
        }

        return true;
    }

    public static void ReflectionCopy<T>(T source, ref T destination) where T : class
    {
        foreach (PropertyInfo propInfo in GetProperties<T>())
        {
            if (!propInfo.CanWrite) continue;
            propInfo.SetValue(destination, propInfo.GetValue(source));
        }
    }

    public static T ReflectionClone<T>(T obj) where T : class
    {
        T instance = Activator.CreateInstance<T>();
        ReflectionCopy(obj, ref instance);
        return instance;
    }
}