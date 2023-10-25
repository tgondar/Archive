using System;
using System.Collections.Generic;

namespace Solarc.webapp.secure
{
    public partial class Report : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //FillGrid();
            }
        }

        private void FillGrid()
        {
            List<string> t = new List<string>();
        }
        protected void lkbSearch_Click(object sender, EventArgs e)
        {
            ProcessPaymentBLL ppBLL = new ProcessPaymentBLL();
            gvResult.DataSource = ppBLL.GetProcessPaymentFiltered(txtInternalNumber.Text, txtDate.Text.Length > 0 ? DateTime.Parse(txtDate.Text) : new DateTime(),
                txtValue.Text.Length > 0 ? decimal.Parse(txtValue.Text) : 0, int.Parse("0"), txtRepresentative.Text, txtExecuted.Text, txtEmployer.Text, txtInternalNumber.Text);
            gvResult.DataBind();
            //FillGrid();
        }
    }
}
