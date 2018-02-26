using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOiZ.Model
{
    public class PreciseTrapNum
    {
        private const int Precision = 3;
        public decimal[] SlopeAb { get; } = new decimal[Precision];
        public decimal[] SlopeDc { get; } = new decimal[Precision];

        public PreciseTrapNum(decimal a, decimal b, decimal c, decimal d)
        {
            if (a > b || b > c || c > d)
                throw new WrongTrapezoidalNumberValuesException();
            InitSlopes(a, b, c, d);
        }

        public PreciseTrapNum(decimal[] slopeAb, decimal[] slopeDc)
        {
            CheckSlopes(slopeAb, slopeDc);
            SlopeAb = slopeAb.ToArray();
            SlopeDc = slopeDc.ToArray();
        }

        #region Overwriting operators

        public static PreciseTrapNum operator +(PreciseTrapNum n1, PreciseTrapNum n2)
        {
            var newSlopeAb = new decimal[Precision];
            var newSlopeDc = new decimal[Precision];

            for (int i = 0; i < Precision; ++i)
            {
                newSlopeAb[i] = n1.SlopeAb[i] + n2.SlopeAb[i];
                newSlopeDc[i] = n1.SlopeDc[i] + n2.SlopeDc[i];
            }

            return new PreciseTrapNum(newSlopeAb, newSlopeDc);
        }

        public static PreciseTrapNum operator -(PreciseTrapNum n1, PreciseTrapNum n2)
        {
            var newSlopeAb = new decimal[Precision];
            var newSlopeDc = new decimal[Precision];

            for (int i = 0; i < Precision; ++i)
            {
                newSlopeAb[i] = n1.SlopeAb[i] - n2.SlopeDc[i];
                newSlopeDc[i] = n1.SlopeDc[i] - n2.SlopeAb[i];
            }

            return new PreciseTrapNum(newSlopeAb, newSlopeDc);
        }

        public static PreciseTrapNum operator *(PreciseTrapNum n1, PreciseTrapNum n2)
        {
            var newSlopeAb = new decimal[Precision];
            var newSlopeDc = new decimal[Precision];

            for (int i = 0; i < Precision; ++i)
            {
                newSlopeAb[i] = n1.SlopeAb[i] * n2.SlopeAb[i];
                newSlopeDc[i] = n1.SlopeDc[i] * n2.SlopeDc[i];
            }

            return new PreciseTrapNum(newSlopeAb, newSlopeDc);
        }

        public static PreciseTrapNum operator /(PreciseTrapNum n1, PreciseTrapNum n2)
        {
            var newSlopeAb = new decimal[Precision];
            var newSlopeDc = new decimal[Precision];

            for (int i = 0; i < Precision; ++i)
            {
                newSlopeAb[i] = n1.SlopeAb[i] / n2.SlopeDc[i];
                newSlopeDc[i] = n1.SlopeDc[i] / n2.SlopeAb[i];
            }

            return new PreciseTrapNum(newSlopeAb, newSlopeDc);
        }

        #endregion

        private void CheckSlopes(params decimal[][] slopes)
        {
            if (slopes == null)
                throw new ArgumentNullException(nameof(slopes));

            if (slopes.Any(slope => slope.Length != Precision))
                throw new WrongTrapezoidalNumberValuesException("Unequal slopes precision");
        }

        private void InitSlopes(decimal a, decimal b, decimal c, decimal d)
        {
            decimal step1 = (b - a) / (Precision - 1);
            decimal step2 = (d - c) / (Precision - 1);

            for (var i = 0; i < SlopeAb.Length; ++i)
                SlopeAb[i] = a + step1 * i;

            for (var i = 0; i < SlopeDc.Length; ++i)
                SlopeDc[i] = d - step2 * i;

        }

        public override string ToString()
        {
            string slopeAb = "", slopeDc = "";
            foreach (var value in SlopeAb)
                slopeAb += " " + value;
            foreach (var value in SlopeDc)
                slopeDc += " " + value;

            return $"slopeAB: {slopeAb}\nslopeDc: {slopeDc}";
        }
    }


}

