using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Kurumsal_Uyelik_Formu : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack) return;
        UlkeGetir();
        YetkiKontrol();
        drpUlke.Items.Insert(0,new ListItem("Pays","0"));
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
 
    protected void YetkiKontrol()
    {
        if (Session[SiteTanim.QSKullaniciSession] != null)
        {
            Response.Redirect("/default.aspx");
        }
    }
    
  
    protected void OnaylaveOde_Click(object sender, EventArgs e)
    {
        string kartno = txtKartNumarasi.Text;
        string guvenlikno = txtCcv.Text;
        string sktAy = drpSnkAy.SelectedItem.Value;
        string sktYil = drpSnkYil.SelectedItem.Value;
        int karttip = Convert.ToInt32(drpKartTip.SelectedItem.Value);

        bool sorgusonuc = true;
        if (sorgusonuc)
        {
            UyeOl();
            lblMesaj.Text = "UyeKaydi yapıldı, ödeme alındı.";

        }
        else
        {
            lblMesaj.Text = "Bir Hata Oluştu";
        }

    }
    protected void UyeOl() 
    {
     NuyeOl yeni = new NuyeOl
        {
            SirketIsmi=ayarlar.Temizle(txtSirketIsmi.Text),
            Siren=ayarlar.Temizle(txtSiren.Text),
            Adres=ayarlar.Temizle(txtAdres.Text)+ayarlar.Temizle(txtAdres2.Text)+ayarlar.Temizle(txtAdres3.Text),
            PostaKodu=int.Parse(ayarlar.Temizle(txtPostaKodu.Text)),
            UlkeId=int.Parse(drpUlke.SelectedValue),
            SehirAd=ayarlar.Temizle(txtSehirAd.Text),
            TelefonNo=ayarlar.Temizle(txtTelefon.Text),
            KayitTarih=DateTime.Now,
            Email=ayarlar.Temizle(txtEmail.Text),
            Sifre=ayarlar.Temizle(txtSifre.Text),
            UyeTip=(int)UyeTip.Kurumsal,
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