using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOiZ.Model
{
    public class Point
    {
        public decimal X { get; set; }
        public decimal Y { get; set; }

        public Point(decimal x, decimal y)
        {
            X = x;
            Y = y;
        }
    }
}
