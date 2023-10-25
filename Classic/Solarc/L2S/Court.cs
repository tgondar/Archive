
/// <summary>
/// Summary description for Court
/// </summary>
using System.Data;
using System.Web.Security;
public class Court
{
    private string name = string.Empty, address = string.Empty, phone = string.Empty, fax = string.Empty, email = string.Empty, judicialDistrict = string.Empty;

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
    public string JudicialDistrict
    {
        get { return judicialDistrict; }
        set { judicialDistrict = value; }
    }

	public Court()
	{
	}
    public Court(int ProcessId)
    {
        DataSet ds = DataBase.DataSet("select * from vwProcessCourt where processid=" + ProcessId);
        if (ds != null && ds.Tables[0].Rows.Count > 0)
        {
            Name = ds.Tables[0].Rows[0][2].ToString();
            Address = ds.Tables[0].Rows[0][4].ToString();
            Phone = ds.Tables[0].Rows[0][5].ToString();
            Fax = ds.Tables[0].Rows[0][6].ToString();
            Email = ds.Tables[0].Rows[0][7].ToString();
        }
        else
            Name = "-";
    }

    public override string ToString()
    {
        return Name + (Address.Length > 0 ? Address + "<br>" : string.Empty) +
            "<br>" + (Phone.Length > 0 ? "Tlf.: " + Phone + "<br>" : string.Empty) +
            "<br>" + (Fax.Length > 0 ? "Fax: " + Fax + "<br>" : string.Empty) +
            "<br>" + (Email.Length > 0 ? Email : string.Empty);
    }
    public void Save(int theValue, int theCourtId)
    {
        if (theValue == 0)
        {
            //update
            DataBase.Deinup("exec uspCourtUpdate '" + Name + "','" + Address + "','" + Phone + "','" + Fax + "','" + Email + "','" + JudicialDistrict + "','" + Membership.GetUser().ProviderUserKey + "'," + theCourtId);
        }
        else
        {
            //insert
            DataBase.Deinup("exec uspCourtUpdate '" + Name + "','" + Address + "','" + Phone + "','" + Fax + "','" + Email + "','" + JudicialDistrict + "','" + Membership.GetUser().ProviderUserKey + "',0");
        }
    }
}
