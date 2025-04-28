namespace QueryLib.Extensions;

/// <summary>
/// <see cref="string"/>
/// </summary>
public static class StringExtensions
{
    private static StringComparison StringComparison => StringComparison.OrdinalIgnoreCase;

    /// <summary>
    /// <see cref="StringComparison"/>
    /// </summary>
    public static bool EqualsCaseInsensitive(this string str1, string str2) =>
        str1?.Equals(str2, StringComparison) ?? str2 == null;

    /// <summary>
    /// <see cref="StringComparison"/>
    /// </summary>
    public static bool ContainsCaseInsensitive(this string str1, string str2) =>
        str1?.Contains(str2, StringComparison) ?? str2 == null;
}