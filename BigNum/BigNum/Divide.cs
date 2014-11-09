using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BigNum
{
    public partial class Program
    {
        /// <summary>
        /// 大数相除
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <returns>商，以字符串形式返回</returns>
        private static string Divide(string num1, string num2)
        {
            string result = null;
            int id = 0;
            int newID = -1;//结果开始标志下标
            if (num1 == num2)
            {
                return ("1");
            }
            if (!Compare(num1, num2))
            {
                return "0";
            }
            bool tips = false;//结果开始标志          
            string partNum1 = null;//被除数部分
            string partRemain = "0";

            while (id < num1.Length)
            {
                int partResult = 0;//局部解
                //第一次取与大数Y相等的位数，之后依次取大数X剩下的每一位
                if (id == 0)
                {
                    partNum1 = num1.Substring(id, num2.Length);
                    id = num2.Length - 1;
                }
                else
                {
                    //当前几位num1的前几位能够整除掉num2,则将partnum1置为null,避免将01赋给partNum1,这样会报错
                    if (partNum1 == "0")
                    {
                        partNum1 = null;
                    }
                    //被除数不够，向后借位
                    partNum1 += num1.Substring(id, 1);
                }
                //除法运算开始
                if (partNum1 == num2)
                {
                    result += "1";
                    partNum1 = null;
                    id++;
                    continue;
                }
                partRemain = partNum1;
                //当num2>partNum1,不执行while里的代码，id++,返回上一个while
                while (!Compare(num2, partNum1))
                {
                    if (!Compare(num2, partRemain))
                    {
                        partResult++;
                    }
                    partRemain = Subtract(partRemain, num2);
                    partNum1 = partRemain;
                }
                result += partResult;
                id++;
            }

            //除数中首字符可能为0，以下代码去0
            for (id = 0; id < result.Length; id++)
            {
                if (!tips)
                {
                    if (result[id] != '0')
                    {
                        newID = id;
                        tips = true;
                        break;//当找到result字符串中第一个不为0的字符，结束循环
                    }
                }
            }
            if (newID >= 0)
            {
                result = result.Substring(newID, (result.Length - newID));
            }
            return result;
        }
    }
}
