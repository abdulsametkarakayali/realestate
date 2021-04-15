using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class user_User : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        YetkiKontrol();
    }
    protected void YetkiKontrol()
    {
        if (Session[SiteTanim.QSKullaniciSession] == null)
        {
            pnlUyeGirisi.Visible = true;
            pnlUye.Visible = false;
        }
        else
        {
            lblUyeIsmi.Text = ((NuyeBilgi)Session[SiteTanim.QSKullaniciSession]).Adi;

            pnlUyeGirisi.Visible = false;
            pnlUye.Visible = true;

            if (((NuyeBilgi)Session[SiteTanim.QSKullaniciSession]).UyeTip == (int)UyeTip.Kurumsal)
            {
                lblUyeIsmi.Text = ((NuyeBilgi)Session[SiteTanim.QSKullaniciSession]).SirketIsmi;
            }

        }

    }
}
