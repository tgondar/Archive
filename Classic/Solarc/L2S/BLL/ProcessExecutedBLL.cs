using Solarc.L2S.DAL.SolArcTableAdapters;
using Solarc.L2S.DAL;

[System.ComponentModel.DataObject]
public class ProcessExecutedBLL
{
	public ProcessExecutedBLL()
	{
	}

    private tb_ProcessExecutedTableAdapter _ProcessExecutedAdapter = null;
    protected tb_ProcessExecutedTableAdapter Adapter
    {
        get
        {
            if (_ProcessExecutedAdapter == null)
                _ProcessExecutedAdapter = new tb_ProcessExecutedTableAdapter();

            return _ProcessExecutedAdapter;
        }
    }

    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
    public SolArc.tb_ProcessExecutedDataTable GetProcessExecuted()
    {
        return Adapter.GetProcessExecuted();
    }

    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
    public SolArc.tb_ProcessExecutedDataTable GetProcessExecutedByProcessId(int theProcessId)
    {
        return Adapter.GetProcessExecutedByProcessId(theProcessId);
    }
}
