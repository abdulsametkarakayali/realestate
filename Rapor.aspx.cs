using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using NReco;




public partial class Rapor : System.Web.UI.Page
{
   public int id = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
         
        if (Request.QueryString["id"] != null)
        {
            try
            {
                id = Convert.ToInt32(Request.QueryString["id"]);
            }
            catch { }
        }
        if (id > 0)
        {
            EnerjiSinifiGetir(id);
            KonutDetayGetir(id);
            GetirIlan(id);
            
             
           
           
        }
        else
        {
            Response.Redirect("Default.aspx");
        }
    
    }

    protected void KonutDetayGetir(int id)
    {
        DetayIslem KonutDetay = new DetayIslem();

        var sonuc = KonutDetay.GetirKonutDetay(id);
        dtlKonutDetay.DataSource = sonuc.Veri;
        dtlKonutDetay.DataBind();

    }

    protected void EnerjiSinifiGetir(int id)
    {

        DetayIslem enerji = new DetayIslem();

        var sonuc = enerji.GetirEnerjiSinifi(id);

        if (sonuc.Basarilimi)
        {
            lblEmisyonHaft.Text = sonuc.Veri.EmisyonSinifi;
            lblEmisyonNumara.Text = Convert.ToString(sonuc.Veri.EmisyonDegeri);
            lblEnerjiSinifiHarf.Text = sonuc.Veri.EnerjiSinifi;
            lblEnerjiSinifiNumara.Text = Convert.ToString(sonuc.Veri.EnerjiDegeri);
        }



    }

    protected void GetirIlan(int id)
    {

        DetayIslem ilan = new DetayIslem();

        var sonuc = ilan.GetirIlan(id);

        if (sonuc.Basarilimi)
        {
            lblUygunlukTarihi.Text =(sonuc.Veri.BosOlacagiTarih=="")?"  ---":  String.Format("{0:MM/dd/yyyy}", sonuc.Veri.BosOlacagiTarih);
            if (sonuc.Veri.AylikKira!=0)
            {
                lblSatilikKirada.Text = "oui";
            }
            else
            {
                lblSatilikKirada.Text = "non";
            }
            ltlTitle.Text = sonuc.Veri.IlanTipi + " " + sonuc.Veri.MulkiyetTipi + " " + sonuc.Veri.OdaSayisi + " Pièces" + " " + sonuc.Veri.YasamAlani + " m² " + sonuc.Veri.SehirAd + " " + string.Format("{0:0,00}", sonuc.Veri.Fiyat) + " € |IMMOBILIER - Annonces immobilières | Adhibe Property";
            lblMulkiyetDurum.Text = sonuc.Veri.MulkiyetTipi;
            lblSuOlcumleri.Text = sonuc.Veri.SuOlcum;
            lblIcMekan.Text = sonuc.Veri.IcMekan;
            lblAylikKira.Text =(sonuc.Veri.AylikKira==0)?"  ---":string.Format("{0:### ### ### ###.##}",sonuc.Veri.AylikKira);
            lblBinaYasi.Text =Convert.ToString(sonuc.Veri.BinaYasi);
            lblYillikAidat.Text = string.Format("{0:### ### ### ###.##}",sonuc.Veri.YillikAidat);
            lblKullanimAlani.Text = Convert.ToString(sonuc.Veri.KullanimAlani);
            lblYillikVergi.Text = string.Format("{0:### ### ### ###.##}",sonuc.Veri.YillikVergiler);
            lblMutfakEkipmani.Text =Convert.ToString( sonuc.Veri.MutfakEkipmanlari);
            lblBahceKapi.Text = (sonuc.Veri.BahceKapisi=="")?"non":sonuc.Veri.BahceKapisi;
            lblPencereler.Text = (sonuc.Veri.Pencereler=="")?"non":sonuc.Veri.Pencereler;
            lblPanjurlar.Text = (sonuc.Veri.Panjurlar=="")?"non":sonuc.Veri.Panjurlar;
            lblCati.Text = (sonuc.Veri.CatiDurum=="")?"non":sonuc.Veri.CatiDurum;
            lblCatiIskeleti.Text = (sonuc.Veri.CatiIskeletiDurum=="")?"non":sonuc.Veri.CatiIskeletiDurum;
            lblDisKaplama.Text = (sonuc.Veri.DisKaplamaDurum=="")?"non":sonuc.Veri.DisKaplamaDurum;
            lblDolaplar.Text = (sonuc.Veri.Dolaplar=="")?"non":sonuc.Veri.Dolaplar;
            lblBahceDuvari.Text = (sonuc.Veri.BahceDuvari=="")?"non":sonuc.Veri.BahceDuvari;
            lblInterphone.Text =(sonuc.Veri.Interphone== false) ? "non" : "oui";
            lblAlarm.Text = (sonuc.Veri.Alarm == false) ? "non" : "oui";
            lblUydu.Text = (sonuc.Veri.Uydu == false) ? "non" : "oui";
            lblAnten.Text = (sonuc.Veri.AntenTv == false) ? "non" : "oui";
            lblSomine1.Text = (sonuc.Veri.SomineTip1 == false) ? "non" : "oui";
			 lblSomine2.Text = (sonuc.Veri.SomineTip2 == false) ? "non" : "oui";
            lblCatiKati.Text = (sonuc.Veri.CatiKati=="")?"non":sonuc.Veri.CatiKati;
            lblBodrum.Text = (sonuc.Veri.Bodrum=="")?"non":sonuc.Veri.Bodrum;
            lblGaraj.Text = (sonuc.Veri.Garaj=="")?"non":sonuc.Veri.Garaj;
            lblKiler.Text = (sonuc.Veri.Kiler=="")?"non":sonuc.Veri.Kiler;
            lblGiyinmeOdasi.Text = (sonuc.Veri.GiyinmeOdasi=="")?"non":sonuc.Veri.GiyinmeOdasi;
            lblParkYeri.Text = (sonuc.Veri.ParkYeri=="")?"non":sonuc.Veri.ParkYeri;
            lblHavuz.Text = (sonuc.Veri.Havuz=="")?"non":sonuc.Veri.Havuz;
              lblAsansor.Text = sonuc.Veri.Asansor;
            lblYasamAlani.Text = Convert.ToString(sonuc.Veri.YasamAlani);
            lblOda.Text = Convert.ToString(sonuc.Veri.OdaSayisi);
            lblYatakOdasi.Text = Convert.ToString(sonuc.Veri.YatakOdasi);
            lblKatNo.Text = (sonuc.Veri.KatNo==0)?" ":"étage n°"+sonuc.Veri.KatNo;
             
          
            
            imgRapor.ImageUrl = sonuc.Veri.Resim;
            lblIletisimTel1.Text = sonuc.Veri.IlanTelefon;
            
            
            lblIsitma.Text = sonuc.Veri.Isitma;
            lblIsiYasi.Text = Convert.ToString(sonuc.Veri.IsiSistemleriYasi);
            lblEnerjiTip.Text = sonuc.Veri.EnerjiTipi;
            lblIsinmaTipi.Text = sonuc.Veri.IsinmaTipi;
            lblYillikTuketim.Text = string.Format("{0:### ### ### ###.##}",sonuc.Veri.YillikTuketim);
            lblGenelDurum.Text = sonuc.Veri.GenelDurum;
            lblAmiante.Text =(sonuc.Veri.Asbest == false) ? "non" : "oui";
            lblGaz.Text = (sonuc.Veri.Gaz == false) ? "non" : "oui";
            lblTermite.Text = (sonuc.Veri.Termit == false) ? "non" : "oui";
            lblElectriq.Text =(sonuc.Veri.Electrik == false) ? "non" : "oui";
            lblPlom.Text =  (sonuc.Veri.Kursun == false) ? "non" : "oui";
            lblCarrez.Text = (sonuc.Veri.Carrez == false) ? "non" : "oui";
            if (sonuc.Veri.SirketIsmi!=null)
            {
                lblFiyat.Text = string.Format("{0:### ### ### ###.##}", sonuc.Veri.Fiyat) + " € F.A.I.";
                lblUyeTipeGoreBaslik.Text = "Contacter l'agence Immobilière";
                lblFirmaAdi.Text = sonuc.Veri.SirketIsmi;
                PnlKurumsal.Visible = true;
                lblMail.Text = sonuc.Veri.UyeEposta;
            }
            else
            {
                lblFiyat.Text = string.Format("{0:### ### ### ###.##}", sonuc.Veri.Fiyat) + "€";
                lblUyeTipeGoreBaslik.Text = "Contacter les propriétaires";
                PnlBireysel.Visible = true;
                lblMailBireysel.Text = sonuc.Veri.IlanEmail;
                lblIletisimTelBireysel.Text = sonuc.Veri.IlanTelefon;
            }
            
            lblRef.Text = sonuc.Veri.ReferansNo;
        }



    }

    protected void PdfOlustur_Click(object sender, EventArgs e)
    {
        var htmlToPdf = new NReco.PdfGenerator.HtmlToPdfConverter();
       
        htmlToPdf.GeneratePdfFromFile("http://adhibe-property.com/raporsonuc.aspx?id="+id, null, "Dosya/exprt.pdf");
             
  
       
      Response.ContentType = "Application/pdf";
      Response.AppendHeader("Content-Disposition", "attachment; filename=adhibe.pdf");
      Response.TransmitFile(Server.MapPath("~/Dosya/exprt.pdf"));
      Response.End();
    }

    
}