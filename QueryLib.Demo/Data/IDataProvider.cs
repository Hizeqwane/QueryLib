using QueryLib.Models.Input;
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
        CancellationToken cancellationToken)
        where T : class;
}