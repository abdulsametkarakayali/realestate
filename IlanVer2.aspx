 <%@ Page Title="" Language="C#" MasterPageFile="~/Tema.master" AutoEventWireup="true" CodeFile="IlanVer2.aspx.cs" Inherits="IlanVer2" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<%@ Register
    Assembly="AjaxControlToolkit"
    Namespace="AjaxControlToolkit"
    TagPrefix="ajaxToolkit"%> 
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

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
 <div class="ilanver2">
     <asp:HiddenField ID="hdndolaplar" runat="server" />
        <label>STEP 2 /<asp:Label ID="lblStep" runat="server" Text=""></asp:Label></label>
<div class="konutdetaylari clr">
        <h3>Descritption des pièces à vivre</h3>
<div class="tabloilanver">
<table class="ilanver2" style="100%">
	<tr class="ilktablo">
		<td width="25%">Pièces</td>
		<td width="5%">m2</td>
		<td width="14%">Niveau</td>
		<td width="12%">Orientation</td>
		<td width="12%">Sol</td>
		<td width="12%">Fenêtre </td>
		<td width="12%">Vitrage </td>
		<td width="180">Volets</td>
	</tr>
	<tr>
		<td width="25%">Entrée</td>
		<td width="5%"><asp:TextBox ID="txtm2Giris" MaxLength="3" Width="50" runat="server"></asp:TextBox></td>
		 <asp:FilteredTextBoxExtender ID="FilterGiris"  TargetControlID="txtm2Giris" FilterType="Numbers"
        Enabled="True"  
         runat="server">
		</asp:FilteredTextBoxExtender>
		<td width="14%"> <asp:DropDownList ID="drpZeminGiris"  MaxLength="3" Width="120" runat="server"><asp:ListItem Value="RDC">RDC </asp:ListItem><asp:ListItem Value="1er étage">1er étage </asp:ListItem> <asp:ListItem Value="2ème étage"> 2 ème étage </asp:ListItem></asp:DropDownList></td>
		<td width="12%"><asp:DropDownList ID="drpYonGiris" Width="120" runat="server"><asp:ListItem Value="Nord"> Nord </asp:ListItem><asp:ListItem Value="Sud">Sud</asp:ListItem> <asp:ListItem Value="Est">Est</asp:ListItem> <asp:ListItem Value="Ouest">Ouest</asp:ListItem> <asp:ListItem Value="Nord-Est"> Nord-Est</asp:ListItem> <asp:ListItem Value="Nord-Ouest">Nord-Ouest </asp:ListItem><asp:ListItem Value="Sud-Est">Sud-Est </asp:ListItem><asp:ListItem Value="Sud-Ouest">Sud-Ouest </asp:ListItem></asp:DropDownList></td>
		<td width="12%"><asp:DropDownList ID="drpYerDosemeGiris" Width="120" runat="server"><asp:ListItem Value="Carrelage">Carrelage</asp:ListItem><asp:ListItem Value="Lino">Lino</asp:ListItem> <asp:ListItem Value="Parquet">Parquet</asp:ListItem><asp:ListItem Value="Moquette">Moquette</asp:ListItem></asp:DropDownList></td>
		<td width="12%"><asp:DropDownList ID="drpCercevelerGiris" Width="130" runat="server"><asp:ListItem Value="PCV">PCV</asp:ListItem><asp:ListItem Value="Aluminium">Aluminium  </asp:ListItem> <asp:ListItem Value="Bois"> Bois</asp:ListItem></asp:DropDownList></td>
		<td width="12%"><asp:DropDownList ID="drpCamlarGiris" Width="130" runat="server"><asp:ListItem Value="Double vitrage">Double vitrage</asp:ListItem><asp:ListItem Value="Simple vitrage">Simple  vitrage  </asp:ListItem></asp:DropDownList></td>
		<td width="180"><asp:DropDownList ID="drpPanjularGiris" Width="130" runat="server"><asp:ListItem Value="Roulant électrique">Roulant électrique</asp:ListItem><asp:ListItem Value="Roulant manuel">Roulant manuel</asp:ListItem> <asp:ListItem Value="Persienne">Persienne</asp:ListItem></asp:DropDownList></td>
	</tr>
	<tr>
		<td>Cuisine</td>
        <td width="5%"><asp:TextBox ID="txtm2Mutfak"  MaxLength="3" Width="50" runat="server"></asp:TextBox></td>
		<asp:FilteredTextBoxExtender ID="FilterMutfak"  TargetControlID="txtm2Mutfak" FilterType="Numbers"
        Enabled="True"  
         runat="server">
		</asp:FilteredTextBoxExtender>
		<td width="14%"> <asp:DropDownList ID="drpZeminMutfak" Width="130" runat="server"><asp:ListItem Value="RDC">RDC </asp:ListItem><asp:ListItem Value="1er étage">1er étage </asp:ListItem> <asp:ListItem Value="2ème étage"> 2 ème étage </asp:ListItem></asp:DropDownList></td>
		<td width="12%"><asp:DropDownList ID="drpYonMutfak" Width="130" runat="server"><asp:ListItem Value="Nord"> Nord </asp:ListItem><asp:ListItem Value="Sud">Sud</asp:ListItem> <asp:ListItem Value="Est">Est</asp:ListItem> <asp:ListItem Value="Ouest">Ouest</asp:ListItem> <asp:ListItem Value="Nord-Est"> Nord-Est</asp:ListItem> <asp:ListItem Value="Nord-Ouest">Nord-Ouest </asp:ListItem><asp:ListItem Value="Sud-Est">Sud-Est </asp:ListItem><asp:ListItem Value="Sud-Ouest">Sud-Ouest </asp:ListItem></asp:DropDownList></td>
		<td width="12%"><asp:DropDownList ID="drpYerDosemeMutfak" Width="130" runat="server"><asp:ListItem Value="Carrelage">Carrelage</asp:ListItem><asp:ListItem Value="Lino">Lino</asp:ListItem> <asp:ListItem Value="Parquet">Parquet</asp:ListItem><asp:ListItem Value="Moquette">Moquette</asp:ListItem></asp:DropDownList></td>
		<td width="14%"><asp:DropDownList ID="drpCercevelerMutfak" Width="130" runat="server"><asp:ListItem Value="PCV">PCV</asp:ListItem><asp:ListItem Value="Aluminium">Aluminium  </asp:ListItem> <asp:ListItem Value="Bois"> Bois</asp:ListItem></asp:DropDownList></td>
		<td width="14%"><asp:DropDownList ID="drpCamlarMutfak" Width="130" runat="server"><asp:ListItem Value="Double vitrage">Double vitrage</asp:ListItem><asp:ListItem Value="Simple vitrage">Simple  vitrage  </asp:ListItem></asp:DropDownList></td>
		<td width="180"><asp:DropDownList ID="drpPanjularMutfak" Width="130" runat="server"><asp:ListItem Value="Roulant électrique">Roulant électrique</asp:ListItem><asp:ListItem Value="Roulant manuel">Roulant manuel</asp:ListItem> <asp:ListItem Value="Persienne">Persienne</asp:ListItem></asp:DropDownList></td>
	</tr>
	<tr>
		<td>Salon</td>
		<td width="5%"><asp:TextBox ID="txtm2Salon"  MaxLength="3"  Width="50" runat="server"></asp:TextBox></td>
		<asp:FilteredTextBoxExtender ID="FilterSalon"  TargetControlID="txtm2Salon" FilterType="Numbers"
        Enabled="True"  
         runat="server">
		</asp:FilteredTextBoxExtender>
		<td width="14%"> <asp:DropDownList ID="drpZeminSalon" Width="130" runat="server"><asp:ListItem Value="RDC">RDC </asp:ListItem><asp:ListItem Value="1er étage">1er étage </asp:ListItem> <asp:ListItem Value="2ème étage"> 2 ème étage </asp:ListItem></asp:DropDownList></td>
		<td width="12%"><asp:DropDownList ID="drpYonSalon" Width="130" runat="server"><asp:ListItem Value="Nord"> Nord </asp:ListItem><asp:ListItem Value="Sud">Sud</asp:ListItem> <asp:ListItem Value="Est">Est</asp:ListItem> <asp:ListItem Value="Ouest">Ouest</asp:ListItem> <asp:ListItem Value="Nord-Est"> Nord-Est</asp:ListItem> <asp:ListItem Value="Nord-Ouest">Nord-Ouest </asp:ListItem><asp:ListItem Value="Sud-Est">Sud-Est </asp:ListItem><asp:ListItem Value="Sud-Ouest">Sud-Ouest </asp:ListItem></asp:DropDownList></td>
		<td width="12%"><asp:DropDownList ID="drpYerDosemeSalon" Width="130" runat="server"><asp:ListItem Value="Carrelage">Carrelage</asp:ListItem><asp:ListItem Value="Lino">Lino</asp:ListItem> <asp:ListItem Value="Parquet">Parquet</asp:ListItem><asp:ListItem Value="Moquette">Moquette</asp:ListItem></asp:DropDownList></td>
		<td width="14%"><asp:DropDownList ID="drpCercevelerSalon" Width="130" runat="server"><asp:ListItem Value="PCV">PCV</asp:ListItem><asp:ListItem Value="Aluminium">Aluminium  </asp:ListItem> <asp:ListItem Value="Bois"> Bois</asp:ListItem></asp:DropDownList></td>
		<td width="14%"><asp:DropDownList ID="drpCamlarSalon" Width="130" runat="server"><asp:ListItem Value="Double vitrage">Double vitrage</asp:ListItem><asp:ListItem Value="Simple vitrage">Simple  vitrage  </asp:ListItem></asp:DropDownList></td>
		<td width="180"><asp:DropDownList ID="drpPanjularSalon" Width="130" runat="server"><asp:ListItem Value="Roulant électrique">Roulant électrique</asp:ListItem><asp:ListItem Value="Roulant manuel">Roulant manuel</asp:ListItem> <asp:ListItem Value="Persienne">Persienne</asp:ListItem></asp:DropDownList></td>
	</tr>
	<tr>
		<td>Suite parentale</td>
		<td width="5%"><asp:TextBox ID="txtm2Ebeveyn"  MaxLength="3" Width="50" runat="server"></asp:TextBox></td>
		<asp:FilteredTextBoxExtender ID="FilterEbeveyn"  TargetControlID="txtm2Ebeveyn" FilterType="Numbers"
        Enabled="True"  
         runat="server">
		</asp:FilteredTextBoxExtender>
		<td width="14%"> <asp:DropDownList ID="drpZeminEbeveyn" Width="130" runat="server"><asp:ListItem Value="RDC">RDC </asp:ListItem><asp:ListItem Value="1er étage">1er étage </asp:ListItem> <asp:ListItem Value="2ème étage"> 2 ème étage </asp:ListItem></asp:DropDownList></td>
		<td width="12%"><asp:DropDownList ID="drpYonEbeveyn" Width="130" runat="server"><asp:ListItem Value="Nord"> Nord </asp:ListItem><asp:ListItem Value="Sud">Sud</asp:ListItem> <asp:ListItem Value="Est">Est</asp:ListItem> <asp:ListItem Value="Ouest">Ouest</asp:ListItem> <asp:ListItem Value="Nord-Est"> Nord-Est</asp:ListItem> <asp:ListItem Value="Nord-Ouest">Nord-Ouest </asp:ListItem><asp:ListItem Value="Sud-Est">Sud-Est </asp:ListItem><asp:ListItem Value="Sud-Ouest">Sud-Ouest </asp:ListItem></asp:DropDownList></td>
		<td width="12%"><asp:DropDownList ID="drpYerDosemeEbeveyn" Width="130" runat="server"><asp:ListItem Value="Carrelage">Carrelage</asp:ListItem><asp:ListItem Value="Lino">Lino</asp:ListItem> <asp:ListItem Value="Parquet">Parquet</asp:ListItem><asp:ListItem Value="Moquette">Moquette</asp:ListItem></asp:DropDownList></td>
		<td width="14%"><asp:DropDownList ID="drpCercevelerEbeveyn" Width="130" runat="server"><asp:ListItem Value="PCV">PCV</asp:ListItem><asp:ListItem Value="Aluminium">Aluminium  </asp:ListItem> <asp:ListItem Value="Bois"> Bois</asp:ListItem></asp:DropDownList></td>
		<td width="14%"><asp:DropDownList ID="drpCamlarEbeveyn" Width="130" runat="server"><asp:ListItem Value="Double vitrage">Double vitrage</asp:ListItem><asp:ListItem Value="Simple vitrage">Simple  vitrage  </asp:ListItem></asp:DropDownList></td>
		<td width="180"><asp:DropDownList ID="drpPanjularEbeveyn" Width="130" runat="server"><asp:ListItem Value="Roulant électrique">Roulant électrique</asp:ListItem><asp:ListItem Value="Roulant manuel">Roulant manuel</asp:ListItem> <asp:ListItem Value="Persienne">Persienne</asp:ListItem></asp:DropDownList></td>
	</tr>
	
	<tr>
		<td>Chambre 1</td>
        <td width="5%"><asp:TextBox ID="txtm2YatakOdasi1"  MaxLength="3" Width="50" runat="server"></asp:TextBox></td>
		<asp:FilteredTextBoxExtender ID="FilterYatakOdasi1"  TargetControlID="txtm2YatakOdasi1" FilterType="Numbers"
        Enabled="True"  
         runat="server">
		</asp:FilteredTextBoxExtender>
		<td width="14%"> <asp:DropDownList ID="drpZeminYatakOdasi1" Width="130" runat="server"><asp:ListItem Value="RDC">RDC </asp:ListItem><asp:ListItem Value="1er étage">1er étage </asp:ListItem> <asp:ListItem Value="2ème étage"> 2 ème étage </asp:ListItem></asp:DropDownList></td>
		<td width="12%"><asp:DropDownList ID="drpYonYatakOdasi1" Width="130" runat="server"><asp:ListItem Value="Nord"> Nord </asp:ListItem><asp:ListItem Value="Sud">Sud</asp:ListItem> <asp:ListItem Value="Est">Est</asp:ListItem> <asp:ListItem Value="Ouest">Ouest</asp:ListItem> <asp:ListItem Value="Nord-Est"> Nord-Est</asp:ListItem> <asp:ListItem Value="Nord-Ouest">Nord-Ouest </asp:ListItem><asp:ListItem Value="Sud-Est">Sud-Est </asp:ListItem><asp:ListItem Value="Sud-Ouest">Sud-Ouest </asp:ListItem></asp:DropDownList></td>
		<td width="12%"><asp:DropDownList ID="drpYerDosemeYatakOdasi1" Width="130" runat="server"><asp:ListItem Value="Carrelage">Carrelage</asp:ListItem><asp:ListItem Value="Lino">Lino</asp:ListItem> <asp:ListItem Value="Parquet">Parquet</asp:ListItem><asp:ListItem Value="Moquette">Moquette</asp:ListItem></asp:DropDownList></td>
		<td width="14%"><asp:DropDownList ID="drpCercevelerYatakOdasi1" Width="130" runat="server"><asp:ListItem Value="PCV">PCV</asp:ListItem><asp:ListItem Value="Aluminium">Aluminium  </asp:ListItem> <asp:ListItem Value="Bois"> Bois</asp:ListItem></asp:DropDownList></td>
		<td width="14%"><asp:DropDownList ID="drpCamlarYatakOdasi1" Width="130" runat="server"><asp:ListItem Value="Double vitrage">Double vitrage</asp:ListItem><asp:ListItem Value="Simple vitrage">Simple  vitrage  </asp:ListItem></asp:DropDownList></td>
		<td width="180"><asp:DropDownList ID="drpPanjularYatakOdasi1" Width="130" runat="server"><asp:ListItem Value="Roulant électrique">Roulant électrique</asp:ListItem><asp:ListItem Value="Roulant manuel">Roulant manuel</asp:ListItem> <asp:ListItem Value="Persienne">Persienne</asp:ListItem></asp:DropDownList></td>
	</tr>
	<tr>
		<td>Chambre 2</td>
        <td width="5%"><asp:TextBox ID="txtm2YatakOdasi2"  MaxLength="3" Width="50" runat="server"></asp:TextBox></td>
		<asp:FilteredTextBoxExtender ID="FilterYatakOdasi2"  TargetControlID="txtm2YatakOdasi2" FilterType="Numbers"
        Enabled="True"  
         runat="server">
		</asp:FilteredTextBoxExtender>
		<td width="14%"> <asp:DropDownList ID="drpZeminYatakOdasi2" Width="130" runat="server"><asp:ListItem Value="RDC">RDC </asp:ListItem><asp:ListItem Value="1er étage">1er étage </asp:ListItem> <asp:ListItem Value="2ème étage"> 2 ème étage </asp:ListItem></asp:DropDownList></td>
		<td width="12%"><asp:DropDownList ID="drpYonYatakOdasi2" Width="130" runat="server"><asp:ListItem Value="Nord"> Nord </asp:ListItem><asp:ListItem Value="Sud">Sud</asp:ListItem> <asp:ListItem Value="Est">Est</asp:ListItem> <asp:ListItem Value="Ouest">Ouest</asp:ListItem> <asp:ListItem Value="Nord-Est"> Nord-Est</asp:ListItem> <asp:ListItem Value="Nord-Ouest">Nord-Ouest </asp:ListItem><asp:ListItem Value="Sud-Est">Sud-Est </asp:ListItem><asp:ListItem Value="Sud-Ouest">Sud-Ouest </asp:ListItem></asp:DropDownList></td>
		<td width="12%"><asp:DropDownList ID="drpYerDosemeYatakOdasi2" Width="130" runat="server"><asp:ListItem Value="Carrelage">Carrelage</asp:ListItem><asp:ListItem Value="Lino">Lino</asp:ListItem> <asp:ListItem Value="Parquet">Parquet</asp:ListItem><asp:ListItem Value="Moquette">Moquette</asp:ListItem></asp:DropDownList></td>
		<td width="14%"><asp:DropDownList ID="drpCercevelerYatakOdasi2" Width="130" runat="server"><asp:ListItem Value="PCV">PCV</asp:ListItem><asp:ListItem Value="Aluminium">Aluminium  </asp:ListItem> <asp:ListItem Value="Bois"> Bois</asp:ListItem></asp:DropDownList></td>
		<td width="14%"><asp:DropDownList ID="drpCamlarYatakOdasi2" Width="130" runat="server"><asp:ListItem Value="Double vitrage">Double vitrage</asp:ListItem><asp:ListItem Value="Simple vitrage">Simple  vitrage  </asp:ListItem></asp:DropDownList></td>
		<td width="180"><asp:DropDownList ID="drpPanjularYatakOdasi2" Width="130" runat="server"><asp:ListItem Value="Roulant électrique">Roulant électrique</asp:ListItem><asp:ListItem Value="Roulant manuel">Roulant manuel</asp:ListItem> <asp:ListItem Value="Persienne">Persienne</asp:ListItem></asp:DropDownList></td>
	</tr>
	<tr>
		<td>Chambre 3</td>
        <td width="5%"><asp:TextBox ID="txtm2YatakOdasi3"  MaxLength="3" Width="50" runat="server"></asp:TextBox></td>
		<asp:FilteredTextBoxExtender ID="FilterYatakOdasi3"  TargetControlID="txtm2YatakOdasi3" FilterType="Numbers"
        Enabled="True"  
         runat="server">
		</asp:FilteredTextBoxExtender>
		<td width="14%"> <asp:DropDownList ID="drpZeminYatakOdasi3" Width="130" runat="server"><asp:ListItem Value="RDC">RDC </asp:ListItem><asp:ListItem Value="1er étage">1er étage </asp:ListItem> <asp:ListItem Value="2ème étage"> 2 ème étage </asp:ListItem></asp:DropDownList></td>
		<td width="12%"><asp:DropDownList ID="drpYonYatakOdasi3" Width="130" runat="server"><asp:ListItem Value="Nord"> Nord </asp:ListItem><asp:ListItem Value="Sud">Sud</asp:ListItem> <asp:ListItem Value="Est">Est</asp:ListItem> <asp:ListItem Value="Ouest">Ouest</asp:ListItem> <asp:ListItem Value="Nord-Est"> Nord-Est</asp:ListItem> <asp:ListItem Value="Nord-Ouest">Nord-Ouest </asp:ListItem><asp:ListItem Value="Sud-Est">Sud-Est </asp:ListItem><asp:ListItem Value="Sud-Ouest">Sud-Ouest </asp:ListItem></asp:DropDownList></td>
		<td width="12%"><asp:DropDownList ID="drpYerDosemeYatakOdasi3" Width="130" runat="server"><asp:ListItem Value="Carrelage">Carrelage</asp:ListItem><asp:ListItem Value="Lino">Lino</asp:ListItem> <asp:ListItem Value="Parquet">Parquet</asp:ListItem><asp:ListItem Value="Moquette">Moquette</asp:ListItem></asp:DropDownList></td>
		<td width="14%"><asp:DropDownList ID="drpCercevelerYatakOdasi3" Width="130" runat="server"><asp:ListItem Value="PCV">PCV</asp:ListItem><asp:ListItem Value="Aluminium">Aluminium  </asp:ListItem> <asp:ListItem Value="Bois"> Bois</asp:ListItem></asp:DropDownList></td>
		<td width="14%"><asp:DropDownList ID="drpCamlarYatakOdasi3" Width="130" runat="server"><asp:ListItem Value="Double vitrage">Double vitrage</asp:ListItem><asp:ListItem Value="Simple vitrage">Simple  vitrage  </asp:ListItem></asp:DropDownList></td>
		<td width="180"><asp:DropDownList ID="drpPanjularYatakOdasi3" Width="130" runat="server"><asp:ListItem Value="Roulant électrique">Roulant électrique</asp:ListItem><asp:ListItem Value="Roulant manuel">Roulant manuel</asp:ListItem> <asp:ListItem Value="Persienne">Persienne</asp:ListItem></asp:DropDownList></td>
	</tr>
	<tr>
		<td>Chambre 4</td>
        <td width="5%"><asp:TextBox ID="txtm2YatakOdasi4" MaxLength="3"  Width="50" runat="server"></asp:TextBox></td>
		<asp:FilteredTextBoxExtender ID="FilterYatakOdasi4"  TargetControlID="txtm2YatakOdasi4" FilterType="Numbers"
        Enabled="True"  
         runat="server">
		</asp:FilteredTextBoxExtender>
		<td width="14%"> <asp:DropDownList ID="drpZeminYatakOdasi4" Width="130" runat="server"><asp:ListItem Value="RDC">RDC </asp:ListItem><asp:ListItem Value="1er étage">1er étage </asp:ListItem> <asp:ListItem Value="2ème étage"> 2 ème étage </asp:ListItem></asp:DropDownList></td>
		<td width="12%"><asp:DropDownList ID="drpYonYatakOdasi4" Width="130" runat="server"><asp:ListItem Value="Nord"> Nord </asp:ListItem><asp:ListItem Value="Sud">Sud</asp:ListItem> <asp:ListItem Value="Est">Est</asp:ListItem> <asp:ListItem Value="Ouest">Ouest</asp:ListItem> <asp:ListItem Value="Nord-Est"> Nord-Est</asp:ListItem> <asp:ListItem Value="Nord-Ouest">Nord-Ouest </asp:ListItem><asp:ListItem Value="Sud-Est">Sud-Est </asp:ListItem><asp:ListItem Value="Sud-Ouest">Sud-Ouest </asp:ListItem></asp:DropDownList></td>
		<td width="12%"><asp:DropDownList ID="drpYerDosemeYatakOdasi4" Width="130" runat="server"><asp:ListItem Value="Carrelage">Carrelage</asp:ListItem><asp:ListItem Value="Lino">Lino</asp:ListItem> <asp:ListItem Value="Parquet">Parquet</asp:ListItem><asp:ListItem Value="Moquette">Moquette</asp:ListItem></asp:DropDownList></td>
		<td width="14%"><asp:DropDownList ID="drpCercevelerYatakOdasi4" Width="130" runat="server"><asp:ListItem Value="PCV">PCV</asp:ListItem><asp:ListItem Value="Aluminium">Aluminium  </asp:ListItem> <asp:ListItem Value="Bois"> Bois</asp:ListItem></asp:DropDownList></td>
		<td width="14%"><asp:DropDownList ID="drpCamlarYatakOdasi4" Width="130" runat="server"><asp:ListItem Value="Double vitrage">Double vitrage</asp:ListItem><asp:ListItem Value="Simple vitrage">Simple  vitrage  </asp:ListItem></asp:DropDownList></td>
		<td width="180"><asp:DropDownList ID="drpPanjularYatakOdasi4" Width="130" runat="server"><asp:ListItem Value="Roulant électrique">Roulant électrique</asp:ListItem><asp:ListItem Value="Roulant manuel">Roulant manuel</asp:ListItem> <asp:ListItem Value="Persienne">Persienne</asp:ListItem></asp:DropDownList></td>
	</tr>
	<tr>
		<td>Chambre 5</td>
        <td width="5%"><asp:TextBox ID="txtm2YatakOdasi5"  MaxLength="3" Width="50" runat="server"></asp:TextBox></td>
		<asp:FilteredTextBoxExtender ID="FilterYatakOdasi5"  TargetControlID="txtm2YatakOdasi5" FilterType="Numbers"
        Enabled="True"  
         runat="server">
		</asp:FilteredTextBoxExtender>
		<td width="14%"> <asp:DropDownList ID="drpZeminYatakOdasi5" Width="130" runat="server"><asp:ListItem Value="RDC">RDC </asp:ListItem><asp:ListItem Value="1er étage">1er étage </asp:ListItem> <asp:ListItem Value="2ème étage"> 2 ème étage </asp:ListItem></asp:DropDownList></td>
		<td width="12%"><asp:DropDownList ID="drpYonYatakOdasi5" Width="130" runat="server"><asp:ListItem Value="Nord"> Nord </asp:ListItem><asp:ListItem Value="Sud">Sud</asp:ListItem> <asp:ListItem Value="Est">Est</asp:ListItem> <asp:ListItem Value="Ouest">Ouest</asp:ListItem> <asp:ListItem Value="Nord-Est"> Nord-Est</asp:ListItem> <asp:ListItem Value="Nord-Ouest">Nord-Ouest </asp:ListItem><asp:ListItem Value="Sud-Est">Sud-Est </asp:ListItem><asp:ListItem Value="Sud-Ouest">Sud-Ouest </asp:ListItem></asp:DropDownList></td>
		<td width="12%"><asp:DropDownList ID="drpYerDosemeYatakOdasi5" Width="130" runat="server"><asp:ListItem Value="Carrelage">Carrelage</asp:ListItem><asp:ListItem Value="Lino">Lino</asp:ListItem> <asp:ListItem Value="Parquet">Parquet</asp:ListItem><asp:ListItem Value="Moquette">Moquette</asp:ListItem></asp:DropDownList></td>
		<td width="14%"><asp:DropDownList ID="drpCercevelerYatakOdasi5" Width="130" runat="server"><asp:ListItem Value="PCV">PCV</asp:ListItem><asp:ListItem Value="Aluminium">Aluminium  </asp:ListItem> <asp:ListItem Value="Bois"> Bois</asp:ListItem></asp:DropDownList></td>
		<td width="14%"><asp:DropDownList ID="drpCamlarYatakOdasi5" Width="130" runat="server"><asp:ListItem Value="Double vitrage">Double vitrage</asp:ListItem><asp:ListItem Value="Simple vitrage">Simple  vitrage  </asp:ListItem></asp:DropDownList></td>
		<td width="180"><asp:DropDownList ID="drpPanjularYatakOdasi5" Width="130" runat="server"><asp:ListItem Value="Roulant électrique">Roulant électrique</asp:ListItem><asp:ListItem Value="Roulant manuel">Roulant manuel</asp:ListItem> <asp:ListItem Value="Persienne">Persienne</asp:ListItem></asp:DropDownList></td>
	</tr>
	<tr>
		<td>Chambre 6</td>
        <td width="5%"><asp:TextBox ID="txtm2YatakOdasi6"  MaxLength="3" Width="50" runat="server"></asp:TextBox></td>
		<asp:FilteredTextBoxExtender ID="FilterYatakOdasi6"  TargetControlID="txtm2YatakOdasi6" FilterType="Numbers"
        Enabled="True"  
         runat="server">
		</asp:FilteredTextBoxExtender>
		<td width="14%"> <asp:DropDownList ID="drpZeminYatakOdasi6" Width="130" runat="server"><asp:ListItem Value="RDC">RDC </asp:ListItem><asp:ListItem Value="1er étage">1er étage </asp:ListItem> <asp:ListItem Value="2ème étage"> 2 ème étage </asp:ListItem></asp:DropDownList></td>
		<td width="12%"><asp:DropDownList ID="drpYonYatakOdasi6" Width="130" runat="server"><asp:ListItem Value="Nord"> Nord </asp:ListItem><asp:ListItem Value="Sud">Sud</asp:ListItem> <asp:ListItem Value="Est">Est</asp:ListItem> <asp:ListItem Value="Ouest">Ouest</asp:ListItem> <asp:ListItem Value="Nord-Est"> Nord-Est</asp:ListItem> <asp:ListItem Value="Nord-Ouest">Nord-Ouest </asp:ListItem><asp:ListItem Value="Sud-Est">Sud-Est </asp:ListItem><asp:ListItem Value="Sud-Ouest">Sud-Ouest </asp:ListItem></asp:DropDownList></td>
		<td width="12%"><asp:DropDownList ID="drpYerDosemeYatakOdasi6" Width="130" runat="server"><asp:ListItem Value="Carrelage">Carrelage</asp:ListItem><asp:ListItem Value="Lino">Lino</asp:ListItem> <asp:ListItem Value="Parquet">Parquet</asp:ListItem><asp:ListItem Value="Moquette">Moquette</asp:ListItem></asp:DropDownList></td>
		<td width="14%"><asp:DropDownList ID="drpCercevelerYatakOdasi6" Width="130" runat="server"><asp:ListItem Value="PCV">PCV</asp:ListItem><asp:ListItem Value="Aluminium">Aluminium  </asp:ListItem> <asp:ListItem Value="Bois"> Bois</asp:ListItem></asp:DropDownList></td>
		<td width="14%"><asp:DropDownList ID="drpCamlarYatakOdasi6" Width="130" runat="server"><asp:ListItem Value="Double vitrage">Double vitrage</asp:ListItem><asp:ListItem Value="Simple vitrage">Simple  vitrage  </asp:ListItem></asp:DropDownList></td>
		<td width="180"><asp:DropDownList ID="drpPanjularYatakOdasi6" Width="130" runat="server"><asp:ListItem Value="Roulant électrique">Roulant électrique</asp:ListItem><asp:ListItem Value="Roulant manuel">Roulant manuel</asp:ListItem> <asp:ListItem Value="Persienne">Persienne</asp:ListItem></asp:DropDownList></td>
	</tr>
	<tr>
		<td>Chambre 7</td>
        <td width="5%"><asp:TextBox ID="txtm2YatakOdasi7"  MaxLength="3" Width="50" runat="server"></asp:TextBox></td>
		<asp:FilteredTextBoxExtender ID="FilterYatakOdasi7"  TargetControlID="txtm2YatakOdasi7" FilterType="Numbers"
        Enabled="True"  
         runat="server">
		</asp:FilteredTextBoxExtender>
		<td width="14%"> <asp:DropDownList ID="drpZeminYatakOdasi7" Width="130" runat="server"><asp:ListItem Value="RDC">RDC </asp:ListItem><asp:ListItem Value="1er étage">1er étage </asp:ListItem> <asp:ListItem Value="2ème étage"> 2 ème étage </asp:ListItem></asp:DropDownList></td>
		<td width="12%"><asp:DropDownList ID="drpYonYatakOdasi7" Width="130" runat="server"><asp:ListItem Value="Nord"> Nord </asp:ListItem><asp:ListItem Value="Sud">Sud</asp:ListItem> <asp:ListItem Value="Est">Est</asp:ListItem> <asp:ListItem Value="Ouest">Ouest</asp:ListItem> <asp:ListItem Value="Nord-Est"> Nord-Est</asp:ListItem> <asp:ListItem Value="Nord-Ouest">Nord-Ouest </asp:ListItem><asp:ListItem Value="Sud-Est">Sud-Est </asp:ListItem><asp:ListItem Value="Sud-Ouest">Sud-Ouest </asp:ListItem></asp:DropDownList></td>
		<td width="12%"><asp:DropDownList ID="drpYerDosemeYatakOdasi7" Width="130" runat="server"><asp:ListItem Value="Carrelage">Carrelage</asp:ListItem><asp:ListItem Value="Lino">Lino</asp:ListItem> <asp:ListItem Value="Parquet">Parquet</asp:ListItem><asp:ListItem Value="Moquette">Moquette</asp:ListItem></asp:DropDownList></td>
		<td width="14%"><asp:DropDownList ID="drpCercevelerYatakOdasi7" Width="130" runat="server"><asp:ListItem Value="PCV">PCV</asp:ListItem><asp:ListItem Value="Aluminium">Aluminium  </asp:ListItem> <asp:ListItem Value="Bois"> Bois</asp:ListItem></asp:DropDownList></td>
		<td width="14%"><asp:DropDownList ID="drpCamlarYatakOdasi7" Width="130" runat="server"><asp:ListItem Value="Double vitrage">Double vitrage</asp:ListItem><asp:ListItem Value="Simple vitrage">Simple  vitrage  </asp:ListItem></asp:DropDownList></td>
		<td width="180"><asp:DropDownList ID="drpPanjularYatakOdasi7" Width="130" runat="server"><asp:ListItem Value="Roulant électrique">Roulant électrique</asp:ListItem><asp:ListItem Value="Roulant manuel">Roulant manuel</asp:ListItem> <asp:ListItem Value="Persienne">Persienne</asp:ListItem></asp:DropDownList></td>
	</tr>
	<tr>
		<td>Bureau</td>
        <td width="5%"><asp:TextBox ID="txtm2Calisma" Width="50" MaxLength="3" runat="server"></asp:TextBox></td>
		<asp:FilteredTextBoxExtender ID="FilterCalisma"  TargetControlID="txtm2Calisma" FilterType="Numbers"
        Enabled="True"  
         runat="server">
		</asp:FilteredTextBoxExtender>
		<td width="14%"> <asp:DropDownList ID="drpZeminCalisma" Width="130" runat="server"><asp:ListItem Value="RDC">RDC </asp:ListItem><asp:ListItem Value="1er étage">1er étage </asp:ListItem> <asp:ListItem Value="2ème étage"> 2 ème étage </asp:ListItem></asp:DropDownList></td>
		<td width="12%"><asp:DropDownList ID="drpYonCalisma" Width="130" runat="server"><asp:ListItem Value="Nord"> Nord </asp:ListItem><asp:ListItem Value="Sud">Sud</asp:ListItem> <asp:ListItem Value="Est">Est</asp:ListItem> <asp:ListItem Value="Ouest">Ouest</asp:ListItem> <asp:ListItem Value="Nord-Est"> Nord-Est</asp:ListItem> <asp:ListItem Value="Nord-Ouest">Nord-Ouest </asp:ListItem><asp:ListItem Value="Sud-Est">Sud-Est </asp:ListItem><asp:ListItem Value="Sud-Ouest">Sud-Ouest </asp:ListItem></asp:DropDownList></td>
		<td width="12%"><asp:DropDownList ID="drpYerDosemeCalisma" Width="130" runat="server"><asp:ListItem Value="Carrelage">Carrelage</asp:ListItem><asp:ListItem Value="Lino">Lino</asp:ListItem> <asp:ListItem Value="Parquet">Parquet</asp:ListItem><asp:ListItem Value="Moquette">Moquette</asp:ListItem></asp:DropDownList></td>
		<td width="14%"><asp:DropDownList ID="drpCercevelerCalisma" Width="130" runat="server"><asp:ListItem Value="PCV">PCV</asp:ListItem><asp:ListItem Value="Aluminium">Aluminium  </asp:ListItem> <asp:ListItem Value="Bois"> Bois</asp:ListItem></asp:DropDownList></td>
		<td width="14%"><asp:DropDownList ID="drpCamlarCalisma" Width="130" runat="server"><asp:ListItem Value="Double vitrage">Double vitrage</asp:ListItem><asp:ListItem Value="Simple vitrage">Simple  vitrage  </asp:ListItem></asp:DropDownList></td>
		<td width="180"><asp:DropDownList ID="drpPanjularCalisma" Width="130" runat="server"><asp:ListItem Value="Roulant électrique">Roulant électrique</asp:ListItem><asp:ListItem Value="Roulant manuel">Roulant manuel</asp:ListItem> <asp:ListItem Value="Persienne">Persienne</asp:ListItem></asp:DropDownList></td>
	</tr>
	<tr>
		<td>Salle de bain 1</td>
        <td width="5%"><asp:TextBox ID="txtm2Banyo" Width="50" MaxLength="3" runat="server"></asp:TextBox></td>
			<asp:FilteredTextBoxExtender ID="FilterBanyo"  TargetControlID="txtm2Banyo" FilterType="Numbers"
        Enabled="True"  
         runat="server">
		</asp:FilteredTextBoxExtender>
		<td width="14%"> <asp:DropDownList ID="drpZeminBanyo1" Width="130" runat="server"><asp:ListItem Value="RDC">RDC </asp:ListItem><asp:ListItem Value="1er étage">1er étage </asp:ListItem> <asp:ListItem Value="2ème étage"> 2 ème étage </asp:ListItem></asp:DropDownList></td>
		<td width="12%"><asp:DropDownList ID="drpYonBanyo1" Width="130" runat="server"><asp:ListItem Value="Nord"> Nord </asp:ListItem><asp:ListItem Value="Sud">Sud</asp:ListItem> <asp:ListItem Value="Est">Est</asp:ListItem> <asp:ListItem Value="Ouest">Ouest</asp:ListItem> <asp:ListItem Value="Nord-Est"> Nord-Est</asp:ListItem> <asp:ListItem Value="Nord-Ouest">Nord-Ouest </asp:ListItem><asp:ListItem Value="Sud-Est">Sud-Est </asp:ListItem><asp:ListItem Value="Sud-Ouest">Sud-Ouest </asp:ListItem></asp:DropDownList></td>
		<td width="12%"><asp:DropDownList ID="drpYerDosemeBanyo1" Width="130" runat="server"><asp:ListItem Value="Carrelage">Carrelage</asp:ListItem><asp:ListItem Value="Lino">Lino</asp:ListItem> <asp:ListItem Value="Parquet">Parquet</asp:ListItem><asp:ListItem Value="Moquette">Moquette</asp:ListItem></asp:DropDownList></td>
		<td width="14%"><asp:DropDownList ID="drpCercevelerBanyo1" Width="130" runat="server"><asp:ListItem Value="PCV">PCV</asp:ListItem><asp:ListItem Value="Aluminium">Aluminium  </asp:ListItem> <asp:ListItem Value="Bois"> Bois</asp:ListItem></asp:DropDownList></td>
		<td width="14%"><asp:DropDownList ID="drpCamlarBanyo1" Width="130" runat="server"><asp:ListItem Value="Double vitrage">Double vitrage</asp:ListItem><asp:ListItem Value="Simple vitrage">Simple  vitrage  </asp:ListItem></asp:DropDownList></td>
		<td width="180"><asp:DropDownList ID="drpPanjularBanyo1" Width="130" runat="server"><asp:ListItem Value="Roulant électrique">Roulant électrique</asp:ListItem><asp:ListItem Value="Roulant manuel">Roulant manuel</asp:ListItem> <asp:ListItem Value="Persienne">Persienne</asp:ListItem></asp:DropDownList></td>
	</tr>
	<tr>
		<td>Salle de bain 2</td>
        <td width="5%"><asp:TextBox ID="txtm2Banyo2" Width="50" MaxLength="3" runat="server"></asp:TextBox></td>
		<asp:FilteredTextBoxExtender ID="FilterBanyo2"  TargetControlID="txtm2Banyo2" FilterType="Numbers"
        Enabled="True"  
         runat="server">
		</asp:FilteredTextBoxExtender>
		<td width="14%"> <asp:DropDownList ID="drpZeminBanyo2" Width="130" runat="server"><asp:ListItem Value="RDC">RDC </asp:ListItem><asp:ListItem Value="1er étage">1er étage </asp:ListItem> <asp:ListItem Value="2ème étage"> 2 ème étage </asp:ListItem></asp:DropDownList></td>
		<td width="12%"><asp:DropDownList ID="drpYonBanyo2" Width="130" runat="server"><asp:ListItem Value="Nord"> Nord </asp:ListItem><asp:ListItem Value="Sud">Sud</asp:ListItem> <asp:ListItem Value="Est">Est</asp:ListItem> <asp:ListItem Value="Ouest">Ouest</asp:ListItem> <asp:ListItem Value="Nord-Est"> Nord-Est</asp:ListItem> <asp:ListItem Value="Nord-Ouest">Nord-Ouest </asp:ListItem><asp:ListItem Value="Sud-Est">Sud-Est </asp:ListItem><asp:ListItem Value="Sud-Ouest">Sud-Ouest </asp:ListItem></asp:DropDownList></td>
		<td width="12%"><asp:DropDownList ID="drpYerDosemeBanyo2" Width="130" runat="server"><asp:ListItem Value="Carrelage">Carrelage</asp:ListItem><asp:ListItem Value="Lino">Lino</asp:ListItem> <asp:ListItem Value="Parquet">Parquet</asp:ListItem><asp:ListItem Value="Moquette">Moquette</asp:ListItem></asp:DropDownList></td>
		<td width="14%"><asp:DropDownList ID="drpCercevelerBanyo2" Width="130" runat="server"><asp:ListItem Value="PCV">PCV</asp:ListItem><asp:ListItem Value="Aluminium">Aluminium  </asp:ListItem> <asp:ListItem Value="Bois"> Bois</asp:ListItem></asp:DropDownList></td>
		<td width="14%"><asp:DropDownList ID="drpCamlarBanyo2" Width="130" runat="server"><asp:ListItem Value="Double vitrage">Double vitrage</asp:ListItem><asp:ListItem Value="Simple vitrage">Simple  vitrage  </asp:ListItem></asp:DropDownList></td>
		<td width="180"><asp:DropDownList ID="drpPanjularBanyo2" Width="130" runat="server"><asp:ListItem Value="Roulant électrique">Roulant électrique</asp:ListItem><asp:ListItem Value="Roulant manuel">Roulant manuel</asp:ListItem> <asp:ListItem Value="Persienne">Persienne</asp:ListItem></asp:DropDownList></td>
	</tr>
	<tr>
		<td>Salle d’eau</td>
        <td width="5%"><asp:TextBox ID="txtm2Dusakabin" Width="50" MaxLength="3" runat="server"></asp:TextBox></td>
		<asp:FilteredTextBoxExtender ID="FilterDusakabin"  TargetControlID="txtm2Dusakabin" FilterType="Numbers"
        Enabled="True"  
         runat="server">
		</asp:FilteredTextBoxExtender>
		<td width="14%"> <asp:DropDownList ID="drpZeminDusakabin" Width="130" runat="server"><asp:ListItem Value="RDC">RDC </asp:ListItem><asp:ListItem Value="1er étage">1er étage </asp:ListItem> <asp:ListItem Value="2ème étage"> 2 ème étage </asp:ListItem></asp:DropDownList></td>
		<td width="12%"><asp:DropDownList ID="drpYonDusakabin" Width="130" runat="server"><asp:ListItem Value="Nord"> Nord </asp:ListItem><asp:ListItem Value="Sud">Sud</asp:ListItem> <asp:ListItem Value="Est">Est</asp:ListItem> <asp:ListItem Value="Ouest">Ouest</asp:ListItem> <asp:ListItem Value="Nord-Est"> Nord-Est</asp:ListItem> <asp:ListItem Value="Nord-Ouest">Nord-Ouest </asp:ListItem><asp:ListItem Value="Sud-Est">Sud-Est </asp:ListItem><asp:ListItem Value="Sud-Ouest">Sud-Ouest </asp:ListItem></asp:DropDownList></td>
		<td width="12%"><asp:DropDownList ID="drpYerDosemeDusakabin" Width="130" runat="server"><asp:ListItem Value="Carrelage">Carrelage</asp:ListItem><asp:ListItem Value="Lino">Lino</asp:ListItem> <asp:ListItem Value="Parquet">Parquet</asp:ListItem><asp:ListItem Value="Moquette">Moquette</asp:ListItem></asp:DropDownList></td>
		<td width="14%"><asp:DropDownList ID="drpCercevelerDusakabin" Width="130" runat="server"><asp:ListItem Value="PCV">PCV</asp:ListItem><asp:ListItem Value="Aluminium">Aluminium  </asp:ListItem> <asp:ListItem Value="Bois"> Bois</asp:ListItem></asp:DropDownList></td>
		<td width="14%"><asp:DropDownList ID="drpCamlarDusakabin" Width="130" runat="server"><asp:ListItem Value="Double vitrage">Double vitrage</asp:ListItem><asp:ListItem Value="Simple vitrage">Simple  vitrage  </asp:ListItem></asp:DropDownList></td>
		<td width="180"><asp:DropDownList ID="drpPanjularDusakabin" Width="130" runat="server"><asp:ListItem Value="Roulant électrique">Roulant électrique</asp:ListItem><asp:ListItem Value="Roulant manuel">Roulant manuel</asp:ListItem> <asp:ListItem Value="Persienne">Persienne</asp:ListItem></asp:DropDownList></td>
	</tr>
	<tr>
		<td>WC 1</td>
        <td width="5%"><asp:TextBox ID="txtm2Wc1" Width="50" MaxLength="3" runat="server"></asp:TextBox></td>
		<asp:FilteredTextBoxExtender ID="FilterWc1"  TargetControlID="txtm2Wc1" FilterType="Numbers"
        Enabled="True"  
         runat="server">
		</asp:FilteredTextBoxExtender>
		<td width="14%"> <asp:DropDownList ID="drpZeminWc1" Width="130" runat="server"><asp:ListItem Value="RDC">RDC </asp:ListItem><asp:ListItem Value="1er étage">1er étage </asp:ListItem> <asp:ListItem Value="2ème étage"> 2 ème étage </asp:ListItem></asp:DropDownList></td>
		<td width="12%"><asp:DropDownList ID="drpYonWc1" Width="130" runat="server"><asp:ListItem Value="Nord"> Nord </asp:ListItem><asp:ListItem Value="Sud">Sud</asp:ListItem> <asp:ListItem Value="Est">Est</asp:ListItem> <asp:ListItem Value="Ouest">Ouest</asp:ListItem> <asp:ListItem Value="Nord-Est"> Nord-Est</asp:ListItem> <asp:ListItem Value="Nord-Ouest">Nord-Ouest </asp:ListItem><asp:ListItem Value="Sud-Est">Sud-Est </asp:ListItem><asp:ListItem Value="Sud-Ouest">Sud-Ouest </asp:ListItem></asp:DropDownList></td>
		<td width="12%"><asp:DropDownList ID="drpYerDosemeWc1" Width="130" runat="server"><asp:ListItem Value="Carrelage">Carrelage</asp:ListItem><asp:ListItem Value="Lino">Lino</asp:ListItem> <asp:ListItem Value="Parquet">Parquet</asp:ListItem><asp:ListItem Value="Moquette">Moquette</asp:ListItem></asp:DropDownList></td>
		<td width="14%"><asp:DropDownList ID="drpCercevelerWc1" Width="130" runat="server"><asp:ListItem Value="PCV">PCV</asp:ListItem><asp:ListItem Value="Aluminium">Aluminium  </asp:ListItem> <asp:ListItem Value="Bois"> Bois</asp:ListItem></asp:DropDownList></td>
		<td width="14%"><asp:DropDownList ID="drpCamlarWc1" Width="130" runat="server"><asp:ListItem Value="Double vitrage">Double vitrage</asp:ListItem><asp:ListItem Value="Simple vitrage">Simple  vitrage  </asp:ListItem></asp:DropDownList></td>
		<td width="180"><asp:DropDownList ID="drpPanjularWc1" Width="130" runat="server"><asp:ListItem Value="Roulant électrique">Roulant électrique</asp:ListItem><asp:ListItem Value="Roulant manuel">Roulant manuel</asp:ListItem> <asp:ListItem Value="Persienne">Persienne</asp:ListItem></asp:DropDownList></td>
	</tr>
	<tr>
		<td>WC 2</td>
        <td width="5%"><asp:TextBox ID="txtm2Wc2" Width="50" MaxLength="3" runat="server"></asp:TextBox></td>
		<td width="14%"> <asp:DropDownList ID="drpZeminWc2" Width="130" runat="server"><asp:ListItem Value="RDC">RDC </asp:ListItem><asp:ListItem Value="1er étage">1er étage </asp:ListItem> <asp:ListItem Value="2ème étage"> 2 ème étage </asp:ListItem></asp:DropDownList></td>
		<td width="12%"><asp:DropDownList ID="drpYonWc2" Width="130" runat="server"><asp:ListItem Value="Nord"> Nord </asp:ListItem><asp:ListItem Value="Sud">Sud</asp:ListItem> <asp:ListItem Value="Est">Est</asp:ListItem> <asp:ListItem Value="Ouest">Ouest</asp:ListItem> <asp:ListItem Value="Nord-Est"> Nord-Est</asp:ListItem> <asp:ListItem Value="Nord-Ouest">Nord-Ouest </asp:ListItem><asp:ListItem Value="Sud-Est">Sud-Est </asp:ListItem><asp:ListItem Value="Sud-Ouest">Sud-Ouest </asp:ListItem></asp:DropDownList></td>
		<td width="12%"><asp:DropDownList ID="drpYerDosemeWc2" Width="130" runat="server"><asp:ListItem Value="Carrelage">Carrelage</asp:ListItem><asp:ListItem Value="Lino">Lino</asp:ListItem> <asp:ListItem Value="Parquet">Parquet</asp:ListItem><asp:ListItem Value="Moquette">Moquette</asp:ListItem></asp:DropDownList></td>
		<td width="14%"><asp:DropDownList ID="drpCercevelerWc2" Width="130" runat="server"><asp:ListItem Value="PCV">PCV</asp:ListItem><asp:ListItem Value="Aluminium">Aluminium  </asp:ListItem> <asp:ListItem Value="Bois"> Bois</asp:ListItem></asp:DropDownList></td>
		<td width="14%"><asp:DropDownList ID="drpCamlarWc2" Width="130" runat="server"><asp:ListItem Value="Double vitrage">Double vitrage</asp:ListItem><asp:ListItem Value="Simple vitrage">Simple  vitrage  </asp:ListItem></asp:DropDownList></td>
		<td width="180"><asp:DropDownList ID="drpPanjularWc2" Width="130" runat="server"><asp:ListItem Value="Roulant électrique">Roulant électrique</asp:ListItem><asp:ListItem Value="Roulant manuel">Roulant manuel</asp:ListItem> <asp:ListItem Value="Persienne">Persienne</asp:ListItem></asp:DropDownList></td>
	</tr>
	<tr>
		<td>Mezzanine</td>
        <td width="5%"><asp:TextBox ID="txtm2AsmaKat" Width="50" MaxLength="3" runat="server"></asp:TextBox></td>
		<asp:FilteredTextBoxExtender ID="FilterAsmaKat"  TargetControlID="txtm2AsmaKat" FilterType="Numbers"
        Enabled="True"  
         runat="server">
		</asp:FilteredTextBoxExtender>
		<td width="14%"> <asp:DropDownList ID="drpZeminAsmaKat" Width="130" runat="server"><asp:ListItem Value="RDC">RDC </asp:ListItem><asp:ListItem Value="1er étage">1er étage </asp:ListItem> <asp:ListItem Value="2ème étage"> 2 ème étage </asp:ListItem></asp:DropDownList></td>
		<td width="12%"><asp:DropDownList ID="drpYonAsmaKat" Width="130" runat="server"><asp:ListItem Value="Nord"> Nord </asp:ListItem><asp:ListItem Value="Sud">Sud</asp:ListItem> <asp:ListItem Value="Est">Est</asp:ListItem> <asp:ListItem Value="Ouest">Ouest</asp:ListItem> <asp:ListItem Value="Nord-Est"> Nord-Est</asp:ListItem> <asp:ListItem Value="Nord-Ouest">Nord-Ouest </asp:ListItem><asp:ListItem Value="Sud-Est">Sud-Est </asp:ListItem><asp:ListItem Value="Sud-Ouest">Sud-Ouest </asp:ListItem></asp:DropDownList></td>
		<td width="12%"><asp:DropDownList ID="drpYerDosemeAsmaKat" Width="130" runat="server"><asp:ListItem Value="Carrelage">Carrelage</asp:ListItem><asp:ListItem Value="Lino">Lino</asp:ListItem> <asp:ListItem Value="Parquet">Parquet</asp:ListItem><asp:ListItem Value="Moquette">Moquette</asp:ListItem></asp:DropDownList></td>
		<td width="14%"><asp:DropDownList ID="drpCercevelerAsmaKat" Width="130" runat="server"><asp:ListItem Value="PCV">PCV</asp:ListItem><asp:ListItem Value="Aluminium">Aluminium  </asp:ListItem> <asp:ListItem Value="Bois"> Bois</asp:ListItem></asp:DropDownList></td>
		<td width="14%"><asp:DropDownList ID="drpCamlarAsmaKat" Width="130" runat="server"><asp:ListItem Value="Double vitrage">Double vitrage</asp:ListItem><asp:ListItem Value="Simple vitrage">Simple  vitrage  </asp:ListItem></asp:DropDownList></td>
		<td width="180"><asp:DropDownList ID="drpPanjularAsmaKat" Width="130" runat="server"><asp:ListItem Value="Roulant électrique">Roulant électrique</asp:ListItem><asp:ListItem Value="Roulant manuel">Roulant manuel</asp:ListItem> <asp:ListItem Value="Persienne">Persienne</asp:ListItem></asp:DropDownList></td>
	</tr>
	
	<tr>
		<td>Véranda</td>
        <td width="5%"><asp:TextBox ID="txtm2Veranda" Width="50" MaxLength="3" runat="server"></asp:TextBox></td>
		<asp:FilteredTextBoxExtender ID="FilterVeranda"  TargetControlID="txtm2Veranda" FilterType="Numbers"
        Enabled="True"  
         runat="server">
		</asp:FilteredTextBoxExtender>
		<td width="14%"> <asp:DropDownList ID="drpZeminVeranda" Width="130" runat="server"><asp:ListItem Value="RDC">RDC </asp:ListItem><asp:ListItem Value="1er étage">1er étage </asp:ListItem> <asp:ListItem Value="2ème étage"> 2 ème étage </asp:ListItem></asp:DropDownList></td>
		<td width="12%"><asp:DropDownList ID="drpYonVeranda" Width="130" runat="server"><asp:ListItem Value="Nord"> Nord </asp:ListItem><asp:ListItem Value="Sud">Sud</asp:ListItem> <asp:ListItem Value="Est">Est</asp:ListItem> <asp:ListItem Value="Ouest">Ouest</asp:ListItem> <asp:ListItem Value="Nord-Est"> Nord-Est</asp:ListItem> <asp:ListItem Value="Nord-Ouest">Nord-Ouest </asp:ListItem><asp:ListItem Value="Sud-Est">Sud-Est </asp:ListItem><asp:ListItem Value="Sud-Ouest">Sud-Ouest </asp:ListItem></asp:DropDownList></td>
		<td width="12%"><asp:DropDownList ID="drpYerDosemeVeranda" Width="130" runat="server"><asp:ListItem Value="Carrelage">Carrelage</asp:ListItem><asp:ListItem Value="Lino">Lino</asp:ListItem> <asp:ListItem Value="Parquet">Parquet</asp:ListItem><asp:ListItem Value="Moquette">Moquette</asp:ListItem></asp:DropDownList></td>
		<td width="14%"><asp:DropDownList ID="drpCercevelerVeranda" Width="130" runat="server"><asp:ListItem Value="PCV">PCV</asp:ListItem><asp:ListItem Value="Aluminium">Aluminium  </asp:ListItem> <asp:ListItem Value="Bois"> Bois</asp:ListItem></asp:DropDownList></td>
		<td width="14%"><asp:DropDownList ID="drpCamlarVeranda" Width="130" runat="server"><asp:ListItem Value="Double vitrage">Double vitrage</asp:ListItem><asp:ListItem Value="Simple vitrage">Simple  vitrage  </asp:ListItem></asp:DropDownList></td>
		<td width="180"><asp:DropDownList ID="drpPanjularVeranda" Width="130" runat="server"><asp:ListItem Value="Roulant électrique">Roulant électrique</asp:ListItem><asp:ListItem Value="Roulant manuel">Roulant manuel</asp:ListItem> <asp:ListItem Value="Persienne">Persienne</asp:ListItem></asp:DropDownList></td>
	</tr>
</table>

</div>
</div>
<h3>Des Caractéristiques </h3>
<div class="ozeliklerilan2">
<label>Etat général de votre propriété</label>
<asp:CheckBoxList ID="chckgeneldurum" runat="server">
    <asp:ListItem Text = "neuf"   Value = "neuf" onclick = "MutExChkList(this);">
    </asp:ListItem>
    <asp:ListItem Text = "bon état" Value = "bon état" onclick = "MutExChkList(this);">
    </asp:ListItem>
    <asp:ListItem Text = "moyen" Value = "moyen" onclick = "MutExChkList(this);">
    </asp:ListItem>
    <asp:ListItem Text = "travaux à prévoir" Value = "travaux à prévoir" onclick = "MutExChkList(this);">
    </asp:ListItem>
   
</asp:CheckBoxList>
<label>Etat général de la co-propriété</label>
<asp:CheckBoxList ID="chckOrtakkullanim" runat="server">
    <asp:ListItem Text = "neuf"  Value = "neuf" onclick = "MutExChkList(this);">
    </asp:ListItem>
    <asp:ListItem Text = "bon état" Value = "bon état" onclick = "MutExChkList(this);">
    </asp:ListItem>
    <asp:ListItem Text = "moyen" Value = "moyen" onclick = "MutExChkList(this);">
    </asp:ListItem>
    <asp:ListItem Text = "travaux à prévoir" Value = "travaux à prévoir" onclick = "MutExChkList(this);">
    </asp:ListItem>
   
</asp:CheckBoxList>

<label>Portail</label>
<asp:CheckBoxList ID="chckBahceKapisi" runat="server">
    <asp:ListItem Text = "électrique"  Value = "électrique" onclick = "MutExChkList(this);">
    </asp:ListItem>
    <asp:ListItem Text = "manuel" Value = "manuel" onclick = "MutExChkList(this);">
    </asp:ListItem>
</asp:CheckBoxList>
<label>Portail (état)</label>
<asp:CheckBoxList ID="chckBahceKapisiDurumu" runat="server">
    <asp:ListItem Text = "neuf"  Value = "neuf" onclick = "MutExChkList(this);">
    </asp:ListItem>
    <asp:ListItem Text = "bon état" Value = "bon état" onclick = "MutExChkList(this);">
    </asp:ListItem>
    <asp:ListItem Text = "moyen" Value = "moyen" onclick = "MutExChkList(this);">
    </asp:ListItem>
    <asp:ListItem Text = "travaux à prévoir" Value = "travaux à prévoir" onclick = "MutExChkList(this);">
    </asp:ListItem>
   
</asp:CheckBoxList>

<label>Fenêtres</label>
<asp:CheckBoxList ID="chckPencereler" runat="server">
    <asp:ListItem Text = "neuf"  Value = "neuf" onclick = "MutExChkList(this);">
    </asp:ListItem>
    <asp:ListItem Text = "bon état" Value = "bon état" onclick = "MutExChkList(this);">
    </asp:ListItem>
    <asp:ListItem Text = "moyen" Value = "moyen" onclick = "MutExChkList(this);">
    </asp:ListItem>
    <asp:ListItem Text = "travaux à prévoir" Value = "travaux à prévoir" onclick = "MutExChkList(this);">
    </asp:ListItem>
   
</asp:CheckBoxList>

<label>Volets</label>
<asp:CheckBoxList ID="chckPanjurlar" runat="server">
    <asp:ListItem Text = "neuf"  Value = "neuf" onclick = "MutExChkList(this);">
    </asp:ListItem>
    <asp:ListItem Text = "bon état" Value = "bon état" onclick = "MutExChkList(this);">
    </asp:ListItem>
    <asp:ListItem Text = "moyen" Value = "moyen" onclick = "MutExChkList(this);">
    </asp:ListItem>
    <asp:ListItem Text = "travaux à prévoir" Value = "travaux à prévoir" onclick = "MutExChkList(this);">
    </asp:ListItem>
   
</asp:CheckBoxList>
<label>Toiture</label>
<asp:CheckBoxList ID="chckCatiDurum" runat="server">
    <asp:ListItem Text = "neuf"  Value = "neuf" onclick = "MutExChkList(this);">
    </asp:ListItem>
    <asp:ListItem Text = "bon état" Value = "bon état" onclick = "MutExChkList(this);">
    </asp:ListItem>
    <asp:ListItem Text = "moyen" Value = "moyen" onclick = "MutExChkList(this);">
    </asp:ListItem>
    <asp:ListItem Text = "travaux à prévoir" Value = "travaux à prévoir" onclick = "MutExChkList(this);">
    </asp:ListItem>
   
</asp:CheckBoxList>

<label>Charpente</label>
<asp:CheckBoxList ID="chckCatiIskeleti" runat="server">
    <asp:ListItem Text = "neuf"  Value = "neuf" onclick = "MutExChkList(this);">
    </asp:ListItem>
    <asp:ListItem Text = "bon état" Value = "bon état" onclick = "MutExChkList(this);">
    </asp:ListItem>
    <asp:ListItem Text = "moyen" Value = "moyen" onclick = "MutExChkList(this);">
    </asp:ListItem>
    <asp:ListItem Text = "travaux à prévoir" Value = "travaux à prévoir" onclick = "MutExChkList(this);">
    </asp:ListItem>
   
</asp:CheckBoxList>

<label>Façade</label>
<asp:CheckBoxList ID="chckDisKaplama" runat="server">
    <asp:ListItem Text = "neuf"  Value = "neuf" onclick = "MutExChkList(this);">
    </asp:ListItem>
    <asp:ListItem Text = "bon état" Value = "bon état" onclick = "MutExChkList(this);">
    </asp:ListItem>
    <asp:ListItem Text = "moyen" Value = "moyen" onclick = "MutExChkList(this);">
    </asp:ListItem>
    <asp:ListItem Text = "travaux à prévoir" Value = "travaux à prévoir" onclick = "MutExChkList(this);">
    </asp:ListItem>
   
</asp:CheckBoxList>


</div>
  <asp:UpdatePanel ID="UpdatePanel1" runat="server">
  <ContentTemplate>
<div class="altozeliklerikincisayfa">
  
<label>Charges de co-propriété/an (€) </label>
<asp:TextBox ID="txtYillikAidat"  runat="server">0</asp:TextBox><br />

<label>Taxe foncière annuelle (€)</label>
<asp:TextBox ID="txtYillikVergi"  runat="server"></asp:TextBox><br />

<label>Cuisine équipée</label>
    <asp:CheckBox ID="chckMutfakEkipmanlari" runat="server" /><br />
	
<label>Cellier</label>
<asp:CheckBox ID="chckKiller"  OnCheckedChanged="chckKiller_CheckedChanged" AutoPostBack="true"  runat="server" />
<asp:TextBox ID="txtKiller" Visible="false"  placeholder="surface m2"   runat="server"></asp:TextBox><br />	
 
<label>Placard intégré (chambres)</label>
<asp:CheckBoxList ID="chckDolaplar" runat="server">
    <asp:ListItem Text = "Ch. 1"  Value = "1;" >
    </asp:ListItem>
    <asp:ListItem Text = "Ch. 2" Value = "2;" >
    </asp:ListItem>
    <asp:ListItem Text = "Ch. 3" Value = "3;" >
    </asp:ListItem>
    <asp:ListItem Text = "Ch. 4" Value = "4;" >
    </asp:ListItem>
	  <asp:ListItem Text = "Ch. 5" Value = "5;">
    </asp:ListItem>
	  <asp:ListItem Text = "Ch. 6" Value = "6;" >
    </asp:ListItem> 
	<asp:ListItem Text = "Ch. 7" Value = "7;" >
    </asp:ListItem>
</asp:CheckBoxList>	

<label>Dressing</label>
<asp:CheckBox ID="chckGiyinme" OnCheckedChanged="chckGiyinme_CheckedChanged"   AutoPostBack="true"  runat="server" />
<asp:TextBox ID="txtGiyinmeOdasi"  Visible="false" placeholder="surface m2"  runat="server"></asp:TextBox><br />	
  

<label>Interphone</label>
    <asp:CheckBox ID="chckedInterphone" runat="server" /><br />
<label>Alarme</label>
    <asp:CheckBox ID="chckedAlarm" runat="server" /><br />
<label>Parabole</label>
<asp:CheckBox ID="chckedUydu" runat="server" /><br />
<label>Antenne TV</label>
 <asp:CheckBox ID="chckedAnten" runat="server" /><br />
<label>Cheminée foyer ouvert</label>
 <asp:CheckBox ID="chckedSomine1" runat="server" /><br />
<label>Insert</label>
 <asp:CheckBox ID="chckedSomine2" runat="server" /><br />
<label>Combles aménagées</label>
 <asp:CheckBox ID="chckCatiKati" OnCheckedChanged="chckCatiKati_CheckedChanged" AutoPostBack="true" runat="server" /> <asp:TextBox ID="txtCatikati" Visible="false" placeholder="surface m2" runat="server"></asp:TextBox><br />
 <label>Cave</label>
 <asp:CheckBox ID="chckBodrum"  OnCheckedChanged="chckBodrum_CheckedChanged" AutoPostBack="true" runat="server" /> <asp:TextBox ID="txtBodrum" Visible="false" placeholder="surface m2" runat="server"></asp:TextBox><br />
<label>Garage</label>
 <asp:CheckBox ID="chckGaraj"  OnCheckedChanged="chckGaraj_CheckedChanged"  AutoPostBack="true" runat="server" /> <asp:TextBox ID="txtGaraj" Visible="false"  placeholder="surface m2" runat="server"></asp:TextBox><br />
<label>Parking</label>
 <asp:CheckBox ID="chckParkYeri" OnCheckedChanged="chckParkYeri_CheckedChanged" AutoPostBack="true" runat="server" /> <asp:TextBox ID="txtParkYeri"  Visible="false" placeholder="nombre de place" runat="server"></asp:TextBox><br />
 <label>Piscine</label>
 <asp:CheckBox ID="chckHavuz"  OnCheckedChanged="chckHavuz_CheckedChanged" AutoPostBack="true" runat="server" /> <asp:TextBox ID="txtHavuz" Visible="false" placeholder="dimensions (Long x larg) m" runat="server"></asp:TextBox><br />
<label>Clôture</label>
<asp:CheckBoxList ID="chckBahceDuvari" runat="server">
    <asp:ListItem Text = "grillage"   Value = "grillage" onclick = "MutExChkList(this);">
    </asp:ListItem>
    <asp:ListItem Text = "mur" Value = "mur" onclick = "MutExChkList(this);">
    </asp:ListItem>
    <asp:ListItem Text = "haie" Value = "haie" onclick = "MutExChkList(this);">
    </asp:ListItem>   
</asp:CheckBoxList>
<label>Evacuation des eaux usées  </label>
<asp:CheckBoxList ID="chckSuOlcum" runat="server">
    <asp:ListItem Text = "tout à l’égout"  Value = "tout à l’égout" onclick = "MutExChkList(this);">
    </asp:ListItem>
    <asp:ListItem Text = "fosse septique" Value = "fosse septique" onclick = "MutExChkList(this);">
    </asp:ListItem>
</asp:CheckBoxList>

</div>
 </ContentTemplate>
</asp:UpdatePanel>
</div>
<div class="clr"></div>
<h3>Chauffage</h3>
<div class="isinma">
<label>Etat général</label>
<asp:CheckBoxList ID="chckIsinmagenelDurum" runat="server">
    <asp:ListItem Text = "neuf"  Value = "neuf" onclick = "MutExChkList(this);">
    </asp:ListItem>
    <asp:ListItem Text = "bon état" Value = "bon état" onclick = "MutExChkList(this);">
    </asp:ListItem>
    <asp:ListItem Text = "moyen" Value = "moyen" onclick = "MutExChkList(this);">
    </asp:ListItem>
    <asp:ListItem Text = "travaux à prévoir" Value = "travaux à prévoir" onclick = "MutExChkList(this);">
    </asp:ListItem>
   
</asp:CheckBoxList>

<label>Année de la chaudière </label>
<asp:TextBox ID="txtIsınmaSistemiYasi"  runat="server"></asp:TextBox><br/>
<label>Chauffage  </label>
<asp:CheckBoxList ID="chckIsitma" runat="server">
    <asp:ListItem Text = "individuel"  Value = "individuel" selected="true" onclick = "MutExChkList(this);">
    </asp:ListItem>
    <asp:ListItem Text = "collectif" Value = "collectif" onclick = "MutExChkList(this);">
    </asp:ListItem>
</asp:CheckBoxList>

<label>Type de chauffage</label>
<asp:CheckBoxList ID="chckIsınmaTipi" runat="server">
    <asp:ListItem Text = "radiateur"  Value = "radiateur" onclick = "MutExChkList(this);">
    </asp:ListItem>
    <asp:ListItem Text = "convecteur" Value = "convecteur" onclick = "MutExChkList(this);">
    </asp:ListItem>
    <asp:ListItem Text = "au sol" Value = "au sol" onclick = "MutExChkList(this);">
    </asp:ListItem>
    <asp:ListItem Text = "clim reversible" Value = "clim reversible" selected="true" onclick = "MutExChkList(this);">
    </asp:ListItem>
</asp:CheckBoxList>



<label>Type d’énergie </label>
<asp:CheckBoxList ID="chckEnerjiTipi" runat="server">
    <asp:ListItem Text = "gaz"  Value = "gaz" onclick = "MutExChkList(this);">
    </asp:ListItem>
    <asp:ListItem Text = "electrik" Value = "electrik" onclick = "MutExChkList(this);">
    </asp:ListItem>
    <asp:ListItem Text = "fuel" Value = "fuel" onclick = "MutExChkList(this);">
    </asp:ListItem>
    <asp:ListItem Text = "granulés" Value = "granulés" onclick = "MutExChkList(this);">
    </asp:ListItem>
	    <asp:ListItem Text = "ahsap" Value = "ahsap" onclick = "MutExChkList(this);">
    </asp:ListItem>
</asp:CheckBoxList>

<label>Consommation annuelle €</label>
<asp:TextBox ID="txtIsınmaYillikTuketim"  runat="server">0</asp:TextBox>

</div>
<h3>Diagnostics</h3>
<div class="teshisler">
<label>Diagnostics techniques fournis</label>
<table width="100%" class="teshislertablo">
<tr>
<td><asp:CheckBox ID="chckasbest"  runat="server" /> amiante </td>
<td><asp:CheckBox ID="chctermit"  runat="server" /> termite </td>
<td> <asp:CheckBox ID="chckursun"  runat="server" /> plomb</td>
</tr>
<tr>
<td><asp:CheckBox ID="chccarrez"  runat="server" /> carrez  </td>
<td> <asp:CheckBox ID="chccelectrik"  runat="server" /> éléctrique </td>
<td> <asp:CheckBox ID="chcgaz"  runat="server" /> gaz </td>
</tr>
</table>
 
 
 
 

 
<br/>

     <asp:TextBox ID="txtAciklama" runat="server" Width="100%" onkeypress="return this.value.length<=500"  rows="3" placeholder="Informations complémentaires : 500 caractères maximum" TextMode="MultiLine" MaxLength="500"></asp:TextBox>
</div>
     <br />
    <center> <asp:LinkButton ID="lnkDevami" CssClass="devami" OnClick="lnkDevami_Click" runat="server">Continuer</asp:LinkButton></center>
    </div>
</asp:Content>