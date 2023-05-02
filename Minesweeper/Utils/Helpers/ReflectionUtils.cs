using System.Reflection;

namespace Minesweeper.Utils.Helpers;

/// <summary>
///     A collection of utils for reflection.
/// </summary>
public static class ReflectionUtils
{
    /// <summary>
    ///     Get all properties of a type.
    /// </summary>
    /// <typeparam name="T">The class type.</typeparam>
    /// <returns>All public properties.</returns>
    public static PropertyInfo[] GetProperties<T>()
    {
        return typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
    }

    /// <summary>
    ///     Check if two objects are equals using reflection by comparing all class properties.
    /// </summary>
    /// <typeparam name="T">The class type.</typeparam>
    /// <param name="obj1">The first object to compare.</param>
    /// <param name="obj2">The second object to compare.</param>
    /// <returns><see langword="true" /> if the two objects are equals; otherwise <see langword="false" />.</returns>
    public static bool ReflectionEquals<T>(T obj1, T obj2)
    {
        foreach (PropertyInfo propInfo in GetProperties<T>()) // Loop through all properties
        {
            if (!propInfo.CanRead) continue; // If the property can't be read, ignore it

            object? val = propInfo.GetValue(obj1); // Get the value of the property of the first object
            if (val == null) continue;

            if (!val.Equals(propInfo.GetValue(obj2)))
                return false; // If the property isn't equals, the objects also can't be equals
        }

        return true;
    }

    /// <summary>
    ///     Copy all property values from one object to another object.
    /// </summary>
    /// <typeparam name="T">The class type.</typeparam>
    /// <param name="source">The source object.</param>
    /// <param name="destination">The destination object.</param>
    public static void ReflectionCopy<T>(T source, ref T destination) where T : class
    {
        foreach (PropertyInfo propInfo in GetProperties<T>())
        {
            if (!propInfo.CanWrite) continue;
            propInfo.SetValue(destination, propInfo.GetValue(source));
        }
    }

    /// <summary>
    ///     Create a new object that has the same property values as the source object.
    /// </summary>
    /// <typeparam name="T">The class type.</typeparam>
    /// <param name="obj">The source object.</param>
    /// <returns>A new object with the same property values.</returns>
    public static T ReflectionClone<T>(T obj) where T : class
    {
        T instance = Activator.CreateInstance<T>();
        ReflectionCopy(obj, ref instance);
        return instance;
    }
}