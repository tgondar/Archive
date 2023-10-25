using System;
using System.Text;
using System.Configuration;
using System.Web.Security;
using System.Collections.Generic;

namespace Solarc.webapp.secure
{
    public partial class mntExecuted : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txtName.Focus();
            txtName.Attributes.Add("onKeyPress", "pressenter('" + lkbSearch.ClientID + "');");
            txtAddress.Attributes.Add("onKeyPress", "pressenter('" + lkbSearch.ClientID + "');");
            txtPhone.Attributes.Add("onKeyPress", "pressenter('" + lkbSearch.ClientID + "');");
            txtFax.Attributes.Add("onKeyPress", "pressenter('" + lkbSearch.ClientID + "');");
            txtEmail.Attributes.Add("onKeyPress", "pressenter('" + lkbSearch.ClientID + "');");
            txtIdentityCard.Attributes.Add("onKeyPress", "pressenter('" + lkbSearch.ClientID + "');");
            txtNifNipl.Attributes.Add("onKeyPress", "pressenter('" + lkbSearch.ClientID + "');");
            txtNifs.Attributes.Add("onKeyPress", "pressenter('" + lkbSearch.ClientID + "');");
            txtBornDate.Attributes.Add("onKeyPress", "pressenter('" + lkbSearch.ClientID + "');");

            if (!IsPostBack)
            {
                lkbPrev.CommandArgument = "1";
                lkbNext.CommandArgument = "20";
                if (Roles.IsUserInRole(ConfigurationManager.AppSettings["RoleRepresentative"]) || Roles.IsUserInRole("Cliente"))
                    Server.Transfer("Default.aspx", false);
                FillGrid();
            }
        }

        protected void lkbInsert_Click(object sender, EventArgs e)
        {
            InsertUpdate(1);
        }

        protected void gvExecuted_SelectedIndexChanged(object sender, EventArgs e)
        {
            gvExecuted.Enabled = false;
            lkbInsert.Visible = false;
            lkbSearch.Visible = false;
            lkbSave.Visible = true;

            string aux = string.Empty;

            aux = gvExecuted.Rows[gvExecuted.SelectedIndex].Cells[1].Text;
            txtName.Text = aux.Length > 0 && aux != "&nbsp;" ? aux : string.Empty;

            aux = gvExecuted.Rows[gvExecuted.SelectedIndex].Cells[2].Text;
            txtAddress.Text = aux.Length > 0 && aux != "&nbsp;" ? aux : string.Empty;
            aux = gvExecuted.Rows[gvExecuted.SelectedIndex].Cells[3].Text;
            txtPhone.Text = aux.Length > 0 && aux != "&nbsp;" ? aux : string.Empty;
            aux = gvExecuted.Rows[gvExecuted.SelectedIndex].Cells[4].Text;
            txtPhone.Text = aux.Length > 0 && aux != "&nbsp;" ? aux : string.Empty;
            aux = gvExecuted.Rows[gvExecuted.SelectedIndex].Cells[5].Text;
            txtFax.Text = aux.Length > 0 && aux != "&nbsp;" ? aux : string.Empty;
            aux = gvExecuted.Rows[gvExecuted.SelectedIndex].Cells[6].Text;
            txtEmail.Text = aux.Length > 0 && aux != "&nbsp;" ? aux : string.Empty;
            aux = gvExecuted.Rows[gvExecuted.SelectedIndex].Cells[7].Text;
            txtIdentityCard.Text = aux.Length > 0 && aux != "&nbsp;" ? aux : string.Empty;
            aux = gvExecuted.Rows[gvExecuted.SelectedIndex].Cells[8].Text;
            txtNifNipl.Text = aux.Length > 0 && aux != "&nbsp;" ? aux : string.Empty;
            aux = gvExecuted.Rows[gvExecuted.SelectedIndex].Cells[9].Text;
            txtNifs.Text = aux.Length > 0 && aux != "&nbsp;" ? aux : string.Empty;
            aux = gvExecuted.Rows[gvExecuted.SelectedIndex].Cells[10].Text;
            txtBornDate.Text = aux.Length > 0 && aux != "&nbsp;" ? aux : string.Empty;
        }
        protected void lkbSave_Click(object sender, EventArgs e)
        {
            InsertUpdate(0);

            gvExecuted.SelectedIndex = -1;
            gvExecuted.Enabled = true;
            lkbInsert.Visible = true;
            lkbSearch.Visible = true;
            lkbSave.Visible = false;
        }
        protected void lkbSearch_Click(object sender, EventArgs e)
        {
            FillGrid();
        }

        private void FillGrid()
        {
            try
            {
                StringBuilder sb = new StringBuilder("");

                sb.Append("select * from(select *,row_number() over(order by alterdate desc) as 'Id' from vwExecuted where ");

                List<string> val = new List<string>();

                val.Add(" active=1");
                if (txtName.Text.Length > 0) val.Add(" name like '%" + txtName.Text.Replace("'", string.Empty) + "%'");
                if (txtAddress.Text.Length > 0) val.Add(" address like '%" + txtAddress.Text.Replace("'", string.Empty) + "%'");
                if (txtPhone.Text.Length > 0) val.Add(" phone like '%" + txtPhone.Text.Replace("'", string.Empty) + "%'");
                if (txtFax.Text.Length > 0) val.Add(" fax like '%" + txtFax.Text.Replace("'", string.Empty) + "%'");
                if (txtEmail.Text.Length > 0) val.Add(" email like '%" + txtEmail.Text.Replace("'", string.Empty) + "%'");
                if (txtIdentityCard.Text.Length > 0) val.Add(" identitycard like '%" + txtIdentityCard.Text.Replace("'", string.Empty) + "%'");
                if (txtNifNipl.Text.Length > 0) val.Add(" nifnipl like '%" + txtNifNipl.Text.Replace("'", string.Empty) + "%'");
                if (txtNifs.Text.Length > 0) val.Add(" nifs like '%" + txtNifs.Text.Replace("'", string.Empty) + "%'");
                if (txtBornDate.Text.Length > 0) val.Add(" borndate like '%" + txtBornDate.Text.Replace("'", string.Empty) + "%'");

                sb.Append(string.Join(" and ", val.ToArray()));
                sb.Append(string.Format(" )as tab where id between {0} and {1}", lkbPrev.CommandArgument, int.Parse(lkbNext.CommandArgument) + 1));

                gvExecuted.DataSource = DataBase.DataReader(sb.ToString());
                string[] key = new string[] { "ExecutedId" };
                gvExecuted.DataKeyNames = key;
                gvExecuted.DataBind();

                lkbPrev.Enabled = false;
                lkbNext.Enabled = false;
                if (gvExecuted.Rows.Count > 20) lkbNext.Enabled = true;
                if (lkbPrev.CommandArgument != "1") lkbPrev.Enabled = true;
            }
            catch (Exception ex)
            {
                ltMsg.Text = "Erro: " + ex.Message;
            }
        }
        private void InsertUpdate(int theValue)
        {
            Executed ex = new Executed();
            ex.Name = txtName.Text;
            ex.Address = txtAddress.Text;
            ex.Phone = txtPhone.Text;
            ex.Fax = txtFax.Text;
            ex.Email = txtEmail.Text;
            ex.IdentityCard = txtIdentityCard.Text;
            ex.NifNipl = txtNifNipl.Text;
            ex.Nifs = txtNifs.Text;
            if (txtBornDate.Text.Length > 0)
                ex.BornDate = DateTime.Parse(txtBornDate.Text);
            else
                ex.BornDate = DateTime.Parse(ConfigurationManager.AppSettings["DefaultDate"].ToString());

            ex.Save(theValue, theValue == 1 ? 0 : int.Parse(gvExecuted.SelectedDataKey.Value.ToString()));

            txtAddress.Text = string.Empty;
            txtBornDate.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtFax.Text = string.Empty;
            txtIdentityCard.Text = string.Empty;
            txtName.Text = string.Empty;
            txtNifNipl.Text = string.Empty;
            txtNifs.Text = string.Empty;
            txtPhone.Text = string.Empty;

            FillGrid();
        }
        protected void lkbPrev_Click(object sender, EventArgs e)
        {
            lkbPrev.CommandArgument = (int.Parse(lkbPrev.CommandArgument) - 20).ToString();
            lkbNext.CommandArgument = (int.Parse(lkbNext.CommandArgument) - 20).ToString();
            FillGrid();
        }
        protected void lkbNext_Click(object sender, EventArgs e)
        {
            lkbPrev.CommandArgument = (int.Parse(lkbPrev.CommandArgument) + 20).ToString();
            lkbNext.CommandArgument = (int.Parse(lkbNext.CommandArgument) + 20).ToString();
            FillGrid();
        }
    }
}
