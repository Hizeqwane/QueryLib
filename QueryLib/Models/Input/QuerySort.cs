namespace QueryLib.Models.Input;

/// <summary>
/// Запрос - сортировка
/// </summary>
public class QuerySort : BaseQueryUnit
{
    /// <summary>
    /// Напрвеление сортировки
    /// </summary>
    public SortingOrder Order { get; set; }
}