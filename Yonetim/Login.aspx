<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Yonetim_Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Adhibe Admin Panel</title>
     <link rel="stylesheet" href="css/style.css">
        <link rel="stylesheet" href="http://fonts.googleapis.com/css?family=Varela+Round">

    <!--[if lt IE 9]>
  <script src="http://html5shiv.googlecode.com/svn/trunk/html5.js"></script>
 <![endif]-->
</head>
<body>
   
    <div class="container">

      <div id="login">

        <h2><span class="fontawesome-lock"></span>Adhibe Admin Panel</h2>

      <form id="frm" runat="server">

          <fieldset>
        <asp:Label ID="lblHata" runat="server" Text=""></asp:Label>
            <p><label for="email">Email</label></p>
            <p><input type="text" id="KullaniciAdi" placeholder="Admin" runat="server"></p>

            <p><label for="password">Parola</label></p>
            <p><input type="password" id="password" placeholder="Parola" runat="server"></p>

            <p>
                <asp:Button ID="btnGiris" type="submit" runat="server" Text="Giris" OnClick="btnGiris_Click" />
            </p>

          </fieldset>

        </form>

      </div> <!-- end login -->

    </div>


</body>
</html>
