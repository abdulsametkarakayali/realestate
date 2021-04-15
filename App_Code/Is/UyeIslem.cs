using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for UyeIslem
/// </summary>
public class UyeIslem:UyeVeritabani
{
    public NIslemSonuc<NuyeBilgi> Giris(string Email, string Sifre) 
    {
        var sonuc = base.Giris(Email, Sifre);
        if (sonuc.HataBilgi != null) 
        {
        //Veritabanina Eklenecek
        }
        return sonuc;

    }
    public NIslemSonuc<bool> UyeDuzenle(NuyeOl  UyeBilgi)
    {
        var sonuc = base.UyeDuzenle(UyeBilgi);
        if (sonuc.HataBilgi != null)
        {
            //Hata mesajını veritabanına kaydet
        }
        return sonuc;
    }
    public NIslemSonuc<NuyeBilgi> UyelikBilgileriGetir(int UyeId)
    {
        var sonuc = base.UyeBilgileriGetir(UyeId);
        if (sonuc.HataBilgi != null)
        {
            //Veritabanina Eklenecek
        }
        return sonuc;

    }

    public NIslemSonuc<List<NuyeBilgi>> UyelikBilgileriGetirHepsini()
    {
        var sonuc = base.UyeBilgileriGetirHepsini();
        if (sonuc.HataBilgi != null)
        {
            //Veritabanina Eklenecek
        }
        return sonuc;

    }
    public NIslemSonuc<NuyeBilgi> UyeOl(NuyeOl uyeBilgi)
    {
        var sonuc = base.UyeOl(uyeBilgi);
        if (sonuc.HataBilgi != null)
        {
            //Veritabanina Eklenecek
        }
        return sonuc;

    }
    public NIslemSonuc<NuyeBilgi> SifremiUnuttum(string Email)
    {
        var sonuc = base.SifremiUnutum(Email);
        if (sonuc.HataBilgi != null)
        {
            //Veritabanina Eklenecek
        }
        return sonuc;

    }
    public NIslemSonuc<List<Nuye>> UyeSayisiGetir() 
    {
        var sonuc = base.UyeSayisi();
        if (sonuc.HataBilgi!=null)
        {
            // veritabanaı kayıt edildi.
        }
        return sonuc;
    }
    public NIslemSonuc<bool> SifreDegistir(string ESifre, string YSifre, int UyeId)
    {
        var sonuc = base.SifreDegistir(ESifre, YSifre, UyeId);
        if (sonuc.HataBilgi != null)
        {
            //Veritabanina Eklenecek
        }
        return sonuc;

    }
}