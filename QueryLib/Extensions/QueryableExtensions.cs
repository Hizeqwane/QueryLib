using QueryLib.Models;
using QueryLib.Models.Input;
using QueryLib.Specifications.Interfaces;

namespace QueryLib.Extensions;

/// <summary>
/// <see cref="IQueryable"/>
/// </summary>
public static class QueryableExtensions
{
    /// <summary>
    /// Skip для int?
    /// </summary>
    public static IQueryable<T> SkipOrAll<T>(this IQueryable<T> source, int? skip) =>
        skip.HasValue
            ? source.Skip(skip.Value)
            : source;
    
    /// <summary>
    /// Take для int?
    /// </summary>
    public static IQueryable<T> TakeOrAll<T>(this IQueryable<T> source, int? take) =>
        take.HasValue
            ? source.Take(take.Value)
            : source;
    
    /// <summary>
    /// Skip-Take для <see cref="PageableQuery"/>
    /// </summary>
    public static IQueryable<T> GetSkipTake<T>(this IQueryable<T> source, PageableQuery pageableQuery) =>
        source
            .SkipOrAll(pageableQuery?.Skip)
            .TakeOrAll(pageableQuery?.Take);

    /// <summary>
    /// Применение сортировок к запросу
    /// </summary>
    public static bool TryGetOrdered<T>(
        this IQueryable<T> source,
        IEnumerable<ISortSpecification<T>> sorts,
        out IOrderedQueryable<T> ordered)
    {
        ordered = sorts
            .Aggregate
            (
                (IOrderedQueryable<T>)null,
                (current, sort) =>
                {
                    var isAsc = sort.Order == SortingOrder.Asc;

                    return current == null
                        ? isAsc
                            ? source.OrderBy(sort.Criteria)
                            : source.OrderByDescending(sort.Criteria)
                        : isAsc
                            ? current.ThenBy(sort.Criteria)
                            : current.ThenByDescending(sort.Criteria);
                });

        return ordered != null;
    }
}