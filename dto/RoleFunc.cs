using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitness.dto
{
    class RoleFunc
    {
        public int id { get; set; }
        public int roleID { get; set; }
        public bool active { get; set; }
            
        public int funcID { get; set; }

        public RoleFunc(int id,int roleID, int funcID,bool active)
        {
            this.id = id;
            this.roleID = roleID;
            this.active = active;
            this.funcID = funcID;
        }
    }
}
