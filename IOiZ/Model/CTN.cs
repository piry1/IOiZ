using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOiZ.Model
{
    public class CTN : TrapNum
    {
        public CTN(decimal a, decimal b, decimal c, decimal d) : base(a, b, c, d)
        {
        }

        public static CTN CutNumber(TrapNum ctn, decimal start, decimal end)
        {
            if (start > end)
                throw new Exception();

            if (ctn.A < start) ctn.A = start;
            if (ctn.B < start) ctn.B = start;
            if (ctn.C < start) ctn.C = start;
            if (ctn.D < start) ctn.D = start;

            if (ctn.A > end) ctn.A = end;
            if (ctn.B > end) ctn.B = end;
            if (ctn.C > end) ctn.C = end;
            if (ctn.D > end) ctn.D = end;

            return new CTN(ctn.A, ctn.B, ctn.C, ctn.D);
        }

        public static CTN operator +(CTN n1, CTN n2) => CutNumber(n1 as TrapNum + n2, 0, 1);

        public static CTN operator -(CTN n1, CTN n2) => CutNumber(n1 as TrapNum - n2, 0, 1);

        public static CTN operator *(CTN n1, CTN n2) => CutNumber((n1 as TrapNum) * n2, 0, 1);

        public static CTN operator /(CTN n1, CTN n2) => CutNumber((n1 as TrapNum) / n2, 0, 1);

    }
}
