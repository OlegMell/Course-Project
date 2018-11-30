using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course_Project_Gym.DataBase
{
    public class Complex
    {
        public string Name { get; set; }

        public int? AddressId { get; set; }
        public Streets Street { get; set; }

        public ICollection<AdditionalServices> AdditionalServices { get; set; }
    }
}
