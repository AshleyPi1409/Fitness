using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitness.dto
{
    class Booked
    {
        public int id { get; set; }
        public int customer { get; set; }
        public int staff { get; set; }
        public int course { get; set; }
        public DateTime startDay { get; set; }
        public bool paid { get; set; }

        public Booked()
        {

        }
        public Booked(int id,int customer, int staff, int course, DateTime startDay, bool paid)
        {
            this.id = id;
            this.course = course;
            this.customer = customer;
            this.staff = staff;
            this.startDay = startDay;
            this.paid = paid;
        }

    }
}
