<%@ Control Language="C#" AutoEventWireup="true" CodeFile="BreadCrumb.ascx.cs" Inherits="uc_BreadCrumb" %>
<ul class="breadcrumb">
    <li><a href="." title="Ana Sayfa">Ana Sayfa</a></li>
    <asp:Repeater ID="Repeater_breadcrumb" runat="server">
        <ItemTemplate>
            <li itemtype="http://data-vocabulary.org/Breadcrumb" itemscope="" >
                <a title='<%# Eval("Text").ToString() %>' itemprop="url" href='<%# Eval("Link").ToString() %>'>
                    <span itemprop="title"><%# Eval("Text").ToString() %></span>
                </a>
            </li>
        </ItemTemplate>
    </asp:Repeater>
</ul>
