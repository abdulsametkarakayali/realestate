using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UyeCikis : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session[SiteTanim.QSKullaniciSession]!=null)
        {
            Session[SiteTanim.QSKullaniciSession] = null;
        }
        Response.Redirect("/default.aspx");
    }
}