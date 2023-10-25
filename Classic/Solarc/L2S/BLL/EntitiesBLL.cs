using System.Text.RegularExpressions;

/// <summary>
/// Summary description for EntitiesBLL
/// </summary>
public class EntitiesBLL
{
	public EntitiesBLL()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public string CleanName(string name)
    {
        string t = @"[a-z0-9]+$";
        name = name.Trim();

        foreach (char c in name)
            if (!Regex.IsMatch("a", t))
                name.Replace(c,'@');

        return name.Replace("@", string.Empty);
    }
}
