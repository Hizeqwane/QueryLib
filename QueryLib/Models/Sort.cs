using System.Linq.Expressions;
using QueryLib.Specifications;
using QueryLib.Specifications.Interfaces;

namespace QueryLib.Models;

/// <summary>
/// Сортировка запроса
/// </summary>
public class Sort<T>
{
    /// <summary>
    /// Кастомная сортировка
    /// </summary>
    public Sort(string key,
        Func<SortingOrder, ISortSpecification<T>> sortFunc)
    {
        Key = key;
        SortFunc = sortFunc;
    }

    /// <summary>
    /// Сортировка по полю объекта
    /// </summary>
    public Sort(
        string key,
        Expression<Func<T, object>> propertyGetter)
        : this(
            key,
            order => new SortSpecification<T>(propertyGetter, order))
    { }

    /// <summary>
    /// Делегат получения спецификации сортировки
    /// </summary>
    public Func<SortingOrder, ISortSpecification<T>> SortFunc { get; }

    /// <summary>
    /// Ключ
    /// </summary>
    public string Key { get; set; }
}