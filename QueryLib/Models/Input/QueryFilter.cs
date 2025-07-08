namespace QueryLib.Models.Input;

/// <summary>
/// Запрос - фильтр
/// </summary>
public class QueryFilter : BaseQueryUnit
{
    /// <summary>
    /// Значение
    /// </summary>
    public object Value { get; set; }
}