using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class iletisim : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnGonder_Click(object sender, EventArgs e)
    {
        int sonuc = SendMail();
        if (sonuc == 1)
        {

            pnlBasarili.Visible = true;
            lblBasarili.Text = "Mesajınız bize ulaşmıştır , en kısa sürede size geri dönüş yapılacaktır.";

        }
        else
        {
            pnlBasarisiz.Visible = true;
            lblBasarili.Text = "Bir hata ile karşılaşıldı.";
        }

    }
    public int SendMail()
    {
        // Gmail Address from where you send the mail
        var fromAddress = System.Configuration.ConfigurationManager.AppSettings["VeriyazEmailUserName"];
        // any address where the email will be sending
        var toAddress = "bilgi@linuxmail.org";
        //Password of your gmail address
        var fromPassword = System.Configuration.ConfigurationManager.AppSettings["VeriyazEmailPassword"];
        // Passing the values and make a email formate to display
        string subject = "İletişim Formu";
        string body = "From: " +ayarlar.Temizle(txtAd.Text) + "\n";
        body += "Votre Nom             : " + ayarlar.Temizle(txtAd.Text) + "\n";
        body += "Votre telephone             : " + ayarlar.Temizle(txtTelefon.Text) + "\n";
        body += "Votre e-mail   :" + ayarlar.Temizle(txtEmail.Text) + "\n";
        body += "Votre message      : " + ayarlar.Temizle(txtMesaj.Text) + "\n";
        // smtp settings
        var smtp = new System.Net.Mail.SmtpClient();
        {
            smtp.Host = System.Configuration.ConfigurationManager.AppSettings["VeriyazEmailHost"];
            smtp.Port = 587;
            smtp.EnableSsl = true;
            smtp.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
            smtp.Credentials = new NetworkCredential(fromAddress, fromPassword);
            smtp.Timeout = 20000;
        }
        // Passing values to smtp object
        smtp.Send(fromAddress, toAddress, subject, body);

        return 1;
    }
}