using System.Linq.Expressions;
using QueryLib.Specifications;
using QueryLib.Specifications.Interfaces;

namespace QueryLib.Extensions;

/// <summary>
/// <see cref="IFilterSpecification{T}"/>
/// </summary>
public static class SpecificationExtensions
{
    /// <summary>
    /// И
    /// </summary>
    public static IFilterSpecification<T> And<T>(this IFilterSpecification<T> spec1, IFilterSpecification<T> spec2)
    {
        var parameter = Expression.Parameter(typeof(T));

        var combinedExpression = Expression.AndAlso(
            Expression.Invoke(spec1.Criteria, parameter),
            Expression.Invoke(spec2.Criteria, parameter)
        );

        var lambda = Expression.Lambda<Func<T, bool>>(combinedExpression, parameter);

        return new FilterSpecification<T>(lambda);
    }
    
    /// <summary>
    /// ИЛИ
    /// </summary>
    public static IFilterSpecification<T> Or<T>(this IFilterSpecification<T> spec1, IFilterSpecification<T> spec2)
    {
        var parameter = Expression.Parameter(typeof(T));

        var combinedExpression = Expression.OrElse(
            Expression.Invoke(spec1.Criteria, parameter),
            Expression.Invoke(spec2.Criteria, parameter)
        );

        var lambda = Expression.Lambda<Func<T, bool>>(combinedExpression, parameter);

        return new FilterSpecification<T>(lambda);
    }
}