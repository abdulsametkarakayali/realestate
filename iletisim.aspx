<%@ Page Title="" Language="C#" MasterPageFile="~/Tema.master" AutoEventWireup="true" CodeFile="iletisim.aspx.cs" Inherits="iletisim" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
     <title>Adhibe Property | IMMOBILIER - Annonces immobilières | | De Particulier à Particulier</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="iletisimalani">
      
     <div class="col-md-6  col-sm-12  col-xs-12">
         <asp:Panel ID="pnlBasarili" visible="false" runat="server">
            <div class="alert alert-success">
          <strong>Başarılı!</strong> <asp:Label ID="lblBasarili" runat="server" Text=""></asp:Label>
              
        </div>
    </asp:Panel>
         <asp:Panel ID="pnlBasarisiz" visible="false" runat="server">
            <div class="alert alert-danger">
          <strong>Hata!</strong> <asp:Label ID="lblBasarisiz" runat="server" Text=""></asp:Label>
              
        </div>
    </asp:Panel>
         <div class="contact-form bottom">
             <h4>Contacter par e-mail</h4>
             
                 <div class="form-group">
                     <asp:TextBox ID="txtAd"  class="form-control" required="required"   placeholder="Votre Nom"  runat="server"></asp:TextBox> 
                    
                 </div>
                 <div class="form-group">
                      <asp:TextBox ID="txtTelefon"  class="form-control" required="required"   placeholder="Votre telephone"  runat="server"></asp:TextBox>
                    
                 </div>
                 <div class="form-group">
                      <asp:TextBox ID="txtEmail"  class="form-control" required="required"   placeholder="Votre e-mail"  runat="server"></asp:TextBox>
                   
                 </div>
                 <div class="form-group">
                      <asp:TextBox ID="txtMesaj"  class="form-control" required="required"   placeholder="Votre message"  runat="server" TextMode="MultiLine" Rows="3"></asp:TextBox>
                    
                 </div>
                 <div class="form-group">
                     <asp:Button ID="btnGonder"   class="btn btn-submit" OnClick="btnGonder_Click" runat="server" Text="Envoyer votre message"     />
                     
             
         </div>
     </div>
 </div>
</asp:Content>

