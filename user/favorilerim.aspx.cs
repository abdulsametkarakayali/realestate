using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class user_favorilerim : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack) return;
        FavorilanGetir();
 
       



    }
    public void FavorilanGetir()
    {

        AramaSonucIslem favori = new AramaSonucIslem();

        var sonuc = favori.GetirFavoriler(((NuyeBilgi)Session[SiteTanim.QSKullaniciSession]).UyeId);
        if (sonuc.Basarilimi == true)
        {
            rptFavoriler.DataSource = sonuc.Veri;
            rptFavoriler.DataBind();


        }
    }
    protected void FavoriCikar_Click(object sender, EventArgs e)
    {
        int IlanId =Convert.ToInt32 ((sender as LinkButton).CommandArgument);
        DetayIslem favori = new DetayIslem();
        var sonuc = favori.FavoriCikar(IlanId, ((NuyeBilgi)Session[SiteTanim.QSKullaniciSession]).UyeId);
        if (sonuc.Basarilimi)
        {
            FavorilanGetir();
        }
       
    }


     
}