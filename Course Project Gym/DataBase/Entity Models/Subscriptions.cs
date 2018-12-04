using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course_Project_Gym.DataBase
{
    public class Subscriptions
    {
        public int Id { get; set; }

        public decimal Price { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public ICollection<AdditionalServices> Services { get; set; }
        virtual public SubscriptionType SubscriptionType { get; set; }
    }
}
