using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Fonksiyon
/// </summary>
public class Fonksiyon
{
    public Bitmap resim_boyulandir(Stream resim, int genislik, int yukseklik)
    {
        Bitmap orjinalresim = new Bitmap(resim);
        int yenigenislik = orjinalresim.Width;
        int yeniyukseklik = orjinalresim.Height;
        double enboyorani = Convert.ToDouble(orjinalresim.Width) / Convert.ToDouble(orjinalresim.Height);
        //www.aspnetornekleri.com
        if (enboyorani <= 1 && orjinalresim.Width > genislik)
        {
            yenigenislik = genislik;
            yeniyukseklik = Convert.ToInt32(Math.Round(yenigenislik / enboyorani));
        }
        else if (enboyorani > 1 && orjinalresim.Height > yukseklik)
        {
            yeniyukseklik = yukseklik;
            yenigenislik = Convert.ToInt32(Math.Round(yeniyukseklik * enboyorani));
        }
        return new Bitmap(orjinalresim, yenigenislik, yeniyukseklik);
    }

    public static string MesajBox(string kelime, string link)
    {
        if (link == "geri")
        {
            kelime = "<script language='JavaScript'>alert('" + kelime + "');history.back(-1);</script>";
        }
        else
        {
            kelime = "<script language='JavaScript'>alert('" + kelime + "');window.location = '" + link + "';</script>";
        }
        return kelime;
    }


    public SqlConnection baglan()
    {
        SqlConnection baglanti = new SqlConnection("Data Source=5.2.85.56; Initial Catalog=db750_adhibe; User Id=db750_adhibe;Password=Veriyaz348484");
        baglanti.Open();
        return (baglanti);
    }

    public int cmd(string sqlcumle)
    {
        SqlConnection baglan = this.baglan();
        SqlCommand sorgu = new SqlCommand(sqlcumle, baglan);
        int sonuc = 0;

        try
        {
            sonuc = sorgu.ExecuteNonQuery();
        }
        catch (SqlException ex)
        {
            throw new Exception(ex.Message + " (" + sqlcumle + ")");
        }
        sorgu.Dispose();
        baglan.Close();
        baglan.Dispose();
        return (sonuc);
    }

    public DataTable GetDataTable(string sql)
    {
        SqlConnection baglanti = this.baglan();
        SqlDataAdapter adapter = new SqlDataAdapter(sql, baglanti);
        DataTable dt = new DataTable();
        try
        {
            adapter.Fill(dt);
        }
        catch (SqlException ex)
        {
            throw new Exception(ex.Message + " (" + sql + ")");
        }
        adapter.Dispose();
        baglanti.Close();
        baglanti.Dispose();
        return dt;
    }

    public DataSet GetDataSet(string sql)
    {
        SqlConnection baglanti = this.baglan();
        SqlDataAdapter adapter = new SqlDataAdapter(sql, baglanti);
        DataSet ds = new DataSet();
        try
        {
            adapter.Fill(ds);
        }
        catch (SqlException ex)
        {
            throw new Exception(ex.Message + " (" + sql + ")");
        }
        adapter.Dispose();
        baglanti.Close();
        baglanti.Dispose();
        return ds;
    }

    public DataRow GetDataRow(string sql)
    {
        DataTable table = GetDataTable(sql);
        if (table.Rows.Count == 0) return null;
        return table.Rows[0];
    }

    public string GetDataCell(string sql)
    {
        DataTable table = GetDataTable(sql);
        if (table.Rows.Count == 0) return null;
        return table.Rows[0][0].ToString();
    }
}