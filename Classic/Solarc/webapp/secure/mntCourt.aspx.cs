using System;
using System.Text;
using System.Data;
using System.Web.Security;
using System.Configuration;
using System.Collections.Generic;

namespace Solarc.webapp.secure
{
    public partial class mntCourt : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblInfoCourt.Text = string.Empty;

            txtName.Focus();
            txtName.Attributes.Add("onKeyPress", "pressenter('" + lkbSearch.ClientID + "');");
            txtAddress.Attributes.Add("onKeyPress", "pressenter('" + lkbSearch.ClientID + "');");
            txtPhone.Attributes.Add("onKeyPress", "pressenter('" + lkbSearch.ClientID + "');");
            txtFax.Attributes.Add("onKeyPress", "pressenter('" + lkbSearch.ClientID + "');");
            txtEmail.Attributes.Add("onKeyPress", "pressenter('" + lkbSearch.ClientID + "');");
            txtJudicialDistrict.Attributes.Add("onKeyPress", "pressenter('" + lkbSearch.ClientID + "');");

            if (!IsPostBack)
            {
                lkbPrev.CommandArgument = "1";
                lkbNext.CommandArgument = "20";
                if (Roles.IsUserInRole(ConfigurationManager.AppSettings["RoleRepresentative"])|| Roles.IsUserInRole("Cliente"))
                    Server.Transfer("Default.aspx", false);

                FillGrid();
                FillCombo();
            }
        }

        private void FillGrid()
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("select * from (select *,row_number() over(order by alterdate desc) as 'Id' from vwCourt where ");

                List<string> val = new List<string>();

                val.Add(" active=1");
                if (txtName.Text.Length > 0) val.Add(" name like '%" + txtName.Text + "%'");
                if (txtAddress.Text.Length > 0) val.Add(" address like '%" + txtAddress.Text + "%'");
                if (txtPhone.Text.Length > 0) val.Add(" phone like '%" + txtPhone.Text + "%'");
                if (txtFax.Text.Length > 0) val.Add(" fax like '%" + txtFax.Text + "%'");
                if (txtEmail.Text.Length > 0) val.Add(" email like '%" + txtEmail.Text + "%'");
                if (txtJudicialDistrict.Text.Length > 0) val.Add(" JudicialDistrict like '%" + txtJudicialDistrict.Text + "%'");

                sb.Append(string.Join(" and ", val.ToArray()));
                sb.Append(string.Format(")as tab where id between {0} and {1}", lkbPrev.CommandArgument, int.Parse(lkbNext.CommandArgument) + 1));

                gvCourt.DataSource = DataBase.DataReader(sb.ToString());
                string[] key = new string[] { "CourtId" };
                gvCourt.DataKeyNames = key;
                gvCourt.DataBind();

                lkbPrev.Enabled = false;
                lkbNext.Enabled = false;
                if (gvCourt.Rows.Count > 20) lkbNext.Enabled = true;
                if (lkbPrev.CommandArgument != "1") lkbPrev.Enabled = true;

            }
            catch (Exception ex)
            {
                ltMsg.Text = "Erro: " + ex.Message;
            }
        }
        private void FillCombo()
        {
            DataSet ds = DataBase.DataSet("select * from vwCourt where active=1 order by name");
            cmbCourt.DataSource = ds;
            cmbCourt.DataTextField = "Name";
            cmbCourt.DataValueField = "CourtId";
            cmbCourt.DataBind();

            cmbCourtReplace.DataSource = ds;
            cmbCourtReplace.DataTextField = "Name";
            cmbCourtReplace.DataValueField = "CourtId";
            cmbCourtReplace.DataBind();
        }
        protected void lkbSearch_Click(object sender, EventArgs e)
        {
            FillGrid();
        }
        protected void lkbInsert_Click(object sender, EventArgs e)
        {
            try
            {
                Court c = new Court();
                c.Name = txtName.Text;
                c.Address = txtAddress.Text;
                c.Phone = txtPhone.Text;
                c.Fax = txtFax.Text;
                c.Email = txtEmail.Text;
                c.JudicialDistrict = txtJudicialDistrict.Text;

                c.Save(1, 0);

                txtName.Text = string.Empty;
                txtAddress.Text = string.Empty;
                txtPhone.Text = string.Empty;
                txtFax.Text = string.Empty;
                txtEmail.Text = string.Empty;
                txtJudicialDistrict.Text = string.Empty;

                FillCombo();
                FillGrid();
            }
            catch (Exception ex)
            {
                ltMsg.Text = "Erro: " + ex.Message;
            }
        }
        protected void gvCourt_SelectedIndexChanged(object sender, EventArgs e)
        {
            gvCourt.Enabled = false;
            lkbSearch.Visible = false;
            lkbInsert.Visible = false;
            lkbSave.Visible = true;

            lkbSave.CommandArgument = gvCourt.SelectedValue.ToString();
            txtName.Text = gvCourt.Rows[gvCourt.SelectedIndex].Cells[1].Text.Length > 0 && gvCourt.Rows[gvCourt.SelectedIndex].Cells[1].Text != "&nbsp;" ? gvCourt.Rows[gvCourt.SelectedIndex].Cells[1].Text : string.Empty;
            txtAddress.Text = gvCourt.Rows[gvCourt.SelectedIndex].Cells[2].Text.Length > 0 && gvCourt.Rows[gvCourt.SelectedIndex].Cells[2].Text != "&nbsp;" ? gvCourt.Rows[gvCourt.SelectedIndex].Cells[2].Text : string.Empty;
            txtPhone.Text = gvCourt.Rows[gvCourt.SelectedIndex].Cells[3].Text.Length > 0 && gvCourt.Rows[gvCourt.SelectedIndex].Cells[3].Text != "&nbsp;" ? gvCourt.Rows[gvCourt.SelectedIndex].Cells[3].Text : string.Empty;
            txtFax.Text = gvCourt.Rows[gvCourt.SelectedIndex].Cells[4].Text.Length > 0 && gvCourt.Rows[gvCourt.SelectedIndex].Cells[4].Text != "&nbsp;" ? gvCourt.Rows[gvCourt.SelectedIndex].Cells[4].Text : string.Empty;
            txtEmail.Text = gvCourt.Rows[gvCourt.SelectedIndex].Cells[5].Text.Length > 0 && gvCourt.Rows[gvCourt.SelectedIndex].Cells[5].Text != "&nbsp;" ? gvCourt.Rows[gvCourt.SelectedIndex].Cells[5].Text : string.Empty;
            txtJudicialDistrict.Text = gvCourt.Rows[gvCourt.SelectedIndex].Cells[6].Text.Length > 0 && gvCourt.Rows[gvCourt.SelectedIndex].Cells[6].Text != "&nbsp;" ? gvCourt.Rows[gvCourt.SelectedIndex].Cells[6].Text : string.Empty;
        }
        protected void lkbSave_Click(object sender, EventArgs e)
        {
            Court c = new Court();
            c.Name = txtName.Text;
            c.Address = txtAddress.Text;
            c.Phone = txtPhone.Text;
            c.Fax = txtFax.Text;
            c.Email = txtEmail.Text;

            c.Save(0, int.Parse(lkbSave.CommandArgument));

            gvCourt.Enabled = true;
            lkbSearch.Visible = true;
            lkbInsert.Visible = true;
            lkbSave.Visible = false;

            txtName.Text = string.Empty;
            txtAddress.Text = string.Empty;
            txtPhone.Text = string.Empty;
            txtFax.Text = string.Empty;
            txtEmail.Text = string.Empty;

            gvCourt.SelectedIndex = -1;
            FillGrid();
            FillCombo();
        }
        protected void lkbDelete_Click(object sender, EventArgs e)
        {
            if (cmbCourt.Items.Count > 0)
            {
                string val = DataBase.Scalar("select count(*) from tb_Process where CourtId=" + cmbCourt.SelectedItem.Value);
                if (val != "0")
                {
                    lblInfoCourt.Text = "O tribunal seleccionado esta associado a " + val + " processo(s), nao pode ser apagado directamente<br>para o fazer ou altera os processos 1 a 1, ou entao seleccione pelo que quer substituir.";
                    cmbCourtReplace.Visible = true;
                    lkbCourtReplace.Visible = true;
                }
                else
                {
                    DataBase.Deinup("update tb_Court set active=0 where CourtId=" + cmbCourt.SelectedItem.Value);
                    ltMsg.Text = "Tribunal - " + cmbCourt.SelectedItem.Text + " - desactivado com sucesso!";
                    FillGrid();
                    FillCombo();
                }
            }
        }
        protected void lkbCourtReplace_Click(object sender, EventArgs e)
        {
            if (cmbCourt.Items.Count > 0 && cmbCourtReplace.Items.Count > 0)
            {
                DataBase.Deinup("update tb_Process set CourtId=" + cmbCourtReplace.SelectedItem.Value + " where CourtId=" + cmbCourt.SelectedItem.Value);
                lblInfoCourt.Text = "<b>" + cmbCourt.SelectedItem.Text + "</b> alterado para <b>" + cmbCourtReplace.SelectedItem.Text + "</b> com sucesso!<br>Se ainda pretender, ja pode apagar <b>" + cmbCourt.SelectedItem.Text + "</b>";

                FillGrid();
                FillCombo();

                cmbCourtReplace.Visible = false;
                lkbCourtReplace.Visible = false;
            }
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
