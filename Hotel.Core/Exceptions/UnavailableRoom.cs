using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Core.Exceptions
{
    public class UnavailableRoomException : Exception
    {
        public UnavailableRoomException(int roomNo) : base(String.Format($"Room ({roomNo}) is unavailable."))
        {

        }
    }
}
