using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOiZ.Model
{
    public class CPTN : PreciseTrapNum
    {
        public CPTN(decimal a, decimal b, decimal c, decimal d) : base(a, b, c, d) { }

        public CPTN(decimal[] a, decimal[] b) : base(a, b) { }

        public static CPTN CutNumber(PreciseTrapNum ctn, decimal start, decimal end)
        {
            for (int i = 0; i < ctn.SlopeAb.Length; ++i)
            {
                if (ctn.SlopeAb[i] < start) ctn.SlopeAb[i] = start;
                if (ctn.SlopeAb[i] > end) ctn.SlopeAb[i] = end;

                if (ctn.SlopeDc[i] < start) ctn.SlopeDc[i] = start;
                if (ctn.SlopeDc[i] > end) ctn.SlopeDc[i] = end;
            }
            return new CPTN(ctn.SlopeAb, ctn.SlopeDc);
        }

        public static CPTN operator +(CPTN n1, CPTN n2) => CutNumber(n1 as PreciseTrapNum + n2, 0, 1);

        public static CPTN operator -(CPTN n1, CPTN n2) => CutNumber(n1 as PreciseTrapNum - n2, 0, 1);

        public static CPTN operator *(CPTN n1, CPTN n2) => CutNumber((n1 as PreciseTrapNum) * n2, 0, 1);

        public static CPTN operator /(CPTN n1, CPTN n2) => CutNumber((n1 as PreciseTrapNum) / n2, 0, 1);
    }
}
