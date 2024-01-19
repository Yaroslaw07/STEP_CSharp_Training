using System;
using System.Collections.Generic;
using System.Text;

namespace Design_Pattern_Repository_
{
    public interface IRepository<T>
    {
        IEnumerable<T> Get();

        T Get(int id);

        void Add(T entity);

        void Update(T entity);

        void Delete(int id);
    }
}
