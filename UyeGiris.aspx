<%@ Page Title="" Language="C#" MasterPageFile="~/Tema.master" AutoEventWireup="true" CodeFile="UyeGiris.aspx.cs" Inherits="UyeGiris" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Panel ID="pnlGiris" DefaultButton="Onayla" runat="server">
     <div class="girisalani">
         <asp:Label ID="lblMesaj" runat="server" Text=""></asp:Label>
   <h3>Se connecter à votre Compte</h3>

  <label>E-mail :</label>
      
	 <asp:TextBox ID="txtEmail"  runat="server"  > </asp:TextBox><br />
	<label>Mot de passe :</label>
	 <asp:TextBox ID="txtSifre" runat="server"       TextMode="Password"> </asp:TextBox><br/>
	 
         <asp:LinkButton CSSclass="onayla" ID="Onayla"   runat="server" OnClick="Onayla_Click">Valider</asp:LinkButton>
         <br />
  <div class="sifreunuttum"><a href="/sifresifirlama.aspx" title="#" >> Mot de passe oublié ?</a></div>
  <div class="sifreunuttum "><a href="/bireysel-uyelik-formu.aspx" title="#" class="mavi" >> Vous n'avez pas encorede mot de passe?</a></div>
   </div>
</asp:Panel>
</asp:Content>

