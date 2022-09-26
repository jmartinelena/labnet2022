using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica.EF.Logic
{
    public interface ILogic<T>
    {
        List<T> GetAll();

        T GetById(string id);

        List<T> GetByCountry(string country);

    }
}
