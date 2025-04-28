using System.Linq.Expressions;
using QueryLib.Models;

namespace QueryLib.Specifications.Interfaces;

/// <summary>
/// Спецификация - сортировка
/// </summary>
public interface ISortSpecification<TSource>
{
    /// <summary>
    /// Сортировка
    /// </summary>
    Expression<Func<TSource, object>> Criteria { get; }
    
    /// <summary>
    /// Направление
    /// </summary>
    SortingOrder Order { get; }
}