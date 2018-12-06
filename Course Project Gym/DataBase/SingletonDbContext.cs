using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course_Project_Gym.DataBase
{
    class SingletonDbContext
    {
        private static DBContext instance = null;

        SingletonDbContext() { }

        public static DBContext GetInstance()
        {
            if (instance == null)
                instance = new DBContext();
            return instance;
        }
    }
}
