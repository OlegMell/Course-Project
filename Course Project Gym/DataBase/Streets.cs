using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course_Project_Gym.DataBase
{
    public class Streets
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public int? CityId { get; set; }
        public City City { get; set; }
        public ICollection<Complex> Complices { get; set; }
    }
}
