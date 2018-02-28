using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IOiZ.Model;

namespace IOiZ.Charts
{
    public static class CountT
    {
        public static CTN Count()
        {
            var ctn = new TrapNumGenerator<CTN>();

            var UZM1 = ctn.GetObject(Probability.VerySmall);
            var UZM2 = ctn.GetObject(Probability.VerySmall);
            var UZS = ctn.GetObject(Probability.VerySmall);
            var UM = ctn.GetObject(Probability.Small);
            var US1 = ctn.GetObject(Probability.Average);
            var US2 = ctn.GetObject(Probability.Average);
            var AAP = ctn.GetObject(Probability.Average);
            var ASE = ctn.GetObject(Probability.Big);

            return (UZM1 * UZM2 + US1 + UZS + US2 + UM + AAP * ASE);
        }

        public static CPTN CountPrecise()
        {
            var ctn = new TrapNumGenerator<CPTN>();

            var UZM1 = ctn.GetObject(Probability.VerySmall);
            var UZM2 = ctn.GetObject(Probability.VerySmall);
            var UZS = ctn.GetObject(Probability.VerySmall);
            var UM = ctn.GetObject(Probability.Small);
            var US1 = ctn.GetObject(Probability.Average);
            var US2 = ctn.GetObject(Probability.Average);
            var AAP = ctn.GetObject(Probability.Average);
            var ASE = ctn.GetObject(Probability.Big);

            return (UZM1 * UZM2 + US1 + UZS + US2 + UM + AAP * ASE);
        }
    }
}
