using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using MovieApp.Helpers.Interfaces;

namespace MovieApp.Helpers
{
    public class StringHasher : IStringHasher
    {
        public string HashGenerator(string input)
        {
            var md5 = new MD5CryptoServiceProvider();
            var md5Data = md5.ComputeHash(Encoding.ASCII.GetBytes(input));
            return Encoding.ASCII.GetString(md5Data);
        }
    }
}
