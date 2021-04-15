using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UyeGiris : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Onayla_Click(object sender, EventArgs e)
    {
        UyeIslem uye = new UyeIslem();
       var sonuc= uye.Giris(ayarlar.Temizle(txtEmail.Text),ayarlar.Temizle(txtSifre.Text));

       if (sonuc.Basarilimi)
       {
           Session[SiteTanim.QSKullaniciSession] = sonuc.Veri;
           Response.Redirect("/default.aspx");
       }
       else
       {
           lblMesaj.Text = sonuc.Mesaj;
       }

    }
}