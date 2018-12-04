using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course_Project_Gym.DataBase
{
    public class Complex
    {
        public int Id { get; set; }

        public string Name { get; set; }
        virtual public Address Address { get; set; }
        virtual public ICollection<AdditionalServices> AdditionalServices { get; set; }
        virtual public ICollection<News> News { get; set; }
        virtual public ICollection<Images> Images { get; set; }
    }
}
