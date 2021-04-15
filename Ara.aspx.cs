using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Ara : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack) return;
		 UlkeGetir();
		  drpUlke.Items.Insert(0, new ListItem("Pays", "0"));
    }
	  protected void imageAra_Click(object sender, ImageClickEventArgs e)
     {
         AramaYap();
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
	 protected void  AramaYap(){
      //  AramaSonucIslem  arama = new AramaSonucIslem();
         Fonksiyon system = new Fonksiyon();
    
       // var sonuc = arama.IlanAra(yeni);
		
		int sorguDurum = 0;
            string sorgu = "select * from AramaSonuclari WHERE ";
            if (!string.IsNullOrEmpty(drpMulkiyetTipi.SelectedItem.Value))
            {
                sorgu += "MulkiyetTipi = '"+drpMulkiyetTipi.SelectedItem.Value+"'";
                sorguDurum++;
            }
			  if (!string.IsNullOrEmpty(drpIlanTipi.SelectedItem.Value))
            {
				if (sorguDurum > 0)
					sorgu += " AND ";
                sorgu += "IlanTipi = '"+drpIlanTipi.SelectedItem.Value+"'";
                sorguDurum++;
            }
			  if (!string.IsNullOrEmpty(ayarlar.Temizle(txtIlIlce.Text)))
            {
				if (sorguDurum > 0)
					sorgu += " AND ";
                sorgu += "SehirAd = '"+ayarlar.Temizle(txtIlIlce.Text)+"'";
                sorguDurum++;
            }
			
			
			if (!string.IsNullOrEmpty(drpUlke.SelectedItem.Value))
            {
                 if (sorguDurum > 0)
                    sorgu += " AND ";
                sorgu += "UlkeId = " + drpUlke.SelectedValue + " ";
                sorguDurum++;
            }
			
            if ((string.IsNullOrEmpty(txtOda.Text) ? 0 : int.Parse(txtOda.Text)) != 0)
            {
                if (sorguDurum > 0) 
                    sorgu += " AND ";
                sorgu += "OdaSayisi = " + ayarlar.Temizle(txtOda.Text) + " ";
                sorguDurum++;
            }
            if ((string.IsNullOrEmpty(txtPostaKodu.Text) ? 0 : int.Parse(txtPostaKodu.Text)) != 0)
            {
                if (sorguDurum > 0)
                    sorgu += " AND ";
                sorgu += "PostaKodu = " +ayarlar.Temizle( txtPostaKodu.Text) + " ";
                sorguDurum++;
            }
            if ((string.IsNullOrEmpty(txtYatakOdasi.Text) ? 0 : int.Parse(txtYatakOdasi.Text)) != 0)
            {
                if (sorguDurum > 0)
                    sorgu += " AND ";
                sorgu += "YatakOdaSayisi = " +ayarlar.Temizle( txtYatakOdasi.Text )+ " ";
                sorguDurum++;
            }

            if ((string.IsNullOrEmpty(txtMinM2.Text) ? 0 : int.Parse(txtMinM2.Text)) >= 0 & (string.IsNullOrEmpty(txtMaxM2.Text) ? 0 : int.Parse(txtMaxM2.Text)) > 0)
            {
                if (sorguDurum > 0)
                    sorgu += " AND ";
                sorgu += "(YasamAlani > " + (string.IsNullOrEmpty(ayarlar.Temizle(txtMinM2.Text)) ? 0 : int.Parse(ayarlar.Temizle(txtMinM2.Text))) + " AND YasamAlani < " +(string.IsNullOrEmpty(ayarlar.Temizle(txtMaxM2.Text)) ? 0 : int.Parse(ayarlar.Temizle(txtMaxM2.Text))) + ") ";
                sorguDurum++;
            }

            if ((string.IsNullOrEmpty(ayarlar.Temizle(txtMinE.Text)) ? 0 : int.Parse(ayarlar.Temizle(txtMinE.Text))) >= 0 & (string.IsNullOrEmpty(ayarlar.Temizle(txtMaxE.Text)) ? 0 : int.Parse(ayarlar.Temizle(txtMaxE.Text))) > 0)
            {
                if (sorguDurum > 0)
                    sorgu += " AND ";
                sorgu += "(Fiyat > " + (string.IsNullOrEmpty(ayarlar.Temizle(txtMinE.Text)) ? 0 : int.Parse(ayarlar.Temizle(txtMinE.Text))) + " AND Fiyat < " + (string.IsNullOrEmpty(ayarlar.Temizle(txtMaxE.Text)) ? 0 : int.Parse(ayarlar.Temizle(txtMaxE.Text))) + ") ";
                sorguDurum++;
            }
             DataTable kayitlar = system.GetDataTable(sorgu);
             if (kayitlar.Rows.Count>0)
             {
                 pnlMesaj.Visible = false;
                 PnlSonuc.Visible = true;
                 rptKonutlar.DataSource = kayitlar;
                 rptKonutlar.DataBind();
             }
             else
             {
                 pnlMesaj.Visible = true;
                 PnlSonuc.Visible = false;
                 lblMesaj.Text = "Aradığınız kriterlerde ilgili ilan bulunamadı";
             }
   
           

            //CollectionPager1.DataSource = sonuc.Veri;
            //CollectionPager1.BindToControl = rptKonutlar;
            //rptKonutlar.DataSource = CollectionPager1.DataSourcePaged;
             
         
    
    }
   
}