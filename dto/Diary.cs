using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitness.dto
{
    class Diary
    {
        public int id { get; set; }
        public int account { get; set; }
        public DateTime date { get; set; }
        public string description { get; set; }

        public Diary()
        {

        }
        public Diary(int id,int account, DateTime date, string description)
        {
            this.id = id;
            this.account = account;
            this.date = date;
            this.description = description;
        }
    }
}
