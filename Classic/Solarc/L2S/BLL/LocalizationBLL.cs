using Solarc.L2S.DAL.SolArcTableAdapters;
using Solarc.L2S.DAL;

[System.ComponentModel.DataObject]
public class LocalizationBLL
{
    private tb_LocalizationTableAdapter _productsAdapter = null;
    protected tb_LocalizationTableAdapter Adapter
    {
        get
        {
            if (_productsAdapter == null)
                _productsAdapter = new tb_LocalizationTableAdapter();

            return _productsAdapter;
        }
    }

    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
    public SolArc.tb_LocalizationDataTable GetLocalization()
    {
        return Adapter.GetLocalization();
    }
}
