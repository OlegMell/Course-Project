using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course_Project_Gym.DataBase
{
    public class News
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string About { get; set; }
        public DateTime DateNews { get; set; }
        virtual public Complex Complex { get; set; }
    }
}
