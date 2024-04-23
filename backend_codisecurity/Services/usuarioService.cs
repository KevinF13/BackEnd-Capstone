using backend_codisecurity.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;


namespace backend_codisecurity.Services
{

    public class usuarioService
    {
        private readonly IMongoCollection<Usuarios> _usuariosCollection;

        public usuarioService(
            IOptions<codisecurityStoreDatabaseSettings> codisecurityStoreDatabaseSettings)
        {
            var mongoClient = new MongoClient(
                codisecurityStoreDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                codisecurityStoreDatabaseSettings.Value.DatabaseName);

            _usuariosCollection = mongoDatabase.GetCollection<Usuarios>(
                codisecurityStoreDatabaseSettings.Value.codisecurityCollectionName["usuarios"]);
        }

        public async Task<List<Usuarios>> GetAsync() =>
            await _usuariosCollection.Find(_ => true).ToListAsync();

        public async Task<Usuarios?> GetAsync(string id) =>
            await _usuariosCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Usuarios newUsuarios) =>
            await _usuariosCollection.InsertOneAsync(newUsuarios);

        public async Task UpdateAsync(string id, Usuarios updatedUsuarios) =>
            await _usuariosCollection.ReplaceOneAsync(x => x.Id == id, updatedUsuarios);

        public async Task RemoveAsync(string id) =>
            await _usuariosCollection.DeleteOneAsync(x => x.Id == id);

    }
}
