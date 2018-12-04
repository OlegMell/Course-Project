using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course_Project_Gym.DataBase.Repositories
{
    interface IRepository<T> where T : class
    {
        T Get(int id);

        void Update(T item);

        void Delete(int id);

        void Add(T item);

        IEnumerable<T> GetAll();
    }
}
