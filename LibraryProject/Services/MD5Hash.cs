using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Library.Services
{
    public class MD5Hash
    {
        public string HashPassword(string password)
        {
            var md5 = new MD5CryptoServiceProvider();
            var md5data = md5.ComputeHash(Encoding.Default.GetBytes(password));
            return Encoding.Default.GetString(md5data);
        }
    }
}
