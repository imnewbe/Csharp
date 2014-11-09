using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BigNum
{
    public partial class Program
    {
        /// <summary>
        /// 大数相加
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <returns>和，以字符串形式返回</returns>
        public static string Add(string num1, string num2)
        {
            string result = null;
            if (num1 == "0" && num2 == "0")
            {
                return "0";
            }
            else
            {
                int carry;//进位
                int id;
                string max, min;
                if (num1.Length > num2.Length)
                {
                    max = num1;
                    min = num2;
                }
                else  //包含num1.length<=num2.length
                {
                    max = num2;
                    min = num1;
                }

                int[] intMin = Reverse(min);
                int[] intMax = Reverse(max);
                int[] intSum = new int[max.Length + 1];
                //加法核心代码
                carry = 0;
                for (id = 0; id < min.Length; id++)
                {
                    if (intMax[id] + intMin[id] > 9)
                    {
                        intSum[id] = intMin[id] + intMax[id] - 10 + carry;
                        carry = 1;
                    }
                    else
                    {
                        intSum[id] = intMax[id] + intMin[id] + carry;
                        carry = 0;
                    }
                }
                /*上一个for循环，id++,完成加法运算，分别处理两个大数的位数的两种情况  */
                if (min.Length != max.Length)
                {
                    //两个大数的位数不同时，，且已经完成相等的加法运算，只需将位数较大的剩下位数加到intSum数组里
                    for (; id < max.Length; id++)
                    {
                        if (intMax[id] + carry > 9)
                        {
                            intSum[id] = intMax[id] + carry - 10;
                            carry = 1;
                        }
                        else
                        {
                            intSum[id] = intMax[id] + carry;
                            carry = 0;
                        }
                    }
                }
                intSum[id] = carry;

                result = Reverse(intSum);
                return result;
            }
        }
    }
}
