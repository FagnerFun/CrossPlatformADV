using System;
using System.Collections.Generic;
using System.Text;

namespace CrossPlatform.Domain.Interface.Repository
{
    public interface IRepository<T>  where  T : class
    {
        void Add(T entity);
        void Delete(T entity);
        IEnumerable<T> GetAll();
        bool Exist(T Entity);
    }
}
