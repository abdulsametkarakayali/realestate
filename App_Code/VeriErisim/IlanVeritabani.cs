using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Entity;

/// <summary>
/// Summary description for IlanVeritabani
/// </summary>
public class IlanVeritabani:Veritabani
{
    protected NIslemSonuc<int> Kaydet(NIlan Ilan)
    {
        try
        {

            var yeniilan = new Ilan
            {
                ReferansNo=Ilan.ReferansNo,
                
                UlkeId=Ilan.UlkeId,
                PostaKodu=Ilan.PostaKodu,
                SehirAd=Ilan.SehirAd,
                Adres=Ilan.Adres,
                KatNo=Ilan.KatNo,
                BireyselIkiz=Ilan.BireyselIkiz,
                IcMekan=Ilan.IcMekan,
                BinaYasi=Ilan.BinaYasi,
                OdaSayisi=Ilan.OdaSayisi,
                YatakOdaSayisi=Ilan.YatakOdasi,
                YasamAlani=Ilan.YasamAlani,
                KullanimAlani=Ilan.KullanimAlani,
                AylikKira=Ilan.AylikKira,
                Fiyat=Ilan.Fiyat,
                MulkiyetTipi=Ilan.MulkiyetTipi,
                Asansor=Ilan.Asansor,
                IlanTipi=Ilan.IlanTipi,
                 BosOlacagiTarih=Ilan.BosOlacagiTarih,
                  YayinTarih=DateTime.Now,
                 Sokak=Ilan.Sokak,
                  UyeId=Ilan.UyeId,
            
                   
               
            };
            Entity.Ilans.Add(yeniilan);
            
            Entity.SaveChanges();
           
            return new NIslemSonuc<int>
            {
                Basarilimi = true,
                Veri =yeniilan.IlanId
            };
        }
        catch (Exception hata)
        {

            return new NIslemSonuc<int>
            {
                
                Basarilimi = false,
                HataBilgi = new NHata 
                { 
                Sinif="IlanVer",
                Metod="IlanVeritabani",
                HataMesaj=hata.Message            
                },

                Mesaj="Ilan Eklenirken bir hata ile karşılaşıldı"+hata.Message
            };
        }
    
    }
    protected NIslemSonuc<bool> EnerjiBilgisiKaydet(NEnerjiKaydet EnerjiSinifi) 
    {
        try
        {

            var yenienerji = new EnerjiSinifi
            {
                EmisyonDegeri=EnerjiSinifi.EmisyonDegeri,
                 EnerjiDegeri=EnerjiSinifi.EnerjiDegeri,
                 EmisyonSinifi=EnerjiSinifi.EmisyonSinifi,
                 EnerjiSinifi1=EnerjiSinifi.EnerjiSinifi,
                 IlanId=EnerjiSinifi.IlanId
                 
            };
            Entity.EnerjiSinifis.Add(yenienerji);

            Entity.SaveChanges();

            return new NIslemSonuc<bool>
            {
                Basarilimi = true,
               
            };
        }
        catch (Exception hata)
        {

            return new NIslemSonuc<bool>
            {

                Basarilimi = false,
                HataBilgi = new NHata
                {
                    Sinif = "Enerji Bilgisi Kaydet",
                    Metod = "IlanVeritabani",
                    HataMesaj = hata.Message
                },

                Mesaj = "Ilan Eklenirken bir hata ile karşılaşıldı" + hata.Message
            };
        }
    

    }
    //Sayfa 2
    protected NIslemSonuc<bool> IlanDetayKaydet(NIlanDetay IlanDetay)
    {
        try
        {
            var yeniilandetay = new IlanDetay 
            {
                 GiyinmeOdasi=IlanDetay.GiyinmeOdasi,
                 Kiler=IlanDetay.Kiler,
               MGenelDurum=IlanDetay.MulkiyetGenelDurum,
               OKullanimDurum=IlanDetay.OrtakKullanimDurum,
                BahceKapisi=IlanDetay.BahceKapisi,
                BahceKapisiDurumu=IlanDetay.BahceKapisiDurumu,
                Pencereler=IlanDetay.Pencereler,
                Panjurlar=IlanDetay.Panjurlar,
                CatiDurum=IlanDetay.CatiDurum,
                CatiIskeletiDurum=IlanDetay.CatiIskeletiDurum,
                DisKaplamaDurum=IlanDetay.DisKaplamaDurum,
                YillikAidat=IlanDetay.YillikAidat,
                YillikVergiler=IlanDetay.YillikVergiler,
               MutfakEkipManlari=IlanDetay.MutfakEkipmanlari,
               Dolaplar=IlanDetay.Dolaplar,
                Interphone=IlanDetay.Interphone,
                Alarm=IlanDetay.Alarm,
                Uydu=IlanDetay.Uydu,
                AntenTv=IlanDetay.AntenTv,
                SomineTip1=IlanDetay.SomineTip1,
                SomineTip2=IlanDetay.SomineTip2,
                CatiKati=IlanDetay.CatiKati,
                Bodrum=IlanDetay.Bodrum,
                Garaj=IlanDetay.Garaj,
                ParkYeri=IlanDetay.ParkYeri,
                Havuz=IlanDetay.Havuz,
                BahceDuvari=IlanDetay.BahceDuvari,
               SuOlcumleri=IlanDetay.SuOlcum,
               
                IlanAciklama=IlanDetay.IlanAciklama,
                IlanId=IlanDetay.IlanId
                 
            };
               
            Entity.IlanDetays.Add(yeniilandetay);
            Entity.SaveChanges();
            
            return new NIslemSonuc<bool>
            {
                Basarilimi = true,

            };
        }
        catch (Exception hata)
        {

            return new NIslemSonuc<bool>
            {

                Basarilimi = false,
                HataBilgi = new NHata
                {
                    Sinif = "İlanDetay Bilgisi Kaydet",
                    Metod = "IlanVeritabani",
                    HataMesaj = hata.Message
                },

                Mesaj = "IlanDetay Eklenirken bir hata ile karşılaşıldı" + hata.Message
            };
        }


    }
    //Elden gecirilecek.
    protected NIslemSonuc<bool> IsinmaKaydet(NIsinma Isinma)
    {
        try
        {
            var yeni = new Isinma
            {
                GenelDurum = Isinma.GenelDurum,
                IsiSistemleriYasi = Isinma.IsiSistemleriYasi,
                Isitma = Isinma.Isitma,

                IsinmaTipi = Isinma.IsinmaTipi,
                EnerjiTipi = Isinma.EnerjiTipi,
                YillikTuketim = Isinma.YillikTuketim,
                IlanId = Isinma.IlanId

            };

            Entity.Isinmas.Add(yeni);
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
                HataBilgi = new NHata
                {
                    Sinif = "Isınma",
                    Metod = "IlanVeritabani",
                    HataMesaj = hata.Message
                },

                Mesaj = "Ilan Eklenirken bir hata ile karşılaşıldı" + hata.Message
            };

        }

    }
    protected NIslemSonuc<bool> ResimKaydet(NResimler IlanFotograf)
    {
        try
        {
            var yeni = new IlanFotograf
            { 
                 FotoPath=IlanFotograf.Resim,
                 IlanId=IlanFotograf.IlanId,
                  Thumb=IlanFotograf.Thumb

            };

            Entity.IlanFotografs.Add(yeni);
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
                HataBilgi = new NHata
                {
                    Sinif = "ResimKaydet",
                    Metod = "IlanVeritabani",
                    HataMesaj = hata.Message
                },

                Mesaj = "Resim Eklenirken bir hata ile karşılaşıldı" + hata.Message
            };

        }

    }
    protected NIslemSonuc<bool> TeshislerKaydet(NTeshisler Teshisler)
    {
        try
        {
            var yeni = new Teshisler
            {
                Asbest = Teshisler.Asbest,
                Termit = Teshisler.Termit,
                Kursun = Teshisler.Kursun,
                Carrez = Teshisler.Carrez,
                Electrik = Teshisler.Electrik,
                Gaz = Teshisler.Gaz,
                IlanId = Teshisler.IlanId

            };

            Entity.Teshislers.Add(yeni);
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
                HataBilgi = new NHata
                {
                    Sinif = "Teshisler",
                    Metod = "IlanVeritabani",
                    HataMesaj = hata.Message
                },

                Mesaj = "Ilan Eklenirken bir hata ile karşılaşıldı" + hata.Message
            };

        }

    }
    protected NIslemSonuc<bool> KonutDetayKaydet(NKonutDetay KonutDetay)
    {
        try
        {
            var yeni = new KonutDetay
            {
                Odalar = KonutDetay.Odalar,
                m2 = Convert.ToInt32(KonutDetay.m2),
                Kat = KonutDetay.Kat,
                Yon = KonutDetay.Yon,
                YerDoseme = KonutDetay.YerDoseme,
                Cerceveler = KonutDetay.Cerceveler,
                Camlar = KonutDetay.Camlar,
                Panjur = KonutDetay.Panjur,
                IlanId = KonutDetay.IlanId,

            };

            Entity.KonutDetays.Add(yeni);
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
                HataBilgi = new NHata
                {
                    Sinif = "KonutDetay",
                    Metod = "IlanVeritabani",
                    HataMesaj = hata.Message
                },

                Mesaj = "Ilan Eklenirken bir hata ile karşılaşıldı" + hata.Message
            };

        }

    }
    protected NIslemSonuc<bool> IlanIletisimKaydet(NIlanIletisim IlanIletisim)
    {
        try
        {
            var yeni = new IlanIletisim
            {
                IlanEmail = IlanIletisim.IlanEmail,
                IlanTelefon = IlanIletisim.IlanTelefon,
                IlanTelefon2 = IlanIletisim.IlanTelefon2,
                IlanIletisimSaatleri = IlanIletisim.IlanIletisimSaatleri,
                IlanIletisimSekli=IlanIletisim.IlanIletisimSekli,
                IlanId=IlanIletisim.IlanId
            };

            Entity.IlanIletisims.Add(yeni);
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
                HataBilgi = new NHata
                {
                    Sinif = "KonutDetay",
                    Metod = "IlanVeritabani",
                    HataMesaj = hata.Message
                },

                Mesaj = "Ilan Eklenirken bir hata ile karşılaşıldı" + hata.Message
            };

        }

    }

    //Elden gecirilecek.
    
    protected NIslemSonuc<bool> EvAlanOzelikleriKaydet(NEvAlanOzelik EvAlanOzelikleri) 
    {
        try
        {
            var yenialanozelikleri = new EvAlanOzelikleri
            {
                Dolaplar = EvAlanOzelikleri.Dolaplar,
                DisKaplama = EvAlanOzelikleri.DisKaplama,
                BahceDuvari = EvAlanOzelikleri.BahceDuvari,
                Pencereler = EvAlanOzelikleri.Pencereler,
                MutfakEkipmani = EvAlanOzelikleri.MutfakEkipmani,
                Cati = EvAlanOzelikleri.Cati,
                CatiIskeleti = EvAlanOzelikleri.CatiIskeleti,
                Panjurlar = EvAlanOzelikleri.Panjurlar,
                IlanId = EvAlanOzelikleri.IlanId,
                BinaYasi = EvAlanOzelikleri.BinaYasi,
                KullanimAlani = EvAlanOzelikleri.KullanimAlani
            };

            Entity.EvAlanOzelikleris.Add(yenialanozelikleri);
            Entity.SaveChanges();
            return new NIslemSonuc<bool>
            {
                Basarilimi=true
            };


        }
        catch (Exception hata)
        {
            return new NIslemSonuc<bool>
            {

                Basarilimi = false,
                HataBilgi = new NHata
                {
                    Sinif = "EvAlanOzelikleriKaydet",
                    Metod = "IlanVeritabani",
                    HataMesaj = hata.Message
                },

                Mesaj = "Ilan Eklenirken bir hata ile karşılaşıldı" + hata.Message
            };
            
        }
    
    }
   
    protected NIslemSonuc<bool> EvGenelOzelikleriKaydet(NEvGenelOzelik EvGenelOzelikleri)
    {
        try
        {
            var yeni = new EvGenelOzelikleri
            {
                BosolacagiTarih=EvGenelOzelikleri.BosOlacagiTarih,
                 MulkiyetDurumu=EvGenelOzelikleri.MulkiyetDurumu,
                 OrtakKullanimDurumu=EvGenelOzelikleri.OrtakKullanimDurumu,
                 YillikAidat=EvGenelOzelikleri.YillikAidat,
                 VideSanitaire=EvGenelOzelikleri.VideSanitaire,
                 IlanId=EvGenelOzelikleri.IlanId
               

            };
            Entity.EvGenelOzelikleris.Add(yeni);
            
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
                HataBilgi = new NHata
                {
                    Sinif = "EvGenelOzelikleriKaydet",
                    Metod = "IlanVeritabani",
                    HataMesaj = hata.Message
                },

                Mesaj = "Ilan Eklenirken bir hata ile karşılaşıldı" + hata.Message
            };

        }

    }


}