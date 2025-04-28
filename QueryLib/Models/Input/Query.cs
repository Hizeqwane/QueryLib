namespace QueryLib.Models.Input;

/// <summary>
/// Запрос
/// </summary>
public class Query(
    IEnumerable<QueryFilter> filters,
    IEnumerable<QuerySort> sorts)
    : PageableQuery
{
    /// <summary>
    /// Фильтры
    /// </summary>
    public IEnumerable<QueryFilter> Filters { get; } = filters;
    
    /// <summary>
    /// Сортировки
    /// </summary>
    public IEnumerable<QuerySort> Sorts { get; } = sorts;
}