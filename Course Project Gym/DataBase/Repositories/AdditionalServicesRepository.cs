using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course_Project_Gym.DataBase.Repositories
{
    public class AdditionalServicesRepository : IRepository<AdditionalServices>
    {
        static AdditionalServicesRepository instance = null;

        AdditionalServicesRepository() { }

        public static AdditionalServicesRepository GetInstance()
        {
            if (instance is null) instance = new AdditionalServicesRepository();
            return instance;
        }

        DBContext context = new DBContext();

        public void Add(AdditionalServices item)
        {
            context.AdditionalServices.Add(item);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            var image = Get(id);
            if (image != null)
            {
                context.AdditionalServices.Remove(image);
                context.SaveChanges();
            }
        }

        public AdditionalServices Get(int id) => context.AdditionalServices.ToList().FirstOrDefault(c => c.Id == id);

        public IEnumerable<AdditionalServices> GetAll()
        {
            return context.AdditionalServices.ToList();
        }

        public IEnumerable<AdditionalServices> GetAll(Func<AdditionalServices, bool> predicate)
        {
            return context.AdditionalServices.ToList().Where(predicate);
        }

        public void Update(AdditionalServices item)
        {
            var additional = Get(item.Id);
            if (additional != null)
            {
                additional.Name = item.Name;
                additional.Subscriptions = item.Subscriptions;
                additional.Complexes = item.Complexes;

                context.Entry(additional).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
