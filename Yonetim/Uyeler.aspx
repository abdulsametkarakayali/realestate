<%@ Page Title="" Language="C#" MasterPageFile="~/Yonetim/Yonetim.master" AutoEventWireup="true" CodeFile="Uyeler.aspx.cs" Inherits="Yonetim_Uyeler" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
         <div class="col-md-12">
              <div class="box">
                <div class="box-header with-border">
                  <h3 class="box-title">Uyelik Listesi</h3>
                </div><!-- /.box-header -->
                <div class="box-body">
                  <table class="table table-bordered">
                    <tr>
                      
                      <th>Ad</th>
                      <th>SoyAd</th>
                        <th>SirketIsmi</th>
                      <th>Telefon</th>
                      <th>Email</th>
                      <th >UyeTip</th>
                      <th>KayitTarihi</th>
					  <th>Parola</th>
                    </tr>
                  <asp:Repeater ID="rptUyeler" runat="server">
                      <ItemTemplate>
                    <tr>
                       
                      <td> <%# Eval("Adi") %></td>
                      <td> <%# Eval("Soyadi") %> </td>
                        <td> <%# Eval("SirketIsmi") %> </td>
                      <td><%# Eval("Telefon") %>   </td>
                       <td> <%# Eval("Eposta") %> </td>
                       <td> <%#Convert.ToInt32(Eval("UyeTip"))==1?"Bireysel":"PRO" %> </td>
					   <td><%# Convert.ToDateTime(Eval("KayitTarih")).ToString("d") %></td>
					<td> <%# Eval("Sifre") %> </td>
                        <td ><ul  class="islemler">
                           <li> <a href="/Yonetim/KitapEkle.aspx" class="islem" ><i class="fa fa-plus"></i></a></li>
                           <li><a href="#" class="islem" >  <i class="fa fa-pencil-square-o"></i></a> </li>
                           <li><a href="#" class="islem" >  <i class="fa fa-trash"></i></a>  </li></ul></td>
                    </tr>
                          </ItemTemplate>
                  </asp:Repeater>

                  </table>
                </div><!-- /.box-body -->
</asp:Content>

