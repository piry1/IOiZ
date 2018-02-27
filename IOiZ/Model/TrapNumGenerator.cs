using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOiZ.Model
{
    public class TrapNumGenerator<T>
    {

        public T GetObject(Probability probability)
        {
            decimal a = 0, b = 0, c = 0, d = 0;
            GetTrapezParams(probability, ref a, ref b, ref c, ref d);
            object[] args = new object[] { a, b, c, d };
            return (T)Activator.CreateInstance(typeof(T), args);
        }

        //public static TrapNum TrapNum(Probability probability)
        //{
        //    decimal a = 0, b = 0, c = 0, d = 0;
        //    GetTrapezParams(probability, ref a, ref b, ref c, ref d);
        //    return new TrapNum(a, b, c, d);
        //}

        //public static PreciseTrapNum PreciseTrapNum(Probability probability)
        //{
        //    decimal a = 0, b = 0, c = 0, d = 0;
        //    GetTrapezParams(probability, ref a, ref b, ref c, ref d);
        //    return new PreciseTrapNum(a, b, c, d);
        //}

        //public static CTN CTN(Probability probability)
        //{
        //    decimal a = 0, b = 0, c = 0, d = 0;
        //    GetTrapezParams(probability, ref a, ref b, ref c, ref d);
        //    return new CTN(a, b, c, d);
        //}

        //public static CPTN CPTN(Probability probability)
        //{
        //    decimal a = 0, b = 0, c = 0, d = 0;
        //    GetTrapezParams(probability, ref a, ref b, ref c, ref d);
        //    return new CPTN(a, b, c, d);
        //}



        private static void GetTrapezParams(Probability probability, ref decimal a, ref decimal b, ref decimal c, ref decimal d)
        {
            switch (probability)
            {
                case Probability.VerySmall:
                    a = (decimal)Math.Pow(10, -10);
                    b = (decimal)Math.Pow(10, -10);
                    c = (decimal)Math.Pow(10, -8);
                    d = (decimal)Math.Pow(10, -7);
                    break;
                case Probability.Small:
                    a = (decimal)Math.Pow(10, -8);
                    b = (decimal)Math.Pow(10, -7);
                    c = (decimal)Math.Pow(10, -6);
                    d = (decimal)Math.Pow(10, -5);
                    break;
                case Probability.Average:
                    a = (decimal)Math.Pow(10, -6);
                    b = (decimal)Math.Pow(10, -5);
                    c = (decimal)Math.Pow(10, -4);
                    d = (decimal)Math.Pow(10, -3);
                    break;
                case Probability.Big:
                    a = (decimal)Math.Pow(10, -4);
                    b = (decimal)Math.Pow(10, -3);
                    c = (decimal)Math.Pow(10, -2);
                    d = (decimal)Math.Pow(10, -1);
                    break;
                case Probability.VeryBig:
                    a = (decimal)Math.Pow(10, -2);
                    b = (decimal)Math.Pow(10, -1);
                    c = 1m;
                    d = 1m;
                    break;
            }
        }
    }
}
