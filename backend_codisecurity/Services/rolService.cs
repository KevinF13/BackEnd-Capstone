using backend_codisecurity.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace backend_codisecurity.Services
{
    public class rolService
    {
        private readonly IMongoCollection<Rol> _rolCollection;

        public rolService(
            IOptions<codisecurityStoreDatabaseSettings> codisecurityStoreDatabaseSettings)
        {
            var mongoClient = new MongoClient(
                codisecurityStoreDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                codisecurityStoreDatabaseSettings.Value.DatabaseName);

            _rolCollection = mongoDatabase.GetCollection<Rol>(
                codisecurityStoreDatabaseSettings.Value.codisecurityCollectionName["rol"]);
        }

        public async Task<List<Rol>> GetAsync() =>
            await _rolCollection.Find(_ => true).ToListAsync();

        public async Task<Rol?> GetAsync(string id) =>
            await _rolCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Rol newRol) =>
            await _rolCollection.InsertOneAsync(newRol);

        public async Task UpdateAsync(string id, Rol updatedRol) =>
            await _rolCollection.ReplaceOneAsync(x => x.Id == id, updatedRol);

        public async Task RemoveAsync(string id) =>
            await _rolCollection.DeleteOneAsync(x => x.Id == id);

    }
}
