using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class IlanVer2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
		
        if (IsPostBack) return;
	   YetkiKontrol();
        if (((NuyeBilgi)Session[SiteTanim.QSKullaniciSession]).UyeTip == (int)UyeTip.Bireysel)
        {
             
            lblStep.Text = "3";
        }
        else if (((NuyeBilgi)Session[SiteTanim.QSKullaniciSession]).UyeTip == (int)UyeTip.Kurumsal)
        {
            
            lblStep.Text = "2";

        }
        
    }
	
	
	 protected void YetkiKontrol()
    {
        if (Session[SiteTanim.QSKullaniciSession] != null)
        {
          
        }
        else
        {
            Response.Redirect("/UyeGiris.aspx");
        }

    }
     protected void lnkDevami_Click(object sender, EventArgs e)
     {
         for (int i = 0; i < chckDolaplar.Items.Count ; i++)
         {
             if (chckDolaplar.Items[i].Selected)
             {
                 hdndolaplar.Value  += chckDolaplar.Items[i].Value + " ";

             }
         }
             IlanIslem yenikonudetayislem = new IlanIslem();
             int ilanverid = Convert.ToInt32(Session[SiteTanim.QSIlanID]);
             #region Konutdetay Kayitlari
             var sonucgiris = yenikonudetayislem.KonutDetayKaydet(new NKonutDetay
             {
                 Odalar = "Entrée",
                 m2 = ayarlar.Temizle(txtm2Giris.Text),
                 Kat = drpZeminGiris.SelectedItem.Value,
                 Yon = drpYonGiris.SelectedItem.Value,
                 YerDoseme = drpYerDosemeGiris.SelectedItem.Value,
                 Cerceveler = drpCercevelerGiris.SelectedItem.Value,
                 Camlar = drpCamlarGiris.SelectedItem.Value,
                 Panjur = drpPanjularGiris.SelectedItem.Value,
                 IlanId = ilanverid,

             });


             var sonucmutfak = yenikonudetayislem.KonutDetayKaydet(new NKonutDetay
               {
                   Odalar = "Cuisine",
                   m2 = ayarlar.Temizle(txtm2Mutfak.Text),
                   Kat = drpZeminMutfak.SelectedItem.Value,
                   Yon = drpYonMutfak.SelectedItem.Value,
                   YerDoseme = drpYerDosemeMutfak.SelectedItem.Value,
                   Cerceveler = drpCercevelerMutfak.SelectedItem.Value,
                   Camlar = drpCamlarMutfak.SelectedItem.Value,
                   Panjur = drpPanjularMutfak.SelectedItem.Value,
                   IlanId = ilanverid,
               });


             var sonucsalon = yenikonudetayislem.KonutDetayKaydet(new NKonutDetay
                {

                    Odalar = "Salon",
                    m2 =ayarlar.Temizle(txtm2Salon.Text),
                    Kat = drpZeminSalon.SelectedItem.Value,
                    Yon = drpYonSalon.SelectedItem.Value,
                    YerDoseme = drpYerDosemeSalon.SelectedItem.Value,
                    Cerceveler = drpCercevelerSalon.SelectedItem.Value,
                    Camlar = drpCamlarSalon.SelectedItem.Value,
                    Panjur = drpPanjularSalon.SelectedItem.Value,
                    IlanId = ilanverid,
                });

             var sonucebeveyn = yenikonudetayislem.KonutDetayKaydet(new NKonutDetay
            {
                Odalar = "Suite parentale",
                m2 = ayarlar.Temizle(txtm2Ebeveyn.Text),
                Kat = drpZeminEbeveyn.SelectedItem.Value,
                Yon = drpYonEbeveyn.SelectedItem.Value,
                YerDoseme = drpYerDosemeEbeveyn.SelectedItem.Value,
                Cerceveler = drpCercevelerEbeveyn.SelectedItem.Value,
                Camlar = drpCamlarEbeveyn.SelectedItem.Value,
                Panjur = drpPanjularEbeveyn.SelectedItem.Value,
                IlanId = ilanverid,
            });

           

             var sonucyatak = yenikonudetayislem.KonutDetayKaydet(new NKonutDetay
             {
                 Odalar = "Chambre 1",
                 m2 =ayarlar.Temizle(txtm2YatakOdasi1.Text),
                 Kat = drpZeminYatakOdasi1.SelectedItem.Value,
                 Yon = drpYonYatakOdasi1.SelectedItem.Value,
                 YerDoseme = drpYerDosemeYatakOdasi1.SelectedItem.Value,
                 Cerceveler = drpCercevelerYatakOdasi1.SelectedItem.Value,
                 Camlar = drpCamlarYatakOdasi1.SelectedItem.Value,
                 Panjur = drpPanjularYatakOdasi1.SelectedItem.Value,
                 IlanId = ilanverid,
             });

             var sonucyatak1 = yenikonudetayislem.KonutDetayKaydet(new NKonutDetay
            {
                Odalar = "Chambre 2",
                m2 = ayarlar.Temizle(txtm2YatakOdasi2.Text),
                Kat = drpZeminYatakOdasi2.SelectedItem.Value,
                Yon = drpYonYatakOdasi2.SelectedItem.Value,
                YerDoseme = drpYerDosemeYatakOdasi2.SelectedItem.Value,
                Cerceveler = drpCercevelerYatakOdasi2.SelectedItem.Value,
                Camlar = drpCamlarYatakOdasi2.SelectedItem.Value,
                Panjur = drpPanjularYatakOdasi2.SelectedItem.Value,
                IlanId = ilanverid,
            });

             var sonucyatak2 = yenikonudetayislem.KonutDetayKaydet(new NKonutDetay
            {
                Odalar = "Chambre 3",
                m2 = ayarlar.Temizle(txtm2YatakOdasi3.Text),
                Kat = drpZeminYatakOdasi3.SelectedItem.Value,
                Yon = drpYonYatakOdasi3.SelectedItem.Value,
                YerDoseme = drpYerDosemeYatakOdasi3.SelectedItem.Value,
                Cerceveler = drpCercevelerYatakOdasi3.SelectedItem.Value,
                Camlar = drpCamlarYatakOdasi3.SelectedItem.Value,
                Panjur = drpPanjularYatakOdasi3.SelectedItem.Value,
                IlanId = ilanverid,
            });

             var sonucyatak3 = yenikonudetayislem.KonutDetayKaydet(new NKonutDetay
           {
               Odalar = "Chambre 4",
               m2 = ayarlar.Temizle(txtm2YatakOdasi4.Text),
               Kat = drpZeminYatakOdasi4.SelectedItem.Value,
               Yon = drpYonYatakOdasi4.SelectedItem.Value,
               YerDoseme = drpYerDosemeYatakOdasi4.SelectedItem.Value,
               Cerceveler = drpCercevelerYatakOdasi4.SelectedItem.Value,
               Camlar = drpCamlarYatakOdasi4.SelectedItem.Value,
               Panjur = drpPanjularYatakOdasi4.SelectedItem.Value,
               IlanId = ilanverid,
           });

             var sonucyatak4 = yenikonudetayislem.KonutDetayKaydet(new NKonutDetay
            {
                Odalar = "Chambre  5",
                m2 = ayarlar.Temizle(txtm2YatakOdasi5.Text),
                Kat = drpZeminYatakOdasi5.SelectedItem.Value,
                Yon = drpYonYatakOdasi5.SelectedItem.Value,
                YerDoseme = drpYerDosemeYatakOdasi5.SelectedItem.Value,
                Cerceveler = drpCercevelerYatakOdasi5.SelectedItem.Value,
                Camlar = drpCamlarYatakOdasi5.SelectedItem.Value,
                Panjur = drpPanjularYatakOdasi5.SelectedItem.Value,
                IlanId = ilanverid,
            });

             var sonucyatak5 = yenikonudetayislem.KonutDetayKaydet(new NKonutDetay
            {
                Odalar = "Chambre 6",
                m2 = ayarlar.Temizle(txtm2YatakOdasi6.Text),
                Kat = drpZeminYatakOdasi6.SelectedItem.Value,
                Yon = drpYonYatakOdasi6.SelectedItem.Value,
                YerDoseme = drpYerDosemeYatakOdasi6.SelectedItem.Value,
                Cerceveler = drpCercevelerYatakOdasi6.SelectedItem.Value,
                Camlar = drpCamlarYatakOdasi6.SelectedItem.Value,
                Panjur = drpPanjularYatakOdasi6.SelectedItem.Value,
                IlanId = ilanverid,
            });
             var sonucyatak6 = yenikonudetayislem.KonutDetayKaydet(new NKonutDetay
             {
                 Odalar = "Chambre 7",
                 m2 = ayarlar.Temizle(txtm2YatakOdasi7.Text),
                 Kat = drpZeminYatakOdasi7.SelectedItem.Value,
                 Yon = drpYonYatakOdasi7.SelectedItem.Value,
                 YerDoseme = drpYerDosemeYatakOdasi7.SelectedItem.Value,
                 Cerceveler = drpCercevelerYatakOdasi7.SelectedItem.Value,
                 Camlar = drpCamlarYatakOdasi7.SelectedItem.Value,
                 Panjur = drpPanjularYatakOdasi7.SelectedItem.Value,
                 IlanId = ilanverid,
             });
			 
			 
			  var sonucbureau = yenikonudetayislem.KonutDetayKaydet(new NKonutDetay
             {
                 Odalar = "Bureau",
                 m2 = ayarlar.Temizle(txtm2Calisma.Text),
                 Kat = drpZeminCalisma.SelectedItem.Value,
                 Yon = drpYonCalisma.SelectedItem.Value,
                 YerDoseme = drpYerDosemeCalisma.SelectedItem.Value,
                 Cerceveler = drpCercevelerCalisma.SelectedItem.Value,
                 Camlar = drpCamlarCalisma.SelectedItem.Value,
                 Panjur = drpPanjularCalisma.SelectedItem.Value,
                 IlanId = ilanverid,
             });
			 
			 	  var sonucsalle = yenikonudetayislem.KonutDetayKaydet(new NKonutDetay
             {
                 Odalar = "Salle de bain 1",
                 m2 = ayarlar.Temizle(txtm2Banyo.Text),
                 Kat = drpZeminBanyo1.SelectedItem.Value,
                 Yon = drpYonBanyo1.SelectedItem.Value,
                 YerDoseme = drpYerDosemeBanyo1.SelectedItem.Value,
                 Cerceveler = drpCercevelerBanyo1.SelectedItem.Value,
                 Camlar = drpCamlarBanyo1.SelectedItem.Value,
                 Panjur = drpPanjularBanyo1.SelectedItem.Value,
                 IlanId = ilanverid,
             });
			  	  var sonucsalled = yenikonudetayislem.KonutDetayKaydet(new NKonutDetay
             {
                 Odalar = "Salle d’eau",
                 m2 = ayarlar.Temizle(txtm2Dusakabin.Text),
                 Kat = drpZeminDusakabin.SelectedItem.Value,
                 Yon = drpYonDusakabin.SelectedItem.Value,
                 YerDoseme = drpYerDosemeDusakabin.SelectedItem.Value,
                 Cerceveler = drpCercevelerDusakabin.SelectedItem.Value,
                 Camlar = drpCamlarDusakabin.SelectedItem.Value,
                 Panjur = drpPanjularDusakabin.SelectedItem.Value,
                 IlanId = ilanverid,
             });
			 	  var sonucwc1 = yenikonudetayislem.KonutDetayKaydet(new NKonutDetay
             {
                 Odalar = "WC 1",
                 m2 = ayarlar.Temizle(txtm2Wc1.Text),
                 Kat = drpZeminWc1.SelectedItem.Value,
                 Yon = drpYonWc1.SelectedItem.Value,
                 YerDoseme = drpYerDosemeWc1.SelectedItem.Value,
                 Cerceveler = drpCercevelerWc1.SelectedItem.Value,
                 Camlar = drpCamlarWc1.SelectedItem.Value,
                 Panjur = drpPanjularWc1.SelectedItem.Value,
                 IlanId = ilanverid,
             });
			  	  var sonucwc2 = yenikonudetayislem.KonutDetayKaydet(new NKonutDetay
             {
                 Odalar = "WC 2",
                 m2 = ayarlar.Temizle(txtm2Wc2.Text),
                 Kat = drpZeminWc2.SelectedItem.Value,
                 Yon = drpYonWc2.SelectedItem.Value,
                 YerDoseme = drpYerDosemeWc2.SelectedItem.Value,
                 Cerceveler = drpCercevelerWc2.SelectedItem.Value,
                 Camlar = drpCamlarWc2.SelectedItem.Value,
                 Panjur = drpPanjularWc2.SelectedItem.Value,
                 IlanId = ilanverid,
             });
			   	  var sonucmezzanine = yenikonudetayislem.KonutDetayKaydet(new NKonutDetay
             {
                 Odalar = "Mezzanine",
                 m2 = ayarlar.Temizle(txtm2AsmaKat.Text),
                 Kat = drpZeminAsmaKat.SelectedItem.Value,
                 Yon = drpYonAsmaKat.SelectedItem.Value,
                 YerDoseme = drpYerDosemeAsmaKat.SelectedItem.Value,
                 Cerceveler = drpCercevelerAsmaKat.SelectedItem.Value,
                 Camlar = drpCamlarAsmaKat.SelectedItem.Value,
                 Panjur = drpPanjularAsmaKat.SelectedItem.Value,
                 IlanId = ilanverid,
             });
			
			   	  var sonucveranda = yenikonudetayislem.KonutDetayKaydet(new NKonutDetay
             {
                 Odalar = "Véranda",
                 m2 = ayarlar.Temizle(txtm2Veranda.Text),
                 Kat = drpZeminVeranda.SelectedItem.Value,
                 Yon = drpYonVeranda.SelectedItem.Value,
                 YerDoseme = drpYerDosemeVeranda.SelectedItem.Value,
                 Cerceveler = drpCercevelerVeranda.SelectedItem.Value,
                 Camlar = drpCamlarVeranda.SelectedItem.Value,
                 Panjur = drpPanjularVeranda.SelectedItem.Value,
                 IlanId = ilanverid,
             });
             #endregion

             NIlanDetay yeniilandetay = new NIlanDetay
             {
                 MulkiyetGenelDurum = chckgeneldurum.SelectedValue,
                 OrtakKullanimDurum = chckOrtakkullanim.SelectedValue,
                 BahceKapisi = chckBahceKapisi.SelectedValue,
                 BahceKapisiDurumu = chckBahceKapisiDurumu.SelectedValue,
                 Pencereler = chckPencereler.SelectedValue,
                 CatiDurum = chckCatiDurum.SelectedValue,
                 CatiIskeletiDurum = chckCatiIskeleti.SelectedValue,
                 DisKaplamaDurum = chckDisKaplama.SelectedValue,
                 Panjurlar = chckPanjurlar.SelectedValue,
                
                 Dolaplar=hdndolaplar.Value,
                 YillikAidat = string.IsNullOrEmpty(ayarlar.Temizle(txtYillikAidat.Text)) ? 0 : decimal.Parse(ayarlar.Temizle(txtYillikAidat.Text)),
                 YillikVergiler = string.IsNullOrEmpty(ayarlar.Temizle(txtYillikVergi.Text)) ? 0 : decimal.Parse(ayarlar.Temizle(txtYillikVergi.Text)),
                 MutfakEkipmanlari = chckMutfakEkipmanlari.Checked,
                 Interphone = chckedInterphone.Checked,
                 Alarm = chckedAlarm.Checked,
                 Uydu = chckedUydu.Checked,
                 AntenTv = chckedAnten.Checked,
                 SomineTip1 = chckedSomine1.Checked,
                 SomineTip2 = chckedSomine2.Checked,
                 CatiKati = ayarlar.Temizle(txtCatikati.Text),
                 Bodrum = ayarlar.Temizle(txtBodrum.Text),
                 Garaj = ayarlar.Temizle(txtGaraj.Text),
                 ParkYeri = ayarlar.Temizle(txtParkYeri.Text),
                 Havuz = ayarlar.Temizle(txtHavuz.Text),
                 BahceDuvari = chckBahceDuvari.SelectedValue,
                 SuOlcum=chckSuOlcum.SelectedValue,
                 Kiler=ayarlar.Temizle(txtKiller.Text),
                 GiyinmeOdasi=ayarlar.Temizle(txtGiyinmeOdasi.Text),
                 IlanAciklama=ayarlar.Temizle(txtAciklama.Text),
                 IlanId = ilanverid

             };
             IlanIslem yeniilan = new IlanIslem();


             NIsinma yeniisinma = new NIsinma
             {
                 GenelDurum = chckIsinmagenelDurum.SelectedValue,
                 IsiSistemleriYasi = string.IsNullOrEmpty(ayarlar.Temizle(txtIsınmaSistemiYasi.Text)) ? 0 : int.Parse(ayarlar.Temizle(txtIsınmaSistemiYasi.Text)),
                 Isitma = chckIsitma.SelectedValue,
                 IsinmaTipi = chckIsınmaTipi.SelectedValue,
                 EnerjiTipi = chckEnerjiTipi.SelectedValue,
                 YillikTuketim = string.IsNullOrEmpty(ayarlar.Temizle(txtIsınmaYillikTuketim.Text)) ? 0 : decimal.Parse(ayarlar.Temizle(txtIsınmaYillikTuketim.Text)),
                 IlanId = ilanverid,

             };

             yeniilan.IsinmaKaydet(yeniisinma);

             NTeshisler yeniteshisler = new NTeshisler
             {
                 Asbest = chckasbest.Checked,
                 Termit = chctermit.Checked,
                 Kursun = chckursun.Checked,
                 Gaz = chcgaz.Checked,
                 Carrez = chccarrez.Checked,
                 Electrik = chccelectrik.Checked,
                 IlanId = ilanverid,
             };
             yeniilan.TeshislerKaydet(yeniteshisler);



             yeniilan.IlanDetayKaydet(yeniilandetay);

             if (((NuyeBilgi)Session[SiteTanim.QSKullaniciSession]).UyeTip == (int)UyeTip.Bireysel)
             {
                 Response.Redirect("/ilanver3.aspx");
             }
             else if (((NuyeBilgi)Session[SiteTanim.QSKullaniciSession]).UyeTip == (int)UyeTip.Kurumsal)
             {
                  Response.Redirect("/ilanonay.aspx");
             }

             //    if (ilanEklendiMi){
             //      
             //   else{
             //  Response.Write(Fonksiyon.MesajBox("Özür dileriz, silme işlemi sırasında bir sorun ile karşılaşıldı"));}



         }
 
    protected void chckKiller_CheckedChanged(object sender, EventArgs e)
    {
        txtKiller.Visible = true;
    } 
	 protected void chckGiyinme_CheckedChanged(object sender, EventArgs e)
    {
        txtGiyinmeOdasi.Visible = true;
    } 
	protected void chckCatiKati_CheckedChanged(object sender, EventArgs e)
    {
        txtCatikati.Visible = true;
    }
    protected void chckBodrum_CheckedChanged(object sender, EventArgs e)
    {
        txtBodrum.Visible = true;
    }
    protected void chckGaraj_CheckedChanged(object sender, EventArgs e)
    {
        txtGaraj.Visible = true;
    }
    protected void chckParkYeri_CheckedChanged(object sender, EventArgs e)
    {
        txtParkYeri.Visible = true;
    }
    protected void chckHavuz_CheckedChanged(object sender, EventArgs e)
    {
        txtHavuz.Visible = true;
    }
}