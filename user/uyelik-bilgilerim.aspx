<%@ Page Title="" Language="C#" MasterPageFile="~/user/User.master" AutoEventWireup="true" CodeFile="uyelik-bilgilerim.aspx.cs" Inherits="user_uyelik_bilgilerim" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="sayfabaslik"><h2>  Modifier le mot de passe</h2></div>
	
	 

    <div class="uyelikbilgilerim">
        <div class="uyekayit-formu-bilgilerim">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:Label ID="lblMesaj" runat="server" Text=""></asp:Label><br /><br />
	<label>soyisim :</label>
	<asp:TextBox  runat="server" id="txtSoyad"   ></asp:TextBox><br />
	<label>isim :</label>
	<asp:TextBox name="Ad"  runat="server" id="txtAd"  ></asp:TextBox><br /><br/>
	 
	<label>Adresse :</label>
	<asp:TextBox name="Adres"  runat="server" id="txtAdres"    Rows="3" Height="130px" Width="210px" ></asp:TextBox><br/>
	<label>Posta Kodu :</label>
	<asp:TextBox   runat="server" id="txtPostaKodu"  ></asp:TextBox><br />
   


	<label>Telephone
        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtTelefonNo"
                        ErrorMessage="*" Style="font-weight: 700; font-size: x-small; font-family: Arial;
                        color: #000000"></asp:RequiredFieldValidator> 
        :</label>
	<asp:TextBox    runat="server" id="txtTelefonNo"  ></asp:TextBox><br />
	<label>Email :</label>
	<asp:TextBox    runat="server" id="txtEmail"  ></asp:TextBox><br />
    
	<label>Sifre :</label>
	 <asp:TextBox type="text"       runat="server" id="txtSifre"  ></asp:TextBox><br />
    <asp:LinkButton ID="lnkOnayla" class="uyekayit-onayla"  OnClick="lnkOnayla_Click"  runat="server">Onayla</asp:LinkButton>
            <asp:Label ID="lbMesaj" runat="server" Text=""></asp:Label>
    <br />
	
</div>	

    </div>
</asp:Content>

