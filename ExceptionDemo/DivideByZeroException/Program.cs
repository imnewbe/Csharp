using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DivideByZero
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 30;
            int b = 0;
            int c = 0;
            try
            {
                c = a / b;
            }
            catch (DivideByZeroException e)
            {
                Console.WriteLine("e.Message= "+e.Message);
                Console.WriteLine("e.Source= "+e.Source);
                Console.WriteLine("e.ToString()= "+e.ToString());
                return;
            }
            Console.WriteLine("a={0} b={1} a/b={2}", a,b,c);
        }
    }
}
