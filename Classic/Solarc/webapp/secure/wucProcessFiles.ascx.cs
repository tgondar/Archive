using System;
using System.Web.UI.WebControls;
using System.Text;
using System.IO;
using System.Data;
using System.Web.Security;
using System.Configuration;

namespace Solarc.webapp.secure
{
    public partial class wucProcessFiles : System.Web.UI.UserControl
    {
        private int processId;
        private string ImageFileM = "<div style=\"float:left; text-align:center;\"><a href=\"{0}\" ><img border=\"0\" src=\"../../images/icons/{1}.png\" /><br />{2}</a></div>";
        private string ImageFileS = "<div style=\"float:left; text-align:center;\"><a href=\"{0}\" ><img border=\"0\" src=\"../../images/icons/{1}_s.png\" />&nbsp;{2}</a></div>";

        public int ProcessId
        {
            get { return processId; }
            set { processId = value; }
        }


        /*
            ### info
         * 
         * default
         * <div style="float:left; text-align:center;"><a href="#" ><img border="0" src="../../images/icons/excel.png" /><br />lalala</a></div>
         * 
         * SMALL
         * <div style="float:left; text-align:center;"><a href="#" ><img border="0" src="../../images/icons/excel_s.png" />lalala</a></div>
         */

        protected void Page_Load(object sender, EventArgs e)
        {
            lblInfo.Text = string.Empty;
            if (ProcessId > 0)
            {
                if (!IsPostBack)
                {
                    Parameter p = new Parameter();
                    if (p.GetValue(7) == "0")
                    {
                        ltMsg.Text = "Lamentamos informar, mas nao tem acesso a este módulo, para mais informações contacte " + ConfigurationManager.AppSettings["ContactInformation"];
                        imgBtSend.Visible = false;
                        gvResultFiles.Enabled = false;
                        return;
                    }

                    //GetFiles(int.Parse(ConfigurationManager.AppSettings["FilesSize"]));
                    FillGrid();

                    cklPermissions.Items.Add(new ListItem("Mandatário", "Representative"));
                    if (Roles.IsUserInRole(ConfigurationManager.AppSettings["RoleAdmin"]))
                        cklPermissions.Items.Add(new ListItem("Utilizador", "User"));

                    foreach (ListItem item in cklPermissions.Items)
                        item.Selected = true;
                }
            }
        }

        private void FillGrid()
        {
            gvResultFiles.DataSource = DataBase.DataSet("select ProcessId,Name,UserPermission,RepresentativePermission from vwProcessFile where ProcessId=" + ProcessId);
            string[] key = new string[] { "ProcessId", "Name", "UserPermission", "RepresentativePermission" };
            gvResultFiles.DataKeyNames = key;
            gvResultFiles.DataBind();
        }
        public StringBuilder GetFiles(int MediumSize)
        {
            StringBuilder sb = new StringBuilder("");

            DataSet ds = DataBase.DataSet("select Name,SecureName from vwProcessFile where ProcessId=" + ProcessId);
            if (Roles.IsUserInRole(ConfigurationManager.AppSettings["RoleUser"]))
                sb.Append(" and UserPermission=1");

            foreach (DataRow dtr in ds.Tables[0].Rows)
            {
                switch (dtr[0].ToString().Split('.').GetValue(1).ToString())
                {
                    case "pdf":
                        sb.Append(string.Format((MediumSize == 1 ? ImageFileM : ImageFileS), "../../Handler.ashx?File=" + dtr[0] + "&Process=" + ProcessId, "pdf", dtr[0]));
                        break;
                    case "excel":
                        sb.Append(string.Format((MediumSize == 1 ? ImageFileM : ImageFileS), "../../Handler.ashx?File=" + dtr[0] + "&Process=" + ProcessId, "excel", dtr[0]));
                        break;
                    case "doc":
                        sb.Append(string.Format((MediumSize == 1 ? ImageFileM : ImageFileS), "../../Handler.ashx?File=" + dtr[0] + "&Process=" + ProcessId, "doc", dtr[0]));
                        break;
                    default:
                        sb.Append(string.Format((MediumSize == 1 ? ImageFileM : ImageFileS), "../../Handler.ashx?File=" + dtr[0] + "&Process=" + ProcessId, "noicon", dtr[0]));
                        break;
                }
            }

            if (sb.Length > 0)
                lblFiles.Text = sb.ToString();

            return sb;
        }
        protected void gvResult_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ImageButton lkb = (ImageButton)e.Row.Cells[1].FindControl("imgBtSaveUserPermission");
                lkb.CommandArgument = e.Row.RowIndex.ToString();

                lkb = (ImageButton)e.Row.Cells[2].FindControl("imgBtSaveRepresentativePermission");
                lkb.CommandArgument = e.Row.RowIndex.ToString();

                lkb = (ImageButton)e.Row.Cells[3].FindControl("imgBtDelete");
                lkb.CommandArgument = e.Row.RowIndex.ToString();
            }
        }
        protected void gvResult_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                try
                {
                    ImageButton imgBt = (ImageButton)e.Row.Cells[1].FindControl("imgBtSaveUserPermission");
                    if (gvResultFiles.DataKeys[e.Row.RowIndex][2].ToString() == "1")
                        imgBt.ImageUrl = "~/images/webapp/icons/unlock.png";
                    else
                        imgBt.ImageUrl = "~/images/webapp/icons/lock.png";

                    imgBt = (ImageButton)e.Row.Cells[2].FindControl("imgBtSaveRepresentativePermission");
                    if (gvResultFiles.DataKeys[e.Row.RowIndex][3].ToString() == "1")
                        imgBt.ImageUrl = "~/images/webapp/icons/unlock.png";
                    else
                        imgBt.ImageUrl = "~/images/webapp/icons/lock.png";

                    string val = e.Row.Cells[0].Text;
                    e.Row.Cells[0].Text = "<a href=\"../../handler.ashx?File=" + val + "&Process=" + ProcessId + "\">" + val + "</a>";
                }
                catch (Exception ex)
                {
                    ltMsg.Text = "Erro: " + ex.Message;
                }
            }
        }


        protected void gvResult_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            StringBuilder sb = new StringBuilder("");
            if (e.CommandName.ToLower().Equals("userok"))
            {
                sb.Append("update tb_ProcessFile set UserPermission=");
                sb.Append(gvResultFiles.DataKeys[index][2].ToString() == "1" ? "0" : "1");
                sb.Append(" where ProcessId=" + gvResultFiles.DataKeys[index][0] + " and Name='" + gvResultFiles.DataKeys[index][1] + "'");
                DataBase.Deinup(sb.ToString());
            }
            else if (e.CommandName.ToLower().Equals("representativeok"))
            {
                sb.Append("update tb_ProcessFile set RepresentativePermission=");
                sb.Append(gvResultFiles.DataKeys[index][3].ToString() == "1" ? "0" : "1");
                sb.Append(" where ProcessId=" + gvResultFiles.DataKeys[index][0] + " and Name='" + gvResultFiles.DataKeys[index][1] + "'");
                DataBase.Deinup(sb.ToString());
            }
            else if (e.CommandName.ToLower().Equals("del"))
            {
                string secureFile = DataBase.Scalar("select SecureName from vwProcessFile where ProcessId=" + gvResultFiles.DataKeys[index][0] + " and Name='" + gvResultFiles.DataKeys[index][1] + "'");
                if (secureFile.Length > 0)
                {
                    if (File.Exists(Server.MapPath("~/App_Data/processfiles/") + ProcessId + "/" + secureFile))
                    {
                        File.Delete(Server.MapPath("~/App_Data/processfiles/") + ProcessId + "/" + secureFile);
                        DataBase.Deinup("delete from tb_ProcessFile where ProcessId=" + gvResultFiles.DataKeys[index][0] + " and Name='" + gvResultFiles.DataKeys[index][1] + "'");
                    }
                }
            }

            FillGrid();
            if (gvResultFiles.Rows.Count == 0)
            {
                if (Directory.Exists(Server.MapPath("~") + "/App_Data/processfiles/" + ProcessId))
                    Directory.Delete(Server.MapPath("~") + "/App_Data/processfiles/" + ProcessId + "/", false);
            }
        }
        protected void imgBtSend_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            string AppPath = Server.MapPath("~") + "/App_Data/processfiles/" + ProcessId, finalName, extension, SecureName;
            int error = 0;
            string[] nome;

            try
            {
                if (!Directory.Exists(Server.MapPath("~") + "/App_Data/processfiles/" + ProcessId))
                    Directory.CreateDirectory(Server.MapPath("~") + "/App_Data/processfiles/" + ProcessId + "/");

                nome = uploadform.Value.Split('\\');
                finalName = nome[nome.Length - 1];
                SecureName = Guid.NewGuid().ToString();
                error = 1;
                extension = finalName.Split('.').GetValue(1).ToString();

                string bdSecureName = DataBase.Scalar(new StringBuilder("select SecureName from vwProcessFile where ProcessId=" + ProcessId + " and Name='" + finalName + "'"));
                if (bdSecureName.Length == 0)
                    DataBase.Deinup("exec uspProcessFile " + ProcessId + ",'" + finalName + "','" + SecureName + "." + extension + "'," + (cklPermissions.Items.Count > 1 ? (cklPermissions.Items[1].Selected ? "1" : "0") : "0") + "," + (cklPermissions.Items[0].Selected ? "1" : "0") + ",'" + Membership.GetUser().ProviderUserKey + "'");
                else
                    SecureName = bdSecureName.Split('.').GetValue(0).ToString();

                uploadform.PostedFile.SaveAs(AppPath + "/" + SecureName + "." + extension);
                error = 2;

                // chama funcao para encher tabela temporaria

                //lblFiles.Text = GetFiles(int.Parse(ConfigurationManager.AppSettings["FilesSize"])).ToString();
                FillGrid();

            }
            catch (Exception ex)
            {
                if (error > 1)
                    File.Delete(AppPath);

                ltMsg.Text = "Erro: " + ex.Message;
            }
        }
    }
}
