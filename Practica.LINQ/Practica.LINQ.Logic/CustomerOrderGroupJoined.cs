using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica.LINQ.Logic
{
    public class CustomerOrderGroupJoined
    {
        public CustomerOrderGroupJoined()
        {

        }

        public string CustomerID { get; set; }
        public int Count { get; set; }

        public override string ToString()
        {
            return $"CustomerID: {CustomerID} - Count: {Count}";
        }
    }
}
