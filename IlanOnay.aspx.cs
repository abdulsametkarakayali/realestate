using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class IlanOnay : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       ltlId.Text=Convert.ToString(Session[SiteTanim.QSIlanID]);
    }
}