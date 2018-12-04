using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course_Project_Gym.DataBase.Repositories
{
    public class CityRepository : IRepository<City>
    {
        static CityRepository instance = null;

        CityRepository() { }

        public static CityRepository GetInstance()
        {
            if (instance is null) instance = new CityRepository();
            return instance;
        }

        DBContext context = new DBContext();

        public void Add(City item)
        {
            context.Cities.Add(item);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            var city = Get(id);
            if (city != null)
            {
                context.Cities.Remove(city);
                context.SaveChanges();
            }
        }

        public City Get(int id) => context.Cities.ToList().FirstOrDefault(c => c.Id == id);

        public IEnumerable<City> GetAll()
        {
            return context.Cities.ToList();
        }

        public IEnumerable<City> GetAll(Func<City, bool> predicate)
        {
            return context.Cities.ToList().Where(predicate);
        }

        public void Update(City item)
        {
            var city = Get(item.Id);
            if (city != null)
            {
                city.Name = item.Name;

                context.Entry(city).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
