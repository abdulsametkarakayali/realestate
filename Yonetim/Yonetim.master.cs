using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Yonetim_Yonetim : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session[SiteTanim.QSKullaniciSession] == null)
        {
            Response.Redirect("/yonetim/login.aspx");
        }
        else  if (((NuyeBilgi)Session[SiteTanim.QSKullaniciSession]).UyeTip == (int)UyeTip.Yonetici)
        {
             //giriş yapıldı.
        }
        else  
        {
            Response.Redirect("/yonetim/login.aspx");
        }
        
    }
  
}
