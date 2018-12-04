using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Course_Project_Gym.DataBase.Repositories
{
    public class ComplexRepository : IRepository<Complex>
    {
        static ComplexRepository instance = null;

        ComplexRepository() { }

        public static ComplexRepository GetInstance()
        {
            if (instance is null) instance = new ComplexRepository();
            return instance;
        }

        DBContext context = new DBContext();

        public void Add(Complex item)
        {
            context.Complexes.Add(item);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
           var complex = Get(id);
            if (complex != null)
            {
                context.Complexes.Remove(complex);
                context.SaveChanges();
            }
        }

        public Complex Get(int id) => context.Complexes.ToList().FirstOrDefault(c => c.Id == id);

        public IEnumerable<Complex> GetAll()
        {
            return context.Complexes.ToList();
        }

        public IEnumerable<Complex> GetAll(Func<Complex, bool> predicate)
        {
            return context.Complexes.ToList().Where(predicate);
        }

        public void Update(Complex item)
        {
            var complex = Get(item.Id);
            if(complex != null)
            {
                complex.Name = item.Name;
                complex.Address = item.Address;
                complex.AdditionalServices = item.AdditionalServices;
                complex.News = item.News;
                complex.Images = item.Images;
                complex.Staffs = item.Staffs;

                context.Entry(complex).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
