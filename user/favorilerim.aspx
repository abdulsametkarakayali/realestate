<%@ Page Title="" Language="C#" MasterPageFile="~/user/User.master" AutoEventWireup="true" CodeFile="favorilerim.aspx.cs" Inherits="user_favorilerim" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="sayfabaslik"><h2>Favoris</h2></div>
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
<div class="favoriilanlar">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
    <asp:Repeater ID="rptFavoriler" runat="server">
        <ItemTemplate>
    <div class="favoriilan">

    <div class="favoriilanbaslik fl" ><%#Eval("IlanTipi") %> <%#Eval("OdaSayisi") %> pièces <%#Eval("YasamAlani") %> m²  <%#Eval("SehirAd") %> <%#Eval("PostaKodu") %> </div>
    <div class="favoriilanfiyat fr"><%#Eval("Fiyat","{0:0,00}")%><span> €</span> </div>
    <div class="clr"></div>
        <div class="firmabilgileri">
            Appartement familial et de prestige 
            <br />Réf. : A88/1257 / 03 mars 2016 
        </div>
        <div class="favoriresim fl"><img src="<%#Eval("Resim") %>" width="247px" height="160px" /> </div>
        <div class="favoriaciklamalani fr">
           <p>  <%#Eval("SehirAd") %>  3e ( <%#Eval("PostaKodu") %>) <%#Eval("IlanAciklama") %> </p>
            <div class="favoridetay fl">
                <ul class="favoridetay">
                    <li><span class="label">Pièces</span><%#Eval("OdaSayisi") %> </li>
                    <li><span class="label">Chambres</span><%#Eval("YatakOdasi") %> </li>
                    <li><span class="label">Surface</span><%#Eval("YasamAlani") %> m2 </li>
                </ul>
            </div>
            <div class="favoridetayislem fr"> 
                <a href="/<%#ayarlar.UrlSeo(Eval("IlanTipi").ToString().ToLower()) %>-<%#Eval("OdaSayisi") %>-Pieces-<%#ayarlar.UrlSeo( Eval("SehirAd").ToString().ToLower()) %>-<%#Eval("PostaKodu") %>-<%#Eval("IlanID") %>" class="btndetayfavori">Detaylar </a>
                <asp:LinkButton  class="btndetayfavorisil" OnClick="FavoriCikar_Click"  commandname="Sil" CommandArgument='<%# Eval("IlanId") %>' ID="FavoriCikar" runat="server"><i class="fa fa-trash"></i></asp:LinkButton>
               
            </div>
        </div>


    </div>
</ItemTemplate>
</asp:Repeater>
</ContentTemplate>
</asp:UpdatePanel>
</div>
   
</asp:Content>

