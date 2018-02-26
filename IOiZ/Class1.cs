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
            var A = new TrapNum(1, 2, 3, 4);
            var B = new TrapNum(2, 3, 4, 5);

            var C = A / B;

            var ptn1 = new PreciseTrapNum(1, 2, 3, 4);
            var ptn2 = new PreciseTrapNum(2, 3, 4, 5);
            var ptn = ptn1 / ptn2;
            Console.WriteLine(ptn);

            Console.WriteLine(C);
            Console.WriteLine("END");
            Console.ReadLine();
        }
    }
}
