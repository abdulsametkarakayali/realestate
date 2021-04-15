using LinqKit;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for AramaSonuclari
/// </summary>
public class AramaSonuclariVeritabani:Veritabani
{
    protected NIslemSonuc<List<NAramaSonuc>> GetirAramaKonutSonuc(string MulkiyetTipi)
    {
        try
        {
            var kayitlar = (from i in Entity.Ilans
                            join uye in Entity.Uyes on i.UyeId equals uye.UyeId
                            join e in Entity.EnerjiSinifis on i.IlanId equals e.IlanId
                              orderby i.IlanId descending
                              where i.MulkiyetTipi==MulkiyetTipi
                            select new NAramaSonuc
                            {
                                
                                PostaKodu =(int)i.PostaKodu,
                                YasamAlani =(int)i.YasamAlani,
                               YatakOdasi=(int)i.YatakOdaSayisi,
                                OdaSayisi = (int)i.OdaSayisi,
                                SehirAd=i.SehirAd,
								UyelikTip=(int)uye.UyeTip,
								ReferansNo=i.ReferansNo,
								SirketIsmi=uye.SirketIsmi,
                                IlanTipi=i.IlanTipi+" "+i.MulkiyetTipi,
                                 EnerjiSinifi=e.EnerjiSinifi1,
                                 EmisyonSinifi=e.EmisyonSinifi,
                                 EnerjiSinifiNumara=(int)e.EnerjiDegeri,
                                 EmisyonNumara=(int)e.EmisyonDegeri,
                                 TelefonNo= uye.TelefonNo,
                                 EmailAdresi=uye.EMail,
                                 KayitTarihi=(DateTime)i.YayinTarih,
                                 
                                Fiyat = (decimal)i.Fiyat,
                                IlanID=(int)i.IlanId,
                               

                            }).Take(50).ToList();

            for (int i = 0; i < kayitlar.Count; i++)
            {
                int IlanId = kayitlar[i].IlanID;
                var kayitResim = (from r in Entity.IlanFotografs
                                  where r.IlanId == IlanId
                                  select r.FotoPath);
                if (kayitResim.Count() > 0)
                {
                    kayitlar[i].Resim = kayitResim.FirstOrDefault();
                }
            }

            if (kayitlar.Count > 0)
            {
                return new NIslemSonuc<List<NAramaSonuc>>
                {
                    Basarilimi = true,
                    Veri = kayitlar
                };
            }
            else
            {
                return new NIslemSonuc<List<NAramaSonuc>>
                {
                    Basarilimi = false,
                    Mesaj = "Gerekli Kayitlara Erişilemedi"
                };

            }
        }
        catch (Exception hata)
        {
            return new NIslemSonuc<List<NAramaSonuc>>
            {
                Basarilimi = false,
                HataBilgi = new NHata
                {
                    HataMesaj = hata.Message,
                    Metod = "GetirKonut",
                    Sinif = "AramaSonuclariVeritabani"
                }
            };
        }
    }
    protected NIslemSonuc<List<NAramaSonuc>> IlanAra(NIlanAraKriter Kriter)
    {
        Fonksiyon system = new Fonksiyon();
        try
        {
            //int sorguDurum = 0;
            //string sorgu = "select * from AramaSonuclari WHERE ";
            //if (!string.IsNullOrEmpty(Kriter.MulkiyetTipi))
            //{
            //    sorgu += "MulkiyetTipi = " + Kriter.MulkiyetTipi + " ";
            //    sorguDurum++;
            //}
            //if (Kriter.OdaSayisi != 0)
            //{
            //    if (sorguDurum == 1) 
            //        sorgu += " AND ";
            //    sorgu += "OdaSayisi = " + Kriter.OdaSayisi + " ";
            //    sorguDurum++;
            //}
            //if (Kriter.PostaKodu != 0)
            //{
            //    if (sorguDurum > 0)
            //        sorgu += " AND ";
            //    sorgu += "PostaKodu = " + Kriter.PostaKodu + " ";
            //    sorguDurum++;
            //}
            // if (Kriter.YatakOdasi != 0)
            //{
            //    if (sorguDurum > 0)
            //        sorgu += " AND ";
            //    sorgu += "YatakOdaSayisi = " + Kriter.YatakOdasi + " ";
            //    sorguDurum++;
            //}

            // DataTable kayitlar = system.GetDataTable(sorgu);
 
            //for (int i = 0; i <kayitlar.Columns.Count ; i++)
            //{
            //    int IlanId = kayitlar["IlanId"];
            //    var kayitResim = (from r in Entity.IlanFotografs
            //                      where r.IlanId == IlanId
            //                      select r.FotoPath);
            //    if (kayitResim.Count() > 0)
            //    {
            //        kayitlar[i].Resim = kayitResim.FirstOrDefault();
            //    }
            //}

            //if (kayitlar.Count > 0)
            //{
            //    return new NIslemSonuc<List<NAramaSonuc>>
            //    {
            //        Basarilimi = true,
            //        Veri = kayitlar
            //    };
            //}
            //else
            //{
            
                return new NIslemSonuc<List<NAramaSonuc>>
                {
                    Basarilimi = false,
                    Mesaj = "Gerekli Kayitlara Erişilemedi"
                };

            }
        
        catch (Exception hata)
        {
            return new NIslemSonuc<List<NAramaSonuc>>
            {
                Basarilimi = false,
                HataBilgi = new NHata
                {
                    HataMesaj = hata.Message,
                    Metod = "GetirKonut",
                    Sinif = "AramaSonuclariVeritabani"
                }
            };
        }
    }



 
    protected NIslemSonuc<List<NAramaSonuc>> GetirFavoriler(int UyeId )
    {
        try
        {
            var kayitlar = (from i in Entity.Ilans
                            join uye in Entity.Uyes on i.UyeId equals uye.UyeId
                            join e in Entity.EnerjiSinifis on i.IlanId equals e.IlanId
                            join f in Entity.FavoriIlans on i.IlanId equals f.IlanId
                            join d in Entity.IlanDetays on i.IlanId equals d.IlanId
                            orderby i.IlanId descending
                            where f.UyeId==UyeId
                            select new NAramaSonuc
                            {

                                PostaKodu = (int)i.PostaKodu,
                                YasamAlani = (int)i.YasamAlani,
                                YatakOdasi = (int)i.YatakOdaSayisi,
                                OdaSayisi = (int)i.OdaSayisi,
                                SehirAd = i.SehirAd,                                
                                UyelikTip = (int)uye.UyeTip,
                                ReferansNo = i.ReferansNo,
                                SirketIsmi = uye.SirketIsmi,
                                IlanTipi = i.IlanTipi + " " + i.MulkiyetTipi,
                                EnerjiSinifi = e.EnerjiSinifi1,
                                EmisyonSinifi = e.EmisyonSinifi,
                                EnerjiSinifiNumara = (int)e.EnerjiDegeri,
                                EmisyonNumara = (int)e.EmisyonDegeri,
                                TelefonNo = uye.TelefonNo,
                                EmailAdresi = uye.EMail,
                                KayitTarihi = (DateTime)i.YayinTarih,
                                IlanAciklama=d.IlanAciklama,
                                Fiyat = (decimal)i.Fiyat,
                                IlanID = (int)i.IlanId,


                            }).Take(50).ToList();

            for (int i = 0; i < kayitlar.Count; i++)
            {
                int IlanId = kayitlar[i].IlanID;
                var kayitResim = (from r in Entity.IlanFotografs
                                  where r.IlanId == IlanId
                                  select r.FotoPath);
                if (kayitResim.Count() > 0)
                {
                    kayitlar[i].Resim = kayitResim.FirstOrDefault();
                }
            }

            if (kayitlar.Count > 0)
            {
                return new NIslemSonuc<List<NAramaSonuc>>
                {
                    Basarilimi = true,
                    Veri = kayitlar
                };
            }
            else
            {
                return new NIslemSonuc<List<NAramaSonuc>>
                {
                    Basarilimi = false,
                    Mesaj = "Gerekli Kayitlara Erişilemedi"
                };

            }
        }
        catch (Exception hata)
        {
            return new NIslemSonuc<List<NAramaSonuc>>
            {
                Basarilimi = false,
                HataBilgi = new NHata
                {
                    HataMesaj = hata.Message,
                    Metod = "GetirFavoriIlan",
                    Sinif = "AramaSonuclariVeritabani"
                }
            };
        }
    }
    protected NIslemSonuc<List<NAramaSonuc>> GetirIlanlarim (int UyeId)
    {
        try
        {
            var kayitlar = (from i in Entity.Ilans
                            join uye in Entity.Uyes on i.UyeId equals uye.UyeId
                            join e in Entity.EnerjiSinifis on i.IlanId equals e.IlanId
                            join a in Entity.IlanDetays on i.IlanId equals a.IlanId 
                            orderby i.IlanId descending
                            where i.UyeId==UyeId
                            select new NAramaSonuc
                            {

                                PostaKodu = (int)i.PostaKodu,
                                YasamAlani = (int)i.YasamAlani,
                                YatakOdasi = (int)i.YatakOdaSayisi,
                                OdaSayisi = (int)i.OdaSayisi,
                                SehirAd = i.SehirAd,
                                IlanAciklama=a.IlanAciklama,
                                UyelikTip = (int)uye.UyeTip,
                                ReferansNo = i.ReferansNo,
                                SirketIsmi = uye.SirketIsmi,
                                IlanTipi = i.IlanTipi + " " + i.MulkiyetTipi,
                                EnerjiSinifi = e.EnerjiSinifi1,
                                EmisyonSinifi = e.EmisyonSinifi,
                                EnerjiSinifiNumara = (int)e.EnerjiDegeri,
                                EmisyonNumara = (int)e.EmisyonDegeri,
                                TelefonNo = uye.TelefonNo,
                                EmailAdresi = uye.EMail,
                                KayitTarihi = (DateTime)i.YayinTarih,

                                Fiyat = (decimal)i.Fiyat,
                                IlanID = (int)i.IlanId,


                            }).Take(50).ToList();

            for (int i = 0; i < kayitlar.Count; i++)
            {
                int IlanId = kayitlar[i].IlanID;
                var kayitResim = (from r in Entity.IlanFotografs
                                  where r.IlanId == IlanId
                                  select r.FotoPath);
                if (kayitResim.Count() > 0)
                {
                    kayitlar[i].Resim = kayitResim.FirstOrDefault();
                }
            }

            if (kayitlar.Count > 0)
            {
                return new NIslemSonuc<List<NAramaSonuc>>
                {
                    Basarilimi = true,
                    Veri = kayitlar
                };
            }
            else
            {
                return new NIslemSonuc<List<NAramaSonuc>>
                {
                    Basarilimi = false,
                    Mesaj = "Gerekli Kayitlara Erişilemedi"
                };

            }
        }
        catch (Exception hata)
        {
            return new NIslemSonuc<List<NAramaSonuc>>
            {
                Basarilimi = false,
                HataBilgi = new NHata
                {
                    HataMesaj = hata.Message,
                    Metod = "GetirIlanlarim",
                    Sinif = "AramaSonuclariVeritabani"
                }
            };
        }
    }
}