using CrossPlatform.Domain.Interface.Repository;
using CrossPlatform.Domain.Interface.Service;
using CrossPlatform.Domain.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CrossPlatform.Infra.SQLite
{
    public class Repository<T> : SQLiteConnection, IDisposable, IRepository<T> where T : DBEntity, new()
    {
        private readonly IDataBaseAccessService dataBaseAccessService;

        public Repository(IDataBaseAccessService dataBaseAccessService): base(dataBaseAccessService.GetDataBasePath())
        {
            this.dataBaseAccessService = dataBaseAccessService;

            CreateTable<T>();
        }

        public void Add(T entity)
        {
            try
            {
                BeginTransaction();
                Insert(entity);
                Commit();
            }
            catch
            {
                Rollback();
            }
        }

        public void Delete(T entity)
        {
            try
            {
                BeginTransaction();
                Delete(entity);
                Commit();
            }
            catch
            {
                Rollback();
            }
        }

        public bool Exist(T Entity)
        {
            return (from c in Table<T>() where c.Id == Entity.Id select c).Any();
        }

        public IEnumerable<T> GetAll()
        {
            return (from c in Table<T>() select c);
        }
    }
}
