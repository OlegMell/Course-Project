using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course_Project_Gym.DataBase
{
    public class AdditionalServices
    {
        public string Name { get; set; }
        public ICollection<Complex> Complexes { get; set; }
        public ICollection<Subscriptions> Subscriptions { get; set; }
    }
}
