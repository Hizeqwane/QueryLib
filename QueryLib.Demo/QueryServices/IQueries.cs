using QueryLib.Demo.Models;
using QueryLib.Models;
using QueryLib.Models.Input;

namespace QueryLib.Demo.QueryServices;

/// <summary>
/// Класс запросов
/// </summary>
public interface IQueries
{
    Task<List<object>> Get(Query query, CancellationToken cancellationToken);

    List<Filter<Person>> GetPersonFilters();
    
    List<Filter<Vehicle>> GetVehicleFilters();
    
    List<Sort<Person>> GetPersonSorts();
    
    List<Sort<Vehicle>> GetVehicleSorts();
}