using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course_Project_Gym.DataBase.Repositories
{
    public class ReputationRepository : IRepository<Reputation>
    {
        static ReputationRepository instance = null;

        ReputationRepository() { }

        public static ReputationRepository GetInstance()
        {
            if (instance is null) instance = new ReputationRepository();
            return instance;
        }

        DBContext context = SingletonDbContext.GetInstance();

        public void Add(Reputation item)
        {
            context.Reputations.Add(item);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            var reputation = Get(id);
            if (reputation != null)
            {
                context.Reputations.Remove(reputation);
                context.SaveChanges();
            }
        }

        public Reputation Get(int id) => context.Reputations.ToList().FirstOrDefault(c => c.Id == id);

        public IEnumerable<Reputation> GetAll()
        {
            return context.Reputations.ToList();
        }

        public IEnumerable<Reputation> GetAll(Func<Reputation, bool> predicate)
        {
            return context.Reputations.ToList().Where(predicate);
        }

        public void Update(Reputation item)
        {
            var reputation = Get(item.Id);
            if (reputation != null)
            {
                reputation.Reviews = item.Reviews;
                reputation.Mark = item.Mark;
                reputation.Complex = item.Complex;
                
                context.Entry(reputation).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
