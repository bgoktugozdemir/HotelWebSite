using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Core.Exceptions
{
    public class WrongValueException : Exception
    {
        public WrongValueException() : base(String.Format($"Wrong Value Convertion"))
        {

        }
    }
}
