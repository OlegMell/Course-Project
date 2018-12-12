using System;
using System.Collections.Generic;
using System.IO;
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
        public string ByteToImage(Images img) //перевод байтов в картинку
        {
            string fullFileName = img.Name + img.Extension;
            using (FileStream fs = new FileStream(fullFileName, FileMode.OpenOrCreate, FileAccess.Write, FileShare.ReadWrite))
            {
                fs.Write(img.Link, 0, img.Link.Length);
            }

            return fullFileName;
        }
        public Images ImageToByte(string pathImg) //перевод картинки в байты
        {
            byte[] bytes;
            using (FileStream fs = new FileStream(pathImg, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                bytes = new byte[fs.Length];
                fs.Read(bytes, 0, bytes.Length);
            }

            FileInfo fileInfo = new FileInfo(pathImg);
            Images image = new Images
            {
                Name = fileInfo.Name.Substring(0, fileInfo.Name.LastIndexOf('.')),
                Extension = fileInfo.Extension,
                Link = bytes
            };
            return image;
        }
    }
}
