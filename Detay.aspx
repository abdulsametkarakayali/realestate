<%@ Page Title="" Language="C#" MasterPageFile="~/Tema.master" AutoEventWireup="true" CodeFile="Detay.aspx.cs" Inherits="Detay" %>

 

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
        <script type="text/javascript" src="Tema/js/jquery-1.9.1.min.js"></script>
    <script type="text/javascript" src="Tema/js/jssor.slider.mini.js"></script>
	 <script type="text/javascript" src="Tema/js/custom.js"></script>
	 <title>
         <asp:Literal ID="ltlTitle" runat="server"></asp:Literal>   </title>
	 
	 
<link rel="stylesheet" type="text/css" href="/Tema/adhibe/style.20160301104325.css" />
<script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>

<!-- jQueryUI -->
<script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jqueryui/1.8.23/jquery-ui.min.js"></script>
 <!-- jQuery plugin : Showcase image slideshow -->
<script type="text/javascript" src="/Tema/adhibe/jquery.aw-showcase.min.js"></script>


<!-- jQuery plugin : Placeholder fix IE8 -->

<script type="text/javascript" src="/Tema/adhibe/jquery.placeholder.js"></script>
<script type="text/javascript" src="/Tema/adhibe/adhibe.20160301104201.js"></script>	



</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
<div class="detaybaslik fl">
   
<asp:Panel ID="pnlSirketIsmi" visible="false" runat="server">        
<ul class="firmaadibolumu" >
<li><asp:Label ID="lblSirketIsmi" runat="server" Text=""></asp:Label>  </li><li> <asp:Label ID="lblReferans" runat="server" Text=""></asp:Label> / <asp:Label ID="lblYayinTarih" runat="server" Text=""></asp:Label></li>
</ul>
</asp:Panel>
<ul class="detaybasliklar">
<li>
    <asp:Label ID="lblIlanTipi" runat="server" Text=""></asp:Label>  
</li>
<li><asp:Label ID="lblKatBireysel" runat="server" Text=""></asp:Label> </li>
<li><asp:Label ID="lblAsansor" runat="server" Text=""></asp:Label></li>
<li class="yazibeyaz">
    
    <asp:Label ID="lblFiyat" runat="server"   Text=""></asp:Label></li>
<li><asp:Label ID="lblYasamAlani" runat="server" Text=""></asp:Label> m<sup>2</sup></li> 
<li><asp:Label ID="lblOda" runat="server" Text=""></asp:Label> Pièces </li>
<li><asp:Label ID="lblYatakOdasi" runat="server" Text=""></asp:Label> chambres </li>
<li><asp:Label ID="lblPostaKodu" runat="server" Text=""></asp:Label> /<asp:Label ID="lblSehirAd" runat="server" Text=""></asp:Label></li>
</ul> 
<div class="slideralani">
	<section class="details-annonce-container clearfix">

			<div class="descriptif-container">
				<div class="descriptif-content clearfix">
				 <div id="showcase" class="showcase" style="width:800px;">
				<asp:Repeater ID="rptResimler" runat="server">
              <ItemTemplate>			
				<div class="showcase-slide">
					<div class="showcase-content">
						<img src="<%#Eval("Resim")%>" alt="" />
					</div>
					<div class="showcase-thumbnail">
						<img src="<%#Eval("Thumb") %>" alt="" />
					</div>
				</div>
				 </ItemTemplate>
            </asp:Repeater> 
						
		</div>
		</div>		
	</section>	
   
   
            
            <div data-p="144.50" style="display: none;">
                <img data-u="image" src="" />
                <img data-u="thumb" src="" />
            </div>
              
        </div>
        
		

</div>

</div>
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

<div class="detaykullanici fr">
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
<div class="iconlar">
	<ul class="ozelik-icon2">
	<li><a href="/rapor.aspx?id=<asp:Literal ID="ltlRapor" runat="server"></asp:Literal>"><img src="Tema/img/iconlar/pdf.png" alt="" title=""></a></li>
	<li><asp:ImageButton  ID="ImageEmail" ImageUrl="~/Tema/img/iconlar/email.png" onclick="ImageEmail_Click" runat="server" /></li>
	<li><asp:ImageButton  ID="ImageTel" ImageUrl="~/Tema/img/iconlar/call.png" onclick="ImageTel_Click"  runat="server" /></li>
	<li> <asp:ImageButton   ID="ImgTakipEt" ImageUrl="~/Tema/img/iconlar/star.png" OnClick="ImgTakipEt_Click" runat="server" /><asp:ImageButton ID="ImgTakipBirak"  Visible="false" ImageUrl="~/Tema/img/iconlar/redstar.png" runat="server" OnClick="ImgTakipBirak_Click" /></li>
	</ul>
</div>
    </ContentTemplate>
</asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
    <asp:Panel ID="pnlTelefonEmail" Visible="false" runat="server">
        <div class="telefonemail">
            <h3><asp:Label ID="LblIletisimSaat" runat="server" Text=""></asp:Label></h3>
            <h3><asp:Label ID="lblTelefon" runat="server" Text=""></asp:Label></h3>
            <h3><asp:Label ID="lblEmail" runat="server" Text=""></asp:Label></h3>
        </div>
        
    </asp:Panel>
                </ContentTemplate>
        </asp:UpdatePanel>
<div class="enerjisinif">
<span>Classe énergétique</span>
<img src="Tema/img/enerji/enerji.jpg" alt=""  title=""/><br/>
<span class="enerjisinifikod">
    <asp:Label ID="lblEnerjiSinifiHarf"  runat="server" Text=""></asp:Label></span>
<span class="enerjisinifinumara"><asp:Label ID="lblEnerjiSinifiNumara" runat="server" Text=""></asp:Label></span>
</div>
<div class="enerjisinif">
<span>Emission GES</span>
<img src="Tema/img/enerji/enerjitipi.jpg" alt=""  title=""/><br/>
<span class="enerjisinifikod"><asp:Label ID="lblEmisyonHaft" runat="server" Text=""></asp:Label></span>
<span class="enerjisinifinumara"><asp:Label ID="lblEmisyonNumara" runat="server" Text=""></asp:Label></span>
</div>

</div>





</div>

<div class="konutdetaylari clr">

 <br/>

<table class="bordered" style="100%">
	<tr class="ilktablo">
		<td width="15%">Pièces</td>
		<td width="5%">m2</td>
		<td width="14%">Niveau</td>
		<td width="13%">Orientation</td>
		<td width="13%">Sol</td>
		<td width="10%">Fenêtre</td>
		<td width="14%">Vitrage</td>
		<td width="200">Volets</td>
      
	</tr>
      <tr>
      <asp:DataList ID="dtlKonutDetay"  runat="server" ItemType="NKonutDetay">
        
          <ItemTemplate>
	        
		        <td width="15%"><%# Item.Odalar %></td>
		        <td  width="5%"><%# Item.m2 %></td>
		        <td width="14%"><%# Item.Kat %></td>
		        <td width="13%"><%# Item.Yon %></td>
		        <td width="13%"><%# Item.YerDoseme %></td>
		        <td width="10%"><%# Item.Cerceveler %></td>
		        <td width="14%"><%# Item.Camlar %></td>
		        <td width="200"><%# Item.Panjur %></td>
	       
        </ItemTemplate>
          
    </asp:DataList>
          </tr>
	
</table>








</div>

<div class="konutozelikleri clr">

<div class="konutsol fl">
 <div class="evozelikleri">
 
 <h4>Habitation</h4>
 <table>
  <tr>
    <th>Type de propriété : ........................</th>
    <th class="beyazyazi"><asp:Label ID="lblMulkiyetTipi" runat="server" Text=""></asp:Label></th>
  </tr>
  <tr>
    <td>Vendu Loué : ...................................</td>
    <td class="beyazyazi"><asp:Label ID="lblUygunluk" runat="server" Text=""></asp:Label></td>
  </tr>
  <tr>
    <td>Loyer / mois (€) : ...........................</td>
    <td class="beyazyazi"><asp:Label ID="lblAylikKira" Text="---" runat="server" ></asp:Label></td>
  </tr>
   <tr>
    <td>Etat général du bien : ....................</td>
    <td class="beyazyazi"><asp:Label ID="lblMulkiyetGenelDurum" runat="server" Text=""></asp:Label></td>
  </tr>
     <tr>
    <td>Etat général co-propriété : ..........</td>
    <td class="beyazyazi"><asp:Label ID="lblOrtakKullanimDurumu" runat="server" Text=""></asp:Label></td>
  </tr>
</table>
<br/><br/><br/> 
<h4>Chauffage</h4>
 <table>
  <tr>
    <th>Chauffage: ................................</th>
    <th class="beyazyazi"><asp:Label ID="lblIsitma" runat="server" Text=""></asp:Label></th>
  </tr>
  <tr>
    <td>Etat général: ............................</td>
    <td class="beyazyazi"><asp:Label ID="lblIsitmaGenelDurum" runat="server" Text=""></asp:Label></td>
  </tr>
  <tr>
    <td>Année de la chaudière: .........</td>
    <td class="beyazyazi"><asp:Label ID="lblIsitmaYasi" runat="server" Text=""></asp:Label></td>
</table>
<br/>
<h4>Caracteristiques</h4>

 <table>
  <tr>
    <th>Surface du terrain (m2): .......</th>
    <th class="beyazyazi"><asp:Label ID="lblKullanimAlani" runat="server" Text=""></asp:Label></th>
  </tr>
  <tr>
    <td>Cuisine équipée : .....................</td>
    <td class="beyazyazi"><asp:Label ID="lblMutfakEkipmani" runat="server" Text=""></asp:Label></td>
  </tr>
  <tr>
	<td>Cellier (m2) : ....................... </td>
	<td class="beyazyazi"><asp:Label ID="lblKiler" runat="server" Text=""></asp:Label> </td>
  </tr>
  <tr>
    <td>Placards intégrés (chambres):</td>
    <td class="beyazyazi"><asp:Label ID="lblDolaplar" runat="server" Text=""></asp:Label></td>
  </tr>
  <tr>
	<td>Dressing (m2) : .......................... </td>	
	<td class="beyazyazi"><asp:Label ID="lblGiyinmeOdasi" runat="server" Text=""></asp:Label> </td>
  </tr>
  <tr>
    <td>Portail: ......................................</td>
    <td class="beyazyazi"><asp:Label ID="lblBahceKapi" runat="server" Text=""></asp:Label> / <asp:Label ID="lblBahceKapisiDurumu" runat="server" Text=""></asp:Label></td>
  </tr>
   <tr>
    <td>Fenêtres (état): .......................</td>
    <td class="beyazyazi"><asp:Label ID="lblPencereler" runat="server" Text=""></asp:Label></td>
  </tr>
   <tr>
    <td>Volets (état): ...........................</td>
    <td class="beyazyazi"><asp:Label ID="lblPanjurlar" runat="server" Text=""></asp:Label></td>
  </tr>
   <tr>
    <td>Toiture (état): .........................</td>
    <td class="beyazyazi"><asp:Label ID="lblCati" runat="server" Text=""></asp:Label></td>
  </tr>
   <tr>
    <td>Charpente (état): ...................</td>
    <td class="beyazyazi"><asp:Label ID="lblCatiIskeleti" runat="server" Text=""></asp:Label></td>
  </tr>
   <tr>
    <td>Façade (état): ..........................</td>
    <td class="beyazyazi"><asp:Label ID="lblDisKaplama" runat="server" Text=""></asp:Label></td>
  </tr>
   <tr>
    <td>Clôture: ....................................</td>
    <td class="beyazyazi"><asp:Label ID="lblBahceDuvari" runat="server" Text=""></asp:Label></td>
  </tr>
    <tr>
    <td>Interphone: ..............................</td>
    <td class="beyazyazi"><asp:Label ID="lblInterphone" runat="server" Text=""></asp:Label></td>
  </tr>  
 
</table><br/>
<h4>Diagnostics Techniques Fournis</h4>
  <table>
  <tr>
    <th>Amiante: ...................................</th>
    <th class="beyazyazi"><asp:Label ID="lblAsbest" runat="server" Text=""></asp:Label></th>
  </tr>
  <tr>
    <td>Termite: ....................................</td>
    <td class="beyazyazi"><asp:Label ID="lblTermit" runat="server" Text=""></asp:Label></td>
  </tr>
  <tr>
    <td>Plomb: .......................................</td>
    <td class="beyazyazi"><asp:Label ID="lblKursun" runat="server" Text=""></asp:Label></td>
  </tr>
</table>
 </div>
</div>
<div class="konutsag fr">

<div class="evozelikleri">
 <table>
  <tr>
    <th>Année de construction : ...............</th>
    <th class="beyazyazi">
        <asp:Label ID="lblGenelBinaYasi" runat="server" Text=""></asp:Label></th>
  </tr>
   <tr>
    <td>Vendu Libre le : ...............................</td>
    <td class="beyazyazi"> <asp:Label ID="lblUygunlukVendu" runat="server" Text="—"></asp:Label></td>
  </tr>
  <tr>
    <td>Intérieur : .........................................</td>
    <td class="beyazyazi"> <asp:Label ID="lblIcMekan" runat="server" Text=""></asp:Label></td>
  </tr>
  <tr>
    <td>Taxe foncière annuelle (€) : .........</td>
    <td class="beyazyazi"> <asp:Label ID="lblYillikVergi" runat="server" Text=""></asp:Label></td>
  </tr>
    <tr>
    <td>Charges co-propriété / an (€) : ..</td>
    <td class="beyazyazi"> <asp:Label ID="lblYillikAidat" runat="server" Text=""></asp:Label></td>
  </tr> 
 
</table><br/><br/>
<br/><br/><br/>
 <table>
  <tr>
    <th>Type de chauffage: .................</th>
    <th class="beyazyazi">
        <asp:Label ID="lblIsitmaTipi" runat="server" Text=" "></asp:Label></th>
  </tr>
  <tr>
    <td>Type d’energie: .......................</td>
    <td class="beyazyazi"><asp:Label ID="lblEnerjiTipi" runat="server" Text=""></asp:Label></th>
</td>
  </tr>
  <tr>
    <td>Consommation annuelle (€):</td>
    <td class="beyazyazi"><asp:Label ID="lblIsitmaYillikTuketim" runat="server" Text=""></asp:Label></th>
</td></tr>
 </table>
<br/><br/><br/><br/><br/><br/> 
 <table>
 
  <tr>
    <td>Alarme: .....................................</td>
    <td class="beyazyazi"><asp:Label ID="lblAlarm" runat="server" Text="non"></asp:Label></td>
  </tr>  
  <tr>
    <td>Parabole: ..................................</td>
    <td class="beyazyazi"><asp:Label ID="lblUydu" runat="server" Text="non"></asp:Label></td>
  </tr>   
  <tr>
    <td>Antenne TV : ............................</td>
    <td class="beyazyazi"><asp:Label ID="lblAnten" runat="server" Text="non"></asp:Label></td>
  </tr>
  <tr>
    <td>Cheminée foyer ouvert: ...</td>
    <td class="beyazyazi"><asp:Label ID="lblSomine1" runat="server" Text="non"></asp:Label></td>
  </tr>
   <tr>
    <td>Insert: .......................................</td>
    <td class="beyazyazi"><asp:Label ID="lblSomine2" runat="server" Text="non"></asp:Label></td>
  </tr>
   <tr>
    <td>Combles aménagées (m2): ...</td>
    <td class="beyazyazi"><asp:Label ID="lblCatiKati" runat="server" Text="non"></asp:Label></td>
  </tr>
   <tr>
    <td>Cave (m2): ................................</td>
    <td class="beyazyazi"><asp:Label ID="lblBodrum" runat="server" Text="non"></asp:Label></td>
  </tr>
   <tr>
    <td>Garage (m2): ............................</td>
    <td class="beyazyazi"><asp:Label ID="lblGaraj" runat="server" Text="non"></asp:Label></td>
  </tr>
   <tr>
    <td>Parking (nbre place): .............</td>
    <td class="beyazyazi"><asp:Label ID="lblPark" runat="server" Text="non"></asp:Label></td>
  </tr>
   <tr>
    <td>Piscine (dimensions en m):..</td>
    <td class="beyazyazi"><asp:Label ID="lblHavuz" runat="server" Text="non"></asp:Label></td>
  </tr>
     <tr>
    <td>Evacuations des eaux usées : ..</td>
    <td class="beyazyazi"><asp:Label ID="lblSuOlcumleri" runat="server" Text="non"></asp:Label></td>
  </tr>
</table><br/>
 <br/><br/>
  <table>
  <tr>
    <th>Carrez : .....................................</th>
    <th class="beyazyazi"><asp:Label ID="lblCarez" runat="server" Text=""></asp:Label></th>
  </tr>
  <tr>
    <td>Eléctrique: ................................</td>
    <td class="beyazyazi"><asp:Label ID="lblEnerji" runat="server" Text=""></asp:Label></td>
  </tr>
  <tr>
    <td>Gaz: ...........................................</td>
    <td class="beyazyazi"><asp:Label ID="lblGaz" runat="server" Text=""></asp:Label></td>
  </tr>
   
</table>
 </div>
 

<asp:HiddenField ID="hidden" runat="server" />


</div>
    

</div>
     
<div class="ilanacikalam clr">
<asp:Literal ID="ltlAcikalama" runat="server"></asp:Literal>
    </div>
<script
src="http://maps.googleapis.com/maps/api/js">
</script>
 <script type="text/javascript" src="https://maps.googleapis.com/maps/api/js?sensor=false"></script>
<script>
 var sehir = document.getElementById('<%=hidden.ClientID %>').value;
 
 var geocoder =  new google.maps.Geocoder();
 geocoder.geocode( { 'address':sehir}, function(results, status) {
if (status == google.maps.GeocoderStatus.OK) {      
var amsterdam=new google.maps.LatLng(results[0].geometry.location.lat(),results[0].geometry.location.lng());
function initialize()
{
var mapProp = {
  center:amsterdam,
  zoom:14,
  mapTypeId:google.maps.MapTypeId.ROADMAP
  };
  
var map = new google.maps.Map(document.getElementById("googleMap"),mapProp);

var myCity = new google.maps.Circle({
  center:amsterdam,
  radius:600,
  strokeColor:"#fff",
  strokeOpacity:0.8,
  strokeWeight:2,
  fillColor:"red",
  fillOpacity:0.4
  });

myCity.setMap(map);
}

google.maps.event.addDomListener(window, 'load', initialize);
 } else {
             
			var amsterdam=new google.maps.LatLng(results[0].geometry.location.lat(),results[0].geometry.location.lng());
          }
        });
</script>	
	
	
	<div class="haritaalani">
	<div id="googleMap" style="width:100%;height:380px;"></div>
	
     </div>
</asp:Content>

