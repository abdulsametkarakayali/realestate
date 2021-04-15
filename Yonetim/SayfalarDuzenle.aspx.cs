using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Yonetim_SayfalarDuzenle : System.Web.UI.Page
{
    SayfaIslem yeni = new SayfaIslem();
    protected void Page_Load(object sender, EventArgs e)
    {
       if (IsPostBack) return;
        
       drpKategoriler.Items.Insert(0, new ListItem("Sayfa Seçiniz", "0"));

       SayfalariGetir();
      //  pnlBasarili.Visible = false;
       // pnlBasarisiz.Visible = false;
       
    }
    protected void SayfaDuzenle_Click(object sender, EventArgs e)
    {
        NSayfaBilgi kayit= new NSayfaBilgi
        {
             Icerik=CkeSayfaIcerik.Text,
             SayfaId=Convert.ToInt32(drpKategoriler.SelectedItem.Value),
              SayfaAciklama=txtSayfaAciklama.Text,
              SayfaAdi=txtSayfaAdi.Text
        };
      var sonuc=  yeni.SayfaDuzenle(kayit);
      if (sonuc.Basarilimi)
      {
         // SayfalariGetir();
          Response.Redirect("/yonetim/sayfalarduzenle.aspx");
          pnlBasarili.Visible = true;
          pnlBasarisiz.Visible = true;
      }
    }

    protected void SayfalariGetir() 
    {
       
        var sonuc = yeni.SayfalarGetir();
        if (sonuc.Basarilimi)
        {
            drpKategoriler.DataSource = sonuc.Veri;
            drpKategoriler.DataTextField = "Ad";
            drpKategoriler.DataValueField = "Id";
            drpKategoriler.DataBind();
        }
    
    }
    protected void drpKategoriler_SelectedIndexChanged(object sender, EventArgs e)
    {
        int SayfaId = Convert.ToInt32( drpKategoriler.SelectedItem.Value);
        var sonuc = yeni.SayfaGetir(SayfaId);
        
        if (sonuc.Basarilimi)
        {
           CkeSayfaIcerik.Text = sonuc.Veri.Icerik;
           txtSayfaAciklama.Text = sonuc.Veri.SayfaAciklama;
           txtSayfaAdi.Text = sonuc.Veri.SayfaAdi;
           
            
        }
       
        

    }
}