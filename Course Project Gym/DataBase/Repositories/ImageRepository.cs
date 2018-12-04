using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course_Project_Gym.DataBase.Repositories
{
    public class ImageRepository : IRepository<Images>
    {
        static ImageRepository instance = null;

        ImageRepository() { }

        public static ImageRepository GetInstance()
        {
            if (instance is null) instance = new ImageRepository();
            return instance;
        }

        DBContext context = new DBContext();

        public void Add(Images item)
        {
            context.Images.Add(item);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            var image = Get(id);
            if (image != null)
            {
                context.Images.Remove(image);
                context.SaveChanges();
            }
        }

        public Images Get(int id) => context.Images.ToList().FirstOrDefault(c => c.Id == id);

        public IEnumerable<Images> GetAll()
        {
            return context.Images.ToList();
        }

        public IEnumerable<Images> GetAll(Func<Images, bool> predicate)
        {
            return context.Images.ToList().Where(predicate);
        }

        public void Update(Images item)
        {
            var image = Get(item.Id);
            if (image != null)
            {
                image.Extension = item.Extension;
                image.Name = item.Name;
                image.Link = item.Link;

                context.Entry(image).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
