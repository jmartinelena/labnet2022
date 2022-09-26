using Practica.EF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica.EF.Logic
{
    public class CustomerLogic : BaseLogic, ILogic<Customers>
    {
        public List<Customers> GetAll()
        {
            return _context.Customers.ToList();
        }
    }
}
