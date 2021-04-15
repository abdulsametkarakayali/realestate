using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for AramaSonucIslem
/// </summary>
public class AramaSonucIslem:AramaSonuclariVeritabani
{
    public NIslemSonuc<List<NAramaSonuc>> GetirAramaKonutSonuc(string MulkiyetTipi)
    {
        var sonuc = base.GetirAramaKonutSonuc(MulkiyetTipi);
        if (sonuc.HataBilgi!=null)
        {
            //Veritabanina Kayit Edilecek
        }
        return sonuc;
    
    
    }

    public NIslemSonuc<List<NAramaSonuc>> IlanAra(NIlanAraKriter Kriter)
    {
        var sonuc = base.IlanAra(Kriter);
        if (sonuc.HataBilgi != null)
        {
            //Veritabanina Kayit Edilecek
        }
        return sonuc;


    }

    public NIslemSonuc<List<NAramaSonuc>> GetirFavoriler(int UyeId)
    {
        var sonuc = base.GetirFavoriler(UyeId);
        if (sonuc.HataBilgi != null)
        {
            //Veritabanina Kayit Edilecek
        }
        return sonuc;


    }

    public NIslemSonuc<List<NAramaSonuc>> GetirIlanlarim(int UyeId)
    {
        var sonuc = base.GetirIlanlarim(UyeId);
        if (sonuc.HataBilgi != null)
        {
            //Veritabanina Kayit Edilecek
        }
        return sonuc;


    }
}