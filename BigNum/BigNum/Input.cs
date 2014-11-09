using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BigNum
{
    public partial class Program
    {
        /// <summary>
        /// 输入一个大数，若输入不合法的话提示错误，并再次输入，直至正确
        /// </summary>
        /// <param name="index">第几个大数</param>
        /// <param name="value">保存输入的大数，通过out可以返回</param>
        /// <returns>返回大数的正反</returns>
        public static bool InputValue(int index, out string value)
        {
            int subIndex;
            bool bPositive;
            string[] num = { "", "一", "二" };

            bPositive = true;
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.White;

                Console.WriteLine();
                Console.Write(string.Format("请输入参数{0}：", index));
                value = Console.ReadLine().Trim();
                if (value.StartsWith("+"))
                {
                    value = value.TrimStart('+');
                }
                if (value.StartsWith("-"))
                {
                    bPositive = false;
                    value = value.TrimStart('-');
                }
                value = value.Trim();

                subIndex = Isdigital(value);
                if (subIndex > value.Length)
                {
                    break;
                }

                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("错误：" + value.Substring(0, subIndex - 1));
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(value.Substring(subIndex, 1));
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write(value.Substring(subIndex + 1, value.Length - subIndex - 1));
                Console.WriteLine("不是有效的数字，请重新输入");
            }

            return bPositive;
        }

        public static string InputOperator()
        {
            string op;

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.White;

                Console.WriteLine();
                Console.Write("请输入运算符（+-*/）：");
                op = Console.ReadLine().Trim();

                if (op != "+" &&
                    op != "-" &&
                    op != "*" &&
                    op != "/")
                {
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine("运算符错误，请重新输入");
                }
                else
                {
                    return op;
                }
            }
        }

        /// <summary>
        /// 判断一个串是否是合法的数字
        /// </summary>
        /// <param name="value">要判断的串</param>
        /// <returns>返回第一个非法字符的下标，若没有非法字符，返回的结果为value.Length+1</returns>
        public static int Isdigital(string value)
        {
            int index;

            index = 1;
            foreach (char c in value.ToCharArray())
            {
                if (!Char.IsDigit(c))
                {
                    break;
                }
                index++;
            }

            return index;
        }

        /// <summary>
        /// 将字符串形的大数转变成整数数组，为下一步的计算做好准备
        /// </summary>
        /// <param name="str">要转变的字符串</param>
        /// <returns>返回转变后的整形数组</returns>
        public static int[] Reverse(string str)
        {
            int index;
            int[] intArray;
            char[] charArray;

            charArray = str.ToCharArray();
            Array.Reverse(charArray);

            intArray = new int[charArray.Length];
            for (index = 0; index < charArray.Length; index++)
            {
                intArray[index] = charArray[index] - '0';
            }

            return intArray;
        }

        /// <summary>
        /// 将整形数组转变成字符串
        /// </summary>
        /// <param name="value">要转换的整形数组</param>
        /// <returns>转换后的字符串</returns>
        private static string Reverse(int[] value)
        {
            char[] charArray;

            charArray = new char[value.Length];
            Array.Reverse(value);
            for (int index = 0; index < value.Length; index++)
            {
                charArray[index] = (char)(value[index] + '0');
            }

            return new string(charArray).TrimStart('0');
        }

        //比较字符串大小，大数X大返回真，大数Y大返回假，相等返回假
        private static bool Compare(string strX, string strY)
        {
            bool flag = false;
            if (strX.Length > strY.Length)
            {
                flag = true;
                return flag;
            }
            if (strX.Length < strY.Length)
            {
                return flag;
            }
            //到此步说明丙个数位数相同
            int length = strY.Length;
            int i;
            int[] int1 = new int[length];
            int[] int2 = new int[length];
            for (i = 0; i < length; i++)
            {
                int1[i] = Convert.ToInt32(strX.Substring(i, 1));//substring形参为int
                int2[i] = Convert.ToInt32(strY.Substring(i, 1));
            }
            for (i = 0; i < length; i++)
            {
                if (int1[i] > int2[i])
                {
                    flag = true;
                    break;
                }
                if (int1[i] < int2[i])
                {
                    flag = false;
                    break;
                }
            }
            return flag;
        }
    }
}
