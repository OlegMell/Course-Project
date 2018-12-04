using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Course_Project_Gym.DataBase
{
    class DBInitializator : DropCreateDatabaseIfModelChanges<DBContext>
    {
        protected override void Seed(DBContext context)
        {
            #region Инициализация комплекса полностью

            AccountType accountType = new AccountType
            {
                Name = "Тренер"
            };
            AccountType accountType2 = new AccountType
            {
                Name = "Администратор"
            };
            AccountType accountType3 = new AccountType
            {
                Name = "Клиент"
            };

            Position position = new Position
            {
                Name = "Тренер"
            };

            Position position2 = new Position
            {
                Name = "Администартор"
            };



            context.Entry(accountType).State = EntityState.Added;
            context.Entry(accountType2).State = EntityState.Added;
            context.Entry(accountType3).State = EntityState.Added;
            context.SaveChanges();

            City city = new City
            {
                Name = "Днепр"
            };

            City city2 = new City
            {
                Name="Киев"
            };

            StreetType streetType = new StreetType
            {
                NameType="Проспект"
            };

            streetType = new StreetType
            {
                NameType = "Улица"
            };

            Streets street = new Streets
            {
                Name = "Дмитрия Яворницкого",
                StreetType = streetType
            };
            context.Entry(city).State = EntityState.Added;
            context.Entry(city2).State = EntityState.Added;
            context.Entry(streetType).State = EntityState.Added;
            context.Entry(street).State = EntityState.Added;
            context.SaveChanges();

            Complex complex = new Complex
            {
                Name = "Sport Fit",
                Images = new List<Images>(),
                News = new List<News>(),
                AdditionalServices = new List<AdditionalServices>(),
                Address = new Address
                {
                    City = city,
                    Street =street,
                    House = "3"
                }
            };            

            Images images = new Images();

            string path = @"gym.ipg";
            FileInfo fi = new FileInfo(path);

            images.Name = fi.Name.Substring(0, fi.Name.LastIndexOf('.'));
            images.Extension = fi.Extension;

            byte[] img;
            using (FileStream fs = new FileStream("gym.jpg", FileMode.Open))
            {
                img = new byte[fs.Length];
                fs.Read(img, 0, img.Length);
            }

            images.Link = img;
            
            complex.Images.Add(images);
            context.Entry(complex).State = EntityState.Added;
            context.SaveChanges();

            #endregion

            #region Инициализация аккаунта админа

            var pass = GetHash("admin");

            Staff admin = new Staff
            {
                Name = "Павел",
                SurName = "Дуров",
                PhoneNumber = "0950505055",
                WorkExperience = 1.5f,
                Position = position2,
                Account = new Accounts
                {
                    Login = "admin",
                    Password = pass,
                    AccountType = accountType2
                },
                Complex = complex
           
            };
            context.Entry(admin).State = EntityState.Added;
            context.SaveChanges();

            Staff coach = new Staff
            {
                Name = "Oleg",
                SurName = "Melnik",
                PhoneNumber = "0505555551",
                WorkExperience = 10,
                Position = position,
                Account = new Accounts
                {
                    Login = "coach",
                    Password = "coach1",
                    AccountType = accountType
                },
                Complex = complex
                
            };
            context.Entry(coach).State = EntityState.Added;
            context.SaveChanges();

            coach = new Staff
            {
                Name = "Kirill",
                SurName = "Goyda",
                PhoneNumber = "0505555553",
                WorkExperience = 2,
                Position = position,
                Account = new Accounts
                {
                    Login = "coach2",
                    Password = "coach2",
                    AccountType = accountType
                },
                Complex = complex

            };
            context.Entry(coach).State = EntityState.Added;
            context.SaveChanges();

            AdditionalServices additionalServices = new AdditionalServices
            {
                Name="Pool"

            };
            context.Entry(additionalServices).State = EntityState.Added;
            context.SaveChanges();

            SubscriptionType subscriptionType = new SubscriptionType
            {
                Name = "Безлимит"
            };

            Subscriptions subscriptions = new Subscriptions
            {
                Price = 350,
                SubscriptionType = subscriptionType,
                StartDate = new DateTime(2018, 12, 04),
                EndDate = new DateTime(2019,01,04)
            };

            context.Entry(subscriptionType).State = EntityState.Added;
            context.Entry(subscriptions).State = EntityState.Added;
            context.SaveChanges();

            Schedules schedules = new Schedules
            {
                TimeStart = new DateTime(2018, 04, 12, 12, 10, 00),
                Duration = 1,
                Coach = coach,
                Services = additionalServices
            };
            context.Entry(schedules).State = EntityState.Added;
            context.SaveChanges();

            

            #endregion

            //продолжить инициализацию...
        }

        private static string GetHash(string data) //MD5 хеширование паролей
        {
            MD5 md5 = MD5.Create();
            byte[] bytes = md5.ComputeHash(Encoding.Default.GetBytes(data));

            StringBuilder builder = new StringBuilder();

            foreach (var b in bytes)
            {
                builder.Append(b.ToString("x2"));
            }
            return builder.ToString();
        } 
    }
}
