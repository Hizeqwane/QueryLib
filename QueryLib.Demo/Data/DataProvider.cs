using Microsoft.EntityFrameworkCore;
using QueryLib.Extensions;
using QueryLib.Models.Input;
using QueryLib.Specifications.Interfaces;

namespace QueryLib.Demo.Data;

/// <inheritdoc />
public class DataProvider(
    DataContext dataContext)
    : IDataProvider
{
    /// <inheritdoc />
    public async Task<List<T>> GetListAsync<T>(PageableQuery pageableQuery, IFilterSpecification<T> filterSpec, IEnumerable<ISortSpecification<T>> sorts,
        CancellationToken cancellationToken)
        where T : class
    {
        var query = dataContext
            .Set<T>()
            .AsQueryable();

        if (filterSpec != null)
            query = query.Where(filterSpec.Criteria);

        if (query.TryGetOrdered(sorts, out var ordered))
            query = ordered;

        return await query
            .GetSkipTake(pageableQuery)
            .ToListAsync(cancellationToken: cancellationToken);
    }
}