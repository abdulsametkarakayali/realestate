using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for SehirVeritabani
/// </summary>
public class SehirVeritabani:Veritabani
{
    protected NIslemSonuc<List<NIdAd>> UlkeGetir() 
    {
        try
        {
            var kayitlar = (from u in Entity.ulkes
                            orderby u.UlkeAd
                            select new NIdAd
                            {
                                Id = u.id,
                                Ad = u.UlkeAd
                            }).ToList();
            return new NIslemSonuc<List<NIdAd>>
            {
                Basarilimi = true,
                Veri = kayitlar
            };
        }
        catch (Exception hata)
        {
            return new NIslemSonuc<List<NIdAd>>
            {
                Basarilimi = false,
                HataBilgi = new NHata
                {
                    Sinif="UlkeGetir",
                    Metod="SehirVeritabani",
                    HataMesaj="Veritabanindan Ulke bilgisi çekilemedi"
                }
            };
        }
    
    }
     
    protected NIslemSonuc<List<NIdAd>> SehirGetir(int UlkeId)
    {
        try
        {
            var kayitlar = (from u in Entity.ils
                            where u.ulke_id==UlkeId
                            select new NIdAd
                            {
                                Id = u.id,
                                Ad = u.ad
                            }).ToList();
            return new NIslemSonuc<List<NIdAd>>
            {
                Basarilimi = true,
                Veri = kayitlar
            };
        }
        catch (Exception hata)
        {
            return new NIslemSonuc<List<NIdAd>>
            {
                Basarilimi = false,
                HataBilgi = new NHata
                {
                    Sinif = "SehirGetir",
                    Metod = "SehirVeritabani",
                    HataMesaj = "Veritabanindan Sehir bilgisi çekilemedi"
                }
            };
        }

    }
}