using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Net.Mail;
using System.Net;
using System.IO;
using System.Data.SqlClient;

public partial class SifreSifirlama : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack) return;
    }
    protected void btnGonder_Click(object sender, EventArgs e)
    {
        UyeIslem yeni = new UyeIslem();
        var sonuc=yeni.SifremiUnuttum(txtEmail.Text);
 
        if (sonuc.Basarilimi )//Eger sistemde girilen email varsa
        {

            string body = string.Empty;
            using (StreamReader reader = new StreamReader(Server.MapPath("~/MailSablon/mailsablonsifresifirlama.htm")))
            {
                body = reader.ReadToEnd();
            }


            body = body.Replace("{AdSoyad}", sonuc.Veri.Adi+" "+sonuc.Veri.Soyadi );
            body = body.Replace("{Sifre}", sonuc.Veri.Sifre );
            body = body.Replace("{Mail}", sonuc.Veri.Eposta);

            MailMessage mesaj = new MailMessage();
            mesaj.To.Add(new MailAddress(txtEmail.Text)); //Mailin kime gönderileceği
            mesaj.From = new MailAddress("no-reply@adhibe-property.com", "Adhibe-Property", System.Text.Encoding.UTF8);//Mailin kimden gönderileceği.
            mesaj.Subject = "Adhibe Kullanıcı Bilgileri";//Mailin konusu.
            mesaj.Body = body;
            mesaj.IsBodyHtml = true;
            
            
            //Mail içeriği.
            SmtpClient client = new SmtpClient();
            client.Host = "smtp.adhibe-property.com";//Gmailin kullandığı adres.
            client.Port = 587;
            client.Credentials = new NetworkCredential("no-reply@adhibe-property.com", "Adhibe6541");
            client.EnableSsl = false;
            try
            {
                client.Send(mesaj);//Yukarıda oluşturdugumuz maili gönderiyoruz.
                lblbilgi.Text = "Şifreniz e-mail adresinize gönderilmiştir.";
            }
            catch
            {
                lblbilgi.Text = "Mesaj gönderilirken bir hata oluştu.";
            }
        }
        else
        {
            lblbilgi.Text = "E-mail adresi bulunamadı."; //Kayıtlı bir adres yoksa bilgi labelimize yazdırıyoruz.
        }
         
        System.Threading.Thread.Sleep(2000);//İşlemi 2 saniyeliğine askıya alıyoruz.
    }
}