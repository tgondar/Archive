using System;
using Solarc.L2S.DAL.SolArcTableAdapters;
using Solarc.L2S.DAL;

[System.ComponentModel.DataObject]
public class UserSettingBLL
{
	public UserSettingBLL()
	{
	}

    private tb_UserSettingTableAdapter _productsAdapter = null;
    protected tb_UserSettingTableAdapter Adapter
    {
        get
        {
            if (_productsAdapter == null)
                _productsAdapter = new tb_UserSettingTableAdapter();

            return _productsAdapter;
        }
    }

    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
    public SolArc.tb_UserSettingDataTable GetUserSetting()
    {
        return Adapter.GetUserSetting();
    }

    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
    public SolArc.tb_UserSettingDataTable GetUserSettingByUserId(Guid userId)
    {
        return Adapter.GetUserSettingByUserId(userId);
    }

}
