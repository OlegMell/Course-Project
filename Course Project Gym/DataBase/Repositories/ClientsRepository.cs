using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course_Project_Gym.DataBase.Repositories
{
    public class ClientsRepository : IRepository<Clients>
    {
        static ClientsRepository instance = null;

        ClientsRepository() { }

        public static ClientsRepository GetInstance()
        {
            if (instance is null) instance = new ClientsRepository();
            return instance;
        }

        DBContext context = new DBContext();

        public void Add(Clients item)
        {
            context.Clients.Add(item);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            var client = Get(id);
            if (client != null)
            {
                context.Clients.Remove(client);
                context.SaveChanges();
            }
        }

        public Clients Get(int id) => context.Clients.ToList().FirstOrDefault(c => c.Id == id);

        public IEnumerable<Clients> GetAll()
        {
            return context.Clients.ToList();
        }

        public IEnumerable<Clients> GetAll(Func<Clients, bool> predicate)
        {
            return context.Clients.ToList().Where(predicate);
        }

        public void Update(Clients item)
        {
            var client = Get(item.Id);
            if (client != null)
            {
                client.Name = item.Name;
                client.PhoneNumber = item.PhoneNumber;
                client.Account = item.Account;
                client.SurName = item.SurName;

                context.Entry(client).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}