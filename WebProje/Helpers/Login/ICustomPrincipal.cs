using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

public interface ICustomPrincipal
{
    int ID { get; set; }
    string Firstname { get; set; }
    string Surname { get; set; }
    string Mail { get; set; }
}