using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course_Project_Gym.DataBase.Repositories
{
    public class StreetTypeRepository : IRepository<StreetType>
    {
        static StreetTypeRepository instance = null;

        StreetTypeRepository() { }

        public static StreetTypeRepository GetInstance()
        {
            if (instance is null) instance = new StreetTypeRepository();
            return instance;
        }

        DBContext context = SingletonDbContext.GetInstance();

        public void Add(StreetType item)
        {
            context.StreetTypes.Add(item);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            var streetType = Get(id);
            if (streetType != null)
            {
                context.StreetTypes.Remove(streetType);
                context.SaveChanges();
            }
        }

        public StreetType Get(int id) => context.StreetTypes.ToList().FirstOrDefault(c => c.Id == id);

        public IEnumerable<StreetType> GetAll()
        {
            return context.StreetTypes.ToList();
        }

        public IEnumerable<StreetType> GetAll(Func<StreetType, bool> predicate)
        {
            return context.StreetTypes.ToList().Where(predicate);
        }

        public void Update(StreetType item)
        {
            var streetType = Get(item.Id);
            if (streetType != null)
            {
                streetType.NameType = item.NameType;

                context.Entry(streetType).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
