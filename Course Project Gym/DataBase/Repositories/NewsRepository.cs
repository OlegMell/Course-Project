using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course_Project_Gym.DataBase.Repositories
{
    public class NewsRepository : IRepository<News>
    {
        static NewsRepository instance = null;

        NewsRepository() { }

        public static NewsRepository GetInstance()
        {
            if (instance is null) instance = new NewsRepository();
            return instance;
        }

        DBContext context = new DBContext();

        public void Add(News item)
        {
            context.News.Add(item);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            var News = Get(id);
            if (News != null)
            {
                context.News.Remove(News);
                context.SaveChanges();
            }
        }

        public News Get(int id) => context.News.ToList().FirstOrDefault(c => c.Id == id);

        public IEnumerable<News> GetAll()
        {
            return context.News.ToList();
        }

        public IEnumerable<News> GetAll(Func<News, bool> predicate)
        {
            return context.News.ToList().Where(predicate);
        }

        public void Update(News item)
        {
            var News = Get(item.Id);
            if (News != null)
            {
                News.DateNews = item.DateNews;
                News.About = item.About;
                News.Name = item.Name;

                context.Entry(News).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
