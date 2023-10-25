using Solarc.L2S.DAL.SolArcTableAdapters;
using Solarc.L2S.DAL;
using System;
using System.Web.Security;
using System.Data;

[System.ComponentModel.DataObject]
public class ProcessPaymentBLL
{
    public ProcessPaymentBLL()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    private tb_ProcessPaymentTableAdapter _productsAdapter = null;
    protected tb_ProcessPaymentTableAdapter Adapter
    {
        get
        {
            if (_productsAdapter == null)
                _productsAdapter = new tb_ProcessPaymentTableAdapter();

            return _productsAdapter;
        }
    }

    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
    public SolArc.tb_ProcessPaymentDataTable GetProcessPayment()
    {
        return Adapter.GetProcessPayments();
    }

    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
    public SolArc.tb_ProcessPaymentDataTable GetProcessPaymentTop30()
    {
        return Adapter.GetProcessPaymentTop30();
    }

    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
    public string GetProcessPaymentTotalInfo()
    {
        return Adapter.GetProcessPaymentTotalInfo().ToString();
    }

    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
    public SolArc.tb_ProcessPaymentDataTable GetProcessPaymentByProcessId(int theProcessId)
    {
        return Adapter.GetProcessPaymentByProcessId(theProcessId);
    }

    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
    public int GetProcessPaymentMaxYear()
    {
        return int.Parse(Adapter.GetProcessPaymentMaxYear().ToString());
    }

    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
    public int GetProcessPaymentMaxId(int thePaymentYear)
    {
        return int.Parse(Adapter.GetProcessPaymentMaxId(thePaymentYear).ToString());
    }

    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
    public SolArc.tb_ProcessPaymentDataTable GetProcessPaymentByPaymentId(int thePaymentYear,int thePaymentId)
    {
        return Adapter.GetProcessPaymentById(thePaymentYear, thePaymentId);
    }

    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
    public string GetProcessPaymentInfo(int theProcessId)
    {
        return Adapter.udfProcessPaymentInfo(theProcessId).ToString();
    }

    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
    public SolArc.tb_ProcessPaymentDataTable GetProcessPaymentNotPayedByProcessId(int theProcessId)
    {
        return Adapter.GetProcessPaymentNotPayedByProcessId(theProcessId);
    }

    public DataTable GetProcessPaymentFiltered(string theInternalCode,DateTime thePaymentDate,decimal theTotal,int thePaymentTypeId,string theRepresentative,
        string theExecuted,string theEmployer,string theInvoiceNumber)
    {
        SolArc.tb_ProcessPaymentDataTable dTable = GetProcessPayment();

        foreach (SolArc.tb_ProcessPaymentRow dRow in dTable)
        {
            if ((theInvoiceNumber.Length > 0 && !dRow.InternalNumber.Contains(theInternalCode))
                || (thePaymentDate != new DateTime() && dRow.PaymentDate.ToShortDateString() != thePaymentDate.ToShortDateString())
                || (theTotal > 0 && dRow.Total < theTotal)
                || (thePaymentTypeId > 0 && dRow.PaymentTypeId != thePaymentTypeId)
                || (theRepresentative.Length > 0 && !dRow.PaymentFor.Contains(theRepresentative))
                || (theExecuted.Length > 0 && !dRow.PaymentFor.Contains(theExecuted))
                || (theEmployer.Length > 0 && !dRow.PaymentFor.Contains(theEmployer))
                || (theInvoiceNumber.Length > 0 && !dRow.InvoiceNumber.ToString().Contains(theInvoiceNumber)))
                dRow.Delete();
        }

        return dTable;
    }


    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Insert, true)]
    public bool AddProcessPayment(int theProcessId, int theExecutedId,DateTime thePaymentDate, decimal theOutCome, decimal theInCome, float theVat,float theRetentionValue, int thePaymentTypeId, int theRepresentativeId, int theEmployerId, string theObservation)
    {
        // Create a new ProductRow instance
        SolArc.tb_ProcessPaymentDataTable dTable = new SolArc.tb_ProcessPaymentDataTable();
        SolArc.tb_ProcessPaymentRow ProcessPayment = dTable.Newtb_ProcessPaymentRow();

        int paymYear = GetProcessPaymentMaxYear(), paymId = 0;

        if (paymYear == 0 || paymYear != DateTime.Now.Year) paymYear = DateTime.Now.Year;
        paymId = GetProcessPaymentMaxId(paymYear);
        paymId++;

        ProcessPayment.PaymentYear = paymYear;
        ProcessPayment.PaymentId = paymId;
        
        ProcessPayment.ProcessId = theProcessId;

        if (theExecutedId > 0)
            ProcessPayment.ExecutedId = theExecutedId;

        ProcessPayment.OutCome = theOutCome;
        ProcessPayment.InCome = theInCome;
        ProcessPayment.Vat = theVat;
        ProcessPayment.RetentionValue=theRetentionValue;
        ProcessPayment.PaymentTypeId = thePaymentTypeId;
        ProcessPayment.PaymentDate = thePaymentDate;

        if (theRepresentativeId > 0)
            ProcessPayment.RepresentativeId = theRepresentativeId;

        if (theEmployerId > 0)
            ProcessPayment.EmployerId = theEmployerId;

        ProcessPayment.Status = 0;
        ProcessPayment.Observation = theObservation;

        ProcessPayment.CreateDate = DateTime.Now;
        ProcessPayment.CreateUserId = new Guid(Membership.GetUser().ProviderUserKey.ToString());
        ProcessPayment.AlterDate = ProcessPayment.CreateDate;
        ProcessPayment.AlterUserId = ProcessPayment.CreateUserId;

        // Add the new product
        dTable.Addtb_ProcessPaymentRow(ProcessPayment);
        int rowsAffected = Adapter.Update(dTable);

        // Return true if precisely one row was inserted, otherwise false
        return rowsAffected == 1;
    }


    
    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, false)]
    public bool UpdateProcessPaymentSetPayed(int thePaymentYear,int thePaymentId,int thePayedValue,string theInvoiceNumber,string theObservation)
    {
        SolArc.tb_ProcessPaymentDataTable dTable = Adapter.GetProcessPaymentById(thePaymentYear, thePaymentId);
        if (dTable.Count == 0)
            return false;

        SolArc.tb_ProcessPaymentRow ProcessPayment = dTable[0];

        ProcessPayment.InvoiceNumber = theInvoiceNumber;
        ProcessPayment.Observation = theObservation;
        ProcessPayment.Status = thePayedValue;
        ProcessPayment.AlterDate = DateTime.Now;
        ProcessPayment.AlterUserId = new Guid(Membership.GetUser().ProviderUserKey.ToString());

        int rowsAffected = Adapter.Update(ProcessPayment);

        return rowsAffected == 1;
    }


    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Delete, true)]
    public bool DeleteProcessPayment(int thePaymentYear,int thePaymentId)
    {
        int rowsAffected = Adapter.Delete(thePaymentYear, thePaymentId);

        return rowsAffected == 1;
    }

}
