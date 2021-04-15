using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for NAramaSonuc
/// </summary>
public class NAramaSonuc
{
    public string IlanNo { get; set; }
    public int PostaKodu { get; set; }
    public int YasamAlani { get; set; }
    public int YatakOdasi { get; set; }
    public int OdaSayisi { get; set; }
    public string EnerjiSinifi { get; set; }
	public decimal KiralikMasrafli {get;set;}
    public int EnerjiSinifiNumara { get; set; }
    public string EmisyonSinifi { get; set; }
    public int EmisyonNumara { get; set; }
    public string TelefonNo { get; set; }
    public string EmailAdresi { get; set; }
    public string IlanTipi { get; set; }
    public string SehirAd { get; set; }
	public int UyelikTip {get; set;}
	public string ReferansNo {get; set;}
	public string SirketIsmi {get;set;}
    public decimal? Fiyat { get; set; }
    public DateTime KayitTarihi { get; set; }
    public int IlanID { get; set; }
    public string Resim { get; set; }
    public List<string> Resimler { get; set; }
    public string IlanAciklama { get; set; }
}