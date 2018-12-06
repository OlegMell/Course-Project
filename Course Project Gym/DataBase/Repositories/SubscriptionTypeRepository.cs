using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course_Project_Gym.DataBase.Repositories
{
    public class SubscriptionTypeRepository : IRepository<SubscriptionType>
    {
        static SubscriptionTypeRepository instance = null;

        SubscriptionTypeRepository() { }

        public static SubscriptionTypeRepository GetInstance()
        {
            if (instance is null) instance = new SubscriptionTypeRepository();
            return instance;
        }

        DBContext context = SingletonDbContext.GetInstance();

        public void Add(SubscriptionType item)
        {
            context.SubscriptionTypes.Add(item);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            var subscriptionType = Get(id);
            if (subscriptionType != null)
            {
                context.SubscriptionTypes.Remove(subscriptionType);
                context.SaveChanges();
            }
        }

        public SubscriptionType Get(int id) => context.SubscriptionTypes.ToList().FirstOrDefault(c => c.Id == id);

        public IEnumerable<SubscriptionType> GetAll()
        {
            return context.SubscriptionTypes.ToList();
        }

        public IEnumerable<SubscriptionType> GetAll(Func<SubscriptionType, bool> predicate)
        {
            return context.SubscriptionTypes.ToList().Where(predicate);
        }

        public void Update(SubscriptionType item)
        {
            var subscriptionType = Get(item.Id);
            if (subscriptionType != null)
            {
                subscriptionType.Name = item.Name;

                context.Entry(subscriptionType).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}