using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for SehirIslem
/// </summary>
public class SehirIslem:SehirVeritabani
{
    public NIslemSonuc<List<NIdAd>> UlkeGetir() 
    {
        var sonuc = base.UlkeGetir();
        if (sonuc.HataBilgi != null) 
        {
        //Veritabanina hata kayit Edilecek..
        }
        return sonuc;

    }

     
    public NIslemSonuc<List<NIdAd>> SehirGetir(int UlkeId)
    {
        var sonuc = base.SehirGetir(UlkeId);
        if (sonuc.HataBilgi != null)
        {
            //Veritabanina hata kayit Edilecek..
        }
        return sonuc;

    }
}