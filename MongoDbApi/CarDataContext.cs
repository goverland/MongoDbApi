using MongoDB.Driver;
using MongoDbApi.Models;

public class CarDataContext
{
    private readonly IMongoCollection<Car> _cars;

    public CarDataContext(IConfiguration configuration)
    {

        var client = new MongoClient(configuration.GetConnectionString("MONGODB_URI"));
        var database = client.GetDatabase("carDb");
        _cars = database.GetCollection<Car>("cars");
    }

    public IQueryable<Car> Cars => _cars.AsQueryable();

    public async Task<IEnumerable<Car>> GetCarsAsync()
    {
        return await _cars.Find(_ => true).ToListAsync();
    }
    public async Task<Car> GetCarAsync(string id)
    {
        return await _cars.Find(x => x.Id == id).FirstOrDefaultAsync();
    }

    public async Task<Car> AddCarAsync(Car car)
    {
        await _cars.InsertOneAsync(car);
        return car;
    }

    public async Task<Car> UpdateCarAsync(string id, Car car)
    {
        await _cars.ReplaceOneAsync(x => x.Id == id, car);
        return car;
    }

    public async Task<Car> DeleteCarAsync(string id)
    {
        var car = await GetCarAsync(id);
        await _cars.DeleteOneAsync(x => x.Id == id);
        return car;
    }

}