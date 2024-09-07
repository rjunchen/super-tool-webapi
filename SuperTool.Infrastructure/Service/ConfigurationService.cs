using Microsoft.Extensions.Options;
using MongoDB.Driver;
using SuperTool.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperTool.Infrastructure.Service
{
    public class ConfigurationService
    {
        private readonly IMongoCollection<Configuration> _configurationsCollection;

        public ConfigurationService(IOptions<SuperToolDatabaseSettings> superToolDatabaseSettings) {
            var mongoClient = new MongoClient(superToolDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(superToolDatabaseSettings.Value.DatabaseName);

            _configurationsCollection = mongoDatabase.GetCollection<Configuration>(superToolDatabaseSettings.Value.ConfigurationCollectionName);
        }

        public async Task<List<Configuration>> GetAsync() =>
       await _configurationsCollection.Find(_ => true).ToListAsync();

        public async Task<Configuration?> GetAsync(string id) =>
            await _configurationsCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Configuration newConfiguration) =>
            await _configurationsCollection.InsertOneAsync(newConfiguration);

        public async Task UpdateAsync(string id, Configuration updatedConfiguration) =>
            await _configurationsCollection.ReplaceOneAsync(x => x.Id == id, updatedConfiguration);

        public async Task RemoveAsync(string id) =>
            await _configurationsCollection.DeleteOneAsync(x => x.Id == id);
    }
}
