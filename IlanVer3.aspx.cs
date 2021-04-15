using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class IlanVer3 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
		  if (IsPostBack) return;
        YetkiKontrol();
    }
	 protected void YetkiKontrol()
    {
        if (Session[SiteTanim.QSKullaniciSession] != null)
        {
            if (((NuyeBilgi)Session[SiteTanim.QSKullaniciSession]).UyeTip == (int)UyeTip.Bireysel)
            {
               pnlKurumsalUyeResim.Visible = true;
            }
            else if (((NuyeBilgi)Session[SiteTanim.QSKullaniciSession]).UyeTip == (int)UyeTip.Kurumsal)
            {
               Response.Write(Fonksiyon.MesajBox("İlanınız başarıyla eklendi", "/Default.aspx"));
            }
            else
            {
                //pnlOdemeBireysel.Visible = false;
            }
           
        }
        else
        {
            Response.Redirect("/UyeGiris.aspx");
        }

    }
     protected void lnkOnaylaveOde_Click(object sender, EventArgs e)
     {
		 
		  IlanIslem yeniilan = new IlanIslem();
		  int ilanId  = Convert.ToInt32(Session[SiteTanim.QSIlanID]);
		  
		 if (((NuyeBilgi)Session[SiteTanim.QSKullaniciSession]).UyeTip == (int)UyeTip.Bireysel)
            {
			   
        Fonksiyon yenikucukresim = new Fonksiyon();
        if (FileUpload1.HasFile)
        {
            string kresim = string.Empty;
            string bresim = string.Empty;
            Bitmap yeniresim = null;
            Bitmap byeniresim = null;
            try
            {
               
                
                IList<HttpPostedFile> SecilenDosyalar = FileUpload1.PostedFiles;
                if (!Directory.Exists(HttpContext.Current.Server.MapPath("/Dosya/IlanResim/" + ilanId + "/")))
                    Directory.CreateDirectory(HttpContext.Current.Server.MapPath("/Dosya/IlanResim/" + ilanId + "/"));
                if (!Directory.Exists(HttpContext.Current.Server.MapPath("/Dosya/IlanResim/" + ilanId + "/thump/")))
                    Directory.CreateDirectory(HttpContext.Current.Server.MapPath("/Dosya/IlanResim/" + ilanId + "/thump/"));
                for (int i = 0; i < SecilenDosyalar.Count; i++)
                {
                    FileUpload1.PostedFiles[i].SaveAs(Server.MapPath("/Dosya/IlanResim/" + ilanId + "/") + FileUpload1.PostedFiles[i].FileName);
                    
                     
                    yeniresim = yenikucukresim.resim_boyulandir(FileUpload1.PostedFiles[i].InputStream, 210, 130);//yeni resim için boyut veriyoruz..
                    kresim = Server.MapPath("/Dosya/IlanResim/" + ilanId + "/thump/") +  FileUpload1.PostedFiles[i].FileName;
                    yeniresim.Save(kresim, ImageFormat.Jpeg);

                    NResimler resimkaydet = new NResimler 
                    {
                        Resim = ("/Dosya/IlanResim/" + ilanId + "/") + FileUpload1.PostedFiles[i].FileName,
                         Thumb=("/Dosya/IlanResim/" + ilanId + "/thump/") +  FileUpload1.PostedFiles[i].FileName,
                         IlanId=ilanId
                    };
                   yeniilan.ResimKaydet(resimkaydet);
                
                }
				 
                      Response.Redirect("/ilanonay.aspx");
                 
            }
            catch (Exception ex)
            {
                Response.Write("Hata Oluştu: " + ex.Message.ToString());
            }
            finally
            {
                kresim = string.Empty;
                yeniresim.Dispose();
            }
        }
		
		}

     }
}