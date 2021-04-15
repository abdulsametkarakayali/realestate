<%@ Page Title="" Language="C#" MasterPageFile="~/user/User.master" AutoEventWireup="true" CodeFile="sifre-degistir.aspx.cs" Inherits="user_sifre_degistir" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  
    <div class="sayfabaslik"><h2>Mon compte</h2></div>
    <div class="sifrealani">
          
   <label>Eski Şifre</label>
 <asp:TextBox ID="txtEskiSifre"  runat="server" ForeColor="Black" TextMode="Password"></asp:TextBox><br />
    <label>Yeni Şifre</label>
 <asp:TextBox ID="txtYeniSifre"  TextMode="Password"  ForeColor="Black" runat="server"></asp:TextBox><br />
    <label>Yeni Şifre Tekrar</label>
 <asp:TextBox ID="txtYeniSifreTekrar" TextMode="Password" ForeColor="Black"  runat="server"></asp:TextBox><br />
        <asp:Label ID="lblMesaj" runat="server" Text=""></asp:Label>
        <asp:CompareValidator ID="cmpValidator"  ControlToCompare="txtYeniSifre" ControlToValidate="txtYeniSifreTekrar" runat="server" ErrorMessage="Şifreler Eşleşmiyor"></asp:CompareValidator>
        <asp:Button ID="SifreDegistir" runat="server" class="sifredegistirbtn" OnClick="SifreDegistir_Click"  Text="Değiştir" />
        </div>
</asp:Content>

