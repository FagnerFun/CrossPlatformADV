using CrossPlatform.Domain.Interface.Repository;
using CrossPlatform.Domain.Interface.Service;
using CrossPlatform.Domain.Model;
using LiteDB;
using System.Collections.Generic;
using System.Linq;

namespace CrossPlatform.Infra.LiteDB
{
    public class Repository<T> : IRepository<T> where T : DBEntity
    {
        private string CollectionName { get { return nameof(T); } }
        
        private readonly IDataBaseAccessService dataBaseAccessService;

        public Repository(IDataBaseAccessService dataBaseAccessService)
        {
            this.dataBaseAccessService = dataBaseAccessService;
        }

        public void Add(T entity)
            => GetCollection().Insert(entity);

        public void Delete(T entity)
            => GetCollection().Delete(x => x.Id == entity.Id);

        public IEnumerable<T> GetAll()
            => GetCollection().FindAll().ToList();

        private LiteCollection<T> GetCollection()
        {
            var db = GetOrCreateLiteDatabase();
            return db.GetCollection<T>(CollectionName);
        }

        private LiteDatabase GetOrCreateLiteDatabase()
        {
            var dbPath = dataBaseAccessService.GetDataBasePath();
            return new LiteDatabase($@"{dbPath}");
        }

        public bool Exist(T Entity)
            => GetCollection().Exists(x => x.Id == Entity.Id);
    }
}
