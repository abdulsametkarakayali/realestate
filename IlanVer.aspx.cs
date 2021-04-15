using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class IlanVer : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack) return;
        YetkiKontrol();
        UlkeGetir();
        UyeBilgi();
        drpUlke.Items.Insert(0, new ListItem("Pays", "0"));

        if (((NuyeBilgi)Session[SiteTanim.QSKullaniciSession]).UyeTip == (int)UyeTip.Bireysel)
        {
           
            PnlIletisimBilgileri.Visible = true;
            lblStep.Text = "3";
        }
        else if (((NuyeBilgi)Session[SiteTanim.QSKullaniciSession]).UyeTip == (int)UyeTip.Kurumsal)
        {
            PnlProfSatilik.Visible = true;
            PnlIletisimBilgileri.Visible = false;
            lblStep.Text = "2";
            
        }
        if (Request.QueryString["id"] != null)
        {
            try
            {
                if (Request.QueryString["id"] == "Location")
                {
                   
                    PnlProfSatilik.Visible = false;
                    pnlSatilikEv.Visible = false;
                    lblKonutTipi.Text = "Location";
					lblFiyat.Text="Loyer / mois €";
					if (((NuyeBilgi)Session[SiteTanim.QSKullaniciSession]).UyeTip == (int)UyeTip.Kurumsal)
					{
						 PnlProfSatilik.Visible = true;
					}
					
                }
                else if(Request.QueryString["id"] == "Vente")
                {
                    
                    pnlSatilikEv.Visible = true;
                    lblKonutTipi.Text = "Vente";
					lblFiyat.Text="Prix de vente en €*";
					 if (((NuyeBilgi)Session[SiteTanim.QSKullaniciSession]).UyeTip == (int)UyeTip.Kurumsal)
						{
							lblFiyat.Text = "Prix de vente FAI en €*";
							
						}
                   
                   
                }
                else
                {
                    Response.Redirect("/default.aspx");
                }
            }
            catch { }
        }
        else
        {
            Response.Redirect("/default.aspx");  
        }
        
         
    }

    protected void YetkiKontrol()
    {
        if (Session[SiteTanim.QSKullaniciSession] != null)
        {
            if (((NuyeBilgi)Session[SiteTanim.QSKullaniciSession]).UyeTip == (int)UyeTip.Bireysel)
            {
                pnlOdemeBireysel.Visible = true;
            }
            else if (((NuyeBilgi)Session[SiteTanim.QSKullaniciSession]).UyeTip == (int)UyeTip.Kurumsal)
            {
                pnlOdemeBireysel.Visible = false;
				pnlKurumsalUyeResim.Visible=true;
            }
            else
            {
                pnlOdemeBireysel.Visible = false;
            }
           
        }
        else
        {
            Response.Redirect("/UyeGiris.aspx");
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
    protected void UyeBilgi()
    {
        var uyebilgi = ((NuyeBilgi)Session[SiteTanim.QSKullaniciSession]);
        txtEmail.Text = uyebilgi.Eposta;
        txtTelefon.Text = Convert.ToString(uyebilgi.Telefon);
    
    }
    protected void btDevam_Click(object sender, EventArgs e)
    {
		 IlanIslem yeniilan = new IlanIslem();
		

        if (chckDaire.Checked)
        {
            hdnMulkiyetTipi.Value = "Appartement";
        }
        else if(chckVilla.Checked)
        {
            hdnMulkiyetTipi.Value = "Maison";
        }
        


		
		if(chckDaire.Checked || chckVilla.Checked){

         
        NIlan yeni = new NIlan
        {
           
            UyeId =(int) ((NuyeBilgi)Session[SiteTanim.QSKullaniciSession]).UyeId,
            UlkeId =(int) Convert.ToInt32(drpUlke.SelectedItem.Value),
            BinaYasi =string.IsNullOrEmpty(ayarlar.Temizle(txtBinaYasi.Text)) ? 0 : int.Parse(ayarlar.Temizle(txtBinaYasi.Text)),
            Adres=txtAdres.Text,
            OdaSayisi=Convert.ToInt32(ayarlar.Temizle(txtOdasayisi.Text)),
            YatakOdasi=(int) Convert.ToInt32(ayarlar.Temizle(txtYatakOdasi.Text)),
            YasamAlani=(int) Convert.ToInt32(txtYasamAlani.Text),
            KullanimAlani=string.IsNullOrEmpty(ayarlar.Temizle(txtKullanimAlani.Text)) ? 0 : int.Parse(ayarlar.Temizle(txtKullanimAlani.Text)) , 
            KatNo =string.IsNullOrEmpty(ayarlar.Temizle(txtKatNo.Text)) ? 0 : int.Parse(ayarlar.Temizle(txtKatNo.Text)),
            BireyselIkiz=ayarlar.Temizle(drpBireyselIkiz.SelectedValue),
             SehirAd=ayarlar.Temizle(txtSehirAd.Text),
           ReferansNo=ayarlar.Temizle(txtReferansNo.Text),
           IlanTipi=Convert.ToString(Request.QueryString["id"]),
            MulkiyetTipi=hdnMulkiyetTipi.Value,
            Asansor=ayarlar.Temizle(chckAsansor.SelectedValue),
            AylikKira=string.IsNullOrEmpty(ayarlar.Temizle(txtAylikKira.Text)) ? 0 : decimal.Parse(ayarlar.Temizle(txtAylikKira.Text)),
            BosOlacagiTarih = ayarlar.Temizle(txtBosOlacagiTarih.Text),
              IcMekan=  ayarlar.Temizle(chckIcMekan.SelectedValue),
               Sokak=ayarlar.Temizle(txtSokak.Text),
            Fiyat = string.IsNullOrEmpty(ayarlar.Temizle(txtFiyat.Text)) ? 0 : decimal.Parse(ayarlar.Temizle(txtFiyat.Text)),
            PostaKodu = string.IsNullOrEmpty(ayarlar.Temizle(txtPostaKodu.Text)) ? 0 : int.Parse(ayarlar.Temizle(txtPostaKodu.Text)) ,
           
            
        };
        var sonuc = yeniilan.Kaydet(yeni);
		
        Session[SiteTanim.QSIlanID] = Convert.ToString(sonuc.Veri);

        NEnerjiKaydet yenienerji = new NEnerjiKaydet 
        {
        EmisyonDegeri=Convert.ToInt32(ayarlar.Temizle(txtEmisyonNumara.Text)),
         EmisyonSinifi =txtEmisyonSinifi.Text,
          EnerjiDegeri=Convert.ToInt32(ayarlar.Temizle(txtEnerjiNumara.Text)),
          EnerjiSinifi=txtEnerjiSinifi.Text,
          IlanId=sonuc.Veri,
        };
        yeniilan.EnerjiBilgisiKaydet(yenienerji);
		int ilanId  = Convert.ToInt32(Session[SiteTanim.QSIlanID]);
        NIlanIletisim ilaniletisim = new NIlanIletisim 
        {
         IlanEmail=ayarlar.Temizle(txtEmail.Text),
          IlanIletisimSaatleri=ayarlar.Temizle(txtIletisimSaatleri.Text),
           IlanTelefon=ayarlar.Temizle(txtTelefon.Text),
           IlanTelefon2=ayarlar.Temizle(txtTelefon2.Text),
          // IlanIletisimSekli=chckIletisimSekli.SelectedItem.Value,
         IlanId = ilanId
        };
        yeniilan.IlanIletisimKaydet(ilaniletisim);
      
		
		if (((NuyeBilgi)Session[SiteTanim.QSKullaniciSession]).UyeTip == (int)UyeTip.Kurumsal)
            {
			   
        Fonksiyon yenikucukresim = new Fonksiyon();
        if (FileUpload1.HasFile)
        {
            string kresim = string.Empty;
            string bresim = string.Empty;
            Bitmap yeniresim = null;
            Bitmap byeniresim = null;
            try
            {
               
                
                IList<HttpPostedFile> SecilenDosyalar = FileUpload1.PostedFiles;
                if (!Directory.Exists(HttpContext.Current.Server.MapPath("/Dosya/IlanResim/" + ilanId + "/")))
                    Directory.CreateDirectory(HttpContext.Current.Server.MapPath("/Dosya/IlanResim/" + ilanId + "/"));
                if (!Directory.Exists(HttpContext.Current.Server.MapPath("/Dosya/IlanResim/" + ilanId + "/thump/")))
                    Directory.CreateDirectory(HttpContext.Current.Server.MapPath("/Dosya/IlanResim/" + ilanId + "/thump/"));
                for (int i = 0; i < SecilenDosyalar.Count; i++)
                {
                    FileUpload1.PostedFiles[i].SaveAs(Server.MapPath("/Dosya/IlanResim/" + ilanId + "/") + FileUpload1.PostedFiles[i].FileName);
                    
                     
                    yeniresim = yenikucukresim.resim_boyulandir(FileUpload1.PostedFiles[i].InputStream, 210, 130);//yeni resim için boyut veriyoruz..
                    kresim = Server.MapPath("/Dosya/IlanResim/" + ilanId + "/thump/") +  FileUpload1.PostedFiles[i].FileName;
                    yeniresim.Save(kresim, ImageFormat.Jpeg);

                    NResimler resimkaydet = new NResimler 
                    {
                        Resim = ("/Dosya/IlanResim/" + ilanId + "/") + FileUpload1.PostedFiles[i].FileName,
                         Thumb=("/Dosya/IlanResim/" + ilanId + "/thump/") +  FileUpload1.PostedFiles[i].FileName,
                         IlanId=ilanId
                    };
                    yeniilan.ResimKaydet(resimkaydet);

                }
            }
            catch (Exception ex)
            {
                Response.Write("Hata Oluştu: " + ex.Message.ToString());
            }
            finally
            {
                kresim = string.Empty;
                yeniresim.Dispose();
            }
        }
		
		}
       
		

 
		
        if (sonuc.Basarilimi == true)
        {
            lblMesaj.Text = "Kayit Başarılı" + sonuc.Veri;
            Response.Redirect("/IlanVer2.aspx");
        }
        else
        {
            if (sonuc.HataBilgi != null)
            {
                lblMesaj.Text = "Bir hata oluştu."+sonuc.Mesaj;
            }
            else
            {
                lblMesaj.Text = sonuc.Mesaj;
            }

        }
		
		}
		else
		{
			lblMesaj.Text = "Lütfen Mülkiyet Tipi Seçiniz";
			
		}


    }



    protected void chckKirada_CheckedChanged(object sender, EventArgs e)
    {
        if (chckKirada.Checked==true)
        {
            txtAylikKira.Visible = true;
           
            
        }
        else
        {
            txtAylikKira.Visible = false;
            
            
            txtBosOlacagiTarih.Visible = false;
        }
       
    }
    protected void libre_CheckedChanged(object sender, EventArgs e)
    {
        if (chclibre.Checked == true)
        {
            txtBosOlacagiTarih.Visible = true;
        }
        else
        {
            txtBosOlacagiTarih.Visible = false;
        }
    }
    protected void chckVilla_CheckedChanged(object sender, EventArgs e)
    {
        if (chckVilla.Checked ==true)
        {
            
            drpBireyselIkiz.Visible = true;
            chckDaire.Visible = false;
            lblDaire.Visible = false;
        }
        else
        {
           drpBireyselIkiz.Visible = false;
            chckDaire.Visible = true;
            lblDaire.Visible = true;
            lblVilla.Visible = true;
            chckVilla.Visible = true;
        }
       

    }
    protected void chckDaire_CheckedChanged(object sender, EventArgs e)
    {
        if (chckDaire.Checked==true)
        {
            txtKatNo.Visible = true;
            chckVilla.Visible = false;
            lblVilla.Visible = false;
        }
        else
        {
            txtKatNo.Visible = false;
            chckVilla.Visible = true;
            lblVilla.Visible = true;
                
        }
    }
}