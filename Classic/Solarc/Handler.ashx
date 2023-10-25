<%@ WebHandler Language="C#" Class="Handler" %>

using System;
using System.Web;
using System.Data;
using System.Text;
using System.Web.Security;
using System.Configuration;

public class Handler : IHttpHandler {

    public void ProcessRequest(HttpContext context)
    {
        string filename, ProcessId;
        if (context.Request.QueryString["File"] != null && context.Request.QueryString["Process"] != null)
        {
            filename = context.Request.QueryString["File"];
            ProcessId = context.Request.QueryString["Process"];

            StringBuilder sb = new StringBuilder("select SecureName from vwProcessFile where ProcessId=" + ProcessId);
            if (Membership.GetUser() != null)
            {
                if (Roles.IsUserInRole(ConfigurationManager.AppSettings["RoleUser"]))
                    sb.Append(" and UserPermission=1");
                else if (Roles.IsUserInRole(ConfigurationManager.AppSettings["RoleRepresentative"]) || Roles.IsUserInRole("Cliente"))
                    sb.Append(" and RepresentativePermission=1");
                sb.Append(" and Name='" + filename + "'");

                DataSet ds = DataBase.DataSet(sb);
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    context.Response.Buffer = true;
                    context.Response.Clear();
                    context.Response.AddHeader("content-disposition", "attachment; filename=" + filename);
                    context.Response.ContentType = "octet/stream";
                    context.Response.WriteFile("~/App_Data/processfiles/" + ProcessId + "/" + ds.Tables[0].Rows[0][0]);
                }
            }
        }
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }
}