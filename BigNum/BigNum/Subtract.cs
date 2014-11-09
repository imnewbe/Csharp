using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BigNum
{
    public partial class Program
    {
        /// <summary>
        /// 大数相减
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <returns>差，以字符串形式返回</returns>
        public static string Subtract(string num1, string num2)
        {
            bool sign = false;//差的符号位，若符号位为假，则为正数，真，为负数
            string result = null;
            string max, min;//被减数和减数
            int back;//退位
            int id;//下标
            bool tips = false;//开始位，非零位
            int length;//被减数位数（max）
            if (num1 == num2)
            {
                return "0";
            }
            if (Compare(num1, num2))
            {
                max = num1;
                min = num2;
                length = max.Length;
            }
            else
            {
                max = num2;
                min = num1;
                length = max.Length;
                sign = true;
            }
            int[] intMax = new int[length];
            int[] intMin = new int[length];
            int[] intResult = new int[length];
            Array.Clear(intMax, 0, length);
            Array.Clear(intMin, 0, length);
            Array.Clear(intResult, 0, length);
            //将字符串倒置入数组中
            for (id = 0; id < length; id++)
            {
                intMax[id] = Convert.ToInt32(max.Substring((length - 1 - id), 1));
            }
            for (id = 0; id < min.Length; id++)
            {
                intMin[id] = Convert.ToInt32(min.Substring((min.Length - 1 - id), 1));
            }
            //减法核心代码
            back = 0;
            for (id = 0; id < length; id++)
            {
                if ((intMax[id] - back) < intMin[id])
                {
                    intResult[id] = intMax[id] + 10 - intMin[id] - back;
                    back = 1;
                }
                else
                {
                    intResult[id] = intMax[id] - intMin[id] - back;
                    back = 0;
                }
            }
            id = id - 1;/*如果不减1，id会超出intResult[length]，例如两个5位数相减完成时,id为6，但intResult[5] */
            if (sign)
            {
                result += "-";
            }

            result += Reverse(intResult);
            return result;
        }
    }
}
