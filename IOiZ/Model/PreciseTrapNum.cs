using System;
using System.Collections.Generic;
using System.Linq;

namespace IOiZ.Model
{
    public class PreciseTrapNum
    {
        private const int Precision = 64;
        public decimal[] SlopeAb { get; set; } = new decimal[Precision];
        public decimal[] SlopeDc { get; set; } = new decimal[Precision];

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

        public List<Point> GetPoints()
        {
            var points = new List<Point>();
            const decimal step = 1m / (Precision - 1);

            for (int i = 0; i < Precision; ++i)
                points.Add(new Point(SlopeAb[i], step * i));

            for (int i = Precision - 1; i >= 0; --i)
                points.Add(new Point(SlopeDc[i], step * i));

            return points;
        }

        public static PreciseTrapNum Convert(TrapNum tn)
        {
            return new PreciseTrapNum(tn.A, tn.B, tn.C, tn.D);
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
                newSlopeAb[i] = n1.SlopeAb[i] - n2.SlopeAb[i];
                newSlopeDc[i] = n1.SlopeDc[i] - n2.SlopeDc[i];
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
    }


}

