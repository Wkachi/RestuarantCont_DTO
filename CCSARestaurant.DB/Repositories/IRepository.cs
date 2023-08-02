using CCSARestaurant.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCSARestaurant.DB.Repositories
{
    public interface IRepository<T> where T : Entity
    {
        T GetById(int id);
        List<T> GetAll();
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        void DeleteById(int id);
    }
}
