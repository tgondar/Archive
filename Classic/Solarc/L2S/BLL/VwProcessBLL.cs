using Solarc.L2S.DAL.SolArcTableAdapters;
using Solarc.L2S.DAL;

[System.ComponentModel.DataObject]
public class VwProcessBLL
{
	public VwProcessBLL()
	{
	}

    private vwProcessTableAdapter _productsAdapter = null;
    protected vwProcessTableAdapter Adapter
    {
        get
        {
            if (_productsAdapter == null)
                _productsAdapter = new vwProcessTableAdapter();

            return _productsAdapter;
        }
    }

    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
    public SolArc.vwProcessDataTable GetViewProcess()
    {
        return Adapter.GetViewProcess();
    }

    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
    public SolArc.vwProcessDataTable GetViewProcessByLocalization(int localizationId)
    {
        return Adapter.GetViewProcessByLocalization(localizationId);
    }
}
