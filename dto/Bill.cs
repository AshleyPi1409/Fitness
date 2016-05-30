using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitness.dto
{
    class Bill
    {
        public int id { get; set; }
        public int staff { get; set; }
        public int booked { get; set; }
        public DateTime date { get; set; }

        public Bill( int id ,int staff , int booked , DateTime date)
        {
            this.id = id;
            this.staff = staff;
            this.booked = booked;
            this.date = date;
        }
    }
}
