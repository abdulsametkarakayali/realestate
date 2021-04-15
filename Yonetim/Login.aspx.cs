using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
 
public partial class Yonetim_Login : System.Web.UI.Page
{

  
    protected void Page_Load(object sender, EventArgs e)
    {
        YetkiKontrol();

    }
    protected void YetkiKontrol() 
    {
        if (Session[SiteTanim.QSKullaniciSession] == null)
        {
             
        }
        else
        {
            Response.Redirect("/yonetim/default.aspx");

        }
    
    }
   
    protected void btnGiris_Click(object sender, EventArgs e)
    {
        UyeIslem uye = new UyeIslem();
        var sonuc = uye.Giris(KullaniciAdi.Value,password.Value);

        if (sonuc.Basarilimi)
        {
            Session[SiteTanim.QSKullaniciSession] = sonuc.Veri;
            Response.Redirect("/yonetim/default.aspx");
        }

    }
}