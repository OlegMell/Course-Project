using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course_Project_Gym.DataBase.Repositories
{
    public class SubscriptionRepository : IRepository<Subscriptions>
    {
        static SubscriptionRepository instance = null;

        SubscriptionRepository() { }

        public static SubscriptionRepository GetInstance()
        {
            if (instance is null) instance = new SubscriptionRepository();
            return instance;
        }

        DBContext context = SingletonDbContext.GetInstance();

        public void Add(Subscriptions item)
        {
            context.Subscriptions.Add(item);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            var subscriptions = Get(id);
            if (subscriptions != null)
            {
                context.Subscriptions.Remove(subscriptions);
                context.SaveChanges();
            }
        }

        public Subscriptions Get(int id) => context.Subscriptions.ToList().FirstOrDefault(c => c.Id == id);

        public IEnumerable<Subscriptions> GetAll()
        {
            return context.Subscriptions.ToList();
        }

        public IEnumerable<Subscriptions> GetAll(Func<Subscriptions, bool> predicate)
        {
            return context.Subscriptions.ToList().Where(predicate);
        }

        public void Update(Subscriptions item)
        {
            var subscriptions = Get(item.Id);
            if (subscriptions != null)
            {
                subscriptions.StartDate = item.StartDate;
                subscriptions.Services = item.Services;
                subscriptions.Price = item.Price;
                subscriptions.SubscriptionType = item.SubscriptionType;
                subscriptions.EndDate = item.EndDate;

                context.Entry(subscriptions).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
