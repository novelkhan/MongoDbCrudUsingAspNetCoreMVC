using MongoDB.Bson;
using MongoDB.Driver;
using MongoDbCrudUsingAspNetCoreMVC.Models;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace MongoDbCrudUsingAspNetCoreMVC.Services
{
    public class MongoDbService
    {
        private readonly IMongoCollection<Person> _collection;

        public MongoDbService(IConfiguration configuration)
        {
            //var client = new MongoClient("mongodb+srv://nvl:q3mfFJz5HM68eLNk@cluster1.2auwomk.mongodb.net/PersonDB");
            var client = new MongoClient(configuration["ConnectionStrings:DefaultConnection"]);
            var database = client.GetDatabase("PersonDB");
            _collection = database.GetCollection<Person>("Persons");
        }

        public async Task<List<Person>> GetAll()
        {
            return await _collection.Find(_ => true).ToListAsync();
        }

        public async Task<Person> GetById(string id)
        {
            var objectId = new ObjectId(id);
            return await _collection.Find(person => person._id == objectId).FirstOrDefaultAsync();
        }

        public async Task Create(Person person)
        {
            await _collection.InsertOneAsync(person);
        }

        public async Task Update(string id, Person person)
        {
            var objectId = new ObjectId(id);
            await _collection.ReplaceOneAsync(p => p._id == objectId, person);
        }

        public async Task Delete(string id)
        {
            var objectId = new ObjectId(id);
            await _collection.DeleteOneAsync(p => p._id == objectId);
        }
    }
}
