using System;

namespace Solarc.webapp.secure
{
    public partial class mntProcessDetail : System.Web.UI.Page
    {
        int glPaging = 20;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lkbPrev.CommandArgument = "1";
                lkbNext.CommandArgument = glPaging.ToString();
            }
        }
        protected void lkbOk_Click(object sender, EventArgs e)
        {
            txtName.Text = string.Empty;
            if (cmbTable.SelectedValue != "0")
            {
                FillGrid();
                pnEdit.Visible = true;
            }
            else
            {
                pnEdit.Visible = false;
                gvResult.DataSource = null;
                gvResult.DataBind();
            }
        }
        protected void lkbSave_Click(object sender, EventArgs e)
        {
            DataBase.Deinup("update tb_" + cmbTable.SelectedValue + " set Name='" + txtName.Text.Replace("'", string.Empty) + "' where " + cmbTable.SelectedValue + "Id=" + gvResult.DataKeys[gvResult.SelectedIndex][0]);
            txtName.Text = string.Empty;

            gvResult.Enabled = true;
            lkbAdd.Visible = true;
            lkbSave.Visible = false;
            gvResult.SelectedIndex = -1;

            FillGrid();
        }

        private void FillGrid()
        {
            gvResult.DataSource = DataBase.DataTable("exec uspMntSearch '" + cmbTable.SelectedValue + "'," + lkbPrev.CommandArgument + "," + (int.Parse(lkbNext.CommandArgument) + 1) + ",0");
            string[] key = new string[] { "FieldId" };
            gvResult.DataKeyNames = key;
            gvResult.DataBind();

            lkbPrev.Enabled = false;
            lkbNext.Enabled = false;
            if (gvResult.Rows.Count > glPaging) lkbNext.Enabled = true;
            if (lkbPrev.CommandArgument != "1") lkbPrev.Enabled = true;
        }
        protected void lkbPrev_Click(object sender, EventArgs e)
        {
            lkbPrev.CommandArgument = (int.Parse(lkbPrev.CommandArgument) - glPaging).ToString();
            lkbNext.CommandArgument = (int.Parse(lkbNext.CommandArgument) - glPaging).ToString();
            FillGrid();
        }
        protected void lkbNext_Click(object sender, EventArgs e)
        {
            lkbPrev.CommandArgument = (int.Parse(lkbPrev.CommandArgument) + glPaging).ToString();
            lkbNext.CommandArgument = (int.Parse(lkbNext.CommandArgument) + glPaging).ToString();
            FillGrid();
        }
        protected void gvResult_SelectedIndexChanged(object sender, EventArgs e)
        {
            gvResult.Enabled = false;
            lkbAdd.Visible = false;
            lkbSave.Visible = true;
            txtName.Text = gvResult.Rows[gvResult.SelectedIndex].Cells[1].Text;
        }
        protected void lkbAdd_Click(object sender, EventArgs e)
        {
            string t = txtName.Text.Replace("'", string.Empty);
            t = t.Replace(";", string.Empty);
            t = t.Trim();
            if (t.Length > 0)
            {
                DataBase.Deinup("if(select count(*) from tb_" + cmbTable.SelectedValue + " where Name='" + t + "')=0 insert into tb_" + cmbTable.SelectedValue + " values ('" + t + "')");
                FillGrid();
            }
        }
    }
}
