using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica.MVC.Logic
{
    public interface ILogic<T>
    {
        List<T> GetAll();

        T GetById(string id);

        List<T> GetByCountry(string country);

        void Add(T entity);

        void Update(T entity);

        void Delete(string id);

    }
}
