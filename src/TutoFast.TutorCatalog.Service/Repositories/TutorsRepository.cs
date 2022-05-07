using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
using TutoFast.TutorCatalog.Service.Entities;

namespace TutoFast.TutorCatalog.Service.Repositories
{

    public class TutorsRepository : ITutorsRepository
    {
        private const string collectionName = "tutors"; // store the tutors, similar to tables in relational DBs
        private readonly IMongoCollection<Tutor> dbCollection;
        private readonly FilterDefinitionBuilder<Tutor> filterBuilder = Builders<Tutor>.Filter;
        public TutorsRepository(IMongoDatabase database)
        {
            dbCollection = database.GetCollection<Tutor>(collectionName);
        }
        public async Task<IReadOnlyCollection<Tutor>> GetAllAsync()// asynchronous programming
        {
            return await dbCollection.Find(filterBuilder.Empty).ToListAsync(); // retorna todoslos tutors de la DB
        }
        public async Task<Tutor> GetAsync(Guid id)
        {
            FilterDefinition<Tutor> filter = filterBuilder.Eq(entity => entity.Id, id);
            return await dbCollection.Find(filter).FirstOrDefaultAsync();
        }
        public async Task CreateAsync(Tutor entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            await dbCollection.InsertOneAsync(entity);
        }
        public async Task UpdateAsync(Tutor entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            FilterDefinition<Tutor> filter = filterBuilder.Eq(existingEntity => existingEntity.Id, entity.Id);
            await dbCollection.ReplaceOneAsync(filter, entity);
        }
        public async Task RemoveAsync(Guid id)
        {
            FilterDefinition<Tutor> filter = filterBuilder.Eq(entity => entity.Id, id);
            await dbCollection.DeleteOneAsync(filter);
        }
    }
}