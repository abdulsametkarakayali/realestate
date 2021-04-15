using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Konut : System.Web.UI.Page
{
    public string MulkiyetTipi = "";
    protected void Page_Load(object sender, EventArgs e)
    {
         if (IsPostBack) return;
		 

         

        int sayi = 0;
        if (Request.QueryString["id"] != null)
        {
            try
            {
                MulkiyetTipi = Request.QueryString["id"];
                sayi++;
            }
            catch { }
        }
        if (sayi > 0)
        {
            KonutBilgisiGetir(MulkiyetTipi);

        }
        else
        {
            Response.Redirect("Default.aspx");
        }


    }


    protected void KonutBilgisiGetir(string MulkiyetTipi)
    {
        int id;
        AramaSonucIslem konut = new AramaSonucIslem();

        var sonuc = konut.GetirAramaKonutSonuc(MulkiyetTipi);

        


        if (sonuc.Basarilimi == true)
        {
           // int UyeId = ((NuyeBilgi)Session[SiteTanim.QSKullaniciSession]).UyeId;

        //    foreach (var i in sonuc.Veri)
          //  {
         //       id = i.IlanID;
           //     FavoriSorgula(UyeId, id);
          //  }

            CollectionPager1.DataSource = sonuc.Veri; ;
            CollectionPager1.BindToControl = rptKonutlar;
            rptKonutlar.DataSource = CollectionPager1.DataSourcePaged;
       

            
        }


    }

 
    





     
}