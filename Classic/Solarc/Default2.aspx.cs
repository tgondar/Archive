using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Reflection;
using System.Text;

public partial class Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        StringBuilder strBody = new StringBuilder("");

        strBody.Append("<html " +
                "xmlns:o='urn:schemas-microsoft-com:office:office' " +
                "xmlns:w='urn:schemas-microsoft-com:office:word'" +
                "xmlns='http://www.w3.org/TR/REC-html40'>" +
                "<head><title>Time</title>");

        //'The setting specifies document's view after it is downloaded as Print
        //'instead of the default Web Layout
        strBody.Append("<!--[if gte mso 9]>" +
                                 "<xml>" +
                                 "<w:WordDocument>" +
                                 "<w:View>Print</w:View>" +
                                 "<w:Zoom>90</w:Zoom>" +
                                 "<w:DoNotOptimizeForBrowser/>" +
                                 "</w:WordDocument>" +
                                 "</xml>" +
                                 "<![endif]-->");

        strBody.Append("<style>");
        strBody.Append("<!-- /* Style Definitions */");
        strBody.Append("@page Section1");
        strBody.Append("   {size:8.5in 11.0in; ");
        strBody.Append("   margin:1.0in 1.25in 1.0in 1.25in ; ");
        strBody.Append("   mso-header-margin:.5in; ");
        strBody.Append("   mso-footer-margin:.5in; mso-paper-source:0;}");
        strBody.Append(" div.Section1");
        strBody.Append("   {page:Section1;}");
        strBody.Append("-->");
        strBody.Append("</style></head>");

        strBody.Append("<body lang=EN-US style='tab-interval:.5in'>" + TextBox1.Text.Replace("'", string.Empty));
        strBody.Append("</body></html>");

        //'Force this content to be downloaded 
        //'as a Word document with the name of your choice
        Response.AppendHeader("Content-Type", "application/msword");
        Response.AppendHeader("Content-disposition", "attachment; filename=myword.doc");
        Response.Write(strBody);
    }
    protected void LinkButton3_Click(object sender, EventArgs e)
    {
        StringBuilder sb = new StringBuilder("");

        sb.Append("<html>");
        sb.Append("<head>");
        sb.Append("</head>");
        sb.Append("<body>");
        sb.Append("   <form>");
        sb.Append("     ola ola ola");
        sb.Append("   </form>");
        sb.Append("</body>");
        sb.Append("</html>");

        Response.AppendHeader("Content-Type", "application/msword");
        Response.AppendHeader("Content-disposition", "attachment; filename=myword.doc");
        Response.Write(sb);
    }
}
