using Microsoft.AspNetCore.Mvc;
using QueryLib.Demo.QueryServices;
using QueryLib.Models.Input;

namespace QueryLib.Demo;

[Route("demo")]
public class DemoController(IQueries queries) : ControllerBase
{
    /// <summary>
    /// Метод получения списка объектов
    /// </summary>
    /// <remarks>Для получения Person - передайте фильтр { "Key": "Type", "Value": "Person" }</remarks>
    /// <remarks>Для получения Vehicle - передайте фильтр { "Key": "Type", "Value": "Vehicle" }</remarks>
    [HttpPost("get-list")]
    public async Task<ActionResult> GetList([FromBody] Query query) => 
        Ok(await queries.Get(query, HttpContext.RequestAborted));
}