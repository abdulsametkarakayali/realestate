using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Entity;

/// <summary>
/// Summary description for UyeVeritabani
/// </summary>
public class UyeVeritabani:Veritabani
{
   protected NIslemSonuc<NuyeBilgi> Giris(string Email,string Sifre)
   {
       try
       {
           var kayitlar = (from u in Entity.Uyes
                           where u.EMail == Email && u.Sifre == Sifre
                           select u);

           if (kayitlar.Count() > 0)
           {
               var kayit = kayitlar.FirstOrDefault();
               return new NIslemSonuc<NuyeBilgi>
               {
                   Basarilimi = true,
                   Veri = new NuyeBilgi
                    {
                        Adi = kayit.Ad,
                        SirketIsmi=kayit.SirketIsmi,
                        Soyadi = kayit.Soyad,
                        Eposta = kayit.EMail,
                        UyeId = kayit.UyeId,
                        Telefon=kayit.TelefonNo,
                        UyeTip=(int)kayit.UyeTip
                    }
               };
           }
           else
           {
               return new NIslemSonuc<NuyeBilgi>
               {
                   Basarilimi=false,
                   Mesaj="Uye Kaydi Bulunamadi"

               };
           }

       }
       catch (Exception hata)
       {

           return new NIslemSonuc<NuyeBilgi>
           {
               Basarilimi = false,
               HataBilgi = new NHata 
               { 
               HataMesaj= hata.Message,
               Metod="Giris",
               Sinif="UyeVeritabani"
               },
               Mesaj="Bir hata ile karşılaşıldı"

           };
       }    
   }
   protected NIslemSonuc<NuyeBilgi> UyeOl(NuyeOl uyeBilgi) 
   {
       try
       {
           var uyesayisi=(from u in Entity.Uyes
                          where u.EMail==uyeBilgi.Email
                             select u );
           if (uyesayisi.Count() > 0) 
           {
               return new NIslemSonuc<NuyeBilgi> 
               {
               Basarilimi=false,
               Mesaj="E-posta Adresine ait uye sistemde bulunmaktadır."
               };
           }
           else {

           var yeniuye = new Uye
           {
               Ad=uyeBilgi.Ad,
               Soyad=uyeBilgi.Soyad,
               EMail=uyeBilgi.Email,
               Sifre=uyeBilgi.Sifre,
               Adres=uyeBilgi.Adres,
               UlkeId=uyeBilgi.UlkeId,
              SehirAd=uyeBilgi.SehirAd,
               UyeTip=uyeBilgi.UyeTip,
               PostaKodu=uyeBilgi.PostaKodu,
               SirketIsmi=uyeBilgi.SirketIsmi,
               Siren=uyeBilgi.Siren,
               KayitTarih=uyeBilgi.KayitTarih,
               GirisIp= HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"],
               CinsiyetTip=uyeBilgi.CinsiyetTip,
               TelefonGorunsunMu=uyeBilgi.TelefonGorunsunMu,
               TelefonNo=uyeBilgi.TelefonNo,
               

           };
           Entity.Uyes.Add(yeniuye);
           Entity.SaveChanges();
           return new NIslemSonuc<NuyeBilgi>
           {
               Basarilimi = true,
               Veri = new NuyeBilgi 
               {
                Adi=yeniuye.Ad,
                Soyadi=yeniuye.Soyad,
                Eposta=yeniuye.EMail,
                SirketIsmi=yeniuye.SirketIsmi,
                UyeId=yeniuye.UyeId,
                UyeTip=(int)yeniuye.UyeTip,
                 Telefon=yeniuye.TelefonNo,
               }
           };

           }
       }
       catch (Exception hata)
       {
           return new NIslemSonuc<NuyeBilgi>
           {
               Basarilimi = false,
               HataBilgi = new NHata
               {
                   HataMesaj = hata.Message,
                   Metod = "UyeOl",
                   Sinif = "UyeVeritabani"
               },
               Mesaj = "Bir hata ile karşılaşıldı"

           };

       }
   
   }
   protected NIslemSonuc<NuyeBilgi> SifremiUnutum(string Email) 
   {
       try
       {
           var kayitlar = (from u in Entity.Uyes
                           where u.EMail == Email
                           select u);
           if (kayitlar.Count()>0)
           {
               var kayit = kayitlar.FirstOrDefault();
               return new NIslemSonuc<NuyeBilgi>
               {
                   Basarilimi = true,
                   Veri = new NuyeBilgi 
                   {
                       Adi=kayit.Ad,
                       Sifre=kayit.Sifre,
                       Soyadi=kayit.Soyad,
                        Eposta=kayit.EMail
                         
                   
                   }

               };
           }
           else
           {
               return new NIslemSonuc<NuyeBilgi>
               {
                   Basarilimi = false,
                  Mesaj="Sistemde kayıtlı eposta adresi bulunamadı."

               };
           }
       }
       catch (Exception hata)
       {

           return new NIslemSonuc<NuyeBilgi>
           {
               Basarilimi = false,
               HataBilgi = new NHata 
               {
               Sinif="SifremiUnuttum",
               Metod="UyeVeritabani",
               HataMesaj=hata.Message
               },
               Mesaj="Bir hata ile karşılaşıldı"
           };
       }
   
   }
   protected NIslemSonuc<List<Nuye>> UyeSayisi() 
   {
       try
       {

           var uyeler = (from u in Entity.Uyes
                         select new Nuye
                         {
                             Ad = u.Ad,
                             Email = u.EMail,
                         }).ToList();
          
               return new NIslemSonuc<List<Nuye>>
               {
                   Basarilimi = true,
                   Veri = uyeler
               };
          

       }
       catch (Exception hata)
       {
           return new  NIslemSonuc<List<Nuye>>
           {
               Basarilimi = false,
               HataBilgi = new NHata
               {
                   Sinif = "Uye Sayisi",
                   Metod = "UyeVeritabani",
                   HataMesaj = "Veritabanindan Uye bilgisi çekilemedi"
               }
           };
       }  
   }

   protected NIslemSonuc<bool> SifreDegistir(string ESifre, string YSifre, int UyeId) 
   {
       try
       {
           var sonuc =(from u in Entity.Uyes
                        where u.Sifre==ESifre && u.UyeId==UyeId
                          select u );
           if (sonuc.Count()>0)
           {
               var kayit = sonuc.FirstOrDefault();
               kayit.Sifre = YSifre;
               Entity.SaveChanges();
               return new NIslemSonuc<bool>
               {
                    Basarilimi=true
               };
           }
           else
           {
               return new NIslemSonuc<bool>
               {
                   Basarilimi = false,
                   HataBilgi = new NHata
                   {
                       HataMesaj = "Şifreler Uyuşmuyor",
                       Metod = "Şifre Değiştir",
                       Sinif = "ÜyeVeritabani"
                   },
                   Mesaj = "Şifreler Uyuşmuyor"

               };
           }

           
       }
       catch (Exception hata)
       {

           return new NIslemSonuc<bool>
           {
               Basarilimi = false,
               HataBilgi = new NHata
               {
                   HataMesaj = "Şifre alanında sorun oluştu"+hata.Message,
                   Metod = "Şifre Değiştir",
                   Sinif = "ÜyeVeritabani"
               },
               Mesaj = "Şifreler Uyuşmuyor"

           };
       }
   }

   protected NIslemSonuc<NuyeBilgi> UyeBilgileriGetir(int UyeId)
   {
       try
       {
           var kayitlar = (from u in Entity.Uyes
                           where u.UyeId==UyeId
                           select u).ToList();
           if (kayitlar.Count() > 0)
           {
               var kayit = kayitlar.FirstOrDefault();
               return new NIslemSonuc<NuyeBilgi>
               {
                   Basarilimi = true,
                   Veri = new NuyeBilgi 
                   {
                        Adi=kayit.Ad,
                        Eposta=kayit.EMail,
                        Adres=kayit.Adres,
                        SirketIsmi=kayit.SirketIsmi,
                        Soyadi=kayit.Soyad,
                         Telefon=kayit.TelefonNo,
                         Sifre=kayit.Sifre,
                         PostaKodu=(int)kayit.PostaKodu
                   }

               };
           }
           else
           {
               return new NIslemSonuc<NuyeBilgi>
               {
                   Basarilimi = false,
                   Mesaj = "Sistemde sorun oluştu"

               };
           }
       }
       catch (Exception hata)
       {

           return new NIslemSonuc<NuyeBilgi>
           {
               Basarilimi = false,
               HataBilgi = new NHata
               {
                   Sinif = "UyeBilgileriGetir",
                   Metod = "UyeVeritabani",
                   HataMesaj = hata.Message
               },
               Mesaj = "Bir hata ile karşılaşıldı"
           };
       }

   }

   protected NIslemSonuc<List<NuyeBilgi>> UyeBilgileriGetirHepsini( )
   {
       try
       {
           var kayitlar = (from u in Entity.Uyes
                           select new NuyeBilgi
                           {
                              Adi=u.Ad,
                              Adres=u.Adres,
                              Eposta=u.EMail,
                              SirketIsmi=u.SirketIsmi,
							  Sifre=u.Sifre,
                             UyeTip=(int)u.UyeTip,
                               KayitTarih=(DateTime)u.KayitTarih,
                              Soyadi=u.Soyad,
                              Telefon=u.TelefonNo,
                               
                           }).ToList();
           if (kayitlar.Count() > 0)
           {
              
               return new NIslemSonuc<List<NuyeBilgi>>
               {
                   Basarilimi = true,
                   Veri=kayitlar

               };
           }
           else
           {
               return new NIslemSonuc<List<NuyeBilgi>>
               {
                   Basarilimi = false,
                   Mesaj = "Sistemde sorun oluştu"

               };
           }
       }
       catch (Exception hata)
       {

           return new NIslemSonuc<List<NuyeBilgi>>
           {
               Basarilimi = false,
               HataBilgi = new NHata
               {
                   Sinif = "UyeBilgileriGetir",
                   Metod = "UyeVeritabani",
                   HataMesaj = hata.Message
               },
               Mesaj = "Bir hata ile karşılaşıldı"
           };
       }

   }

   protected NIslemSonuc<bool> UyeDuzenle(NuyeOl UyeBilgi)
   {
       try
       {
           var kayitlar = (from u in Entity.Uyes
                           where u.UyeId== UyeBilgi.UyeId
                           select u);
           if (kayitlar.Count() > 0)
           {
               var kayit = kayitlar.FirstOrDefault();
               kayit.Ad = UyeBilgi.Ad;
               kayit.Adres = UyeBilgi.Adres;
               kayit.EMail = UyeBilgi.Email;
               kayit.PostaKodu = UyeBilgi.PostaKodu;
               kayit.SirketIsmi = UyeBilgi.SirketIsmi;
               kayit.Soyad = UyeBilgi.Soyad;
               kayit.TelefonNo = UyeBilgi.TelefonNo;
               Entity.SaveChanges();

               return new NIslemSonuc<bool>
               {
                    Basarilimi=true
               };
           }
           else
           {
               return new NIslemSonuc<bool>
               {
                   Basarilimi = false,
                   Mesaj = "Veritabanında ilgili kayıt bulunamadı"
               };
           }
       }
       catch (Exception hata)
       {
           return new NIslemSonuc<bool>
           {
               Basarilimi = false,
               HataBilgi = new NHata
               {
                   HataMesaj = hata.Message,
                   Metod = "Duzenle",
                   Sinif = "UyeVeritabani"
               }
           };
       }
   }



   }