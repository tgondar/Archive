using System;
using System.Web;
using System.Xml;

public class AppKey
{
    public char v1 { get; set; }
    public char v2 { get; set; }
    public char v3 { get; set; }

	public AppKey()
	{
	}

    private string GetAppKey()
    {
        string path = HttpContext.Current.Server.MapPath("~\\webapp\\parameters\\Parameter.xml");
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.Load(path);
        XmlNode node = xmlDoc.SelectNodes("parameters/parameter").Item(8);

        return node.Attributes["value"].Value;
    }

    public string GetRandomKey()
    {
        Random r = new Random();
        string key = GetAppKey();
        return r.Next(key.Length - 1) + "-" + r.Next(key.Length - 1) + "-" + r.Next(key.Length - 1);
    }

    public bool CheckKey(int _v1,int _v2,int _v3)
    {
        string key = GetAppKey();

        return (v1 == key[_v1] && v2 == key[_v2] && v3 == key[_v3]);
    }
}
