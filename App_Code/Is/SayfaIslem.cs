using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for SayfaIslem
/// </summary>
public class SayfaIslem:SayfaVeritabani
{
    public NIslemSonuc<NSayfaBilgi> SayfaGetir(int SayfaId)
    {
        var sonuc = base.SayfaGetir(SayfaId);
        if (sonuc.HataBilgi != null)
        {
            //Veritabanina hata kayit Edilecek..
        }
        return sonuc;

    }

    public NIslemSonuc<List<NIdAd>> SayfalarGetir()
    {
        var sonuc = base.SayfalariGetir();
        if (sonuc.HataBilgi != null)
        {
            //Veritabanina hata kayit Edilecek..
        }
        return sonuc;

    }
    public NIslemSonuc<bool> SayfaDuzenle(NSayfaBilgi Sayfalar) 
    {

        var sonuc = base.SayfaDuzenle(Sayfalar);
        if (sonuc.HataBilgi!=null)
        {
            //Veritabanına kayıt edilecek. hata olarak
        }
        return sonuc;
    }
}