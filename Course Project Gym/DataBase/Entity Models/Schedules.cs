using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Course_Project_Gym.DataBase
{
    public class Schedules
    {
        public int Id { get; set; }

        public DateTime TimeStart { get; set; }
        public DateTime Date { get; set; }
        public int Duration { get; set; }
        public Staff Coach { get; set; }
        public AdditionalServices Services { get; set; }
    }
}
