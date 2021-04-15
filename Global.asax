<%@ Application Language="C#" %>
<%@ Import Namespace="System.Web.Routing" %>
<script runat="server">

    void Application_Start(object sender, EventArgs e) 
    {
        // Code that runs on application startup
        RoutingAyarlari(RouteTable.Routes);
    }

    void RoutingAyarlari(RouteCollection routes)
    {

        routes.MapPageRoute("", "contact", "~/iletisim.aspx");
        routes.MapPageRoute("", "rechercher-un-bien", "~/ara.aspx");
        routes.MapPageRoute("konumesajlari", "{IlanTipi}-{OdaSayisi}-Pieces-{SehirAd}-{PostaKodu}-{IlanID}", "~/detay.aspx");

	   routes.MapPageRoute("", "uye-ol", "~/uye-ol.aspx");
        routes.MapPageRoute("", "uye-giris", "~/uye-giris.aspx");
        routes.MapPageRoute("", "uye", "~/uye.aspx");
        routes.MapPageRoute("", "sayfa/{sayfa}", "~/default.aspx");
        routes.MapPageRoute("Uye", "uye/{UyeAdi}", "~/uye.aspx");
        routes.MapPageRoute("Yorumlar", "{KonuBaslik}/{Konu}-{MesajID}", "~/yorumlar.aspx");

      //  routes.MapPageRoute("konumesajlari", "{KonuBaslik}-{KonuID}", "~/konumesajlari.aspx");
        // routes.MapPageRoute("konumesajlari", "{KonuID}-{KonuBaslik}", "~/konumesajlari.aspx");
        // routes.MapPageRoute("Yorumlar", "{Konu}-{MesajID}", "~/Yorumlar.aspx");



    }
    
    void Application_End(object sender, EventArgs e) 
    {
        //  Code that runs on application shutdown

    }
        
    void Application_Error(object sender, EventArgs e) 
    { 
        // Code that runs when an unhandled error occurs

    }

    void Session_Start(object sender, EventArgs e) 
    {
        // Code that runs when a new session is started

    }

    void Session_End(object sender, EventArgs e) 
    {
        // Code that runs when a session ends. 
        // Note: The Session_End event is raised only when the sessionstate mode
        // is set to InProc in the Web.config file. If session mode is set to StateServer 
        // or SQLServer, the event is not raised.

    }
       
</script>
