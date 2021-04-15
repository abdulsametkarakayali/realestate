using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DetayIslem
/// </summary>
public class DetayIslem:DetayVeritabani
{
    public NIslemSonuc<NEnerji> GetirEnerjiSinifi(int id)
    {
        var sonuc = base.GetirEnerjiSinifi(id);
        if (sonuc.HataBilgi != null)
        {
            //Veritabanina Kayit yapılacak
        }
        return sonuc;
    }

    public NIslemSonuc<List<NKonutDetay>> GetirKonutDetay(int id)
    {
        var sonuc = base.GetirKonutDetay(id);
        if (sonuc.HataBilgi !=null)
        {
            // Veritabanına Kayit Yapılacak.
        }

        return sonuc;
    
    }

    public NIslemSonuc<NGenelIlanGetir> GetirIlan(int id)
    {
        var sonuc = base.GetirIlan(id);
        if (sonuc.HataBilgi != null)
        {
            // Veritabanına Kayit Yapılacak.
        }

        return sonuc;

    }

    public NIslemSonuc<List<NResimler>> GetirResimler(int id)
    {
        var sonuc = base.GetirResimler(id);
        if (sonuc.HataBilgi != null)
        {
            //Veritabanına Kayit Edilecek
        }
        return sonuc;
    }

    public NIslemSonuc<NFavori> FavoriSorgula(int UyeId, int IlanId)
    {
        var sonuc = base.FavoriSorgula(UyeId, IlanId);
        if (sonuc.HataBilgi != null)
        {
            // Veritabanına Kayit Yapılacak.
        }

        return sonuc;

    }
    public NIslemSonuc<bool> FavoriEkle(NFavori FavoriIlans) 
    {
        var sonuc = base.FavoriEkle(FavoriIlans);
        if (sonuc.HataBilgi!=null)
        {
            //veritabanınana hata kayt et
        }
        return sonuc; 
    }
    public NIslemSonuc<bool> FavoriCikar(int IlanId, int UyeId)
    {
        var sonuc = base.FavoriCikar(IlanId, UyeId);
        if (sonuc.HataBilgi != null)
        {
            // Veritabanına Kayit Yapılacak.
        }

        return sonuc;

    }


}