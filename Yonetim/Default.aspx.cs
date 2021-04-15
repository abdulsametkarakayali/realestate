using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
 

public partial class Yonetim_Default : System.Web.UI.Page
{
    UyeIslem uyesayisi = new UyeIslem();
    IlanIslem ilansayisi = new IlanIslem();
    AramaSonucIslem aramasonuc = new AramaSonucIslem();
    protected void Page_Load(object sender, EventArgs e)
    {
        var sonuc= aramasonuc.GetirAramaKonutSonuc("Daire");
       // lblIlanSayisi.Text = Convert.ToString( sonuc.Veri.Count());
        var uye = uyesayisi.UyeSayisiGetir();
        lblUyeSayisi.Text = Convert.ToString(uye.Veri.Count());
    }

    
}