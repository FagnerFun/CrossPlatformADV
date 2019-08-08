using CrossPlatform.Domain.Interface.Repository;
using CrossPlatform.Domain.Model;
using System;
using System.Collections.Generic;

namespace CrossPlatform.Infra.SQLite
{
    public class Repository<T> : IRepository<T> where T : DBEntity
    {
        public void Add(T entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public bool Exist(T Entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
