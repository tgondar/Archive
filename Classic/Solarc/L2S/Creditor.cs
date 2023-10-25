using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI.WebControls;
using System.Web.Security;

/// <summary>
/// Summary description for Creditor
/// </summary>
public class Creditor
{
    private string name = string.Empty, address = string.Empty, phone = string.Empty, fax = string.Empty, email = string.Empty,
        identityCard = string.Empty, nifNipl = string.Empty, nifs = string.Empty;
    private DateTime bornDate;

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
    public string MPhone
    {
        get;
        set;
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
    public string IdentityCard
    {
        get { return identityCard; }
        set { identityCard = value; }
    }
    public string NifNipl
    {
        get { return nifNipl; }
        set { nifNipl = value; }
    }
    public string Nifs
    {
        get { return nifs; }
        set { nifs = value; }
    }
    public DateTime BornDate
    {
        get { return bornDate; }
        set { bornDate = value; }
    }

    public Creditor()
    {
    }
	public Creditor(string theName,string theAddress, string thePhone, string theMPhone,string theFax,string theEmail,string theIdentityCard,string theNifNipl,string theNifs,DateTime theBorDate)
	{
        Name = theName;
        Address = theAddress;
        Phone = thePhone;
        MPhone = theMPhone;
        Fax = theFax;
        Email = theEmail;

        IdentityCard = theIdentityCard;
        NifNipl = theNifNipl;
        Nifs = theNifs;
        BornDate = theBorDate;
	}
    public Creditor(int theCreditorId)
    {
        DataTable dt = DataBase.DataTable("select Name,Address from tb_Creditor where CreditorId=" + theCreditorId);
        if (dt.Rows.Count > 0)
        {
            Name = dt.Rows[0][0].ToString();
            Address = dt.Rows[0][1].ToString();
        }
    }

    public void Save(int theValue, int theExecutedId)
    {
        if (theValue == 0)
        {
            //update
            DataBase.Deinup("exec uspCreditorUpdate '" + Name + "','" + Address + "','" + Phone + "','" + MPhone + "','" + Fax + "','" + Email + "','" + Membership.GetUser().ProviderUserKey + "','" + IdentityCard + "','" + NifNipl + "','" + Nifs + "','" + BornDate.ToString("MM-dd-yyyy") + "'," + theExecutedId);
        }
        else
        {
            //insert
            DataBase.Deinup("exec uspCreditorUpdate '" + Name + "','" + Address + "','" + Phone + "','" + MPhone + "','" + Fax + "','" + Email + "','" + Membership.GetUser().ProviderUserKey + "','" + IdentityCard + "','" + NifNipl + "','" + Nifs + "','" + BornDate.ToString("MM-dd-yyyy") + "',0");
        }
    }
}
