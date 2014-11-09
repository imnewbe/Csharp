using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;

namespace BigInt
{
    class Program
    {
        static void Main(string[] args)
        {
            BigInteger num1, num2;

            Console.Write("请输入参数1：");
            num1 = BigInteger.Parse(Console.ReadLine().Trim());

            Console.Write("请输入参数2：");
            num2 = BigInteger.Parse(Console.ReadLine().Trim());

            Console.WriteLine("和：" + BigInteger.Add(num1, num2));
            Console.WriteLine("差：" + BigInteger.Subtract(num1, num2));
            Console.WriteLine("积：" + BigInteger.Multiply(num1, num2));
            Console.WriteLine("商：" + BigInteger.Divide(num1, num2));

            Console.ReadKey();
        }
    }
}
