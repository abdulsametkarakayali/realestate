using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for IlanIslem
/// </summary>
public class IlanIslem:IlanVeritabani
{
    public NIslemSonuc<int> Kaydet(NIlan Ilan)
    {
        var sonuc = base.Kaydet(Ilan);
        if (sonuc.HataBilgi != null)
        {
            //Veritabanina Eklenecek
        }
        return sonuc;

    }
    public NIslemSonuc<bool> EnerjiBilgisiKaydet(NEnerjiKaydet EnerjiSinifi)
    {
        var sonuc = base.EnerjiBilgisiKaydet(EnerjiSinifi);
        if (sonuc.HataBilgi != null)
        {
            //Veritabanina Eklenecek
        }
        return sonuc;

    }
    public NIslemSonuc<bool> KonutDetayKaydet(NKonutDetay KonutDetay)
    {
        var sonuc = base.KonutDetayKaydet(KonutDetay);
        if (sonuc.HataBilgi != null)
        {
            // Veritabanına kayıt edildi
        }
        return sonuc;
    }
    public NIslemSonuc<bool> IlanDetayKaydet(NIlanDetay IlanDetay) 
    {
        var sonuclar = base.IlanDetayKaydet(IlanDetay);
        if (sonuclar.HataBilgi!=null)
        {
            //veritabanınaa hata kayit edilecek
        }
        return sonuclar;
    }

    public NIslemSonuc<bool> TeshislerKaydet(NTeshisler Teshisler)
    {
        var sonuc = base.TeshislerKaydet(Teshisler);
        if (sonuc.HataBilgi != null)
        {
            //Veritabanına Kayıt Edilecek           
        }
        return sonuc;
    }
    public NIslemSonuc<bool> IsinmaKaydet(NIsinma Isınma)
    {
        var sonuc = base.IsinmaKaydet(Isınma);
        if (sonuc.HataBilgi != null)
        {
            //Hata Bilgisi Kaydet
        }
        return sonuc;
    }
    public NIslemSonuc<bool> ResimKaydet(NResimler IlanFotograf)
    {
        var sonuc = base.ResimKaydet(IlanFotograf);
        if (sonuc.HataBilgi != null)
        {
            //Hata Bilgisi Kaydet
        }
        return sonuc;
    }
    public NIslemSonuc<bool> IlanIletisimKaydet(NIlanIletisim IlanIletisim)
    {
        var sonuc = base.IlanIletisimKaydet(IlanIletisim);
        if (sonuc.HataBilgi != null)
        {
            //Hata Bilgisi Kaydet
        }
        return sonuc;
    }

    
    public NIslemSonuc<bool> EvAlanOzelikleriKaydet(NEvAlanOzelik EvAlanOzelikleri)
    {
        var sonuc = base.EvAlanOzelikleriKaydet(EvAlanOzelikleri);
        if (sonuc.HataBilgi != null)
        {
            //Veritabanina Eklenecek
        }
        return sonuc;

    }
    
    public NIslemSonuc<bool> EvGenelOzelikleriKaydet(NEvGenelOzelik EvGenelOzelikleri)
    {
        var sonuc = base.EvGenelOzelikleriKaydet(EvGenelOzelikleri);
        if (sonuc.HataBilgi != null)
        {
            //Veritabanina Eklenecek
        }
        return sonuc;

    }

  
}