using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica.LINQ.Logic
{
    public class CustomerOrderJoined
    {
        public CustomerOrderJoined()
        {

        }

        public string CustomerID { get; set; }
        public DateTime? OrderDate { get; set; }

        public string Region { get; set; }

        public override string ToString()
        {
            return $"CustomerID: {CustomerID} - Region: {Region} - OrderDate: {OrderDate}";
        }
    }

}
