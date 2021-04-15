using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Entity;

/// <summary>
/// Summary description for DetayVeritabani
/// </summary>
public class DetayVeritabani:Veritabani
{

    protected NIslemSonuc<NEnerji> GetirEnerjiSinifi(int id)
    {
        try
        {
            var kayitlar = (from u in Entity.EnerjiSinifis
                            where u.IlanId == id
                            select new NEnerji
                            {
                                EmisyonDegeri = (int)u.EmisyonDegeri,
                                EmisyonSinifi = u.EmisyonSinifi,
                                EnerjiDegeri = (int)u.EnerjiDegeri,
                                EnerjiSinifi = u.EnerjiSinifi1,
                            }).ToList();

            if (kayitlar.Count > 0)
            {
                return new NIslemSonuc<NEnerji>
                {
                    Basarilimi = true,
                    Veri = kayitlar.FirstOrDefault()
                };
            }
            else
            {
                return new NIslemSonuc<NEnerji>
                {
                    Basarilimi = false,
                    Mesaj = "Gerekli Kayitlara Erişilemedi"
                };

            }



        }
        catch (Exception hata)
        {
            return new NIslemSonuc<NEnerji>
            {
                Basarilimi = false,
                HataBilgi = new NHata
                {
                    HataMesaj = hata.Message,
                    Metod = "GetirEnerjiSinifi",
                    Sinif = "IlanVeritabani"
                }
            };
        }
    }

    protected NIslemSonuc<NGenelIlanGetir> GetirIlan(int id)
    {
        try
        {
            var kayitlar = (from u in Entity.Ilans
                            join i  in Entity.IlanDetays  on u.IlanId equals i.IlanId
                            join t in Entity.Isinmas on u.IlanId equals t.IlanId
                            join a in Entity.Teshislers on u.IlanId equals a.IlanId
                            join uye in Entity.Uyes on u.UyeId equals uye.UyeId
                            join iletisim in Entity.IlanIletisims on u.IlanId equals iletisim.IlanId
                            join  ulk in Entity.ulkes on u.UlkeId equals ulk.id
                            where u.IlanId==id
                            select new NGenelIlanGetir
                            {
                                IcMekan=u.IcMekan,
                                IlanTipi=u.IlanTipi,
                                BinaYasi=(int)u.BinaYasi,
                                MulkiyetTipi=u.MulkiyetTipi,
                                AylikKira=(decimal)u.AylikKira,
                                BosOlacagiTarih=u.BosOlacagiTarih,
                                SehirAd=u.SehirAd,
                                PostaKodu=(int)u.PostaKodu,
                                YasamAlani=(int)u.YasamAlani,
                                UyeEposta=uye.EMail,
                                Fiyat=(decimal)u.Fiyat,
                                OdaSayisi=(int)u.OdaSayisi,
                                YatakOdasi=(int)u.YatakOdaSayisi,
                                KullanimAlani=(int)u.KullanimAlani,
                                Alarm=(bool)i.Alarm,
                                AntenTv=(bool)i.AntenTv,
                                Dolaplar=i.Dolaplar,
                                BahceDuvari=i.BahceDuvari,
                                BahceKapisi=i.BahceKapisi,
                                CatiKati=i.CatiKati,
                                 GiyinmeOdasi=i.GiyinmeOdasi,
                                 Kiler=i.Kiler,
                                 Asansor=u.Asansor,
                                Havuz=i.Havuz,
                                Interphone=(bool)i.Interphone,
                                MulkiyetGenelDurum=i.MGenelDurum,
                                ParkYeri=i.ParkYeri,
                                Garaj=i.Garaj,
                                Pencereler=i.Pencereler,
                                SomineTip1=(bool)i.SomineTip1,
                                SomineTip2=(bool)i.SomineTip2,
                                MutfakEkipmanlari=(bool)i.MutfakEkipManlari,
                                 
                                Uydu=(bool)i.Uydu,
                                YillikAidat=(decimal)i.YillikAidat,
                                YillikVergiler=(decimal)i.YillikVergiler,
                                OrtakKullanimDurum=i.OKullanimDurum,
                                Bodrum=i.Bodrum,
                                EnerjiTipi=t.EnerjiTipi,
                                Panjurlar=i.Panjurlar,
                                SirketIsmi=uye.SirketIsmi,
                                YayinTarih=(DateTime)u.YayinTarih,
                                ReferansNo=u.ReferansNo,
                                UyeAdSoyAd=uye.Ad+" "+uye.Soyad,
                                UlkeAdi=ulk.UlkeAd,
                                BahceKapisiDurumu=i.BahceKapisiDurumu,
                                GenelDurum=t.GenelDurum,
                                IsinmaTipi=t.IsinmaTipi,
                                Isitma=t.Isitma,
                                IsiSistemleriYasi=(int)t.IsiSistemleriYasi,
                                YillikTuketim=(int)t.YillikTuketim,
                                Asbest=(bool)a.Asbest,
                                Carrez=(bool)a.Carrez,
                                Gaz=(bool)a.Gaz,
                                Electrik=(bool)a.Electrik,
                                Kursun=(bool)a.Kursun,
                                Termit=(bool)a.Termit,
                                CatiDurum=i.CatiDurum,
                                CatiIskeletiDurum=i.CatiIskeletiDurum,
                                DisKaplamaDurum=i.DisKaplamaDurum,
                                BireyselIkiz=u.BireyselIkiz,
                                KatNo=(int)u.KatNo,  
                                Adres=u.Adres,
                                Sokak=u.Sokak,
                                IlanId=u.IlanId,
                                IlanEmail=iletisim.IlanEmail,
                                IlanIletisimSaatleri=iletisim.IlanIletisimSaatleri,
                                IlanTelefon=iletisim.IlanTelefon,
                                IlanTelefon2=iletisim.IlanTelefon2,
                                IlanAciklama=i.IlanAciklama,
                                UyeTip=(int)uye.UyeTip,
                                SuOlcum=i.SuOlcumleri
                            }).ToList();
				 for (int i = 0; i < kayitlar.Count; i++)
            {
                int IlanId = kayitlar[i].IlanId;
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
                return new NIslemSonuc<NGenelIlanGetir>
                {
                    Basarilimi = true,
                    Veri = kayitlar.FirstOrDefault()
                };
            }
            else
            {
                return new NIslemSonuc<NGenelIlanGetir>
                {
                    Basarilimi = false,
                    Mesaj = "Gerekli Kayitlara Erişilemedi"
                };

            }



        }
        catch (Exception hata)
        {
            return new NIslemSonuc<NGenelIlanGetir>
            {
                Basarilimi = false,
                HataBilgi = new NHata
                {
                    HataMesaj = hata.Message,
                    Metod = "GetirIlan",
                    Sinif = "IlanVeritabani"
                }
            };
        }
    }
    protected NIslemSonuc<List<NKonutDetay>> GetirKonutDetay (int id)
    {
    
    try 
	{	        
		var konutdetay =(from  u  in Entity.KonutDetays
                          where u.IlanId==id 
                             select new NKonutDetay
                             {
                                m2=u.m2.ToString(),
                                Camlar=u.Camlar,
                                Cerceveler=u.Cerceveler,
                                Kat=u.Kat,
                                Odalar=u.Odalar,
                                Panjur=u.Panjur,
                                YerDoseme=u.YerDoseme,
                                Yon=u.Yon
                             }).ToList();
        if (konutdetay.Count()> 0)
    	{
            return new NIslemSonuc<List<NKonutDetay>>
            {
                Basarilimi = true,
                Veri = konutdetay

            };
    	} 
        else
            {
                return new NIslemSonuc<List<NKonutDetay>>
                {
                    Basarilimi = false,
                    Mesaj = "Gerekli Kayitlara Erişilemedi"
                };

            }


	}
	catch (Exception hata)
	{
		
		return new NIslemSonuc<List<NKonutDetay>>
        {
            Basarilimi=false,
            HataBilgi =new NHata
            {
                Sinif="GetirKonutDetay",
                HataMesaj="Konut Detay Getirilirken hata oluştur",
                Metod="Detay Veritabani"
                
                
            }
        };
	}
    
    }
    protected NIslemSonuc<List<NResimler>> GetirResimler(int id)
    {
        try
        {
            var kayitlar = (from r in Entity.IlanFotografs
                            where r.IlanId==id
                            select new NResimler 
                            {
                                Resim=r.FotoPath,
                                Thumb=r.Thumb
                                
                            }).ToList();

            if (kayitlar.Count > 0)
            {
                return new NIslemSonuc<List<NResimler>>
                {
                    Basarilimi = true,
                    Veri=kayitlar
                  
                };
            }
            else
            {
                return new NIslemSonuc<List<NResimler>>
                {
                    Basarilimi = false,
                    Mesaj = "Gerekli Kayitlara Erişilemedi"
                };

            }
        }
        catch (Exception hata)
        {
            return new NIslemSonuc<List<NResimler>>
            {
                Basarilimi = false,
                HataBilgi = new NHata
                {
                    HataMesaj = hata.Message,
                    Metod = "GetirResimler",
                    Sinif = "Detay Veritabani"
                }
            };
        }
    }
    protected NIslemSonuc<NIsinma> GetirIsinma(int id)
    {
        try
        {
            var kayitlar = (from u in Entity.Isinmas
                            where u.IlanId == id
                            select new NIsinma
                            {
                                GenelDurum = u.GenelDurum,
                                IsinmaTipi = u.IsinmaTipi,
                                IsiSistemleriYasi = (int)u.IsiSistemleriYasi,
                                YillikTuketim = (int)u.YillikTuketim,



                            }).ToList();

            if (kayitlar.Count > 0)
            {
                return new NIslemSonuc<NIsinma>
                {
                    Basarilimi = true,
                    Veri = kayitlar.FirstOrDefault()
                };
            }
            else
            {
                return new NIslemSonuc<NIsinma>
                {
                    Basarilimi = false,
                    Mesaj = "Gerekli Kayitlara Erişilemedi"
                };

            }
        }
        catch (Exception hata)
        {
            return new NIslemSonuc<NIsinma>
            {
                Basarilimi = false,
                HataBilgi = new NHata
                {
                    HataMesaj = hata.Message,
                    Metod = "GetirIsınma",
                    Sinif = "Detay Veritabani"
                }
            };
        }
    }

    protected NIslemSonuc<NFavori> FavoriSorgula(int UyeId, int IlanId)
    {
        try
        {
            var kayitlar = (from u in  Entity.FavoriIlans
                            where  u.IlanId==IlanId && u.UyeId==UyeId
                            select u).ToList();

            if (kayitlar.Count > 0)
            {
                return new NIslemSonuc<NFavori>
                {
                    Basarilimi = true,
                    
                };
            }
            else
            {
                return new NIslemSonuc<NFavori>
                {
                    Basarilimi = false,
                    Mesaj = "Gerekli Kayitlara Erişilemedi"
                };

            }
        }
        catch (Exception hata)
        {
            return new NIslemSonuc<NFavori>
            {
                Basarilimi = false,
                HataBilgi = new NHata
                {
                    HataMesaj = hata.Message,
                    Metod = "Favori Sorgula",
                    Sinif = "Detay Veritabani"
                }
            };
        }
    }
    protected NIslemSonuc<bool> FavoriEkle(NFavori FavoriIlan) 
    {
        try
        {
            var yenifavori = new FavoriIlan
            {
                IlanId = FavoriIlan.IlanId,
                UyeId = FavoriIlan.UyeId
            };
            Entity.FavoriIlans.Add(yenifavori);
            Entity.SaveChanges();

            return new NIslemSonuc<bool>
            {
                Basarilimi = true
            };
        }
        catch (Exception hata)
        {

            return new NIslemSonuc<bool>
            {
                Basarilimi = false,
                Mesaj = hata.Message,
                HataBilgi = new NHata 
                {
                HataMesaj="Favorilere Eklenemedi",
                 Metod="FavoriEkle",
                 Sinif="DetayVeritabani",
                }
            };
        }
    }
    public NIslemSonuc<bool> FavoriCikar(int IlanId,int UyeId)
    {
        try
        {
            var kayit = (from u in  Entity.FavoriIlans
                         where u.IlanId==IlanId && u.UyeId==UyeId
                         select u);
            if (kayit.Count() > 0)
            {
                var silinecekkayit = kayit.FirstOrDefault();
                Entity.FavoriIlans.Remove(silinecekkayit);
                Entity.SaveChanges();
            }
            return new NIslemSonuc<bool>
            {
                Basarilimi = true
            };
        }
        catch (Exception hata)
        {
            return new NIslemSonuc<bool>
            {
                Basarilimi = false,
                HataBilgi = new NHata
                {
                    HataMesaj = hata.Message,
                    Metod = "Favori Çıkar",
                    Sinif = "KitapVeritabani",

                },
                Mesaj = "Favori ilan çıkarılırken bir hata oluştu",
            };

        }

    }
}
