namespace QueryLib.Models.Input;

/// <summary>
/// Запрос - сортировка
/// </summary>
public class QuerySort
{
    /// <summary>
    /// Ключ
    /// </summary>
    public string Key { get; set; }

    /// <summary>
    /// Напрвеление сортировки
    /// </summary>
    public SortingOrder Order { get; set; }
}