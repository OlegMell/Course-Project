using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course_Project_Gym.DataBase
{
    public class Accounts
    {
        public int Id { get; set; }

        public string Login { get; set; }
        public string Password { get; set; }
        public AccountType AccountType { get; set; }
    }
}
