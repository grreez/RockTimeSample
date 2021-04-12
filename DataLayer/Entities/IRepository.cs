using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities
{
    public interface IRepository<T> : IDisposable
    {
        IQueryable<T> All { get; }
        T Default { get; }
        T Find(int ID);
        void InsertOrUpdate(T entity);
        void Delete(T entity);
        bool Save();

    }
}
