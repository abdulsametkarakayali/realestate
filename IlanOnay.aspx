<%@ Page Title="" Language="C#" MasterPageFile="~/Tema.master" AutoEventWireup="true" CodeFile="IlanOnay.aspx.cs" Inherits="IlanOnay" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="ilanonayalani">
   <div class="onayresim"> <img src="Tema/img/onay.png" /></div>
<p>Şimdi Ne Yapmak İstersiniz? </p>

<ul class="onaylinkleri">
<li><a href="/ilanver.aspx">Diffuser une autre annonce </a></li>
<li><a href="/detay.aspx?id=<asp:Literal ID="ltlId" runat="server"></asp:Literal>">Voir mon annonce </a></li>
<li><a href="/default.aspx">Retour â l'accueil</a></li>
</ul>
</div>
</asp:Content>

