using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course_Project_Gym.DataBase.Repositories
{
    public class SchedulesRepository : IRepository<Schedules>
    {
        static SchedulesRepository instance = null;

        SchedulesRepository() { }

        public static SchedulesRepository GetInstance()
        {
            if (instance is null) instance = new SchedulesRepository();
            return instance;
        }

        DBContext context = new DBContext();

        public void Add(Schedules item)
        {
            context.Schedules.Add(item);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            var schedules = Get(id);
            if (schedules != null)
            {
                context.Schedules.Remove(schedules);
                context.SaveChanges();
            }
        }

        public Schedules Get(int id) => context.Schedules.ToList().FirstOrDefault(c => c.Id == id);

        public IEnumerable<Schedules> GetAll()
        {
            return context.Schedules.ToList();
        }

        public IEnumerable<Schedules> GetAll(Func<Schedules, bool> predicate)
        {
            return context.Schedules.ToList().Where(predicate);
        }

        public void Update(Schedules item)
        {
            var schedules = Get(item.Id);
            if (schedules != null)
            {
                schedules.TimeStart = item.TimeStart;
                schedules.Services = item.Services;
                schedules.Duration = item.Duration;
                schedules.Coach = item.Coach;

                context.Entry(schedules).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
