<%@ Page Title="" Language="C#" MasterPageFile="~/Tema.master" AutoEventWireup="true" CodeFile="IlanVer.aspx.cs" Inherits="IlanVer" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<script src="//ajax.googleapis.com/ajax/libs/jquery/1.10.2/jquery.min.js"></script>
		<script type="text/javascript" src="Tema/js/jquery.price_format.2.0.min.js"></script>
       <script type = "text/javascript">
      function MutExChkList(chk) {
          var chkList = chk.parentNode.parentNode.parentNode;
          var chks = chkList.getElementsByTagName("input");
          for (var i = 0; i < chks.length; i++) {
              if (chks[i] != chk && chk.checked) {
                  chks[i].checked = false;
              }
          }
      }
</script>
 
 <script type="text/javascript">
   $(function(){
  
   $('#ContentPlaceHolder1_txtKiralikFiyat').priceFormat({
    prefix: '',
	centsLimit: 3,
});
    });
</script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:HiddenField ID="hdnMulkiyetTipi" runat="server" />
	 <asp:HiddenField ID="hdnFiyat" runat="server" />
    <asp:Label ID="lblMesaj" runat="server" Text=""></asp:Label>
<h3>STEP 1 / <asp:Label ID="lblStep" runat="server" Text=""></asp:Label></h3>

    <asp:Panel ID="PnlIletisimBilgileri" visible="false" runat="server">
<h4>Vos coordonnées</h4>
<span>Indiquez votre e-mail ou/et votre numéro de téléphone afin que des acheteurs puissent vous contacter.</span>
<div class="satilikform">
<label>E-mail<asp:RequiredFieldValidator ID="rqvEmail" runat="server" ErrorMessage="*" ControlToValidate="txtEmail" ></asp:RequiredFieldValidator>  </label>
 <asp:TextBox ID="txtEmail" width="325" runat="server"></asp:TextBox><br />
<label>Téléphone(s)<asp:RequiredFieldValidator ID="rqvTelefon" runat="server" ErrorMessage="*" ControlToValidate="txtTelefon" ></asp:RequiredFieldValidator> </label>
 <asp:TextBox ID="txtTelefon"  runat="server"></asp:TextBox><br />
<label> </label> <asp:TextBox ID="txtTelefon2"  runat="server"></asp:TextBox><br />
<br/>
<label class="icmekan">Vous souhaitez être contacté par</label>
    
<asp:CheckBoxList ID="chckIletisimSekli"  runat="server">
    <asp:ListItem Text = "telephone"    Value ="telephone"  >
    </asp:ListItem>
    <asp:ListItem Text = "email" Value ="email">
    </asp:ListItem>
</asp:CheckBoxList>	

<label>Plage horraire pour être contacté</label> <asp:TextBox ID="txtIletisimSaatleri" width="325"  placeholder="ex : veuillez me contacter entre 18h et 21h" runat="server"></asp:TextBox><br/><br/>
<div class="fotografyorum">Les photos sont téléchargées après le réglement de l’annonce.</div>

</div>
</asp:Panel>


<h4><asp:Label ID="lblKonutTipi" runat="server" Text=""></asp:Label></h4>
<div class="satilikform">
     <asp:UpdatePanel ID="UpdatePanel1" runat="server">
       <ContentTemplate>
	<label>Pays :</label>
    <asp:DropDownList width="188" ID="drpUlke" class="drop" runat="server">
        <asp:ListItem Selected="True"  Value="0">sélectionnez pays</asp:ListItem>
    </asp:DropDownList>
           <asp:RequiredFieldValidator ID="rqlUlke" runat="server" ControlToValidate="drpUlke" InitialValue="0" ErrorMessage="*"></asp:RequiredFieldValidator>
    </ContentTemplate>
    </asp:UpdatePanel>
	<label>Code postal / Ville / Commune</label>
	<asp:TextBox ID="txtPostaKodu" placeholder="code postal"   runat="server"></asp:TextBox> 
      <asp:FilteredTextBoxExtender ID="FilterPostaKodu"  TargetControlID="txtPostaKodu" FilterType="Numbers"
        Enabled="True"  
         runat="server">
    </asp:FilteredTextBoxExtender>
	<asp:TextBox ID="txtSehirAd" placeholder="ville / commune" runat="server"></asp:TextBox> <br />
<label>Adresse de la propriété<asp:RequiredFieldValidator ID="rqvAdres" runat="server" ErrorMessage="*" ControlToValidate="txtAdres" ></asp:RequiredFieldValidator><asp:RequiredFieldValidator ID="rqvSokak" runat="server" ErrorMessage="*" ControlToValidate="txtSokak" ></asp:RequiredFieldValidator></label>
 <asp:TextBox ID="txtAdres"  placeholder="numéro"   runat="server"></asp:TextBox>  <asp:TextBox ID="txtSokak" placeholder="avenue / boulevard / rue"  runat="server"></asp:TextBox><br />
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
<label>Type de propriété</label>
            <asp:CheckBox ID="chckVilla"   AutoPostBack="true" OnCheckedChanged="chckVilla_CheckedChanged" runat="server" />
			<asp:Label ID="lblVilla" runat="server" Text="maison"></asp:Label>
			 <asp:DropDownList width="188" ID="drpBireyselIkiz" visible="false" class="drop" runat="server">
				<asp:ListItem   Value="individuelle">individuelle</asp:ListItem>
				<asp:ListItem   Value="mitoyenne">mitoyenne</asp:ListItem>
			</asp:DropDownList>
			 
			</asp:TextBox> <asp:CheckBox ID="chckDaire" AutoPostBack="true" OnCheckedChanged="chckDaire_CheckedChanged" runat="server" /> 
			<asp:Label ID="lblDaire" runat="server" Text="appartement">
			</asp:Label>  <asp:TextBox ID="txtKatNo" Visible="false" width="80" placeholder="à quel étage"  runat="server">
			</asp:TextBox>
   </ContentTemplate>
            </asp:UpdatePanel>
<label class="icmekan">Intérieur</label>
<asp:CheckBoxList ID="chckIcMekan" runat="server">
    <asp:ListItem Text = "meublé" Value ="meublé"  onclick = "MutExChkList(this);" >
    </asp:ListItem>
    <asp:ListItem Text = "non meublé" Value ="non meublé"     onclick = "MutExChkList(this);">
    </asp:ListItem>
</asp:CheckBoxList>	
<div class="asansor">
<label class="icmekan">Ascenseur</label>
<asp:CheckBoxList ID="chckAsansor" runat="server">
    <asp:ListItem Text = "sans ascenseur" Value ="sans ascenseur"  onclick = "MutExChkList(this);">
    </asp:ListItem>
    <asp:ListItem Text = "avec ascenseur" Value ="avec ascenseur"   onclick = "MutExChkList(this);">
    </asp:ListItem>
</asp:CheckBoxList>	
</div>
<label>Année de construction<asp:RequiredFieldValidator ID="rqvBinaYasi" runat="server" ErrorMessage="*" ControlToValidate="txtBinaYasi" ></asp:RequiredFieldValidator></label>
 <asp:TextBox ID="txtBinaYasi" MaxLength="4"  runat="server"></asp:TextBox><br />
   
 
 
<asp:Panel ID="pnlSatilikEv" Visible="false" runat="server">
 <asp:UpdatePanel ID="updSatilikEv" runat="server">
 <ContentTemplate>
<label> Propriété vendue</label>
 <asp:CheckBox ID="chckKirada" runat="server" OnCheckedChanged="chckKirada_CheckedChanged" AutoPostBack="True" />louée
 <asp:TextBox ID="txtAylikKira" visible="false"  Width="130"   placeholder="montant loyer" runat="server"></asp:TextBox>
<asp:CheckBox ID="chclibre"  OnCheckedChanged="libre_CheckedChanged" AutoPostBack="True"   runat="server" /> 
<asp:Label ID="lbllibre"  runat="server" Text="libre le"></asp:Label><asp:TextBox ID="txtBosOlacagiTarih" visible="false" Width="130" placeholder="jj/mm/aaaa" runat="server"></asp:TextBox>

 </ContentTemplate>
</asp:UpdatePanel>
</asp:Panel>
<label>Nombre de pièces<asp:RequiredFieldValidator ID="rqvFiyat" runat="server" ErrorMessage="*" ControlToValidate="txtOdasayisi" ></asp:RequiredFieldValidator></label>
 <asp:TextBox ID="txtOdasayisi" MaxLength="3" runat="server"></asp:TextBox><br/>
      <asp:FilteredTextBoxExtender ID="FilterOdaSayisi"  TargetControlID="txtOdasayisi" FilterType="Numbers"
        Enabled="True"  
         runat="server">
    </asp:FilteredTextBoxExtender>
<label>Nombre de chambres<asp:RequiredFieldValidator ID="rqvYatakOdaSayisi" runat="server" ErrorMessage="*" ControlToValidate="txtYatakOdasi" ></asp:RequiredFieldValidator></label>
 <asp:TextBox ID="txtYatakOdasi" MaxLength="3"  runat="server"></asp:TextBox><br/>
      <asp:FilteredTextBoxExtender ID="FilterYatakOdasi"  TargetControlID="txtYatakOdasi" FilterType="Numbers"
        Enabled="True"  
         runat="server">
    </asp:FilteredTextBoxExtender>
<label>Surface habitable en m2<asp:RequiredFieldValidator ID="rqvYasamAlani" runat="server" ErrorMessage="*" ControlToValidate="txtYasamAlani" ></asp:RequiredFieldValidator></label>
 <asp:TextBox ID="txtYasamAlani" MaxLength="5" runat="server"></asp:TextBox><br/>
     <asp:FilteredTextBoxExtender ID="FilterYasamAlani"  TargetControlID="txtYasamAlani" FilterType="Numbers"
        Enabled="True"  
         runat="server">
    </asp:FilteredTextBoxExtender>
<label>Surface terrain en m2 </label>
 <asp:TextBox ID="txtKullanimAlani" MaxLength="5" runat="server"></asp:TextBox><br/>
    <asp:FilteredTextBoxExtender ID="FilterKullanimAlani"  TargetControlID="txtKullanimAlani" FilterType="Numbers"
        Enabled="True"  
         runat="server">
    </asp:FilteredTextBoxExtender>
 <br/>

<label> Important :</label> <div class="enerjihakkindaaciklama"> Depuis le 1er janvier 2011, la loi impose l’affichage du DPE
sur les annonces immobilières.
Vous devez impérativement avoir votre DPE pour diffuser
votre annonce.
 
 </div>
    
 <div class="clr"></div>
<label>Classe énergétique DPE<asp:RequiredFieldValidator ID="rqvEnerjiSinifi" runat="server" ErrorMessage="*" ControlToValidate="txtEnerjiSinifi" ></asp:RequiredFieldValidator><asp:RequiredFieldValidator ID="rqvEnerjiNumara" runat="server" ErrorMessage="*" ControlToValidate="txtEnerjiNumara" ></asp:RequiredFieldValidator></label>
 <asp:TextBox ID="txtEnerjiSinifi" MaxLength="1"  placeholder="de A à G (sélectionnez)"  runat="server"></asp:TextBox> <asp:TextBox ID="txtEnerjiNumara" MaxLength="3"  placeholder="ex : 182"  runat="server"></asp:TextBox> kWhEP/m2/an<br/>
 <asp:FilteredTextBoxExtender ID="FilterEnerji"  TargetControlID="txtEnerjiNumara" FilterType="Numbers"
        Enabled="True"  
         runat="server">
    </asp:FilteredTextBoxExtender>
 <label>Emission GES (gaz à effet de serre)<asp:RequiredFieldValidator ID="rqvEmisyonGes" runat="server" ErrorMessage="*" ControlToValidate="txtEmisyonSinifi" ></asp:RequiredFieldValidator><asp:RequiredFieldValidator ID="rqvEmisyonNumara" runat="server" ErrorMessage="*" ControlToValidate="txtEmisyonNumara" ></asp:RequiredFieldValidator></label>
 <asp:TextBox ID="txtEmisyonSinifi"  MaxLength="1" placeholder="de A à G (sélectionnez)" runat="server"></asp:TextBox> <asp:TextBox ID="txtEmisyonNumara"  MaxLength="3"   placeholder="ex : 43" runat="server"></asp:TextBox> kgéqCO2/m2/an<br/>
    <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender1"  TargetControlID="txtEmisyonNumara" FilterType="Numbers"
        Enabled="True"  
         runat="server">
    </asp:FilteredTextBoxExtender>
      
 <br/>
  
<label> <asp:Label ID="lblFiyat" runat="server" Text=""></asp:Label><asp:RequiredFieldValidator ID="rqvFiyatim" runat="server" ErrorMessage="*" ControlToValidate="txtFiyat" ></asp:RequiredFieldValidator></label>
 <asp:TextBox ID="txtFiyat"   runat="server" >0</asp:TextBox><br/>
 
    <asp:FilteredTextBoxExtender ID="FilteredSatisFiyati"  TargetControlID="txtFiyat" FilterType="Numbers"
        Enabled="True"    
         runat="server">
    </asp:FilteredTextBoxExtender>
 
   <asp:Panel ID="PnlProfSatilik" Visible="false" runat="server">
<label>Votre référence d’annonce PRO</label>
 <asp:TextBox ID="txtReferansNo"  runat="server"></asp:TextBox><br/>
</asp:Panel>



<asp:Panel ID="pnlOdemeBireysel" Visible="false" runat="server">
 <div class="fiyatodemealani">	
Sélectionnez votre forfait pour la diffusion de votre annonce<br/>
<div class="odemeaciklamasi">+ 1 mois offert pour la diffusion de votre première annonce</div>
<div class="uyeliktipi">
	<ul class="uyetip">
	<li>Forfait 14 jours <br/> 
	<input type="checkbox" name="vehicle" value="Bike"><br/>
	7,85 euros
	</li>
	<li>Forfait 45 jours<br/> 
	<input type="checkbox" name="vehicle" value="Bike"><br/>
	19,90 euros
	</li>
	<li>Forfait 90 jours<br/> 
	<input type="checkbox" name="vehicle" value="Bike"><br/>
	33,60 euros
	</li>
	</ul>
	</div>
       
</div>
</div>
 </asp:Panel>		
	<div class="clr"></div>
<asp:Panel ID="pnlKurumsalUyeResim" Visible="false" runat="server">	
<h2>Photos</h2>
<div class="dosyayuklemepaneli">

	<asp:FileUpload AllowMultiple="true" ID="FileUpload1" runat="server" />
    
</div>
</asp:Panel>
<div class="devami">
    <asp:LinkButton ID="btDevam" runat="server" OnClick="btDevam_Click">Continuer</asp:LinkButton>
     </div>


</asp:Content>

