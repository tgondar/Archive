
/// <summary>
/// Summary description for Delegate
/// </summary>
using System.Web.Security;
using System.Data;
public class Delegate
{
    public string Name
    {
        get;
        set;
    }
    public string Address
    {
        get;
        set;
    }
    public string Phone
    {
        get;
        set;
    }
    public string MPhone
    {
        get;
        set;
    }
    public string Fax
    {
        get;
        set;
    }
    public string Email
    {
        get;
        set;
    }

	public Delegate()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public void Save(int theDelegateId)
    {
        DataBase.Deinup("exec uspDelegateUpdate '" + Name + "','" + Address + "','" + Phone + "','" + MPhone + "','" + Fax + "','" + Email + "','" + Membership.GetUser().ProviderUserKey + "'," + theDelegateId);
    }
    public DataTable GetDelegate(int theStart,int theEnd)
    {
        return DataBase.DataTable("select * from(select d.DelegateId,d.Name,d.Address,d.Phone,d.MPhone,d.Fax,d.Email,u.UserName,d.AlterDate,row_number() over(order by d.AlterDate desc) as 'Id' from tb_Delegate d left join aspnet_Users u on d.AlterUserId=u.UserId) as t where Id between " + theStart + " and " + theEnd);
    }
    public DataTable GetAllDelegate()
    {
        return DataBase.DataTable("select DelegateId,Name from tb_Delegate order by Name");
    }

    public void DeleteDelegate(int theProcessId,int theDelegateId)
    {
        DataBase.Deinup("delete from tb_ProcessDelegate where ProcessId=" + theProcessId + " and DelegateId=" + theDelegateId);
    }
}
