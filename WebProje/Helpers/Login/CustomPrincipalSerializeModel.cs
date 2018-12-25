using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class CustomPrincipalSerializeModel
{
    public CustomPrincipalSerializeModel()
    {
        this.Roles = new List<string>();
    }

    public int ID { get; set; }
    public string Firstname { get; set; }
    public string Surname { get; set; }
    public string Mail { get; set; }
    public virtual List<string> Roles { get; set; }
}