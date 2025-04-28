using System.Text.Json.Serialization;

namespace QueryLib.Models;

/// <summary>
/// Напревление сортировки
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter<SortingOrder>))]
public enum SortingOrder
{
    /// <summary>
    /// А-Я
    /// </summary>
    Asc,
    
    /// <summary>
    /// Я-А
    /// </summary>
    Desc
}