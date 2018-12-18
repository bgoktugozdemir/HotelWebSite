using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

public class EnumHelpers
{
    public int ID { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

    //Enum Description 
    public static string GetEnumDescription(Enum value)
    {
        FieldInfo fi = value.GetType().GetField(value.ToString());
        DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
        return (attributes.Length > 0) ? attributes[0].Description : value.ToString();
    }

    public static List<EnumHelpers> ConvertEnumToList(Type tnt)
    {
        Array enumValueList = Enum.GetValues(tnt);
        List<EnumHelpers> enumList = new List<EnumHelpers>();
        foreach (int item in enumValueList)
        {
            EnumHelpers enDto = new EnumHelpers();
            enDto.ID = item;
            enDto.Name = Enum.GetName(tnt, item);
            enDto.Description = GetEnumDescription((Enum)Enum.ToObject(tnt, enDto.ID));
            enumList.Add(enDto);
        }
        return enumList;
    }
}

