using Practica.MVC.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica.MVC.Logic
{
    public abstract class BaseLogic<T> : ILogic<T>
    {
        protected readonly NorthwindContext _context;

        public BaseLogic()
        {
            _context = new NorthwindContext();
        }

        public abstract void Add(T entity);
        public abstract void Delete(string id);
        public abstract List<T> GetAll();
        public abstract List<T> GetByCountry(string country);
        public abstract T GetById(string id);
        public abstract void Update(T entity);
    }
}
