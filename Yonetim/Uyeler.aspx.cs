using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Yonetim_Uyeler : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        UyeIslem yeni = new UyeIslem();
        var sonuc = yeni.UyelikBilgileriGetirHepsini();
        if (sonuc.Basarilimi)
        {
            rptUyeler.DataSource = sonuc.Veri;
            rptUyeler.DataBind();
        }
       
    }
}