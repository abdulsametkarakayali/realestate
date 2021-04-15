<%@ Page Title="" Language="C#" EnableEventValidation="false"  MasterPageFile="~/Tema.master" AutoEventWireup="true" CodeFile="Rapor.aspx.cs" Inherits="Rapor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
 <title>
         <asp:Literal ID="ltlTitle" runat="server"></asp:Literal>   </title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div class="raporprint">
        <asp:LinkButton ID="PdfOlustur" OnClick="PdfOlustur_Click" runat="server"> <i class="fa fa-print"></i></asp:LinkButton> </div>
    <div class="raporAlani">
        <div class="raporsolalan fl">
            <div class="raporlogoalani fl"><img src="Tema/img/logo.jpg" /></div>
            <div class="raporsagalan1 fr">
			<br/><br/>
            <asp:Label ID="lblIslemTipi" runat="server" Text=""></asp:Label>
            <label>Vendu Libre le :</label> <asp:Label ID="lblUygunlukTarihi" runat="server" Text="—-"></asp:Label><br />
			<label>Vendu Loué :</label><asp:Label ID="lblSatilikKirada" runat="server" Text=" "></asp:Label><br/>
			<label>Loyer / mois (€)</label><asp:Label ID="lblAylikKira" runat="server" Text=" "></asp:Label><br/><br/>
			<label>Intérieur :</label><asp:Label ID="lblIcMekan" runat="server" Text=" "></asp:Label><br/>
            <label>Type de propriété :</label> <asp:Label ID="lblMulkiyetDurum" runat="server" Text=" "></asp:Label><br />
            <label>Année construction :</label> <asp:Label ID="lblBinaYasi" runat="server" Text=" "></asp:Label><br />
			 <label>Charges Co-propriété/an (€) :</label> <asp:Label ID="lblYillikAidat" runat="server" Text=" "></asp:Label><br />
			 <label>Surface du terrain en m2 :</label> <asp:Label ID="lblKullanimAlani" runat="server" Text=" "></asp:Label><br />
			<label>Taxe foncière annuelle (€) :</label> <asp:Label ID="lblYillikVergi" runat="server" Text=" "></asp:Label><br />        
            <label>Cuisine équipée :</label> <asp:Label ID="lblMutfakEkipmani" runat="server" Text=" "></asp:Label><br />
            <label>Cellier (m2):</label> <asp:Label ID="lblKiler" runat="server" Text=" "></asp:Label><br />
			<label>Placard intégré (chbre n°) :</label> <asp:Label ID="lblDolaplar" runat="server" Text=" "></asp:Label><br />
			 <label>Dressing (m2) :</label> <asp:Label ID="lblGiyinmeOdasi" runat="server" Text=" "></asp:Label><br />
            <label>Portail :</label> <asp:Label ID="lblBahceKapi" runat="server" Text=" "></asp:Label><br />
            <label>Fenêtres :</label> <asp:Label ID="lblPencereler" runat="server" Text=" "></asp:Label><br />
            <label>Volets :</label> <asp:Label ID="lblPanjurlar" runat="server" Text=" "></asp:Label><br />
            <label>Toiture :</label> <asp:Label ID="lblCati" runat="server" Text=" "></asp:Label><br />
            <label>Charpente :</label> <asp:Label ID="lblCatiIskeleti" runat="server" Text=" "></asp:Label><br />
            <label>Façade :</label> <asp:Label ID="lblDisKaplama" runat="server" Text=" "></asp:Label><br />
            <label>Clôture :</label> <asp:Label ID="lblBahceDuvari" runat="server" Text=" "></asp:Label><br />
            <label>Interphone :</label> <asp:Label ID="lblInterphone" runat="server" Text=" "></asp:Label><br />
            <label>Alarme :</label> <asp:Label ID="lblAlarm" runat="server" Text=" "></asp:Label><br />
            <label>Parabole :</label> <asp:Label ID="lblUydu" runat="server" Text=" "></asp:Label><br />
            <label>Antenne TV :</label> <asp:Label ID="lblAnten" runat="server" Text=" "></asp:Label><br />
            <label>Cheminée foyer ouvert :</label> <asp:Label ID="lblSomine1" runat="server" Text=" "></asp:Label><br />
            <label>Insert :</label> <asp:Label ID="lblSomine2" runat="server" Text=" "></asp:Label><br />
            <label>Combles aménagées (m2) :</label> <asp:Label ID="lblCatiKati" runat="server" Text=" "></asp:Label><br />
            <label>Cave (m2) :</label> <asp:Label ID="lblBodrum" runat="server" Text=" "></asp:Label><br />
            <label>Garage (m2) :</label> <asp:Label ID="lblGaraj" runat="server" Text=" "></asp:Label><br />
            <label>Parking :</label> <asp:Label ID="lblParkYeri" runat="server" Text=" "></asp:Label><br />
            <label>Piscine (dimensions) :</label> <asp:Label ID="lblHavuz" runat="server" Text="---"></asp:Label><br />
            <label>Evacuation des eaux usées :</label> <asp:Label ID="lblSuOlcumleri" runat="server" Text=" "></asp:Label><br />
        </div>
            </div>
        <div class="raporsagalan fr">

            <div class="ustbilgialani">
                <ul class="raporbilgi">
                    <li class="ilkbolum"><asp:Label ID="lblYasamAlani" runat="server" Text=" "></asp:Label> m<sup>2</sup></li>
                    <li><label>Pièces :</label> <asp:Label ID="lblOda" runat="server" Text=" "></asp:Label>  <br />
                        <label>Chambres :</label> <asp:Label ID="lblYatakOdasi" runat="server" Text=" "></asp:Label>
                    </li>
                    <li><asp:Label ID="lblKatNo" runat="server" Text=" "></asp:Label><br />
                       <asp:Label ID="lblAsansor" runat="server" Text=""></asp:Label>
                    </li>
                    <li><asp:Label ID="lblFiyat" runat="server" Text=" "></asp:Label></li>
                </ul>

            </div>
               <div class="raporresimalani clr">
                   <asp:Image ID="imgRapor" runat="server" />   

               </div>

            <div class="mulkiyetbilgileri clr">
                 
                <div class="mulkiyetsahibi  "> 
                    <h4><asp:Label ID="lblUyeTipeGoreBaslik" runat="server" Text=""></asp:Label></h4>
                    <asp:Panel ID="PnlKurumsal" Visible="false" runat="server">
                        Référence :<asp:Label ID="lblRef" runat="server" Text=""></asp:Label><br />
                        Agence Immobilière :<asp:Label ID="lblFirmaAdi" runat="server" Text=""></asp:Label><br/>
                        Téléphone PortableTél. : <asp:Label ID="lblIletisimTel1" runat="server" Text=""></asp:Label><br />
                        Téléphone Fixe : <asp:Label ID="lblFax" runat="server" Text=""></asp:Label><br />
                        E-mail : <asp:Label ID="lblMail" runat="server" Text=""></asp:Label><br />
                    </asp:Panel>
                    <asp:Panel ID="PnlBireysel" Visible="false" runat="server">
					 Tél. : <asp:Label ID="lblIletisimTelBireysel" runat="server" Text=""></asp:Label><br />
					  E-mail : <asp:Label ID="lblMailBireysel" runat="server" Text=""></asp:Label><br />
                    </asp:Panel>
					 
					
					 <asp:Label ID="lblIletisimBilgileri" runat="server" Text=""></asp:Label>
                    
                   
                    <br />
                    
                </div>

            </div>

            <div class="raporozelikleri clr">
                <div class="raporisitma fl">
                    <h4>Chauffage</h4>
                    <label>Année chaudière :</label> <asp:Label ID="lblIsiYasi" runat="server" Text=" "></asp:Label><br />
					<label>Chauffage :</label> <asp:Label ID="lblIsitma" runat="server" Text=" "></asp:Label><br />
                     <label>Type de chauffage :</label> <asp:Label ID="lblIsinmaTipi" runat="server" Text=" "></asp:Label><br />
					 <label>Type d'énergie :</label> <asp:Label ID="lblEnerjiTip" runat="server" Text=" "></asp:Label><br />
                     <label>Conso. / an (€) :</label> <asp:Label ID="lblYillikTuketim" runat="server" Text=" "></asp:Label><br />
                     <label>Etat général :</label> <asp:Label ID="lblGenelDurum" runat="server" Text=" "></asp:Label><br />

                </div>
                <div class="raporteshisler fr"> 
                    <h4>Diagnostics fournis</h4>
                <label>Classe énergie</label> <asp:Label ID="lblEnerjiSinifiHarf" runat="server" Text=" "></asp:Label>
              <asp:Label ID="lblEnerjiSinifiNumara" runat="server" Text=" "></asp:Label>  kWhEP/m2/an<br />
                    <label>Emission  GES </label> <asp:Label ID="lblEmisyonHaft" runat="server" Text=" "></asp:Label> <asp:Label ID="lblEmisyonNumara" runat="server" Text=" "></asp:Label> kgéqCO2/m2/an <br />
                   <br/> 
				   <div class="raporteshisdetay fl">
                         <label>Amiante :</label> <asp:Label ID="lblAmiante" runat="server" Text=" "></asp:Label><br />
						 <label>Termite :</label> <asp:Label ID="lblTermite" runat="server" Text=" "></asp:Label><br />
						 <label>Eléctrique :</label> <asp:Label ID="lblElectriq" runat="server" Text=" "></asp:Label><br />
                    </div>
                    <div class="raporteshisdetay fr">
                        <label>Plomb :</label> <asp:Label ID="lblPlom" runat="server" Text=" "></asp:Label><br />
						<label>Carrez :</label> <asp:Label ID="lblCarrez" runat="server" Text=" "></asp:Label><br />
						<label>Gaz   :</label> <asp:Label ID="lblGaz" runat="server" Text=" "></asp:Label><br />
                    </div>
                   
                </div>

            </div>
             <div class="clr"></div>
             
            
             <br />
           
             
            
            
             
            
        </div>
        <div class="rapordetay clr">
            <div class="konutdetaylari rapor clr">
            
            <table class="bordered" style="100%">
	            <tr class="ilkincitablo">
		            <td width="15%">PIECES</td>
		            <td width="5%">M2</td>
		            <td width="14%">NIVEAU</td>
		            <td width="13%">ORIENTATION</td>
		            <td width="13%">SOL</td>
		            <td width="9%">FENÊTRE</td>
		            <td width="14%">VITRAGE</td>
		            <td width="240">VOLETS</td>
	            </tr>
                  <tr>
                  <asp:DataList ID="dtlKonutDetay"  runat="server" ItemType="NKonutDetay">
                      <ItemTemplate>
		                    <td width="15%"><%# Item.Odalar %></td>
		                    <td  width="5%"><%# Item.m2 %></td>
		                    <td width="14%"><%# Item.Kat %></td>
		                    <td width="13%"><%# Item.Yon %></td>
		                    <td width="13%"><%# Item.YerDoseme %></td>
		                    <td width="9%"><%# Item.Cerceveler %></td>
		                    <td width="14%"><%# Item.Camlar %></td>
		                    <td width="240"><%# Item.Panjur %></td>
	       
                    </ItemTemplate>
          
                </asp:DataList>
                      </tr>
            </table>
            </div>
        </div>
    </div>
</asp:Content>

