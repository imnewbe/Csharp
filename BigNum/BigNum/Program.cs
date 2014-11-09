using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BigNum
{
    public partial class Program
    {
        static void Main(string[] args)
        {
            String param1, param2, result;
            Boolean bPositive1, bPositive2;

            Console.Title = "大数计算器";

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("---------------------------------");
            Console.WriteLine("* 大数计算器 v1.0               *");
            Console.WriteLine("* 学校：北华航天工业学院        *");
            Console.WriteLine("* 日期：2014.9                  *");
            Console.WriteLine("---------------------------------");
            Console.WriteLine();

            while (true)
            {
                bPositive1 = InputValue(1, out param1);
                bPositive2 = InputValue(2, out param2);

                result = "";
                switch (InputOperator())
                {
                    case "+":
                        if (bPositive1 && bPositive2)
                        {
                            result = Add(param1, param2);
                        }
                        else
                        {
                            if ((!bPositive1) && (!bPositive2))
                            {
                                result = "-" + Add(param1, param2);
                            }
                            else
                            {
                                if (bPositive1)
                                {
                                    result = Subtract(param1, param2);
                                }
                                else
                                {
                                    result = Subtract(param2, param1);
                                }
                            }
                        }
                        break;

                    case "-":
                        if (bPositive1 && bPositive2)
                        {
                            result = Subtract(param1, param2);
                        }
                        else
                        {
                            if ((!bPositive1) && (!bPositive2))
                            {
                                result = Subtract(param2, param1);
                            }
                            else
                            {
                                if (bPositive1)
                                {
                                    result = Add(param1, param2);
                                }
                                else
                                {
                                    result = "-" + Add(param1, param2);
                                }
                            }
                        }
                        break;

                    case "*":
                        result = Multiply(param1, param2);
                        if (!(bPositive1 & bPositive2))
                        {
                            result = "-" + result;
                        }
                        break;

                    case "/":
                        if (param1 == "0")
                        {
                            result = "0";
                        }
                        if (param2 == "0")
                        {
                            result = "错误！除数不能为0！";
                            break;
                        }
                        if (bPositive1 && bPositive2)
                        {
                            result = Divide(param1, param2);
                        }
                        else
                        {
                            if ((!bPositive1) && (!bPositive2))
                            {
                                result = Divide(param1, param2);
                            }
                            else
                            {
                                result = "-" + Divide(param1, param2);
                            }
                        }
                        break;

                    default:
                        break;
                }

                Console.WriteLine();
                Console.WriteLine("运算结果为：" + result);

                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine();
                Console.WriteLine("按ESC退出，按其他任意键继续……");
                Console.WriteLine();
                ConsoleKeyInfo key = Console.ReadKey(false);
                if (key.Key == ConsoleKey.Escape)
                {
                    break;
                }
            }
        }
    }
}
