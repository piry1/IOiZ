using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
