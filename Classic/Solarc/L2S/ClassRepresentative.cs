using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for Representative
/// </summary>
public class ClassRepresentative
{
    private string name = string.Empty, address = string.Empty, phone = string.Empty, fax = string.Empty, email = string.Empty, cc = string.Empty;

    public string Name
    {
        get { return name; }
        set { name = value; }
    }
    public string Address
    {
        get { return address; }
        set { address = value; }
    }
    public string Phone
    {
        get { return phone; }
        set { phone = value; }
    }
    public string Fax
    {
        get { return fax; }
        set { fax = value; }
    }
    public string Email
    {
        get { return email; }
        set { email = value; }
    }
    public string CC
    {
        get { return cc; }
        set { cc = value; }
    }

    public ClassRepresentative()
    {
        Name = string.Empty;
        Address = string.Empty;
        Phone = string.Empty;
        Fax = string.Empty;
        Email = string.Empty;
    }
    public ClassRepresentative(string theName, string theAddress, string thePhone, string theFax, string theEmail)
    {
        Name = theName;
        Address = theAddress;
        Phone = thePhone;
        Fax = theFax;
        Email = theEmail;
	}
    public ClassRepresentative(int theRepresentativeId)
    {
        DataTable dt = DataBase.DataTable("select Name,Address,CarbonCopy from tb_Representative where RepresentativeId=" + theRepresentativeId);
        if (dt.Rows.Count>0)
        {
            Name = dt.Rows[0][0].ToString();
            Address = dt.Rows[0][1].ToString();
            CC = dt.Rows[0][2].ToString();
        }
    }
}
