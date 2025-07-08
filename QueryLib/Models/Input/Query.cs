namespace QueryLib.Models.Input;

/// <summary>
/// Запрос
/// </summary>
public class Query(
    IEnumerable<QueryFilter> filters,
    IEnumerable<QuerySort> sorts,
    IEnumerable<QueryModifier> modifiers)
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
    
    /// <summary>
    /// Модификаторы
    /// </summary>
    public IEnumerable<QueryModifier> Modifiers { get; } = modifiers;
}