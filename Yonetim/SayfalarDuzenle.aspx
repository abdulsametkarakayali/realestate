<%@ Page Title="" Language="C#" MasterPageFile="~/Yonetim/Yonetim.master" AutoEventWireup="true" CodeFile="SayfalarDuzenle.aspx.cs" Inherits="Yonetim_SayfalarDuzenle" %>

<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
     <div class="col-md-2"></div>
     <div class="col-md-8">
         <asp:Panel ID="pnlBasarili" visible="false" runat="server">
        <div class="alert alert-success alert-dismissable">
          <button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>
            <h4><i class="icon fa fa-check"></i> Basarili!</h4>
            <asp:Label ID="lblMesajBasarili" runat="server" Text=""></asp:Label>
          </div>
    </asp:Panel>
    <asp:Panel ID="pnlBasarisiz" visible="false" runat="server">
      <div class="alert alert-danger alert-dismissable">
        <button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>
        <h4><i class="icon fa fa-ban"></i> Uyarı!</h4>
          <asp:Label ID="lblMesajBasarisiz" runat="server" Text=""></asp:Label>
      </div>

    </asp:Panel>
         
          <asp:UpdatePanel ID="UpdatePanel1" runat="server"> 
              <ContentTemplate>
                <div class="form-group">
           <label for="KategoriAdi">Sayfa Seç</label><br />
   
       <asp:DropDownList ID="drpKategoriler"   class="form-control" runat="server"   OnSelectedIndexChanged="drpKategoriler_SelectedIndexChanged" AutoPostBack="True">
          <asp:ListItem Value=""></asp:ListItem>
      </asp:DropDownList>
        </div>
       <div class="form-group">
                   <label for="SayfaAciklama">Sayfa Ad</label><br />
                  <asp:TextBox ID="txtSayfaAdi" Width="100%" runat="server" ></asp:TextBox>
               </div>
              <div class="form-group">
                   <label for="SayfaAciklama">Sayfa Açıklama</label><br />
                  <asp:TextBox ID="txtSayfaAciklama" Width="100%" runat="server" Rows="3" TextMode="MultiLine"></asp:TextBox>
               </div>
         <CKEditor:CKEditorControl ID="CkeSayfaIcerik" runat="server"></CKEditor:CKEditorControl>
         
          <div class="box-footer">
            <asp:Button ID="SayfaDuzenle" class="btn btn-primary" OnClick="SayfaDuzenle_Click"   runat="server" Text="Sayfa Düzenle" />
        </div>
     </div>
          </ContentTemplate>
    </asp:UpdatePanel>
    </div>  
     <div class="col-md-2"></div>

</asp:Content>

