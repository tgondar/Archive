using System;
using Solarc.L2S.DAL.SolArcTableAdapters;
using Solarc.L2S.DAL;
using System.Web.Security;

[System.ComponentModel.DataObject]
public class ProcessBLL
{
	public ProcessBLL()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    private tb_ProcessTableAdapter _productsAdapter = null;
    protected tb_ProcessTableAdapter Adapter
    {
        get
        {
            if (_productsAdapter == null)
                _productsAdapter = new tb_ProcessTableAdapter();

            return _productsAdapter;
        }
    }

    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
    public SolArc.tb_ProcessDataTable GetProcess()
    {
        return Adapter.GetProcess();
    }

    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
    public SolArc.tb_ProcessDataTable GetProcessByNumberYear(int theNumber,int theYear)
    {
        return Adapter.GetProcessByNumberYear(theNumber, theYear);
    }

    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
    public SolArc.tb_ProcessDataTable GetProcessById(int theProcessId)
    {
        return Adapter.GetProcessById(theProcessId);
    }

    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Insert, true)]
    public int AddProcess(string theCode, int theNumber, int theYear, string theInitials, string theProcessNumber)
    {
        SolArc.tb_ProcessDataTable dTable = new SolArc.tb_ProcessDataTable();
        dTable = GetProcessByNumberYear(theNumber, theYear);
        if (dTable.Count > 0) throw new Exception("Ja existe processo!");
        SolArc.tb_ProcessRow Process = dTable.Newtb_ProcessRow();

        Process.Code = theCode;
        Process.Number = theNumber;
        Process.Year = theYear;
        Process.Initials = theInitials;
        Process.ProcessNumber = theProcessNumber;

        Process.CreateDate = DateTime.Now;
        Process.CreateUserID = new Guid(Membership.GetUser().ProviderUserKey.ToString());
        Process.AlterDate = Process.CreateDate;
        Process.AlterUserId = Process.CreateUserID;

        dTable.Addtb_ProcessRow(Process);
        int rowsAffected = Adapter.Update(dTable);

        dTable = GetProcessByNumberYear(theNumber, theYear);
        if (dTable.Count == 0) return 0;
        Process = dTable[0];

        return Process.ProcessId;
    }
    public string ValidadeCode(string theInternalCode)
    {
        string[] pn = theInternalCode.Split('/');
        if (pn.Length >= 3)
        {
            if (pn[0].Length <= 10)
                theInternalCode = pn[0].ToUpper() + "/";
            else
                throw new Exception("Codigo - Maximo 10 Caracteres");
            theInternalCode += pn[1] + "/";
            theInternalCode += pn[2];
            if (pn.Length > 3)
                if (pn[3].Length <= 3)
                    theInternalCode += "/" + pn[3].ToUpper();
        }
        else
            throw new Exception("Numero Interno - Formato errado [Cod/Num/Ano/Iniciais]");

        return theInternalCode;
    }
}
