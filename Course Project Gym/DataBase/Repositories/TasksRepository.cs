using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course_Project_Gym.DataBase.Repositories
{
    public class TasksRepository : IRepository<Tasks>
    {
        static TasksRepository instance = null;
        TasksRepository() { }

        public static TasksRepository GetInstance()
        {
            if (instance is null) instance = new TasksRepository();
            return instance;
        }

        DBContext context = SingletonDbContext.GetInstance();

        public void Add(Tasks item)
        {
            context.Tasks.Add(item);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            var task = Get(id);
            if(task !=null)
            {
                context.Tasks.Remove(task);
                context.SaveChanges();
            }
        }

        public Tasks Get(int id) => context.Tasks.ToList().FirstOrDefault(c => c.Id == id);

        public IEnumerable<Tasks> GetAll()
        {
            return context.Tasks.ToList();
        }

        public void Update(Tasks item)
        {
            var task = Get(item.Id);
            if(task != null)
            {
                task.Name = item.Name;
                task.About = item.About;

                context.Entry(task).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
