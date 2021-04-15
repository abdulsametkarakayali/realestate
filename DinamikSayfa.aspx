<%@ Page Title="" Language="C#" MasterPageFile="~/Tema.master" AutoEventWireup="true" CodeFile="DinamikSayfa.aspx.cs" Inherits="DinamikSayfa" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>Adhibe Property | IMMOBILIER - Annonces immobilières | | De Particulier à Particulier</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
            <h4> <asp:Label ID="lblBaslik" runat="server" Text=""></asp:Label></h4>
            <div class="icerikalani">
                <asp:Literal ID="ltlIcerik" runat="server"></asp:Literal>
            </div>
</asp:Content>

