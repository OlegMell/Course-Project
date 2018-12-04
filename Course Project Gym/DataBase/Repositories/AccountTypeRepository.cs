using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course_Project_Gym.DataBase.Repositories
{
    public class AccountTypeRepository : IRepository<AccountType>
    {
        static AccountTypeRepository instance = null;

        AccountTypeRepository() { }

        public static AccountTypeRepository GetInstance()
        {
            if (instance is null) instance = new AccountTypeRepository();
            return instance;
        }

        DBContext context = new DBContext();

        public void Add(AccountType item)
        {
            context.AccountTypes.Add(item);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            var accountType = Get(id);
            if (accountType != null)
            {
                context.AccountTypes.Remove(accountType);
                context.SaveChanges();
            }
        }

        public AccountType Get(int id) => context.AccountTypes.ToList().FirstOrDefault(c => c.Id == id);

        public IEnumerable<AccountType> GetAll()
        {
            return context.AccountTypes.ToList();
        }

        public IEnumerable<AccountType> GetAll(Func<AccountType, bool> predicate)
        {
            return context.AccountTypes.ToList().Where(predicate);
        }

        public void Update(AccountType item)
        {
            var accountType = Get(item.Id);
            if (accountType != null)
            {
                accountType.Name = item.Name;

                context.Entry(accountType).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
