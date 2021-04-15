<%@ Page Title="" Language="C#" MasterPageFile="~/Tema.master" AutoEventWireup="true" CodeFile="Kurumsal-Uyelik-Formu.aspx.cs" Inherits="Kurumsal_Uyelik_Formu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
  
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
     <div class="uyekayit">
 <h4>Création du Compte Professionnel</h4>
<div class="uyekayit-formu">
    <asp:Label ID="lblMesaj" runat="server" Text=""></asp:Label><br /><br />
	<label>Nom de la société:<asp:RequiredFieldValidator ID="rqSirketIsmi" runat="server" ErrorMessage="*" ControlToValidate="txtSirketIsmi"></asp:RequiredFieldValidator> </label>
	<asp:TextBox ID="txtSirketIsmi"  runat="server"></asp:TextBox> Le nom apparaîtra dans l’annonce<br />
	<label>Siren :<asp:RequiredFieldValidator ID="rqSiren" runat="server" ErrorMessage="*" ControlToValidate="txtSiren"></asp:RequiredFieldValidator></label>
	<asp:TextBox ID="txtSiren"  runat="server"></asp:TextBox><br /><br/>
	 
	<label>Adresse :<asp:RequiredFieldValidator ID="rqAdres" runat="server" ErrorMessage="*" ControlToValidate="txtAdres"></asp:RequiredFieldValidator><asp:RequiredFieldValidator ID="rqAdres2" runat="server" ErrorMessage="*" ControlToValidate="txtAdres2"></asp:RequiredFieldValidator></label>
	<asp:TextBox ID="txtAdres"  runat="server" placeholder="numéro" ></asp:TextBox> <asp:TextBox ID="txtAdres2" placeholder="avenue / boulevard / rue"  runat="server"></asp:TextBox><br />
	<div class="adrestekli"><asp:TextBox ID="txtAdres3" placeholder="n° Appartement"  runat="server"></asp:TextBox></div><br />
	<label>Code postal:<asp:RequiredFieldValidator ID="rqPostaKod" runat="server" ErrorMessage="*" ControlToValidate="txtPostaKodu"></asp:RequiredFieldValidator> </label>
	<asp:TextBox ID="txtPostaKodu"  runat="server"></asp:TextBox><br />
   <asp:UpdatePanel ID="UpdatePanel1" runat="server">
       <ContentTemplate>
	<label>Pays:</label>
    <asp:DropDownList ID="drpUlke" class="drop" runat="server" AutoPostBack="True"  >
        <asp:ListItem Selected="True"  Value="0">Pays</asp:ListItem>
    </asp:DropDownList>
	<br />
	<label>Ville :<asp:RequiredFieldValidator ID="rqvSehirAd" runat="server" ErrorMessage="*" ControlToValidate="txtSehirAd"></asp:RequiredFieldValidator></label>
	  <asp:TextBox ID="txtSehirAd"  runat="server"></asp:TextBox><br />
       </ContentTemplate>
    </asp:UpdatePanel>

	
	<label>Téléphone :<asp:RequiredFieldValidator ID="rqTelefon" runat="server" ErrorMessage="*" ControlToValidate="txtTelefon"></asp:RequiredFieldValidator></label>
	<asp:TextBox ID="txtTelefon"  runat="server"></asp:TextBox><br />
	<label>E-mail :<asp:RequiredFieldValidator ID="rqEmail" runat="server" ErrorMessage="*" ControlToValidate="txtEmail"></asp:RequiredFieldValidator></label>
	<asp:TextBox ID="txtEmail"  runat="server"></asp:TextBox><br />
	<label>E-mail confirmation :<asp:RequiredFieldValidator ID="rqconf" runat="server" ErrorMessage="*" ControlToValidate="txtEmailOnay"></asp:RequiredFieldValidator></label>
	<asp:TextBox ID="txtEmailOnay"  runat="server"></asp:TextBox><br /><br/>
	<label>Mot de passe:<asp:RequiredFieldValidator ID="rqsifre" runat="server" ErrorMessage="*" ControlToValidate="txtSifre"></asp:RequiredFieldValidator></label>
	<asp:TextBox ID="txtSifre"  runat="server"></asp:TextBox><br />
	<label>Confirmer le mot de passe:<asp:RequiredFieldValidator ID="rqSifreOnay" runat="server" ErrorMessage="*" ControlToValidate="txtSifreOnay"></asp:RequiredFieldValidator></label>
	<asp:TextBox ID="txtSifreOnay"  runat="server"></asp:TextBox><br />
	<br/>
	<h4>Sélectionnez votre forfait pour la diffusion de vos annonces sur votre Compte Professionnel</h4>
	<div class="uyeliktipi">
	<ul class="uyetip">
	<li>Forfait 6 mois <br/> 
	<input type="checkbox" name="vehicle" class="odemetip" value="Bike"><br/>
	159 euros
	</li>
	<li>Forfait 12 mois<br/> 
	<input type="checkbox" name="vehicle" class="odemetip" value="Bike"><br/>
	292 euros
	</li>
	</ul>
	</div>
	
	</div>
	<div class="odemeguvenligi clr">
	<h4>Paiement sécurisé</h4>
	<span>Paiement sécurisé par le système CyberMut du Crédit Mutuel</span>
	
	<ul class="karttipi">
	<li>Carte bleu</li>
	<li>VISA</li>
	<li>Master Card</li>
	</ul>
	
	</div>
	
	<div class="kredikartiodeme">
	<label>Numéro de carte:</label>
	<asp:TextBox ID="txtKartNumarasi" MaxLength="16"   runat="server"></asp:TextBox><br />
	<label>Date d’expiration:</label>
	<asp:DropDownList ID="drpSnkAy" runat="server">
        <asp:ListItem Value="01" Text="01"></asp:ListItem>
        <asp:ListItem Value="02" Text="02"></asp:ListItem>
         <asp:ListItem Value="03" Text="03"></asp:ListItem>
         <asp:ListItem Value="04" Text="04"></asp:ListItem>
         <asp:ListItem Value="05" Text="05"></asp:ListItem>
         <asp:ListItem Value="06" Text="06"></asp:ListItem>
         <asp:ListItem Value="07" Text="07"></asp:ListItem>
         <asp:ListItem Value="08" Text="08"></asp:ListItem>
         <asp:ListItem Value="09" Text="09"></asp:ListItem>
         <asp:ListItem Value="10" Text="10"></asp:ListItem>
         <asp:ListItem Value="11" Text="11"></asp:ListItem>
         <asp:ListItem Value="12" Text="12"></asp:ListItem>
    </asp:DropDownList>
        <asp:DropDownList ID="drpSnkYil" runat="server">
        <asp:ListItem Value="2016" Text="2016"></asp:ListItem>
        <asp:ListItem Value="2017" Text="2017"></asp:ListItem>
         <asp:ListItem Value="2018" Text="2018"></asp:ListItem>
         <asp:ListItem Value="2019" Text="2019"></asp:ListItem>
         <asp:ListItem Value="2020" Text="2020"></asp:ListItem>
         <asp:ListItem Value="2021" Text="2021"></asp:ListItem>
         <asp:ListItem Value="2022" Text="2022"></asp:ListItem>
         <asp:ListItem Value="2023" Text="2023"></asp:ListItem>
    </asp:DropDownList>
        
        <br />
	<label>CVV :</label>
	<asp:TextBox ID="txtCcv"  MaxLength="3"    runat="server"></asp:TextBox><br />
    <label>Cryptogramme :</label>
    <asp:DropDownList ID="drpKartTip" runat="server">
        <asp:ListItem Value="1" Text="Master"></asp:ListItem>
        <asp:ListItem Value="2" Text="Visa"></asp:ListItem>
        <asp:ListItem Value="3" Text="Card Blue"></asp:ListItem>
    </asp:DropDownList>

	
	
	</div>
	
	<div class="onayyazisi">
	<p>
<input type="checkbox" name="vehicle" value="Bike">	Je déclare avoir pris connaissance des conditions générales de vente et des conditions d’accés aux données
personnelles. Je demande l’exécution immédiate du contrat avant l’expiration du délai de rétractation et
renonce au bénéfice de celui-ci.
	
	</p>
	
	</div>

         <asp:LinkButton ID="OnaylaveOde"  class="onaylaode" runat="server" OnClick="OnaylaveOde_Click">Valider la commande et le paiement</asp:LinkButton><br /><br />
	 
	  <script src="https://code.jquery.com/jquery-2.1.0.min.js"></script>
    <script>
        $('input[type="checkbox"]').on('change', function () {
            $(this).siblings('input[type="checkbox"]').not(this).prop('checked', false);
        });
    </script>
	
	
</asp:Content>

