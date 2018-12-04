using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course_Project_Gym.DataBase.Repositories
{
    
    public class PositionRepository : IRepository<Position>
    {
        static PositionRepository instance = null;

        PositionRepository() { }

        public static PositionRepository GetInstance()
        {
            if (instance is null) instance = new PositionRepository();
            return instance;
        }

        DBContext context = new DBContext();

        public void Add(Position item)
        {
            context.Positions.Add(item);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            var position = Get(id);
            if (position != null)
            {
                context.Positions.Remove(position);
                context.SaveChanges();
            }
        }

        public Position Get(int id) => context.Positions.ToList().FirstOrDefault(c => c.Id == id);

        public IEnumerable<Position> GetAll()
        {
            return context.Positions.ToList();
        }

        public IEnumerable<Position> GetAll(Func<Position, bool> predicate)
        {
            return context.Positions.ToList().Where(predicate);
        }

        public void Update(Position item)
        {
            var position = Get(item.Id);
            if (position != null)
            {
                position.Name = item.Name;
                
                context.Entry(position).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
