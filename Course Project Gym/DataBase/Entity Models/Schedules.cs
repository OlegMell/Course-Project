using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course_Project_Gym.DataBase
{
    public class Schedules
    {
        public int Id { get; set; }

        public DateTime TimeStart { get; set; }
        public int Duration { get; set; }
        public Staff Coach { get; set; }
        public AdditionalServices Services { get; set; }
    }
}
