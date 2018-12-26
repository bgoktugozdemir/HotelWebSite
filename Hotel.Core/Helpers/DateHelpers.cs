using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

public class DateHelper
{
    public static bool Between(DateTime input, DateTime date1, DateTime date2)
    {
        return (input >= date1 && input <= date2);
    }
    public static bool Between(DateTime date1, DateTime date2)
    {
        DateTime input = DateTime.Today;
        return (input >= date1 && input <= date2);
    }

    public static bool IncludeDate(DateTime input, DateTime date1, DateTime date2)
    {
        return (input >= date1 || input <= date2);
    }
    public static bool IncludeDate(DateTime date1, DateTime date2)
    {
        DateTime input = DateTime.Today;
        return (input >= date1 || input <= date2);
    }

    public static bool AvailableDate(DateTime inputArrival, DateTime inputDeparture, DateTime dateArrival, DateTime dateDeparture)
    {
        if (inputArrival < dateArrival)
        {
            return (inputDeparture < dateArrival);
        }
        else if (inputArrival > dateArrival)
        {
            return (inputArrival > dateDeparture);
        }

        return false;
    }
    public static bool AvailableDate(DateTime date1, DateTime date2)
    {
        DateTime input = DateTime.Today;
        return (input >= date1 && input <= date2);
    }
}

