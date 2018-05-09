using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aquaivy.Cryptography
{
    public class MD5
    {
        // MD5 长度32位

        public string GetMD5(byte[] bytes)
        {
            System.Security.Cryptography.MD5CryptoServiceProvider md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
            byte[] bytHash = md5.ComputeHash(bytes);
            md5.Clear();

            string sTemp = string.Empty;

            for (int i = 0; i < bytHash.Length; i++)
            {
                sTemp += bytHash[i].ToString("X").PadLeft(2, '0');
            }

            return sTemp.ToUpper();
        }

        public string GetMD5(string path)
        {
            return string.Empty;
        }
    }
}
