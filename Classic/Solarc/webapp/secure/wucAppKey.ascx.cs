using System;

namespace Solarc.webapp.secure
{
    public partial class wucAppKey : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        public void NewAppKey()
        {
            AppKey ak = new AppKey();
            string code = ak.GetRandomKey();
            lblV1.Text = code.Split('-').GetValue(0).ToString();
            lblV2.Text = code.Split('-').GetValue(1).ToString();
            lblV3.Text = code.Split('-').GetValue(2).ToString();
        }

        public bool CheckAppKey()
        {
            AppKey ak = new AppKey();
            try
            {
                ak.v1 = char.Parse(txtV1.Text);
                ak.v2 = char.Parse(txtV2.Text);
                ak.v3 = char.Parse(txtV3.Text);
            }
            catch
            {
                return false;
            }

            return ak.CheckKey(int.Parse(lblV1.Text), int.Parse(lblV2.Text), int.Parse(lblV3.Text));
        }
    }
}
