<%@ Page Title="" Language="C#" MasterPageFile="~/Tema.master" AutoEventWireup="true" CodeFile="IlanVer3.aspx.cs" Inherits="IlanVer3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<!---Menu Alani  Sonu-->	
<div class="ortaalan clr">
<h3>STEP 3 / 3</h3>
	<div class="odemeguvenligi clr">
	<h4>Ödeme Güvenliği</h4>
	<span>Paiement sécurisé par le système CyberMut de la Caisse d’Epargne</span>
	
	<ul class="karttipi">
	<li>Carte bleu</li>
	<li>VISA</li>
	<li>Master Card</li>
	</ul>
	
	</div>
	
<div class="kredikartiodeme">
	<label>Numéro de carte*</label>
	<asp:TextBox ID="txtKartNumarasi" MaxLength="16"    runat="server"></asp:TextBox><br />
	<label>Date d’expiration*</label>
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
	<label>Cryptogramme* :</label>
	<asp:TextBox ID="txtCcv"  MaxLength="3"   runat="server"></asp:TextBox><br />
    <label>Karttip :</label>
    <asp:DropDownList ID="drpKartTip" runat="server">
        <asp:ListItem Value="1" Text="Master"></asp:ListItem>
        <asp:ListItem Value="2" Text="Visa"></asp:ListItem>
        <asp:ListItem Value="3" Text="Card Blue"></asp:ListItem>
    </asp:DropDownList>

	
	
	</div>
	
	<div class="onayyazisi">
	<p>
<input type="checkbox" name="vehicle" value="Bike">	Je déclare avoir pris connaissance des kullanim kosullari et des conditions d’accés aux données
personnelles. Je demande l’exécution immédiate du contrat avant l’expiration du délai de rétractation et
renonce au bénéfice de celui-ci.
	
	</p>
	
	</div>
		<asp:Panel ID="pnlKurumsalUyeResim" Visible="false" runat="server">	
		<h2>Photos</h2>
		<div class="dosyayuklemepaneli">

			<asp:FileUpload AllowMultiple="true" ID="FileUpload1" runat="server" />
			
		</div>
		</asp:Panel>	
	
	
    <asp:LinkButton ID="lnkOnaylaveOde" CssClass="onaylaveode" OnClick="lnkOnaylaveOde_Click" runat="server">Valider</asp:LinkButton>
	
     
</div>
<!---İçerik Alani  Sonu-->

</asp:Content>

