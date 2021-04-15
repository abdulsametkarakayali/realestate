<%@ Page Title="" Language="C#" MasterPageFile="~/Tema.master" AutoEventWireup="true" CodeFile="Ara.aspx.cs" Inherits="Ara" %>
<%@ Register assembly="CollectionPager" namespace="SiteUtils" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
     <title>Adhibe Property | IMMOBILIER - Annonces immobilières | | De Particulier à Particulier</title>
	 
	 
	 <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.0/jquery.min.js"></script>	 
 <script>
$(document).ready(function(){
   

    $(".telefongor img").click(function () {
        var id = $(this).attr('data-pid');
		 $('.d' + id).css("display", "none");
        $('.i' + id).css("display", "block");
      
    });
	
	  $(".mailgor img").click(function () {
        var id = $(this).attr('data-pid');
		 $('.d' + id).css("display", "none");
        $('.m' + id).css("display", "block");
      
    });
	
    
});
       
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="AramaAlani">
	<div class="ara">
		<ul class="aramaalani fl">
		<li>
		<asp:DropDownList ID="drpUlke"  Cssclass="dropara" runat="server">
        <asp:ListItem Selected="True">Ulke Seçiniz</asp:ListItem>
		</asp:DropDownList>
		</li>
		<li><asp:TextBox ID="txtIlIlce" width="230"  PlaceHolder="Ville / Commune" runat="server"></asp:TextBox></li>
		<li><asp:TextBox ID="txtPostaKodu" width="170"  PlaceHolder="Code Postal" runat="server"></asp:TextBox></li>
			<li> <asp:DropDownList ID="drpIlanTipi" Width="110"   Cssclass="dropara" runat="server">
            <asp:ListItem Value="Location">Location </asp:ListItem>
             <asp:ListItem Value="Vente">Vente </asp:ListItem>
		     </asp:DropDownList>
		</li>
		<li> <asp:DropDownList ID="drpMulkiyetTipi" Width="100"   Cssclass="dropara" runat="server">
            <asp:ListItem Value="Maison">Maison </asp:ListItem>
             <asp:ListItem Value="Appartement">Appartement </asp:ListItem>
		     </asp:DropDownList>
		</li></ul>
		<ul class="aramaalani fl">
		<li><asp:TextBox ID="txtOda"  width="170" PlaceHolder="Pieces" runat="server"></asp:TextBox></li>
		<li><asp:TextBox ID="txtYatakOdasi"   width="170" PlaceHolder="Chambres" runat="server"></asp:TextBox></li>
		<li><asp:TextBox ID="txtMinM2"   width="120" PlaceHolder="Min" runat="server"></asp:TextBox>m<sup>2</sup></li>
		<li><asp:TextBox ID="txtMaxM2"  width="120" PlaceHolder="Max" runat="server"></asp:TextBox>m<sup>2</sup></li>
		<li><asp:TextBox ID="txtMinE"  width="120" PlaceHolder="Min" runat="server"></asp:TextBox>€</li>
		<li><asp:TextBox ID="txtMaxE"  width="120" PlaceHolder="Max" runat="server"></asp:TextBox>€</li>
		</ul>
		
	</div>
	<div class="arabutono fr">
        <asp:ImageButton ID="imageAra" ImageUrl="../Tema/img/ara.png" onclick="imageAra_Click" runat="server" /> 
	</div>

</div>

     <div class="sag  koyurenk">
         <asp:Panel ID="pnlMesaj" Visible="false" runat="server"><br />
         <asp:Label ID="lblMesaj" runat="server" Text=""></asp:Label>
             </asp:Panel>
         <asp:Panel ID="PnlSonuc" Visible="false" runat="server">
         <asp:Repeater ID="rptKonutlar" runat="server">
             <ItemTemplate>
	  <a href="<%#ayarlar.UrlSeo(Eval("IlanTipi").ToString().ToLower()) %>-<%#Eval("OdaSayisi") %>-Pieces-<%#ayarlar.UrlSeo( Eval("SehirAd").ToString().ToLower()) %>-<%#Eval("PostaKodu") %>-<%#Eval("IlanID") %>" class="Pli">
                        <div class="listeitem bg_dynamic_1 liste-golge inner-golge" id="61370" >
                            <div class="resim">
                                <img src='<%#Eval("Thumb") %>' width="185" height="147">
                            </div>
                            <div class="info">
                                <div class="adi"><%#Eval("IlanTipi") %><%#Eval("MulkiyetTipi") %></div>
								<div class="ilposta"> <%#Eval("PostaKodu") %> <%#Eval("SehirAd") %> </div>
								<div class="clr"></div>
								 <asp:Panel ID="PnlKurumsal" Visible='<%#Convert.ToInt32(Eval("UyeTip"))==2%>' runat="server"> 
                                <div class="bolgesi"><%#Eval("ReferansNo") %>  <%# Convert.ToDateTime(Eval("KayitTarih")).ToString("d") %></div>
								<div class="firmaadi">  <%#Eval("SirketIsmi")==""?"":Eval("SirketIsmi") %></div>
								</asp:Panel> 
								 <br class="gizle"/>
								 <div class="enerji-verimlilik-baslik">Classe énergétique:</div>
								 <div class="enerji-verimlik">&nbsp;<span><%#Eval("EnerjiSinifi").ToString().ToUpper() %></span> <%#Eval("EnerjiDegeri") %></div>
								  <div class="emisyon-ges-baslik">Emission GES:</div>
								 <div class="emisyon-ges">&nbsp;<span><%#Eval("EmisyonSinifi").ToString().ToUpper() %></span> <%#Eval("EmisyonDegeri") %> </div>
								  <br class="gizle"/>
								  <div class="iconlar-emlak">
								 <div class="alan"><span>Surface</span><br/><%#Eval("YasamAlani") %> m<sup>2</sup></div>
								
								   
								 <div class="oda"><span>Pièces</span><br/><%#Eval("OdaSayisi") %></div>
								  <div class="yatakodasi"><span>Chambres</span><br/><%#Eval("YatakOdaSayisi") %></div>
                                 </div>
								 </div>
                            <div class="ozellik">
                                 <div class="fiyat"><%#Eval("Fiyat","{0:### ### ### ###.##}")%><span> € <%#Convert.ToInt32(Eval("UyeTip"))==1?"":"F.A.I." %></span></div>
								<div class="iconlar">
								<ul class="ozelik-icon">
								<li><a href="/rapor.aspx?id=<%#Eval("IlanID") %>" title="" ><img src="Tema/img/iconlar/pdf.png" alt="" title=""></a></li>
								<li class="mailgor"> <img src="Tema/img/iconlar/email.png"  data-pid="<%#Eval("IlanID") %>" alt="" title=""></li>
								<li class="telefongor">  <img src="Tema/img/iconlar/call.png" data-pid="<%#Eval("IlanID") %>"   alt="" title=""/> 
								</li>
								
								</div>
								<div class="Pro"><%#Convert.ToInt32(Eval("UyeTip"))==1?"":"PRO" %></div>
                               <asp:Panel ID="PnlDevami"    runat="server">
                               <a href="<%#ayarlar.UrlSeo(Eval("IlanTipi").ToString().ToLower()) %>-<%#Eval("OdaSayisi") %>-Pieces-<%#ayarlar.UrlSeo( Eval("SehirAd").ToString().ToLower()) %>-<%#Eval("PostaKodu") %>-<%#Eval("IlanID") %>" class="Pli"><div class="odam2  d<%#Eval("IlanID") %>">En savoir plus…</div></a>
                               </asp:Panel>
                           
							<div class="i<%#Eval("IlanID") %> iletisim" style="display:none"> <i class="fa fa-phone" aria-hidden="true"></i><%#Eval("TelefonNo") %></div> 
								    <div class="m<%#Eval("IlanID") %> iletisim" style="display:none"> <i class="fa fa-envelope-o" aria-hidden="true"></i>  <%#Eval("EMail") %></div> 
								<!--	<h3><asp:Label ID="lblEmail" runat="server" Text=""></asp:Label></h3>-->
								 </div>
                            <div style="clear: both"></div>
             </div>
         </a>
            </ItemTemplate>
		  </asp:Repeater>
		 </asp:Panel>
              <div class="sayfalama">
        <cc1:CollectionPager ID="CollectionPager1" runat="server" SliderSize="100" ShowPageNumbers="True"
        LabelText="" PageSize="10" NextText="İleri" LastText="" BackText="Geri" BackNextLinkSeparator=""
        BackNextLocation="None" BackNextStyle="padding:0 5px;" PageNumbersDisplay="Numbers"
        ResultsFormat="" MaxPages="100" QueryStringKey="sayfa" BackNextButtonStyle="sayfaGeri"
        PageNumbersSeparator=" ">
        </cc1:CollectionPager>
		  </div>


</asp:Content>

