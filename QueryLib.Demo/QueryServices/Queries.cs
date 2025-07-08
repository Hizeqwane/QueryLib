using QueryLib.Demo.Data;
using QueryLib.Demo.Models;
using QueryLib.Extensions;
using QueryLib.Models;
using QueryLib.Models.Input;
using QueryLib.Specifications;

namespace QueryLib.Demo.QueryServices;

public class Queries(IDataProvider dataProvider) : IQueries
{
    public Task<List<object>> Get(Query query, CancellationToken cancellationToken)
    {
        var typeFilter = query.Filters
            .FirstOrDefault(f => f.Key.EqualsCaseInsensitive("Type"))?
            .Value?
            .ToString()
            ?.ToLower();

        if (string.IsNullOrWhiteSpace(typeFilter))
            throw new Exception("Не задан тип объекта");

        if (typeFilter.EqualsCaseInsensitive(nameof(Person).ToLower()))
            return GetPersons(query, cancellationToken);

        if (typeFilter.EqualsCaseInsensitive(nameof(Vehicle).ToLower()))
            return GetPersons(query, cancellationToken);

        throw new Exception($"Неизвестный тип объекта: {typeFilter}");
    }

    public List<Filter<Person>> GetPersonFilters() =>
    [
        new
        (
            nameof(Person.Id),
            rawValue =>
                int.TryParse(rawValue?.ToString(), out var intValue)
                    ? new FilterSpecification<Person>(p => p.Id == intValue)
                    : null
        ),
        new
        (
            nameof(Person.Name),
            rawValue =>
            {
                var str = rawValue?.ToString()?.ToLower();
                return new FilterSpecification<Person>(p => p.Name.ToLower().Contains(str));
            }
        )
    ];

    public List<Filter<Vehicle>> GetVehicleFilters() =>
    [
        new
        (
            nameof(Vehicle.Id),
            rawValue =>
                int.TryParse(rawValue?.ToString(), out var intValue)
                    ? new FilterSpecification<Vehicle>(p => p.Id == intValue)
                    : null
        ),
        new
        (
            nameof(Vehicle.Model),
            rawValue =>
            {
                var str = rawValue?.ToString()?.ToLower();
                return new FilterSpecification<Vehicle>(p => p.Model.ToLower().Contains(str));
            }
        )
    ];

    public List<Sort<Person>> GetPersonSorts() =>
    [
        new
        (
            nameof(Person.Name),
            person => person.Name
        )
    ];
    
    public List<Modifier<Person>> GetPersonModifiers() =>
    [
        new
        (
            "ToUpper",
            person =>
            {
                person.SetName(person.Name.ToUpper());
                
                return person;
            })
    ];

    public List<Sort<Vehicle>> GetVehicleSorts() =>
    [
        new
        (
            nameof(Vehicle.Model),
            vehicle => vehicle.Model
        )
    ];
    
    public List<Modifier<Vehicle>> GetVehicleModifiers() =>
    [
        new
        (
            "ToLower",
            vehicle =>
            {
                vehicle.SetModel(vehicle.Model.ToUpper());
                
                return vehicle;
            })
    ];

    public async Task<List<object>> GetPersons(Query query, CancellationToken cancellationToken)
    {
        var filterSpec = query.ToSpecifications(GetPersonFilters());
        var sorts = query.ToSpecifications(GetPersonSorts());
        var modifier = query.ToModifier(GetPersonModifiers());

        var list = await dataProvider.GetListAsync(query, filterSpec, sorts, modifier, cancellationToken);

        return list
            .Select(s => s as object)
            .ToList();
    }

    public async Task<List<object>> GetVehicles(Query query, CancellationToken cancellationToken)
    {
        var filterSpec = query.ToSpecifications(GetVehicleFilters());
        var sorts = query.ToSpecifications(GetVehicleSorts());
        var modifier = query.ToModifier(GetVehicleModifiers());

        var list = await dataProvider.GetListAsync(query, filterSpec, sorts, modifier, cancellationToken);

        return list
            .Select(s => s as object)
            .ToList();
    }
}