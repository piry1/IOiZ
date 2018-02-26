using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IOiZ.Model;

namespace IOiZ
{
    public static class Class1
    {
        public static void Main()
        {
            Console.WriteLine("Start");
            var A = new TrapezoidalNumber(1, 2, 3, 4);
            var B = new TrapezoidalNumber(2, 3, 4, 5);

            var C = A - A;

            Console.WriteLine(C);
            Console.WriteLine("END");
            Console.ReadLine();
        }
    }
}
