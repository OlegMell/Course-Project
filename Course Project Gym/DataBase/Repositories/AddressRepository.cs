using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course_Project_Gym.DataBase.Repositories
{
    public class AddressRepository : IRepository<Address>
    {
        static AddressRepository instance = null;

        AddressRepository() { }

        public static AddressRepository GetInstance()
        {
            if (instance is null) instance = new AddressRepository();
            return instance;
        }

        DBContext context = SingletonDbContext.GetInstance();

        public void Add(Address item)
        {
            context.Addresses.Add(item);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            var address = Get(id);
            if (address != null)
            {
                context.Addresses.Remove(address);
                context.SaveChanges();
            }
        }

        public Address Get(int id) => context.Addresses.ToList().FirstOrDefault(c => c.Id == id);

        public IEnumerable<Address> GetAll()
        {
            return context.Addresses.ToList();
        }

        public IEnumerable<Address> GetAll(Func<Address, bool> predicate)
        {
            return context.Addresses.ToList().Where(predicate);
        }

        public void Update(Address item)
        {
            var address = Get(item.Id);
            if (address != null)
            {
                address.Street = item.Street;
                address.City = item.City;
                address.House = item.House;

                context.Entry(address).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
