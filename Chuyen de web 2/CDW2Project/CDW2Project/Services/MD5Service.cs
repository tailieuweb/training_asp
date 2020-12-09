using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CDW2Project.Services
{
    public class MD5Service
    {
        private static int _numberUp = 1;
        public string GetHashId()
        {
            Guid getGuid = Guid.NewGuid();
            string articleId = getGuid.ToString() + _numberUp++;
            MD5 md5 = new MD5CryptoServiceProvider();
            // Compute hash from the bytes of text
            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(articleId));
            // Get hash result after compute it
            byte[] result = md5.Hash;
            StringBuilder strBuilder = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                strBuilder.Append(result[i].ToString("x2"));
            }
            return strBuilder.ToString();
        }
    }
}
