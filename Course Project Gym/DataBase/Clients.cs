using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course_Project_Gym.DataBase
{
    class Clients
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string SurName { get; set; }
        public string PhoneNumber { get; set; }
        public Accounts Account { get; set; }
    }
}
