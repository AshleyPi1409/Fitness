using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitness.dto
{
    class Roles
    {
        public int id { get; set; }
        public string roleName { get; set; }
        public string description { get; set; }
        public bool active { get; set; }

        public Roles()
        {

        }
        public Roles(int id, string roleName , string description, bool active)
        {
            this.id = id;
            this.description = description;
            this.roleName = roleName;
            this.active = active;
        }
    }
}
