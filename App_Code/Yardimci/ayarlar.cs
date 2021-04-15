using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI.HtmlControls;

/// <summary>
/// Summary description for ayarlar
/// </summary>
public class ayarlar
{
	public ayarlar()
	{
		//
		// TODO: Add constructor logic here
		//

	}
    public static string TarihAraligi(string Tarih)
    {
        DateTime YeniTarih = Convert.ToDateTime(Tarih);

        var timeSpan = DateTime.Now - YeniTarih;

        if (timeSpan <= TimeSpan.FromSeconds(60))
            return string.Format("{0} saniye önce", timeSpan.Seconds);

        if (timeSpan <= TimeSpan.FromMinutes(60))
            return timeSpan.Minutes > 1 ? String.Format("{0} dakika önce", timeSpan.Minutes) : "1 dk önce";

        if (timeSpan <= TimeSpan.FromHours(24))
            return timeSpan.Hours > 1 ? String.Format("{0} saat önce", timeSpan.Hours) : "1 saat önce";

        if (timeSpan <= TimeSpan.FromDays(30))
            return timeSpan.Days > 1 ? String.Format("{0} gün önce", timeSpan.Days) : "dün";

        if (timeSpan <= TimeSpan.FromDays(365))
            return timeSpan.Days > 30 ? String.Format("{0} ay önce", timeSpan.Days / 30) : "geçen ay";

        return timeSpan.Days > 365 ? String.Format("{0} yıl önce", timeSpan.Days / 365) : "1 yıl önce";
    }
    public static string Temizle(string Metin)
    {
        string deger = Metin;

        deger = deger.Replace("'", "");
        deger = deger.Replace("<", "");
        deger = deger.Replace(">", "");
        deger = deger.Replace("&", "");
        deger = deger.Replace("[", "");
        deger = deger.Replace("]", "");

        return deger;
    }

    public static string UrlSeo(string Metin)
    {
        string s = Metin;
        if (string.IsNullOrEmpty(s)) return "";
        if (s.Length > 80)
            s = s.Substring(0, 80);
        s = s.Replace("ş", "s");
        s = s.Replace("Ş", "S");
        s = s.Replace("ğ", "g");
        s = s.Replace("Ğ", "G");
        s = s.Replace("İ", "I");
        s = s.Replace("ı", "i");
        s = s.Replace("ç", "c");
        s = s.Replace("Ç", "C");
        s = s.Replace("ö", "o");
        s = s.Replace("Ö", "O");
        s = s.Replace("ü", "u");
        s = s.Replace("Ü", "U");
        s = s.Replace("'", "");
        s = s.Replace("\"", "");
        Regex r = new Regex("[^a-zA-Z0-9_-]");
        //if (r.IsMatch(s))
        s = r.Replace(s, "-");
        if (!string.IsNullOrEmpty(s))
            while (s.IndexOf("--") > -1)
                s = s.Replace("--", "-");
        if (s.StartsWith("-")) s = s.Substring(1);
        if (s.EndsWith("-")) s = s.Substring(0, s.Length - 1);
        return s;
    }

    public static string SayfaMeta(string Metin)
    {
        string s = Metin;
        if (string.IsNullOrEmpty(s)) return "";
        if (s.Length > 160)
            s = s.Substring(0, 160);
        return s;
    }

     public static string SifreOlustur()

	  {
	      char[] karakter = "0123456789abcdefghijklmnoprstuvyz".ToCharArray(); //Şifrenin hangi harf ve sayılardan oluşacağını burada belirliyoruz
	       string sonuc = "";

	       Random rnd = new Random();
	      for (int i = 0; i < 6; i++) //Şifremiz şuan 6 karakter içericek.
	       {
	               sonuc += karakter[rnd.Next(0, karakter.Length - 1)].ToString();
	       }
	     return sonuc;
	 }
    

}