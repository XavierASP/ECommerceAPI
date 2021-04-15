using ECommerceAPI.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceAPI.Data
{
    public interface IRepository<T> where T:class
    {
        IEnumerable<T> GetAll();
        T Get(int id);

        void Add(T command);

        void Update(T employee);

        void Delete(int id);

        bool SaveChanges();
    }
}
