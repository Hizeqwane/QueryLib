using QueryLib.Models;
using QueryLib.Models.Input;
using QueryLib.Specifications.Interfaces;

namespace QueryLib.Extensions;

/// <summary>
/// <see cref="Query"/>
/// </summary>
public static class QueryExtensions
{
    /// <summary>
    /// Query -> ISpecification&lt;T&gt;
    /// </summary>
    public static IFilterSpecification<T> ToSpecifications<T>(this Query query,
        IEnumerable<Filter<T>> filters)
    {
        IFilterSpecification<T> specs = null;

        var filterList = filters?.ToList() ?? [];
        if (query?.Filters?.Any() != true || filterList.Count == 0) 
            return null;

        // Ищем фильтры с одинаковым ключом - они будут объединены по "ИЛИ"
        var filterGroups = query.Filters.GroupBy(s => s.Key);
        
        foreach (var filterGroup in filterGroups)
        {
            var foundedFilter = filterList.FirstOrDefault(s =>
                s.Key.EqualsCaseInsensitive(filterGroup.Key));

            var spec = filterGroup.Aggregate
            (
                (IFilterSpecification<T>)null,
                (current, next) =>
                {
                    var newSpec = foundedFilter?.SpecificationFunc(next.Value);
                    return current?.Or(newSpec) ?? newSpec;
                });
            
            if (spec != null)
                specs = specs?.And(spec) ?? spec;
        }

        return specs;
    }
    
    /// <summary>
    /// Query -> IEnumerable&lt;ISortSpecification&lt;T&gt;&gt;
    /// </summary>
    public static IEnumerable<ISortSpecification<T>> ToSpecifications<T>(this Query query,
        IEnumerable<Sort<T>> sortDescriptions)
    {
        var sortDescriptionList = sortDescriptions?.ToList() ?? [];
        if (query?.Sorts?.Any() != true || sortDescriptionList.Count == 0) 
            yield break;
        
        foreach (var querySort in query.Sorts)
        {
            var foundedSort = sortDescriptionList.FirstOrDefault(s =>
                s.Key.EqualsCaseInsensitive(querySort.Key));

            var spec = foundedSort?.SortFunc(querySort.Order);
            if (spec != null)
                yield return spec;
        }
    }
}