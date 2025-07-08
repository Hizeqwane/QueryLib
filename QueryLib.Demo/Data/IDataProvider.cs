using QueryLib.Models.Input;
using QueryLib.Specifications;
using QueryLib.Specifications.Interfaces;

namespace QueryLib.Demo.Data;

/// <summary>
/// Поставщик данных
/// </summary>
public interface IDataProvider
{
    /// <summary>
    /// Получить список
    /// </summary>
    Task<List<T>> GetListAsync<T>(
        PageableQuery pageableQuery,
        IFilterSpecification<T> filterSpec,
        IEnumerable<ISortSpecification<T>> sorts,
        ModifierDelegate<T> modifier,
        CancellationToken cancellationToken)
        where T : class;
}