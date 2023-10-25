using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;

/// <summary>
/// Summary description for DataBase
/// </summary>
public class DataBase
{
    public DataBase()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    private static SqlConnection _GetConn()
    {
        try
        {
            string strConnString = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
            SqlConnection conn = new SqlConnection(strConnString);
            return conn;
        }
        catch (Exception)
        {
            //tem erro
            return null;
        }
    }
    public static void Deinup(string strsql)
    {
        SqlConnection conn = _GetConn();
        conn.Open();
        SqlCommand comando = new SqlCommand(strsql, conn);
        comando.ExecuteReader();
        //SqlDataReader leitor = comando.ExecuteReader();
        conn.Close();
    }
    public static DataSet DataSet(string strsql)
    {
        SqlConnection conn = _GetConn();
        DataSet ds = new DataSet();
        SqlDataAdapter adapter = new SqlDataAdapter(strsql.ToString(), conn);
        adapter.Fill(ds);
        conn.Close();
        return ds;
    }
    public static DataSet DataSet(StringBuilder strsql)
    {
        SqlConnection conn = _GetConn();
        DataSet ds = new DataSet();
        SqlDataAdapter adapter = new SqlDataAdapter(strsql.ToString(), conn);
        adapter.Fill(ds);
        conn.Close();
        return ds;
    }
    public static DataTable DataTable(string strsql)
    {
        SqlConnection conn = _GetConn();
        DataSet ds = new DataSet();
        SqlDataAdapter adapter = new SqlDataAdapter(strsql, conn);
        adapter.Fill(ds);
        conn.Close();

        return ds.Tables[0];
    }
    public static DataTable DataTable(StringBuilder strsql)
    {
        SqlConnection conn = _GetConn();
        DataSet ds = new DataSet();
        SqlDataAdapter adapter = new SqlDataAdapter(strsql.ToString(), conn);
        adapter.Fill(ds);
        conn.Close();
        return ds.Tables[0];
    }

    public static bool HasRows(StringBuilder strsql)
    {
        SqlConnection conn = _GetConn();
        SqlCommand comando = new SqlCommand(strsql.ToString(), conn);
        conn.Open();
        SqlDataReader leitor = comando.ExecuteReader();
        bool valor;
        if (leitor.HasRows)
            valor = true;
        else
            valor = false;
        conn.Close();
        return valor;
    }
    public static string Scalar(StringBuilder strsql)
    {
        SqlConnection conn = _GetConn();
        SqlCommand comando = new SqlCommand(strsql.ToString(), conn);
        conn.Open();
        SqlDataReader leitor = comando.ExecuteReader();
        string valor;
        if (leitor.HasRows)
        {
            leitor.Read();
            valor = Convert.ToString(leitor.GetValue(0));
        }
        else
            valor = string.Empty;
        conn.Close();
        return valor;
    }
    public static string Scalar(string strsql)
    {
        SqlConnection conn = _GetConn();
        SqlCommand comando = new SqlCommand(strsql, conn);
        conn.Open();
        SqlDataReader leitor = comando.ExecuteReader();
        string valor;
        if (leitor.HasRows)
        {
            leitor.Read();
            valor = Convert.ToString(leitor.GetValue(0));
        }
        else
            valor = string.Empty;
        conn.Close();
        return valor;
    }
    public static SqlDataReader DataReader(string strsql)
    {
        SqlConnection conn = _GetConn();
        conn.Open();
        SqlCommand command = new SqlCommand(strsql.ToString(), conn);
        SqlDataReader reader = command.ExecuteReader();

        return reader.HasRows ? reader : null;
    }

    public static void Backup(string theDataBaseName, string thePath)
    {
        Deinup("exec uspBackup '" + theDataBaseName + "','" + thePath + "webapp\\secure\\files\\bd\\'");
    }
}
