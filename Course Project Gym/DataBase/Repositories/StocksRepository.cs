using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course_Project_Gym.DataBase.Repositories
{
    public class StocksRepository : IRepository<Stocks>
    {
        static StocksRepository instance = null;

        StocksRepository() { }

        public static StocksRepository GetInstance()
        {
            if (instance is null) instance = new StocksRepository();
            return instance;
        }

        DBContext context = new DBContext();

        public void Add(Stocks item)
        {
            context.Stocks.Add(item);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            var stocks = Get(id);
            if (stocks != null)
            {
                context.Stocks.Remove(stocks);
                context.SaveChanges();
            }
        }

        public Stocks Get(int id) => context.Stocks.ToList().FirstOrDefault(c => c.Id == id);

        public IEnumerable<Stocks> GetAll()
        {
            return context.Stocks.ToList();
        }

        public IEnumerable<Stocks> GetAll(Func<Stocks, bool> predicate)
        {
            return context.Stocks.ToList().Where(predicate);
        }

        public void Update(Stocks item)
        {
            var stocks = Get(item.Id);
            if (stocks != null)
            {
                stocks.Name = item.Name;
                stocks.StartDate = item.StartDate;
                stocks.EndDate = item.EndDate;
                stocks.AmountOfDiscount = item.AmountOfDiscount;
                stocks.About = item.About;

                context.Entry(stocks).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
