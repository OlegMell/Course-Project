using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course_Project_Gym.DataBase.Repositories
{
    public class StreetRepository : IRepository<Streets>
    {
        static StreetRepository instance = null;

        StreetRepository() { }

        public static StreetRepository GetInstance()
        {
            if (instance is null) instance = new StreetRepository();
            return instance;
        }

        DBContext context = SingletonDbContext.GetInstance();

        public void Add(Streets item)
        {
            context.Streets.Add(item);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            var street = Get(id);
            if (street != null)
            {
                context.Streets.Remove(street);
                context.SaveChanges();
            }
        }

        public Streets Get(int id) => context.Streets.ToList().FirstOrDefault(c => c.Id == id);

        public IEnumerable<Streets> GetAll()
        {
            return context.Streets.ToList();
        }

        public IEnumerable<Streets> GetAll(Func<Streets, bool> predicate)
        {
            return context.Streets.ToList().Where(predicate);
        }

        public void Update(Streets item)
        {
            var street = Get(item.Id);
            if (street != null)
            {
                street.Name = item.Name;
                street.StreetType = item.StreetType;

                context.Entry(street).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}