using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class user_ilanlarim : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack) return;
        IlalarimiGetir();
    }
    public void IlalarimiGetir()
    {

        AramaSonucIslem ilanlarim = new AramaSonucIslem();

        var sonuc = ilanlarim.GetirIlanlarim(((NuyeBilgi)Session[SiteTanim.QSKullaniciSession]).UyeId);
        if (sonuc.Basarilimi == true)
        {
            rptFavoriler.DataSource = sonuc.Veri;
            rptFavoriler.DataBind();


        }
    }
}