namespace QueryLib.Models.Input;

/// <summary>
/// Запрос - фильтр
/// </summary>
public class QueryFilter
{
    /// <summary>
    /// Ключ
    /// </summary>
    public string Key { get; set; }
    
    /// <summary>
    /// Значение
    /// </summary>
    public object Value { get; set; }
}