using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using MongoDbApi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MongoDbApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CarsController : ControllerBase
{
    private readonly CarDataContext _context;

    public CarsController(CarDataContext context)
    {
        _context = context;
    }
    // GET: api/<ValuesController>
    [HttpGet]
    public async Task<IEnumerable<Car>> Get()
    {
        return await _context.GetCarsAsync();
    }

    // GET api/<ValuesController>/5
    [HttpGet("{id}")]
    public async Task<Car> Get(string id)
    {
        return await _context.GetCarAsync(id);
    }

    // POST api/<ValuesController>
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Car car)
    {
        var result = await _context.AddCarAsync(car);

        return Ok(result);
    }

    // PUT api/<ValuesController>/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    // DELETE api/<ValuesController>/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
}
