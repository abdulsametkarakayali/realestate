<%@ Page Title="" Language="C#" MasterPageFile="~/Tema.master" AutoEventWireup="true" CodeFile="SifreSifirlama.aspx.cs" Inherits="SifreSifirlama" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="sifresifirlamaekrani">
            <label>Email</label> <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox> 
			<asp:RequiredFieldValidator ID="rqvEmail" ControlToValidate="txtEmail" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator></td>
       
                <asp:Button ID="btnGonder" class="SifreSifirlamabtn" OnClick="btnGonder_Click" runat="server" Text="Gonder" /> 
		   <br/> <br/>
                <asp:Label ID="lblbilgi" runat="server" Text="Email Adresinizi Yazınız"></asp:Label> </td>
    </div>    
</asp:Content>

