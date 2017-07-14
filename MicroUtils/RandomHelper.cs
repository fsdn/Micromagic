using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MicroUtils
{
    /// <summary>
    /// 随机数据帮助类
    /// </summary>
    public class RandomHelper
    {
        /// <summary>
        /// 生成随机数，可以指定长度
        /// 键值包含 0-9、a-z、A-Z
        /// </summary>
        /// <param name="len"></param>
        /// <returns></returns>
        public static string GetGenerateRandomString(int len)
        {
            char[] keys ={
            '0','1','2','3','4','5','6','7','8','9',
            'a','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z',
            'A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z'};
            System.Threading.Thread.Sleep(3); // 睡眠毫秒，随机因子不同
            int key = unchecked((int)DateTime.Now.Ticks);
            Random rd = new Random(key);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < len; i++)
            {
                sb.Append(keys[rd.Next(keys.Length)]);
            }
            return sb.ToString();
        }

        /// <summary>
        /// 生成字母随机数，可以指定长度
        /// 键值包含 a-z、A-Z
        /// </summary>
        /// <param name="len"></param>
        /// <returns></returns>
        public static string GetLetterRandomString(int len)
        {
            char[] keys ={
            'a','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z',
            'A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z'};
            System.Threading.Thread.Sleep(3); // 睡眠毫秒，随机因子不同
            int key = unchecked((int)DateTime.Now.Ticks);
            Random rd = new Random(key);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < len; i++)
            {
                sb.Append(keys[rd.Next(keys.Length)]);
            }
            return sb.ToString();
        }

        /// <summary>
        /// 生成数字随机数，可以指定长度
        /// 键值包含 0-9
        /// </summary>
        /// <param name="len"></param>
        /// <returns></returns>
        public static string GetDigitRandomString(int len)
        {
            char[] keys = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            System.Threading.Thread.Sleep(3); // 睡眠毫秒，随机因子不同
            int key = unchecked((int)DateTime.Now.Ticks);
            Random rd = new Random(key);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < len; i++)
            {
                sb.Append(keys[rd.Next(keys.Length)]);
            }
            return sb.ToString();
        }

        /// <summary>
        /// 生成随机整数数组，并且每一个整数都不同
        /// </summary>
        /// <param name="len">长度，个数</param>
        /// <param name="minValue">最小值，限定大小</param>
        /// <param name="maxValue">最大值，限定大小</param>
        /// <returns></returns>
        public static int[] GetDigitDifferRandomArray(int len, int minValue, int maxValue)
        {
            Random ra = new Random(unchecked((int)DateTime.Now.Ticks));
            int[] arrNum = new int[len];
            int tmp = 0;
            for (int i = 0; i <= len - 1; i++)
            {
                tmp = ra.Next(minValue, maxValue); //随机取数
                arrNum[i] = GetDigitDifferChecked(arrNum, tmp, minValue, maxValue, ra); //取出值赋到数组中
            }
            return arrNum;
        }

        /// <summary>
        /// 检测随机数是否存在，若是存在则重新生成
        /// </summary>
        /// <param name="arrNum"></param>
        /// <param name="tmp"></param>
        /// <param name="minValue"></param>
        /// <param name="maxValue"></param>
        /// <param name="ra"></param>
        /// <returns></returns>
        private static int GetDigitDifferChecked(int[] arrNum, int tmp, int minValue, int maxValue, Random ra)
        {
            int n = 0;
            while (n <= arrNum.Length - 1)
            {
                if (arrNum[n] == tmp) //利用循环判断是否有重复
                {
                    tmp = ra.Next(minValue, maxValue); //重新随机获取。
                    tmp = GetDigitDifferChecked(arrNum, tmp, minValue, maxValue, ra);//递归:如果取出来的数字和已取得的数字有重复就重新随机获取。
                }
                n++;
            }
            return tmp;
        }

        /// <summary>
        /// 生成数字随机数（0 - len），可以指定最大值
        /// </summary>
        /// <param name="len"></param>
        public static int GetRngDigitRandomString(int len)
        {
            int ret = 0;
            byte[] rndSeries = new byte[8];
            RNGCryptoServiceProvider rngCrypto = new RNGCryptoServiceProvider();
            rngCrypto.GetBytes(rndSeries);

            decimal _base = (decimal)long.MaxValue;
            ret = (int)(Math.Abs(BitConverter.ToInt64(rndSeries, 0)) / _base * (len + 1));//不含100需去掉+1 
            return ret;
        }

    }
}
