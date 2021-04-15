using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for SayfaVeritabani
/// </summary>
public class SayfaVeritabani:Veritabani
{
    protected NIslemSonuc<NSayfaBilgi> SayfaGetir(int SayfaId)
    {
        try
        {
            var sayfalar = (from u in Entity.Sayfalars
                            where u.SayfaId == SayfaId
                            select new NSayfaBilgi 
                            { 
                                SayfaAdi=u.SayfaAdi,
                                SayfaAciklama=u.SayfaAciklama,
                                Icerik=u.Icerik

                            });

            if (sayfalar.Count() > 0)
            {
                return new NIslemSonuc<NSayfaBilgi>
                {
                    Basarilimi = true,
                    Veri = sayfalar.FirstOrDefault()

                };
            }
            else
            {
                return new NIslemSonuc<NSayfaBilgi>
                {
                    Basarilimi=false,
                    Mesaj="Veritabanında ilgili Kayıt Bulunamadı"
                };
            
            }
 

        }
        catch (Exception hata)
        {

            return new NIslemSonuc<NSayfaBilgi>
             {
                 Basarilimi = false,
                 HataBilgi = new NHata
                 {
                     Sinif = "SayfaGetir",
                     Metod = "SayfaVeritabani",
                     HataMesaj = hata.Message
                 },
                 Mesaj = "Bir hata ile karşılaşıldı"

             };
        }
    
    }

    protected NIslemSonuc<List<NIdAd>> SayfalariGetir()
    {
        try
        {
            var sayfalar = (from u in Entity.Sayfalars
                            
                            select new NIdAd
                            {
                                 Ad=u.SayfaAdi,
                                 Id=u.SayfaId,

                            }).ToList();

            if (sayfalar.Count() > 0)
            {
                return new NIslemSonuc<List<NIdAd>>
                {
                    Basarilimi = true,
                    Veri = sayfalar

                };
            }
            else
            {
                return new NIslemSonuc<List<NIdAd>>
                {
                    Basarilimi = false,
                    Mesaj = "Veritabanında ilgili Kayıt Bulunamadı"
                };

            }


        }
        catch (Exception hata)
        {

            return new NIslemSonuc<List<NIdAd>>
            {
                Basarilimi = false,
                HataBilgi = new NHata
                {
                    Sinif = "SayfalarGetir",
                    Metod = "SayfaVeritabani",
                    HataMesaj = hata.Message
                },
                Mesaj = "Bir hata ile karşılaşıldı"

            };
        }

    }

    protected NIslemSonuc<bool> SayfaDuzenle(NSayfaBilgi Sayfalar) 
    {
        try
        {
            var kayitlar= (from u in Entity.Sayfalars
                               where u.SayfaId==Sayfalar.SayfaId
                               select u);
            if (kayitlar.Count()>0)
            {
                var kayit = kayitlar.FirstOrDefault();
                kayit.SayfaAdi=Sayfalar.SayfaAdi;
                kayit.SayfaAciklama = Sayfalar.SayfaAciklama;
                kayit.Icerik = Sayfalar.Icerik;
                Entity.SaveChanges();
                return new NIslemSonuc<bool>
                {
                    Basarilimi = true
                };

            }
            else
            {
                return new NIslemSonuc<bool>
                {
                     Basarilimi=false,
                     Mesaj="veritabanında ilgili kayit bulunamadı",
                };
            }
        }
        catch (Exception hata)
        {
            
            return new NIslemSonuc<bool>
            {
                Basarilimi=false,
                HataBilgi = new NHata
                {
                    HataMesaj = hata.Message,
                    Metod = "Duzenle",
                    Sinif = "UrunVeritabani"
                }
            };
        }
    }
}