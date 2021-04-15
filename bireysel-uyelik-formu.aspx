<%@ Page Title="" Language="C#" MasterPageFile="~/Tema.master" AutoEventWireup="true" CodeFile="bireysel-uyelik-formu.aspx.cs" Inherits="bireysel_uyelik_formu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="uyekayit">
 <h4>Création du<span class="mavi"> Compte Particulier</span></h4>
  
<div class="uyekayit-formu">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:Label ID="lblMesaj" runat="server" Text=""></asp:Label><br /><br />
	<label>Nom <asp:RequiredFieldValidator ID="rqSoyAd" runat="server" ErrorMessage="*" ControlToValidate="txtSoyad"></asp:RequiredFieldValidator>:</label>
	<asp:TextBox  runat="server" id="txtSoyad"   ></asp:TextBox><br />
	<label>Prénom <asp:RequiredFieldValidator ID="rqAd" runat="server" ErrorMessage="*" ControlToValidate="txtAd"></asp:RequiredFieldValidator>:</label>
	<asp:TextBox name="Ad"  runat="server" id="txtAd"  ></asp:TextBox><br /><br/>
	 
	<label>Adresse<asp:RequiredFieldValidator ID="rqAdres" runat="server" ErrorMessage="*" ControlToValidate="txtAdres"></asp:RequiredFieldValidator> :</label>
	<asp:TextBox name="Adres"  runat="server" id="txtAdres" placeholder="numéro"  ></asp:TextBox>
       <asp:TextBox placeholder="cadde / boulevard / sokak" runat="server" ID="txtAdres2"   ></asp:TextBox><br />
	<div class="adrestekli"><asp:TextBox placeholder="n° Appartement" runat="server" ID="txtAdres3"   ></asp:TextBox></div><br />
	<asp:UpdatePanel ID="UpdatePanel1" runat="server">
       <ContentTemplate>
	<label>Pays :</label>
    <asp:DropDownList ID="drpUlke" Cssclass="drop" runat="server" >
        <asp:ListItem Selected="True"  Value="0">sélectionner</asp:ListItem>
    </asp:DropDownList>
	
     </ContentTemplate>
    </asp:UpdatePanel>
	<label>Ville :</label>
	  <asp:TextBox    runat="server" id="txtSehirAd"  ></asp:TextBox><br />
	  
	<label>Code postal <asp:RequiredFieldValidator ID="rqlPostaKodu" runat="server" ErrorMessage="*" ControlToValidate="txtPostaKodu"></asp:RequiredFieldValidator>:</label>
	<asp:TextBox   runat="server" id="txtPostaKodu"  ></asp:TextBox><br />
	

     <label>Telephone
        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtTelefonNo"
                        ErrorMessage="*" Style="font-weight: 700; font-size: x-small; font-family: Arial;
                        color: #000000"></asp:RequiredFieldValidator> 
        :</label>
	<asp:TextBox    runat="server" id="txtTelefonNo"  ></asp:TextBox><br />
	<label>E-mail<asp:RequiredFieldValidator ID="rqlEmail" runat="server" ErrorMessage="*" ControlToValidate="txtEmail"></asp:RequiredFieldValidator> :</label>
	<asp:TextBox    runat="server" id="txtEmail"  ></asp:TextBox><br />
	<label>E-mail confirmation <asp:RequiredFieldValidator ID="rqlEmailOnay" runat="server" ErrorMessage="*" ControlToValidate="txtEmailOnay"></asp:RequiredFieldValidator>:</label>
	<asp:TextBox     runat="server" id="txtEmailOnay"  ></asp:TextBox><br /><br/>
    <asp:CompareValidator ID="cmvEmail" runat="server" ErrorMessage="Email Adresleri Eşleşmiyor" ControlToCompare="txtEmail" ControlToValidate="txtEmailOnay"></asp:CompareValidator><br />
	<label>Mot de passe<asp:RequiredFieldValidator ID="rqlSifre" runat="server" ErrorMessage="*" ControlToValidate="txtSifre"></asp:RequiredFieldValidator>  :</label>
	 <asp:TextBox type="text"    TextMode="Password"  runat="server" id="txtSifre"  ></asp:TextBox><br />
	<label>Confirmer le mot de passe <asp:RequiredFieldValidator ID="rqlSifreOnay" runat="server" ErrorMessage="*" ControlToValidate="txtSifreOnay"></asp:RequiredFieldValidator>:</label>
 <asp:TextBox type="text"    TextMode="Password"  runat="server" id="txtSifreOnay"  ></asp:TextBox><br />
    <asp:CompareValidator ID="cmvSifre" runat="server" ErrorMessage="Şifreler Eşleşmiyor" ControlToCompare="txtSifre" ControlToValidate="txtSifreOnay"></asp:CompareValidator>
    <asp:LinkButton ID="lnkOnayla" class="uyekayit-onayla" OnClick="lnkOnayla_Click" runat="server">Valider</asp:LinkButton>
    
    <br />
	
</div>	
	
</div>	

</asp:Content>

