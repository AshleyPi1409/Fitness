using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitness.dao
{
    class Type
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public bool active { get; set; }

        public Type(int id, string name, string description, bool active)
        {
            this.id = id;
            this.name = name;
            this.description = description;
            this.active = active;           

        }
    }
}
