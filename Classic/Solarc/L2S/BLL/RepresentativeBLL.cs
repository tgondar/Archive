using System;
using System.Web.Security;
using Solarc.L2S.DAL.SolArcTableAdapters;
using Solarc.L2S.DAL;

[System.ComponentModel.DataObject]
public class RepresentativeBLL
{
	public RepresentativeBLL()
	{
	}
    private tb_RepresentativeTableAdapter _productsAdapter = null;
    protected tb_RepresentativeTableAdapter Adapter
    {
        get
        {
            if (_productsAdapter == null)
                _productsAdapter = new tb_RepresentativeTableAdapter();

            return _productsAdapter;
        }
    }

    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
    public SolArc.tb_RepresentativeDataTable GetRepresentative()
    {
        return Adapter.GetRepresentative();
    }

    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
    public SolArc.tb_RepresentativeDataTable GetRepresentativeById(int theRepesentativeId)
    {
        return Adapter.GetRepresentativeById(theRepesentativeId);
    }

    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Insert, true)]
    public bool AddRepresentative(string theName, string theAddress, string thePhone, string theFax, string theEmail, string theNif, string theCarbonCopy, string theMPhone,
        string theLaywerNumber, string theBlindCarbonCopy)
    {
        // Create a new ProductRow instance
        SolArc.tb_RepresentativeDataTable dTable = new SolArc.tb_RepresentativeDataTable();
        SolArc.tb_RepresentativeRow Representative = dTable.Newtb_RepresentativeRow();

        Representative.Name = theName;
        Representative.Address = theAddress;
        Representative.Phone = thePhone;
        Representative.Fax = theFax;
        Representative.Email = theEmail;
        Representative.Nif = theNif;
        Representative.CarbonCopy = theCarbonCopy;
        Representative.MPhone = theMPhone;
        Representative.LawyerNumber = theLaywerNumber;
        Representative.BlindCarbonCopy = theBlindCarbonCopy;

        Representative.CreateDate = DateTime.Now;
        Representative.CreateUserId = new Guid(Membership.GetUser().ProviderUserKey.ToString());
        Representative.AlterDate = Representative.CreateDate;
        Representative.AlterUserId = Representative.CreateUserId;

        dTable.Addtb_RepresentativeRow(Representative);
        int rowsAffected = Adapter.Update(dTable);

        return rowsAffected == 1;
    }
}
