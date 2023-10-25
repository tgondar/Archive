using System;
using System.Web;
using System.Xml;
using System.Data;

/// <summary>
/// Summary description for Parameter
/// </summary>
public class Parameter
{
    private string processorId = "BFEBFBFF00020652";

    public string ProcessorId { get { return processorId; } }
    //1769 - 1
    //0769 ou com outro numero qualquer na 1ª posicao da sempre - 0
    private string Key1 = "93C71725-1769-40F6-82A0-9D97CAE0DFA8",
        Key3 = "5F2AFD04-7997-45C2-AC77-687903DAB089",
        Key5 = "5CBF2AB4-B934-4020-90FB-80413B33E948",
        Key6 = "47993F5A-CBEF-4A9F-A686-A4E2A28625A3",
        Key7 = "36A59DB0-F4C9-430A-955F-5079CDE97406";
    private int defaultStart = 8;

	public Parameter()
	{
	}

    public string GetValue(int Id)
    {
        string Value, defaultKey = string.Empty, aux = "0";

        XmlDocument xmldoc = new XmlDocument();
        xmldoc.Load(HttpContext.Current.Server.MapPath("~\\webapp\\parameters\\Parameter.xml"));
        XmlNodeList elements = xmldoc.SelectNodes(@"//parameters/parameter");

        //Value = elements[Id].Attributes.GetNamedItem("Value").FirstChild.InnerText;
        Value = elements[Id].Attributes[1].Value;
        switch (Id)
        {
            case 0: defaultKey = Key1; break;
            // informacoes mandatario
            case 1: defaultKey = Key1; break;
            // ipaddress
            case 2: return Value;
            // pagamentos/money
            case 3: defaultKey = Key3; break;
            case 4: return Value;
            case 5: defaultKey = Key5; Id++; break;
            case 6: defaultKey = Key6; Id++; break;
            case 7: defaultKey = Key7; Id++; break;
            default: throw new Exception("Id incorrecto.");
        }

        if (defaultKey.Remove(defaultStart + Id, 1) == Value.Remove(defaultStart + Id, 1))
        {
            if (Value[defaultStart + Id] == '1')
                aux = "1";
        }

        return aux;
    }

    public void SaveMessage(int theId, string theValue)
    {
        string path = HttpContext.Current.Server.MapPath("~\\webapp\\parameters\\Messages.xml");
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.Load(path);
        XmlNode node = xmlDoc.SelectNodes("messages/message").Item(theId);
        node.Attributes["value"].Value = theValue;
        xmlDoc.Save(path);
    }
    public DataTable GetAllMessages()
    {
        string path = HttpContext.Current.Server.MapPath("~\\webapp\\parameters\\Messages.xml");
        DataSet ds = new DataSet();
        ds.ReadXml(path);

        return ds.Tables[0];
    }
    public string GetMessage(int theId)
    {
        string path = HttpContext.Current.Server.MapPath("~\\webapp\\parameters\\Messages.xml");

        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.Load(path);
        XmlNode node = xmlDoc.SelectNodes("messages/message").Item(theId - 1);
        return node.Attributes["value"].Value;
    }

    public string GetInformation(int theId)
    {
        string path = HttpContext.Current.Server.MapPath("~\\webapp\\parameters\\Info.xml");

        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.Load(path);
        XmlNode node = xmlDoc.SelectNodes("information/info").Item(theId);
        return node.Attributes["value"].Value;
    }
}
