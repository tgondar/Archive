using System;

namespace Solarc.webapp.secure
{
    public partial class mntPermission : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FillGrid();
            }
        }

        private void FillGrid()
        {
            //PermissionService ps = new PermissionService();
            //gvResult.DataSource = ps.GetUsers();
            //string[] key = new string[] { "UserId" };
            //gvResult.DataKeyNames = key;
            //gvResult.DataBind();
        }
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillGrid();
        }
    }
}
