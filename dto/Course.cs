using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitness.dto
{
    class Course
    {
        public int id { get; set; }
        public string name { get; set; }
        public decimal months { get; set; }
        public decimal price { get; set; }
        public int type { get; set; }
        public bool active { get; set; }

        public Course(int id , string name, decimal months, decimal price, int type, bool active)
        {
            this.id = id;
            this.name = name;
            this.months = months;
            this.price = price;
            this.type = type;
            this.active = active;
        }
    }
}
