using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Course_Project_Gym.DataBase.Repositories
{
    public class AccountRepository : IRepository<Accounts>
    {
        static AccountRepository instance = null;

        AccountRepository() { }

        public static AccountRepository GetInstance()
        {
            if (instance is null) instance = new AccountRepository();
            return instance;
        }

        DBContext context = new DBContext();

        public void Add(Accounts item)
        {
            context.Accounts.Add(item);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            var account = Get(id);
            if (account != null)
            {
                context.Accounts.Remove(account);
                context.SaveChanges();
            }
        }

        public Accounts Get(int id) => context.Accounts.ToList().FirstOrDefault(c => c.Id == id);

        public Accounts Get(string login) => context.Accounts.ToList().FirstOrDefault(c => c.Login.Equals(login));
        
        public IEnumerable<Accounts> GetAll()
        {
            return context.Accounts.ToList();
        }

        public IEnumerable<Accounts> GetAll(Func<Accounts, bool> predicate)
        {
            return context.Accounts.ToList().Where(predicate);
        }

        public void Update(Accounts item)
        {
            var account = Get(item.Id);
            if (account != null)
            {
                account.Login = item.Login;
                account.Password = item.Password;
                account.AccountType = item.AccountType;

                context.Entry(account).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
