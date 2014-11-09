using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BigNum
{
    public partial class Program
    {
        /// <summary>
        /// 大数相乘
        /// </summary>
        /// <param name="multiplicand">乘数</param>
        /// <param name="multiplier">被乘数</param>
        /// <returns>乘积，以字符串形式返回</returns>
        public static string Multiply(string num1, string num2)
        {
            int carry;
            int[] result;
            int[] multiplicand, multiplier;

            multiplicand = Reverse(num1);
            multiplier = Reverse(num2);

            result = new int[multiplicand.Length + multiplier.Length + 3];
            for (int indexMplier = 0; indexMplier < multiplier.Length; indexMplier++)
            {
                for (int indexMplicand = 0; indexMplicand < multiplicand.Length; indexMplicand++)
                {
                    result[indexMplier + indexMplicand] +=
                        multiplicand[indexMplicand] * multiplier[indexMplier];
                }
            }

            for (int index = 0; index < result.Length; index++)
            {
                carry = result[index] / 10;
                result[index] = result[index] % 10;

                if (carry > 0)
                {
                    result[index + 1] += carry;
                }
            }

            return Reverse(result);
        }
    }
}
