using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Solarc.L2S.DAL.SolArcTableAdapters;
using Solarc.L2S.DAL;

[System.ComponentModel.DataObject]
public class ProcessEmployerBLL
{
	public ProcessEmployerBLL()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    private tb_ProcessEmployerTableAdapter _productsAdapter = null;
    protected tb_ProcessEmployerTableAdapter Adapter
    {
        get
        {
            if (_productsAdapter == null)
                _productsAdapter = new tb_ProcessEmployerTableAdapter();

            return _productsAdapter;
        }
    }

    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
    public SolArc.tb_ProcessEmployerDataTable GetProcessEmployer()
    {
        return Adapter.GetProcessEmployer();
    }

    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
    public SolArc.tb_ProcessEmployerDataTable GetProcessEmployerByProcessId(int theProcessId)
    {
        return Adapter.GetProcessEmployerByProcessId(theProcessId);
    }

    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
    public SolArc.tb_ProcessEmployerDataTable GetProcessEmployerByEmployerId(int theEmployerId)
    {
        return Adapter.GetProcessEmployerByEmployerId(theEmployerId);
    }

    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Insert, true)]
    public bool AddProcessEmployer(int theProcessId, int theExecutedId, decimal theOutCome, decimal theInCome, float theVat, int thePaymentTypeId, int theRepresentativeId, int theEmployerId, string theObservation)
    {
        // Create a new ProductRow instance
        SolArc.tb_ProcessEmployerDataTable dTable = new SolArc.tb_ProcessEmployerDataTable();
        SolArc.tb_ProcessEmployerRow ProcessEmployer = dTable.Newtb_ProcessEmployerRow();

        /*

        ProcessEmployer.PaymentId = Guid.NewGuid();
        ProcessEmployer.ProcessId = theProcessId;

        if (theExecutedId > 0)
            ProcessEmployer.ExecutedId = theExecutedId;

        ProcessEmployer.OutCome = theOutCome;
        ProcessEmployer.InCome = theInCome;
        ProcessEmployer.Vat = theVat;
        ProcessEmployer.PaymentTypeId = thePaymentTypeId;

        if (theRepresentativeId > 0)
            ProcessEmployer.RepresentativeId = theRepresentativeId;

        if (theEmployerId > 0)
            ProcessEmployer.EmployerId = theEmployerId;

        ProcessEmployer.Status = 0;
        ProcessEmployer.Observation = theObservation;

        ProcessEmployer.CreateDate = DateTime.Now;
        ProcessEmployer.CreateUserId = new Guid(Membership.GetUser().ProviderUserKey.ToString());
        ProcessEmployer.AlterDate = ProcessEmployer.CreateDate;
        ProcessEmployer.AlterUserId = ProcessEmployer.CreateUserId;
         */

        // Add the new product
        dTable.Addtb_ProcessEmployerRow(ProcessEmployer);
        int rowsAffected = Adapter.Update(dTable);

        // Return true if precisely one row was inserted, otherwise false
        return rowsAffected == 1;
    }
}
