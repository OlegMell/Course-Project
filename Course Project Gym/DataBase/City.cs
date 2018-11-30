using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course_Project_Gym.DataBase
{
    public class City
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public ICollection<Streets> Streets { get; set; }
    }
}
