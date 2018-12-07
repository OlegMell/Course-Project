using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course_Project_Gym.DataBase.Repositories
{
    public class StaffRepository : IRepository<Staff>
    {
        static StaffRepository instance = null;

        StaffRepository() { }

        public static StaffRepository GetInstance()
        {
            if (instance is null) instance = new StaffRepository();
            return instance;
        }

        DBContext context = SingletonDbContext.GetInstance();

        public void Add(Staff item)
        {
            context.Entry(item).State = EntityState.Added;
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            var staff = Get(id);
            if (staff != null)
            {
                context.Staffs.Remove(staff);
                context.SaveChanges();
            }
        }

        public Staff Get(int id) => context.Staffs.ToList().FirstOrDefault(c => c.Id == id);

        public IEnumerable<Staff> GetAll()
        {
            return context.Staffs.ToList();
        }

        public IEnumerable<Staff> GetAll(Func<Staff, bool> predicate)
        {
            return context.Staffs.ToList().Where(predicate);
        }

        public void Update(Staff item)
        {
            var staff = Get(item.Id);
            if (staff != null)
            {
                staff.Name = item.Name;
                staff.PhoneNumber = item.PhoneNumber;
                staff.Position = item.Position;
                staff.Account = item.Account;
                staff.Complex = item.Complex;
                staff.WorkExperience = item.WorkExperience;
                staff.SurName = item.SurName;

                context.Entry(staff).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
