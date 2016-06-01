using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitness.dto
{
    class Customer
    {
        public int id { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public string phone { get; set; }

        public Customer()
        {
                
        }
        public Customer(int id, string name, string address, string phone)
        {
            this.id = id;

            this.name = name;
            this.address = address;
            this.phone = phone;
        }
    }
}
