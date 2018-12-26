using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Core.Exceptions
{
    public class BookingDateException : Exception
    {
        public BookingDateException(DateTime arrivalDate, DateTime departureDate) : base(String.Format($"Arrival Date must be less than Departure Date! ({arrivalDate.ToShortDateString()} - {departureDate.ToShortDateString()})"))
        {

        }
    }
}
