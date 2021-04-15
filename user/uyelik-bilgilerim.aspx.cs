using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class user_uyelik_bilgilerim : System.Web.UI.Page
{
    int UyeId;
    protected void Page_Load(object sender, EventArgs e)
    {
		 if (IsPostBack) return;
        UyeIslem yeni = new UyeIslem();
        UyeId = ((NuyeBilgi)Session[SiteTanim.QSKullaniciSession]).UyeId;
        var sonuc= yeni.UyelikBilgileriGetir(UyeId);
        if (sonuc.Basarilimi)
        {
            txtAd.Text = sonuc.Veri.Adi;
            txtPostaKodu.Text=Convert.ToString(sonuc.Veri.PostaKodu);
            txtTelefonNo.Text = sonuc.Veri.Telefon;
            txtEmail.Text = sonuc.Veri.Eposta;
            txtSoyad.Text = sonuc.Veri.Soyadi;
            txtSifre.Text = sonuc.Veri.Sifre;
            txtAdres.Text = sonuc.Veri.Adres;

        }
    }




    protected void lnkOnayla_Click(object sender, EventArgs e)
    {

        UyeIslem yeni = new UyeIslem();
        int UyeId = (int)((NuyeBilgi)Session[SiteTanim.QSKullaniciSession]).UyeId;
        var sonuc =yeni.UyeDuzenle(new NuyeOl
        {
             Ad=txtAd.Text,
             Adres=txtAdres.Text,
             TelefonNo=txtTelefonNo.Text,
             Soyad=txtSoyad.Text,
             Email=txtEmail.Text,
             Sifre=txtSifre.Text,
              PostaKodu=Convert.ToInt32(txtPostaKodu.Text),
               UyeId=UyeId

        });
        if (sonuc.Basarilimi)
        {
            Response.Redirect("/user/uyelik-bilgilerim.aspx");
        }
        else
        {
            if (sonuc.HataBilgi != null)
            {
                lbMesaj.Text = "Bir hata oluştu";
            }
            else
            {
                lbMesaj.Text = sonuc.Mesaj;
            }
        }
    }
}