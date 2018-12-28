using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hotel.Core.Exceptions;

public class ConvertHelpers
{
    public static int ConvertBoolToInt(bool value)
    {
        return value ? 1 : 0;
    }

    public static bool ConvertIntToBool(int value)
    {
        if (value == 1)
        {
            return true;
        }
        else if (value == 0)
        {
            return false;
        }

        throw new WrongValueException();
    }
}