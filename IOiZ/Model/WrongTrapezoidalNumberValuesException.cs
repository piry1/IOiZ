using System;

namespace IOiZ.Model
{
    public class WrongTrapezoidalNumberValuesException : Exception
    {
        public WrongTrapezoidalNumberValuesException()
            : base()
        {
        }

        public WrongTrapezoidalNumberValuesException(String message)
            : base(message)
        {
        }

    }
}
