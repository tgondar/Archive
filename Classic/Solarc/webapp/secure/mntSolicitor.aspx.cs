using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Configuration;
using System.Text;

namespace Solarc.webapp.secure
{
    public partial class mntSolicitor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txtName.Focus();
            txtName.Attributes.Add("onKeyPress", "pressenter('" + lkbSearch.ClientID + "');");
            txtCardNumber.Attributes.Add("onKeyPress", "pressenter('" + lkbSearch.ClientID + "');");

            if (!IsPostBack)
            {
                if (Roles.IsUserInRole(ConfigurationManager.AppSettings["RoleRepresentative"]) || Roles.IsUserInRole("Cliente"))
                    Server.Transfer("Default.aspx", false);
                FillGrid();
            }
        }
        private void FillGrid()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("select SolicitorId,Name,CardNumber");
            sb.Append(" from tb_Solicitor");

            List<string> filter = new List<string>();

            if (txtName.Text.Trim().Length > 0)
                filter.Add("Name like '%" + txtName.Text + "%'");
            if (txtCardNumber.Text.Trim().Length > 0)
                filter.Add("CardNumber like '%" + txtCardNumber.Text + "%'");

            if (filter.Count > 0)
                sb.Append(" where " + string.Join(" and ", filter.ToArray()));

            sb.Append(" order by Name");

            gvResult.DataSource = DataBase.DataTable(sb);
            string[] key = new string[] { "SolicitorId" };
            gvResult.DataKeyNames = key;
            gvResult.DataBind();
        }
        protected void lkbInsert_Click(object sender, EventArgs e)
        {
            string Name, CardNumber;
            Name = txtName.Text.Replace("'", string.Empty).Replace(";", string.Empty);
            CardNumber = txtCardNumber.Text.Replace("'", string.Empty).Replace(";", string.Empty);

            DataBase.Deinup("exec uspSolicitorAdd 0,'" + Name + "','" + CardNumber + "'");

            FillGrid();
        }
        protected void lkbSearch_Click(object sender, EventArgs e)
        {
            FillGrid();
        }
        protected void lkbSave_Click(object sender, EventArgs e)
        {
            gvResult.Rows[gvResult.SelectedIndex].Cells[1].Text = txtName.Text;
            gvResult.Rows[gvResult.SelectedIndex].Cells[2].Text = txtCardNumber.Text;

            lkbInsert.Visible = true;
            lkbSave.Visible = false;
            gvResult.Enabled = true;
            gvResult.SelectedIndex = -1;
        }
        protected void gvResult_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtName.Text = gvResult.Rows[gvResult.SelectedIndex].Cells[1].Text;
            txtCardNumber.Text = gvResult.Rows[gvResult.SelectedIndex].Cells[2].Text;

            lkbInsert.Visible = false;
            lkbSave.Visible = true;
            gvResult.Enabled = false;
        }
    }
}
