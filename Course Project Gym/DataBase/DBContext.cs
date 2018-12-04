using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course_Project_Gym.DataBase
{
    public class DBContext : DbContext 
    {
        static DBContext() => Database.SetInitializer(new DBInitializator());

        public DBContext() : base("myConnection") { }

        public DbSet<Accounts> Accounts { get; set; }
        public DbSet<AccountType> AccountTypes { get; set; }
        public DbSet<Clients> Clients { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<AdditionalServices> AdditionalServices { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Complex> Complexes { get; set; }
        public DbSet<Images> Images { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<Reputation> Reputations { get; set; }
        public DbSet<Schedules> Schedules { get; set; }
        public DbSet<Stocks> Stocks { get; set; }
        public DbSet<Streets> Streets { get; set; }
        public DbSet<StreetType> StreetTypes { get; set; }
        public DbSet<Subscriptions> Subscriptions { get; set; }
        public DbSet<SubscriptionType> SubscriptionTypes { get; set; }
        public DbSet<Address> Addresses { get; set; }
    }
}
