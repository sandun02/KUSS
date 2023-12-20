using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_Test
{
    public class Customer
    {
        public Customer()
        {
            chairs = new List<int>();
        }
        public string NameCustomer { get; set; }
        
        public string CustomerNo { get; set; }

        public List<int> chairs { get; set; }
        
        public double Price
        {

            get 
            {
              
                return chairs.Count * SeatsBooking.Tprice; 
            }
        }

        public override string ToString()
        {
            return this.NameCustomer;
        }

    }
}
