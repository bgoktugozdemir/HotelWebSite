using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

public class CustomPrincipal : ICustomPrincipal
{
    public CustomPrincipal(string email, int ID, string Firstname, string Surname, string Image, List<string> Roles)
    {
        this.Identity = new GenericIdentity(email);
        this.Firstname = Firstname;
        this.Surname = Surname;
        this.Mail = email;
        this.Image = Image;
        this.ID = ID;
        this.Roles = Roles;

    }

    public virtual List<string> Roles { get; set; }

    public string Firstname
    {
        get; set;
    }

    public int ID
    {
        get; set;
    }

    public IIdentity Identity
    {
        get; private set;
    }

    public string Mail
    {
        get; set;
    }

    public string Surname
    {
        get; set;
    }

    public string Image
    {
        get; set;
    }

    public bool IsInRole(string role)
    {
        if (Roles.Contains(role))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}