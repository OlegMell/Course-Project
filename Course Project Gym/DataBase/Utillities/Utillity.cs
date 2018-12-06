using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Course_Project_Gym.DataBase.Utillities
{
    public class Utillity
    {
        static Utillity instance = null;
        Utillity() { }
        public static Utillity GetInstance()
        {
            if (instance is null) instance = new Utillity();
            return instance;
        }
        public string GetHash(string data) //MD5 хеширование паролей
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
