using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitness.dto
{
    class Accounts
    {
        public int id { get; set; }
        public string accountName { get; set; }
        public string passWord { get; set; }
        public string fullName { get; set; }
        public int role { get; set; }

        public bool active { get; set; }
        public Accounts()
        {
                
        }
        public Accounts(int id, string accountName, string passWord, string fullName, int role, bool active)
        {
            this.id = id;
            this.accountName = accountName;
            this.fullName = fullName;
            this.passWord = passWord;
            this.role = role;
            this.active = active;
        }
       
    }
}
