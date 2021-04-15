using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for NGenelIlanGetir
/// </summary>
public class NGenelIlanGetir
{
    public string Kiler  { get; set; }
    public string GiyinmeOdasi { get; set; }
	public string ReferansNo { get; set; } 
    public string IlanBaslik { get; set; }   
     public int UlkeId { get; set; }
     public string SehirAd { get; set; }
    public int PostaKodu { get; set; }
    public string Adres { get; set; }
    public string Sokak { get; set; }
    public string MulkiyetTipi { get; set; }
    public string Dolaplar { get; set; }
    public string IlanTipi { get; set; }
    public string IcMekan { get; set; }
    public int BinaYasi { get; set; }
    public int OdaSayisi { get; set; }
    public int YatakOdasi { get; set; }
    public int YasamAlani { get; set; }
    public int KullanimAlani { get; set; }
   // public decimal KiralikMasrafsiz { get; set; }
   // public decimal KiralikMasrafli { get; set; }
    public decimal? Fiyat { get; set; }
  //  public decimal KomisyonluSatisFiyati { get; set; }
    public decimal? AylikKira { get; set; }
    public  string  BosOlacagiTarih { get; set; }
    public DateTime YayinTarih { get; set; }
    public int UyeId { get; set; }
   public string MulkiyetGenelDurum { get; set; }
    public string OrtakKullanimDurum { get; set; }
    public string BahceKapisi { get; set; }
    public string Pencereler { get; set; }
    public decimal? YillikAidat { get; set; }
    public decimal? YillikVergiler { get; set; }
    public bool  MutfakEkipmanlari { get; set; }
    public bool Interphone { get; set; }
    public bool Alarm { get; set; }
    public bool Uydu { get; set; }
    public bool AntenTv { get; set; }
    public bool SomineTip1 { get; set; }
    public bool SomineTip2 { get; set; }
    public string CatiKati { get; set; }
    public string Bodrum { get; set; }
    public string Garaj { get; set; }
    public string ParkYeri { get; set; }
    public string Havuz { get; set; }
    public string BahceDuvari { get; set; }
    public string Asansor { get; set; }
    public string SuOlcum { get; set; }
    public string GenelDurum { get; set; }
    public int IsiSistemleriYasi { get; set; }
    public string Isitma { get; set; }
    public string EnerjiTipi { get; set; }
    public string IsinmaTipi { get; set; }
    public string BahceKapisiDurumu { get; set; }
    public string  Panjurlar { get; set; }
    public int YillikTuketim { get; set; }
    public bool Asbest { get; set; }
    public bool Termit { get; set; }
    public bool Kursun { get; set; }
    public bool Carrez { get; set; }
    public bool Electrik { get; set; }
    public bool Gaz { get; set; }
    public string CatiDurum { get; set; }
    public string CatiIskeletiDurum { get; set; }
    public string DisKaplamaDurum { get; set; }
    public string SirketIsmi { get; set; }
    public int KatNo { get; set; }
    public string BireyselIkiz { get; set; }
    public string Resim { get; set; }
    public List<string> Resimler { get; set; }
    public int IlanId { get; set; }
    public string IlanEmail { get; set; }
    public string UyeEposta { get; set; }
    public string IlanTelefon { get; set; }
    public string IlanTelefon2 { get; set; }
    public string IlanIletisimSaatleri { get; set; }
    public string IlanIletisimSekli { get; set; }
    public string UlkeAdi { get; set; }
    public string UyeAdSoyAd  { get; set; }
    public string IlanAciklama { get; set; }
    public int UyeTip { get; set; }
}