using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course_Project_Gym.DataBase
{
    public class DBContext : DbContext
    {
        static DBContext() => Database.SetInitializer(new DBInitializator());

        public DBContext() : base("myConnection") { }
        
        //set...
    }
}
