using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Detay : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

         int id = 0;
        
        if (RouteData.Values["IlanID"] != null)
        {
            try
            {
                id = Convert.ToInt32(RouteData.Values["IlanID"]);
                
            }
            catch { }
        }
        if (id > 0)
        {
           ltlRapor.Text = RouteData.Values["IlanID"].ToString();
           
            EnerjiSinifiGetir(id);
            KonutDetayGetir(id);
            GetirResimler(id);
            GetirIlan(id);
            if (Session[SiteTanim.QSKullaniciSession] == null)
            {
               //veritabanına kayit edildi.;
            }
            else
            {
			
                int UyeId = ((NuyeBilgi)Session[SiteTanim.QSKullaniciSession]).UyeId;
                FavoriSorgula(UyeId, id);
            }
           

        }
        else
        {
            Response.Redirect("/Default.aspx");
        }
    }

    protected void EnerjiSinifiGetir(int id)
    {

        DetayIslem enerji = new DetayIslem();

        var sonuc = enerji.GetirEnerjiSinifi(id);

        if (sonuc.Basarilimi)
        {
            lblEmisyonHaft.Text = sonuc.Veri.EmisyonSinifi.ToUpper() ;
            lblEmisyonNumara.Text = Convert.ToString(sonuc.Veri.EmisyonDegeri);
            lblEnerjiSinifiHarf.Text = sonuc.Veri.EnerjiSinifi.ToUpper();
            lblEnerjiSinifiNumara.Text = Convert.ToString(sonuc.Veri.EnerjiDegeri);
        }

    
    
    }

    protected void GetirIlan(int id)
    {

        DetayIslem ilan = new DetayIslem();
         
        var sonuc = ilan.GetirIlan(id);

        if (sonuc.Basarilimi)
        {
            if (sonuc.Veri.UyeTip==2)
            {
                lblFiyat.Text = string.Format("{0:### ### ### ###.##}", sonuc.Veri.Fiyat) + " € F.A.I.";
                 
            }
            else
            {
                lblFiyat.Text = string.Format("{0:### ### ### ###.##}", sonuc.Veri.Fiyat) + " €";   
            }
           ltlTitle.Text= sonuc.Veri.IlanTipi + " " + sonuc.Veri.MulkiyetTipi + " " + sonuc.Veri.OdaSayisi + " Pièces" + " " + sonuc.Veri.YasamAlani + " m² " + sonuc.Veri.SehirAd + " " + string.Format("{0:0,00}", sonuc.Veri.Fiyat) + " € |IMMOBILIER - Annonces immobilières | Adhibe Property";
          // Page.Header.Description=" Annonce immobilière :"+ sonuc.Veri.IlanTipi + " " + sonuc.Veri.MulkiyetTipi + " " + sonuc.Veri.OdaSayisi + " Pièces" + " " + sonuc.Veri.YasamAlani + " m² " + sonuc.Veri.SehirAd + " " + string.Format("{0:0,00}", sonuc.Veri.Fiyat) + " € |IMMOBILIER - Annonces immobilières | Adhibe Property";
            lblYasamAlani.Text =Convert.ToString( sonuc.Veri.YasamAlani);
            lblOda.Text = Convert.ToString(sonuc.Veri.OdaSayisi);
            lblYatakOdasi.Text = Convert.ToString(sonuc.Veri.YatakOdasi);
            lblPostaKodu.Text =Convert.ToString( sonuc.Veri.PostaKodu);
            lblSehirAd.Text = sonuc.Veri.SehirAd;
            hidden.Value = sonuc.Veri.Sokak + " " + sonuc.Veri.SehirAd + " " + sonuc.Veri.UlkeAdi;
            lblMulkiyetTipi.Text = sonuc.Veri.MulkiyetTipi;
            lblAsansor.Text = sonuc.Veri.Asansor;
            lblUygunluk.Text = sonuc.Veri.IlanTipi;
            lblMulkiyetGenelDurum.Text = (sonuc.Veri.MulkiyetGenelDurum=="")?"non":sonuc.Veri.MulkiyetGenelDurum;
            lblOrtakKullanimDurumu.Text = (sonuc.Veri.OrtakKullanimDurum=="")?"non":sonuc.Veri.OrtakKullanimDurum;
            lblIsitma.Text = (sonuc.Veri.Isitma=="")?"non":sonuc.Veri.Isitma;
            lblIsitmaGenelDurum.Text = sonuc.Veri.GenelDurum;
            lblIsitmaYasi.Text = Convert.ToString(sonuc.Veri.IsiSistemleriYasi);
            lblIsitmaTipi.Text = sonuc.Veri.IsinmaTipi;
            lblEnerjiTipi.Text = sonuc.Veri.EnerjiTipi;
            lblIsitmaYillikTuketim.Text = Convert.ToString(sonuc.Veri.YillikTuketim);
            lblSuOlcumleri.Text = (sonuc.Veri.SuOlcum=="")?"non":sonuc.Veri.SuOlcum;
            lblGenelBinaYasi.Text = Convert.ToString(sonuc.Veri.BinaYasi);
            lblIcMekan.Text = sonuc.Veri.IcMekan;
            lblYillikVergi.Text =Convert.ToString(string.Format("{0:### ### ### ###.##}", sonuc.Veri.YillikVergiler));
            lblYillikAidat.Text = Convert.ToString(string.Format("{0:### ### ### ###.##}",sonuc.Veri.YillikAidat));
            lblKullanimAlani.Text = Convert.ToString(sonuc.Veri.KullanimAlani);
			lblAylikKira.Text= (sonuc.Veri.AylikKira==0)?"---":string.Format("{0:### ### ### ###.##}",sonuc.Veri.AylikKira);
            lblMutfakEkipmani.Text = Convert.ToString(sonuc.Veri.MutfakEkipmanlari);
            lblDolaplar.Text = (sonuc.Veri.Dolaplar== null)?"non":sonuc.Veri.Dolaplar;;
            lblBahceKapi.Text = sonuc.Veri.BahceKapisi;
            lblBahceKapisiDurumu.Text = sonuc.Veri.BahceKapisiDurumu;
            lblPencereler.Text = (sonuc.Veri.Pencereler=="")?"non":sonuc.Veri.Pencereler;
            lblCatiKati.Text = (sonuc.Veri.CatiKati=="")?"non":sonuc.Veri.CatiKati;
            lblPanjurlar.Text = (sonuc.Veri.Panjurlar=="")?"non":sonuc.Veri.Panjurlar;
            lblBahceDuvari.Text = (sonuc.Veri.BahceDuvari=="")?"non":sonuc.Veri.BahceDuvari;
            lblKiler.Text = (sonuc.Veri.Kiler  == null) ? "non" : sonuc.Veri.Kiler;
            lblGiyinmeOdasi.Text = (sonuc.Veri.GiyinmeOdasi == "") ? "non" : sonuc.Veri.GiyinmeOdasi;
            lblInterphone.Text =(sonuc.Veri.Interphone== true) ? "non" : "oui";
            lblAlarm.Text =  (sonuc.Veri.Alarm== true) ? "non" : "oui";
            lblAnten.Text =  (sonuc.Veri.AntenTv== true) ? "non" : "oui";
            lblSomine1.Text =  (sonuc.Veri.SomineTip1== true) ? "non" : "oui";
            lblSomine2.Text =  (sonuc.Veri.SomineTip2== true) ? "non" : "oui";
            lblBodrum.Text = (sonuc.Veri.Bodrum=="")?"non":sonuc.Veri.Garaj;
            lblGaraj.Text = (sonuc.Veri.Garaj=="")?"non":sonuc.Veri.Garaj;
            lblPark.Text = (sonuc.Veri.ParkYeri=="")?"non":sonuc.Veri.ParkYeri;
            lblHavuz.Text = (sonuc.Veri.Havuz=="")?"non":sonuc.Veri.Havuz;
            lblUydu.Text = (sonuc.Veri.Uydu== true) ? "non" : "oui";
            lblUygunlukVendu.Text = (sonuc.Veri.BosOlacagiTarih == "") ? "----" : sonuc.Veri.BosOlacagiTarih;
            lblAsbest.Text = (sonuc.Veri.Asbest == true) ? "non" : "oui";
            lblCarez.Text = (sonuc.Veri.Carrez == true) ? "non" : "oui";
            lblGaz.Text =  (sonuc.Veri.Gaz== true) ? "non" : "oui";
            lblTermit.Text = (sonuc.Veri.Termit== true) ? "non" : "oui";
            lblKursun.Text = (sonuc.Veri.Kursun == true) ? "non" : "oui";
            lblEnerji.Text = (sonuc.Veri.Electrik == true) ? "non" : "oui";
            lblIlanTipi.Text = sonuc.Veri.IlanTipi+" "+sonuc.Veri.MulkiyetTipi;
            lblCati.Text=(sonuc.Veri.CatiDurum=="")?"non":sonuc.Veri.CatiDurum;
            lblCatiIskeleti.Text = (sonuc.Veri.CatiIskeletiDurum=="")?"non":sonuc.Veri.CatiIskeletiDurum;
            lblDisKaplama.Text = (sonuc.Veri.DisKaplamaDurum=="")?"non":sonuc.Veri.DisKaplamaDurum;
            lblSirketIsmi.Text = sonuc.Veri.SirketIsmi;
            lblYayinTarih.Text = Convert.ToString(sonuc.Veri.YayinTarih.ToString("dd/M/yyyy"));
            lblReferans.Text ="Ref:"+sonuc.Veri.ReferansNo;
            lblTelefon.Text ="İletişim Numarası :<br/>"+ sonuc.Veri.IlanTelefon +"<br/>" +sonuc.Veri.IlanTelefon2;
            lblEmail.Text ="Email:<br/>"+sonuc.Veri.IlanEmail;
            LblIletisimSaat.Text ="İletişim Saatleri :<br/>"+sonuc.Veri.IlanIletisimSaatleri;
            ltlAcikalama.Text = sonuc.Veri.IlanAciklama;
            if (sonuc.Veri.MulkiyetTipi == "Maison")
            {

                lblKatBireysel.Text = sonuc.Veri.BireyselIkiz;
            }
            else
            {
                lblKatBireysel.Text ="Kat n°"+sonuc.Veri.KatNo.ToString();
            }

            if (sonuc.Veri.SirketIsmi==null)
            {
                pnlSirketIsmi.Visible = false;
            }
            else
            {
                pnlSirketIsmi.Visible = true;
            }
            
 
        }



    }


    protected void KonutDetayGetir(int id)
    {
        DetayIslem KonutDetay = new DetayIslem();

        var sonuc = KonutDetay.GetirKonutDetay(id);
        dtlKonutDetay.DataSource = sonuc.Veri;
        dtlKonutDetay.DataBind();
    
    }


    protected void GetirResimler(int id)
    {
        DetayIslem resimler = new DetayIslem();
        var sonuc = resimler.GetirResimler(id);
        if (sonuc.Basarilimi)
        {
            rptResimler.DataSource = sonuc.Veri;
            rptResimler.DataBind();
        }
    }

    protected void  FavoriSorgula(int UyeId, int IlanId)
    {
        DetayIslem  favori = new DetayIslem();
        var sonuc = favori.FavoriSorgula(UyeId, IlanId); 
        if (sonuc.Basarilimi)
        {
            ImgTakipBirak.Visible = true;
            ImgTakipEt.Visible = false;
        }
        else
        {
            ImgTakipBirak.Visible = false;
            ImgTakipEt.Visible = true;
        }
    }

    protected void ImgTakipEt_Click(object sender, ImageClickEventArgs e)
    {
				if (Session[SiteTanim.QSKullaniciSession]==null)
				{
					  Response.Redirect("/UyeGiris.aspx");
					 
				}
				else
				{
					 
				
		
		
        DetayIslem favori = new DetayIslem();
        NFavori yeni = new NFavori 
        {
         IlanId=Convert.ToInt32(RouteData.Values["IlanID"]),
         UyeId=((NuyeBilgi)Session[SiteTanim.QSKullaniciSession]).UyeId
         
        };
      var sonuc=  favori.FavoriEkle(yeni);
      if (sonuc.Basarilimi)
      {
          ImgTakipBirak.Visible = true;
          ImgTakipEt.Visible = false;
      }
	  }
		
        
    }
    protected void ImgTakipBirak_Click(object sender, ImageClickEventArgs e)
    {
        DetayIslem favori = new DetayIslem();
      var sonuc=   favori.FavoriCikar(Convert.ToInt32(RouteData.Values["IlanID"]), ((NuyeBilgi)Session[SiteTanim.QSKullaniciSession]).UyeId);
        if (sonuc.Basarilimi)
        {
            ImgTakipBirak.Visible = false;
            ImgTakipEt.Visible = true;
        }
    }
    protected void ImageEmail_Click(object sender, ImageClickEventArgs e)
    {
        pnlTelefonEmail.Visible = true;
        lblTelefon.Visible = false;
        lblEmail.Visible = true;
        LblIletisimSaat.Visible = false;
    }
    protected void ImageTel_Click(object sender, ImageClickEventArgs e)
    {
        pnlTelefonEmail.Visible = true;
        LblIletisimSaat.Visible = true;
        lblTelefon.Visible = true;
        lblEmail.Visible = false;
    }
}