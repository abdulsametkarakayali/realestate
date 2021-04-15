using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class bireysel_uyelik_formu : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack) return;
        UlkeGetir();
        YetkiKontrol();
        drpUlke.Items.Insert(0, new ListItem("Pays", "0"));
       

    }
    protected void YetkiKontrol()
    {
        if (Session[SiteTanim.QSKullaniciSession]!=null)
        {
            Response.Redirect("/default.aspx");
        }
    }

    protected void UlkeGetir() 
    {
        SehirIslem ulke = new SehirIslem();
        var sonuc = ulke.UlkeGetir();
        if (sonuc.Basarilimi == true) 
        {
            drpUlke.DataSource = sonuc.Veri;
            drpUlke.DataTextField = "Ad";
            drpUlke.DataValueField = "Id";
            drpUlke.DataBind();
        }
    }

    

   
    protected void lnkOnayla_Click(object sender, EventArgs e)
    {
        NuyeOl yeni = new NuyeOl
        {
            Ad=ayarlar.Temizle(txtAd.Text),
            Soyad=ayarlar.Temizle(txtSoyad.Text),
            Adres=ayarlar.Temizle(txtAdres.Text)+ayarlar.Temizle(txtAdres2.Text)+ayarlar.Temizle(txtAdres3.Text),
            PostaKodu=int.Parse(ayarlar.Temizle(txtPostaKodu.Text)),
            UlkeId=int.Parse(drpUlke.SelectedValue),
            SehirAd=ayarlar.Temizle(txtSehirAd.Text),
            TelefonNo=ayarlar.Temizle(txtTelefonNo.Text),
            KayitTarih=DateTime.Now,
            Email=ayarlar.Temizle(txtEmail.Text),
            Sifre=ayarlar.Temizle(txtSifre.Text),
            UyeTip=(int)UyeTip.Bireysel
        };

        UyeIslem uye = new UyeIslem();
        var sonuc= uye.UyeOl(yeni);

        if (sonuc.Basarilimi == true)
        {
            Session[SiteTanim.QSKullaniciSession] = sonuc.Veri;
            Response.Redirect("/default.aspx");
        }
        else 
        {
            if (sonuc.HataBilgi != null)
            {
                lblMesaj.Text = "Bir hata oluştu.";
            }
            else
            {
                lblMesaj.Text = sonuc.Mesaj;
            }
        
        }
    }
}