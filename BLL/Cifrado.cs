using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace UI
{
    public class Cifrado
    {
        public static string Encriptar(String cadena, Boolean metodo)
        {
            if (metodo)
            {
                byte[] bytes = Encoding.ASCII.GetBytes(cadena);

                return Convert.ToBase64String(bytes);
            }
            else
            {
                byte[] bytes = Encoding.ASCII.GetBytes(cadena);
                MD5 md5 = new MD5CryptoServiceProvider();
                md5.ComputeHash(bytes);

                byte[] result = md5.Hash;

                StringBuilder strBuilder = new StringBuilder();
                for (int i = 0; i < result.Length; i++)
                {
                    //change it into 2 hexadecimal digits  
                    //for each byte  
                    strBuilder.Append(result[i].ToString("x2"));
                }

                return strBuilder.ToString();
            }
        }

        public static string Desencriptar(String cadena)
        {
            byte[] cad_byte = Convert.FromBase64String(cadena);
            return Encoding.ASCII.GetString(cad_byte);
        }
    }
}
