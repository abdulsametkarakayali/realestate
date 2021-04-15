using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DinamikSayfa : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int SayfaId = 0;
        if (Request.QueryString["SayfaId"] != null) 
        {
        try
        {
            SayfaId = Convert.ToInt32(Request.QueryString["SayfaId"]);
        }
         
        catch {   }

        if (SayfaId > 0)
        {
            SayfaGetir(SayfaId);
        }
        else
        {
            Response.Redirect("/default.aspx");
        }


        }
    }
    protected void SayfaGetir(int SayfaId)
    {
        SayfaIslem sayfa = new SayfaIslem();
        var sonuc = sayfa.SayfaGetir(SayfaId);

        if (sonuc.Basarilimi)
        {
           lblBaslik.Text=sonuc.Veri.SayfaAdi;
           ltlIcerik.Text = sonuc.Veri.Icerik;
        }else
	    {
            Response.Redirect("/default.aspx");    
	    }

    }
}