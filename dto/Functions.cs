using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitness.dto
{
    class Functions
    {
        public int id { get; set; }
        public string funcName { get; set; }
        public string description { get; set; }
        public bool active { get; set; }
        public Functions(int id,string funcName, string description,bool active)
        {
            this.id = id;
            this.description = description;
            this.funcName = funcName;
            this.active = active;
        }
    }
}
