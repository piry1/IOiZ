using System.Collections.Generic;

namespace IOiZ.Model
{
    public class TrapNum
    {
        public decimal A { get; set; }
        public decimal B { get; set; }
        public decimal C { get; set; }
        public decimal D { get; set; }

        public TrapNum(decimal a, decimal b, decimal c, decimal d)
        {
            if (a > b || b > c || c > d)
                throw new WrongTrapezoidalNumberValuesException("Incorrect trapnum values");

            A = a;
            B = b;
            C = c;
            D = d;
        }

        public List<Point> GetPoints()
        {
            var points = new List<Point>
            {
                new Point(A, 0),
                new Point(B, 1),
                new Point(C, 1),
                new Point(D, 0)
            };

            return points;
        }

        #region Overwritten Operators

        public static TrapNum operator +(TrapNum n1, TrapNum n2)
        {
            return new TrapNum(
                n1.A + n2.A,
                n1.B + n2.B,
                n1.C + n2.C,
                n1.D + n2.D);
        }

        public static TrapNum operator -(TrapNum n1, TrapNum n2)
        {
            return new TrapNum(
                n1.A - n2.A,
                n1.B - n2.B,
                n1.C - n2.C,
                n1.D - n2.D);
        }

        public static TrapNum operator *(TrapNum n1, TrapNum n2)
        {
            return new TrapNum(
                n1.A * n2.A,
                n1.B * n2.B,
                n1.C * n2.C,
                n1.D * n2.D);
        }

        public static TrapNum operator /(TrapNum n1, TrapNum n2)
        {
            return new TrapNum(
                n1.A / n2.D,
                n1.B / n2.C,
                n1.C / n2.B,
                n1.D / n2.A);
        }

        #endregion

        public override string ToString()
        {
            return $"{A}\t{B}\t{C}\t{D}";
        }
    }
}
