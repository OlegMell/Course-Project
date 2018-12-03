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
    class DBInitializator : DropCreateDatabaseAlways<DBContext>
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

            context.Entry(accountType).State = EntityState.Added;
            context.Entry(accountType2).State = EntityState.Added;
            context.Entry(accountType3).State = EntityState.Added;
            context.SaveChanges();
            
            
            Complex complex = new Complex
            {
                Name = "Sport Fit",
                Images = new List<Images>(),
                News = new List<News>(),
                AdditionalServices = new List<AdditionalServices>(),
                Address = new Address
                {
                    City = new City { Name = "Днепр" },
                    Street = new Streets { Name = "Дмитрия Яворницкого", StreetType = new StreetType { NameType = "проспект" } },
                    House = "3"
                }
            };

            Images images = new Images();

            string path = @"C:\Users\olegm\source\repos\Course-Project\Course Project Gym\gym.ipg";
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
                Position = new Position { Name = "Администратор" },
                Account = new Accounts
                {
                    Login = "admin",
                    Password = pass,
                    AccountType = accountType2
                }
            };

            context.Entry(admin).State = EntityState.Added;
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
