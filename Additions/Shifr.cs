using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace TheBestQuiz.Additions
{
    static class Shifr
    {
        public static string GenerateSaltedHash(string inputData)
        {
            byte[] salt = GenerateSalt();
            byte[] saltedData = ConcatenateBytes(Encoding.UTF8.GetBytes(inputData), salt);
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashBytes = sha256.ComputeHash(saltedData);
                string hashString = BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
                return hashString;
            }
        }
        private static byte[] GenerateSalt()
        {
            byte[] salt = new byte[16];
            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(salt);
            }
            return salt;
        }
        private static byte[] ConcatenateBytes(byte[] a, byte[] b)
        {
            byte[] result = new byte[a.Length + b.Length];
            Buffer.BlockCopy(a, 0, result, 0, a.Length);
            Buffer.BlockCopy(b, 0, result, a.Length, b.Length);
            return result;
        }
        public static string SHA(string inputData)
        {
            using (HashAlgorithm hashAlgorithm = MD5.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(inputData);
                byte[] hashBytes = hashAlgorithm.ComputeHash(inputBytes);
                string hashString = BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
                return hashString;
            }
        }
        public static string MD(string inputData)
        {
            using (HashAlgorithm hashAlgorithm = MD5.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(inputData);
                byte[] hashBytes = hashAlgorithm.ComputeHash(inputBytes);
                string hashString = BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
                return hashString;
            }
        }
        public static string ShifrMy(string str)
        {
            str = Transponirovanie(str);
            int lenstr = str.Length;
            byte[] inputBytes = Encoding.ASCII.GetBytes(str);
            List<string> test = new List<string>();
            string all = "";
            for (int i = 0; i < inputBytes.Length; i++)
            {
                string s = Convert.ToString(inputBytes[i], 2);
                s = s.PadLeft(8, '0');
                test.Add(s);
                all += test[i];
            }
            int g = all.Length;
            all = PeidPepperCompress(all);
            DeShifrMy(all);
            return all;
        }
        private static string PeidPepperDicompress(string str)
        {
            var lst = str.Split('.').ToList();
            string all = "";
            for (int i = 0; i < lst.Count; i++)
            {
                string s = "";
                for (int j = 0; j < int.Parse(lst[i]) % 10; j++)
                {
                    s += lst[i][0];
                }
                all +=s;
            }
            return all;
        }
        /// <summary>
        /// Я третий день не сплю. Надо что-то менять в этом алгоритме...
        /// Возможно следовало использовать алгоритм ИЗЦЕНТРА-НАРУЖУ
        /// </summary>
        private static string PeidPepperCompress(string str)
        {
            int nowSchet = 1;
            char nowChar = str[0];
            string all = "";
            for (int i = 1; i < str.Length; i++)
            {
                if (str[i] != str[i - 1])
                {
                    all += nowChar;
                    all += nowSchet;
                    all += ".";
                    nowSchet = 0;
                }
                nowChar = str[i];
                nowSchet++;

            }
            all += nowChar;
            all += nowSchet;
            //var a = all.Split('.');
            int l1 = str.Length;
            int l2 = all.Length;
            return all;
        }//увеличивает в 1,32
        private static string Transponirovanie(string str)
        {
            int n = str.Length;
            for (int i = 0; i * i < str.Length; i++)
                n = i;
            n++;
            char[,] sample = new char[n, n];
            int nowCount = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (nowCount < str.Length)
                    {
                        sample[i, j] = str[nowCount];
                    }
                    else
                    {
                        sample[i, j] = ' ';
                    }
                    nowCount++;
                }
            }
            string all = "";
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {

                    all += sample[j, i];
                }
            }
            return all;
        }
        public static string DeShifrMy(string str)
        {
            str = PeidPepperDicompress(str);
            //byte[] inputBytes = Encoding.UTF8.GetBytes(str);
            List<string> testBin = new List<string>();
            List<string> test = new List<string>();
            string temp = "";
            string all = "";
            for (int i = 0; i < str.Length; i++)
            {
                temp += str[i];
                if (i % 8 == 7 && i != 0 || i == str.Length - 1)
                {
                    string result = Convert.ToString(Convert.ToInt32(temp, 2), 10);
                    testBin.Add(temp);
                    test.Add(result);
                    temp = "";
                    all += (char)(int.Parse(result));
                }
            }
            all = Transponirovanie(all).Trim();
            int l = all.Length;
            return all;
        }
    }
}
