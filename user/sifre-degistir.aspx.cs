using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class user_sifre_degistir : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
  
    protected void SifreDegistir_Click(object sender, EventArgs e)
    {
        int UyeId = (int)((NuyeBilgi)Session[SiteTanim.QSKullaniciSession]).UyeId;
        UyeIslem yeni = new UyeIslem();
        var sonuc = yeni.SifreDegistir(ayarlar.Temizle(txtEskiSifre.Text), ayarlar.Temizle(txtYeniSifre.Text), UyeId);
        if (sonuc.Basarilimi)
        {
            lblMesaj.Text = "Şifre değiştirme işlemi gerçekleştirildi.";
        }
        else
        {
            lblMesaj.Text = sonuc.Mesaj;
        }
    }
}