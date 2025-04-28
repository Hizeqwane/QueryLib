using System.Linq.Expressions;

namespace QueryLib.Specifications.Interfaces;

/// <summary>
/// Спецификация - фильтр
/// </summary>
public interface IFilterSpecification<T>
{
    /// <summary>
    /// Фильтр
    /// </summary>
    Expression<Func<T, bool>> Criteria { get; }
}