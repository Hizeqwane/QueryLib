using QueryLib.Specifications.Interfaces;

namespace QueryLib.Models;

/// <summary>
/// Фильтр запроса
/// </summary>
public class Filter<T>(
    string key,
    Func<object, IFilterSpecification<T>> specificationFunc)
{
    /// <summary>
    /// Ключ
    /// </summary>
    public string Key { get; } = key;
    
    /// <summary>
    /// Делегат получения спецификации из входного параметра
    /// </summary>
    public Func<object, IFilterSpecification<T>> SpecificationFunc { get; } = specificationFunc;
}