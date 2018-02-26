﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOiZ.Model
{
    public class TrapezoidalNumber
    {
        public decimal A { get; }
        public decimal B { get; }
        public decimal C { get; }
        public decimal D { get; }

        public TrapezoidalNumber(decimal a, decimal b, decimal c, decimal d)
        {
            if (a > b || b > c || c > d)
                throw new WrongTrapezoidalNumberValuesException();

            A = a;
            B = b;
            C = c;
            D = d;
        }

        #region Overwritten Operators

        public static TrapezoidalNumber operator +(TrapezoidalNumber n1, TrapezoidalNumber n2)
        {
            return new TrapezoidalNumber(
                n1.A + n2.A,
                n1.B + n2.B,
                n1.C + n2.C,
                n1.D + n2.D);
        }

        public static TrapezoidalNumber operator -(TrapezoidalNumber n1, TrapezoidalNumber n2)
        {
            return new TrapezoidalNumber(
                n1.A - n2.D,
                n1.B - n2.C,
                n1.C - n2.B,
                n1.D - n2.A);
        }

        public static TrapezoidalNumber operator *(TrapezoidalNumber n1, TrapezoidalNumber n2)
        {
            return new TrapezoidalNumber(
                n1.A * n2.A,
                n1.B * n2.B,
                n1.C * n2.C,
                n1.D * n2.D);
        }

        public static TrapezoidalNumber operator /(TrapezoidalNumber n1, TrapezoidalNumber n2)
        {
            return new TrapezoidalNumber(
                n1.A / n2.D,
                n1.B / n2.C,
                n1.C / n2.B,
                n1.D / n2.A);
        }

        #endregion

        public override string ToString()
        {
            return $"A: {A}, B: {B}, C: {C}, D: {D}";
        }
    }
}
