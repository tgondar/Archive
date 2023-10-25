using SolarcLogic.Dal;
using SolarcLogic.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Solarc.webapp.secure
{
    public partial class mntEntity : System.Web.UI.Page
    {
        EntityLogic el = new EntityLogic();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                gvResult.DataSource = el.GetLastChangedEntities();
                gvResult.DataKeyNames = new string[] { "EntityId" };
                gvResult.DataBind();
            }
        }

        protected void gvResult_SelectedIndexChanged(object sender, EventArgs e)
        {
            var ent = el.GetEntity(int.Parse(gvResult.DataKeys[gvResult.SelectedIndex][0].ToString()));

            txtAddress.Text = ent.EAddress;
            txtCode.Text = ent.Code;
            txtContactName.Text = ent.ContactName;
            txtEmail.Text = ent.Email;
            txtFax.Text = ent.Fax;
            txtHPhone.Text = ent.HPhone;
            txtIdentityCard.Text = ent.IdentityCard;
            txtMPhone.Text = ent.MPhone;
            txtName.Text = ent.Name;
            txtObservation.Text = ent.Observation;
            txtPostalCode.Text = ent.PostalCode;
            txtTaxNumber.Text = ent.TaxNumber;
            cbActive.Checked = ent.Active;

            btAdd.Visible = false;
            btSave.Visible = true;
            btSearch.Visible = false;
            gvResult.Enabled = false;
        }

        protected void gvResult_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int key = int.Parse(gvResult.DataKeys[e.RowIndex][0].ToString());

            try
            {
                el.DeleteEntity(key);
                ltMsg.Text = "Apagado com sucesso.";
            }
            catch (Exception ex)
            {
                ltMsg.Text = "Erro - Verifique se registo nao tem dados cruzados (está associado a um processo existente).";
            }

            gvResult.DataSource = el.GetLastChangedEntities();
            gvResult.DataKeyNames = new string[] { "EntityId" };
            gvResult.DataBind();
        }

        protected void btSearch_Click(object sender, EventArgs e)
        {
            gvResult.DataSource = el.GetEntities(txtName.Text);
            gvResult.DataKeyNames = new string[] { "EntityId" };
            gvResult.DataBind();
        }

        protected void btAdd_Click(object sender, EventArgs e)
        {
            //tb_Entity tent = new tb_Entity();

            //tent.Active = true;
            //tent.AlterDate = DateTime.Now;
            //tent.AlterUser = HttpContext.Current.User.Identity.Name;
            //tent.Code = txtCode.Text;
            //tent.ContactName = txtContactName.Text;
            //tent.CreateDate = DateTime.Now;
            //tent.CreateUser = HttpContext.Current.User.Identity.Name;
            //tent.EAddress = txtAddress.Text;
            //tent.Email = txtEmail.Text;
            //tent.Fax = tent.Fax;
            //tent.HPhone = txtHPhone.Text;
            //tent.IdentityCard = txtIdentityCard.Text;
            //tent.MPhone = txtMPhone.Text;
            //tent.Name = txtName.Text;
            //tent.Observation = txtObservation.Text;
            //tent.PostalCode = txtPostalCode.Text;
            //tent.TaxNumber = txtTaxNumber.Text;

            el.SaveEntity(0, txtCode.Text, txtName.Text, txtIdentityCard.Text, txtHPhone.Text, txtMPhone.Text, txtContactName.Text, txtFax.Text, txtEmail.Text, txtTaxNumber.Text, txtAddress.Text, txtPostalCode.Text, txtObservation.Text, HttpContext.Current.User.Identity.Name, cbActive.Checked);

            gvResult.DataSource = el.GetLastChangedEntities();
            gvResult.DataKeyNames = new string[] { "EntityId" };
            gvResult.DataBind();

        }

        protected void btSave_Click(object sender, EventArgs e)
        {
            el.SaveEntity(int.Parse(gvResult.DataKeys[gvResult.SelectedIndex][0].ToString()), txtCode.Text, txtName.Text, txtIdentityCard.Text, txtHPhone.Text, txtMPhone.Text, txtContactName.Text, txtFax.Text, txtEmail.Text, txtTaxNumber.Text, txtAddress.Text, txtPostalCode.Text, txtObservation.Text, HttpContext.Current.User.Identity.Name, cbActive.Checked);

            btAdd.Visible = true;
            btSave.Visible = false;
            btSearch.Visible = true;
            gvResult.Enabled = true;
            gvResult.SelectedIndex = -1;

            gvResult.DataSource = el.GetLastChangedEntities();
            gvResult.DataKeyNames = new string[] { "EntityId" };
            gvResult.DataBind();

            txtAddress.Text = "";
            txtCode.Text = "";
            txtContactName.Text = "";
            txtEmail.Text = "";
            txtFax.Text = "";
            txtHPhone.Text = "";
            txtIdentityCard.Text = "";
            txtMPhone.Text = "";
            txtName.Text = "";
            txtObservation.Text = "";
            txtPostalCode.Text = "";
            txtTaxNumber.Text = "";
            cbActive.Checked = false;
        }
    }
}
