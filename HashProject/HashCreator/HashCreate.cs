using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;

namespace HashCreator
{
    public enum HashType
    {
        MD5,
        SHA1,
        SHA256,
        SHA384,
        SHA512
    }
    public class HashCreate
    {
        public string CreateHash(HashType t,string szoveg)
        {
            string hash = "";
            if (t==HashType.MD5)
            {
                MD5CryptoServiceProvider hashprovider = new MD5CryptoServiceProvider();
                byte[] data;

                if (File.Exists(szoveg))
                {
                    data = File.ReadAllBytes(szoveg);

                } else
                {
                    data = new UTF8Encoding().GetBytes(szoveg);

                }
                hash = ByteToHash(hashprovider.ComputeHash(data));
            }
            else if (t==HashType.SHA1)
            {
                SHA1CryptoServiceProvider hashprovider = new SHA1CryptoServiceProvider();
                byte[] data;

                if (File.Exists(szoveg))
                {
                    data = File.ReadAllBytes(szoveg);

                }
                else
                {
                    data = new UTF8Encoding().GetBytes(szoveg);

                }
                hash = ByteToHash(hashprovider.ComputeHash(data));
            }
            else if (t==HashType.SHA256)
            {
                SHA256CryptoServiceProvider hashprovider = new SHA256CryptoServiceProvider();
                byte[] data;

                if (File.Exists(szoveg))
                {
                    data = File.ReadAllBytes(szoveg);

                }
                else
                {
                    data = new UTF8Encoding().GetBytes(szoveg);

                }
                hash = ByteToHash(hashprovider.ComputeHash(data));
            }
            else if (t==HashType.SHA384)
            {
                SHA384CryptoServiceProvider hashprovider = new SHA384CryptoServiceProvider();
                byte[] data;

                if (File.Exists(szoveg))
                {
                    data = File.ReadAllBytes(szoveg);

                }
                else
                {
                    data = new UTF8Encoding().GetBytes(szoveg);

                }
                hash = ByteToHash(hashprovider.ComputeHash(data));
            } else
            {
                SHA512CryptoServiceProvider hashprovider = new SHA512CryptoServiceProvider();
                byte[] data;

                if (File.Exists(szoveg))
                {
                    data = File.ReadAllBytes(szoveg);

                }
                else
                {
                    data = new UTF8Encoding().GetBytes(szoveg);

                }
                hash = ByteToHash(hashprovider.ComputeHash(data));
            }



            return hash;
        }

        private string ByteToHash(byte[] data)
        {
            StringBuilder stringhash = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                stringhash.Append(data[i].ToString("x2"));
            }

            return stringhash.ToString();
        }

    }
}
