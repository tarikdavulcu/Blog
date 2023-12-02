using CaptchaMvc.HtmlHelpers;
using IronBarCode;
using Microsoft.Web.Helpers;
using myblogNew.Models;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.ServiceModel.Syndication;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Net.Codecrete.QrCodeGenerator;
using QRCoder;

namespace myblogNew.Controllers
{
    public class BlogController : MyController
    {
        myBlogContext context = new myBlogContext();
        // GET: Blog

        public ActionResult Index(string id)
        {
            ViewBag.ayarlar = context.SiteAyarlaris.ToList();

            var data = context.Blogs.OrderByDescending(i => i.BlogID).ToList();

            if (id != null && id != "All")
            {
                data = context.Blogs.Where(p => p.Kullanicilar.KullaniciAdi == id).OrderByDescending(i => i.BlogID).ToList();
            }
            else if (id == null)
            {
                data = context.Blogs.OrderByDescending(i => i.BlogID).ToList();
            }
            else if (id == "All")
            {
                data = context.Blogs.OrderByDescending(i => i.BlogID).ToList();
            }
            return View(data);
        }

        [AcceptVerbs(HttpVerbs.Post | HttpVerbs.Get)]

        public ActionResult ChangeLanguage(string lang)
        {
            new LanguageMang().SetLanguage(lang);
            return RedirectToAction("Index", "Blog");
        }

        public ActionResult Iletisim()
        {
            return View(context.SiteAyarlaris.ToList());
        }

        public string MailGondermeAsync(string body)
        {
            var kimden = new MailAddress("info@tarikdavulcu.com");
            var kime = new MailAddress("info@tarikdavulcu.com");
            const string konu = "Tarık Davulcu | Siteden Gelen | İletişim Formu";
            using (var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new System.Net.NetworkCredential(kimden.Address, "dbjt gkbx addy pfpf")
            })
            {
                using (var message = new MailMessage(kimden, kime) { Subject = konu, Body = body })
                {
                    try
                    {
                        smtp.Send(message);
                        return "E-Posta gönderildi. En kısa sürede sizinle iletişime geçilecektir.";

                    }
                    catch (Exception ex)
                    {

                        return "Error: " + ex.Message.ToString();
                    }
                }
            }
        }
        public ActionResult Header()
        {
            return PartialView(context.SiteAyarlaris.ToList());
        }
        [HttpPost]
        public ActionResult SendMail(FormCollection mesaj)
        {
            if (this.IsCaptchaValid("Captcha is not valid"))
            {
                //captcha verisi doğruysa yapılacaklar
                Mesajlar m = new Mesajlar();
                m.Ad = mesaj["name"].ToString();
                m.Mail = mesaj["email"].ToString();
                m.Mesaj = mesaj["message"].ToString();
                m.Telefon = mesaj["phone"].ToString();
                context.Mesajlars.Add(m);
                context.SaveChanges();

                //mail gönderme işlemi yapacağız
                var body = new StringBuilder();
                body.AppendLine("Gönderen :" + mesaj["name"].ToString());
                body.AppendLine("Mail Adresi :" + mesaj["email"].ToString());
                body.AppendLine("Tel :" + mesaj["phone"].ToString());
                body.AppendLine("Mesaj :" + mesaj["message"].ToString());
                TempData["Ret"] = MailGondermeAsync(body.ToString());
                return RedirectToAction("Index", "Blog");
            }
            else
            {
                return RedirectToAction("Index", "Blog");
            }
        }
        public ActionResult Title()
        {
            ViewBag.ayarlar = context.SiteAyarlaris.ToList();
            return PartialView(ViewBag.ayarlar);
        }
        public ActionResult Menu()
        {
            ViewBag.ayarlar = context.SiteAyarlaris.ToList();
            return PartialView((from i in context.Menus orderby i.SiraNo ascending select i).ToList());
        }

        public ActionResult Footer()
        {
            return PartialView(context.SiteAyarlaris.ToList());
        }





        public ActionResult Hakkimda()
        {
            return View(context.SiteAyarlaris.ToList());
        }

        public ActionResult Detayi(string id)
        {
            var r = context.Blogs.Where(p => p.SeoLink == id).ToList();
            if (r.Count > 0)
            {
                ViewBag.Title = r[0].Baslik;
                return View(r);
            }
            else return RedirectToAction("Error");
        }
        public ActionResult Error()
        {

            Response.StatusCode = 404;
            Response.TrySkipIisCustomErrors = true;
            return View();
        }


        public ActionResult RssFeed()
        {
            SyndicationFeed feed = null;
            string siteTitle, description, siteUrl;
            siteTitle = "Blog";
            siteUrl = "https://www.tarikdavulcu.com";
            description = "Welcome to the tarikdavulcu.com!";


            List<SyndicationItem> items = new List<SyndicationItem>();
            //Last 10 Post
            var c = context.Blogs.OrderByDescending(a => a.BlogID).Take(10).ToList();
            foreach (var i in c)
            {
                SyndicationItem item = new SyndicationItem
                {
                    Title = new TextSyndicationContent(i.Baslik),
                    Content = new TextSyndicationContent(GetPlainText(i.Icerik, 200)), //here content may be Html content so we should use plain text
                    PublishDate = DateTimeOffset.Parse(i.PostTarihi.ToString()),
                };
                item.Links.Add(new SyndicationLink(new Uri(Request.Url.Scheme + "://" + Request.Url.Host + i.SeoLink)));
                items.Add(item);
            }
            feed = new SyndicationFeed(siteTitle, description, new Uri(siteUrl));
            feed.Items = items;
            return new RSSResult { feedData = feed };
        }
        private string GetPlainText(string htmlContent, int length = 0)
        {
            string HTML_TAG_PATTERN = "<.*?>";
            string plainText = Regex.Replace(htmlContent, HTML_TAG_PATTERN, string.Empty);
            return length > 0 && plainText.Length > length ? plainText.Substring(0, length) : plainText;
        }
        public ActionResult Qr()
        {
          var res=  GetDatabaseQrList();

            
            //ImageGeneratedBarcode.ImageUrl = "~/GeneratedQRcodeImage/" + Path.GetFileName(filePath);


            return View(res);
        }
        public List<QrModel> GetDatabaseQrList()
        {
            List<QrModel> list = new List<QrModel>();

            // Open connection to the database
            string conString = "Server=78.135.85.53,1444;Database=MyBlog;uid=sa;Pwd=20342034T-d?;";

            using (SqlConnection con = new SqlConnection(conString))
            {
                con.Open();

                // Set up a command with the given query and associate
                // this with the current connection.
                using (SqlCommand cmd = new SqlCommand("SELECT * from Qr", con))
                {
                    using (IDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            QrModel nq = new QrModel();
                            nq.Id = int.Parse(dr[0].ToString());
                            nq.Title = dr[1].ToString();
                            nq.Desc = dr[2].ToString();
                            nq.Stock = dr[3].ToString();
                            nq.QrCode = dr[4].ToString();
                            list.Add(nq);
                        }
                    }
                }
            }
            return list;

        }
        public QrModel GetDatabaseQrDetail(int id)
        {
            QrModel nq = new QrModel();

            // Open connection to the database
            string conString = "Server=78.135.85.53,1444;Database=MyBlog;uid=sa;Pwd=20342034T-d?;";

            using (SqlConnection con = new SqlConnection(conString))
            {
                con.Open();

                // Set up a command with the given query and associate
                // this with the current connection.
                using (SqlCommand cmd = new SqlCommand("SELECT * from Qr where id="+id, con))
                {
                    using (IDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            nq.Id = int.Parse(dr[0].ToString());
                            nq.Title = dr[1].ToString();
                            nq.Desc = dr[2].ToString();
                            nq.Stock = dr[3].ToString();
                            nq.QrCode = dr[4].ToString();
                        }
                    }
                }
            }
            return nq;

        }
        public ActionResult QrAdd() {
            return View();
        }
        public ActionResult QrDetail(int id) {
            var r = GetDatabaseQrDetail(id);
            if(r.Id == 0)  return RedirectToAction("Error");
            else return View(GetDatabaseQrDetail(id));
        }

        [HttpPost]
        public ActionResult QrAdd(FormCollection val)
        {
            var tit=val["Title"].ToString();
            var desc=val["Desc"].ToString();
            var stock=val["Stock"].ToString();



            string _connStr = "Server=78.135.85.53,1444;Database=MyBlog;uid=sa;Pwd=20342034T-d?;";
            string _query = "INSERT INTO Qr (Title,[Desc],Stock) values (@Title,@Desc,@Stock); SELECT SCOPE_IDENTITY();";
            using (SqlConnection conn = new SqlConnection(_connStr))
            {
                using (SqlCommand comm = new SqlCommand())
                {
                    comm.Connection = conn;
                    comm.CommandType = CommandType.Text;
                    comm.CommandText = _query;
                    comm.Parameters.AddWithValue("@Title", tit);
                    comm.Parameters.AddWithValue("@Desc", desc);
                    comm.Parameters.AddWithValue("@Stock", stock);
                    try
                    {
                        conn.Open();
                        int id = Convert.ToInt32 (comm.ExecuteScalar());
                        
                        conn.Close();
                        string _queryy = "Update Qr Set QrCode=@QrCode where Id=" + id.ToString();
                        using (SqlCommand commm = new SqlCommand())
                        {
                            commm.Connection = conn;
                            commm.CommandType = CommandType.Text;
                            commm.CommandText = _queryy;



                           



                            string generatebarcode = "GeneratedQRcodeImage/"+id+".png";
                            string host = HttpContext.Request.Url.Authority.ToString();
                            string generatebarcode2 = host+"/Blog/QrDetail/"+id;
                            //GeneratedBarcode barcode = QRCodeWriter.CreateQrCode(generatebarcode2, 300);

                            string filePath = Server.MapPath(generatebarcode);
                             
                            using (QRCodeGenerator qrGenerator = new QRCodeGenerator())
                            using (QRCodeData qrCodeData = qrGenerator.CreateQrCode(generatebarcode2, QRCodeGenerator.ECCLevel.Q))
                            using (QRCode qrCode = new QRCode(qrCodeData))
                            {
                                Bitmap qrCodeImage = qrCode.GetGraphic(20);
                                qrCodeImage.Save(filePath, System.Drawing.Imaging.ImageFormat.Png);

                                

                                

                            }

                            // Styling a QR code and adding annotation text
                            //barcode.AddBarcodeValueTextAboveBarcode();
                            //barcode.AddBarcodeValueTextBelowBarcode();
                            //barcode.SetMargins(10);
                            //barcode.ChangeBarCodeColor(Color.BlueViolet);

                            //Create a folder to place generated QR code
                            var folder = Server.MapPath("/App_Data/GeneratedQRcodeImage");
                            if (!Directory.Exists(folder))
                            {
                                Directory.CreateDirectory(folder);
                            }
                            //barcode.SaveAsPng(filePath);
                            commm.Parameters.AddWithValue("@QrCode", generatebarcode);



                            try
                            {
                                conn.Open();
                                var aa = commm.ExecuteNonQuery();
                                conn.Close();
                            }
                            catch(SqlException ex) { 
                            
                            }
                            }
                                return RedirectToAction("Qr", "Blog");
                    }
                    catch (SqlException ex)
                    {
                        // other codes here
                        // do something with the exception
                        // don't swallow it.
                    }
                }
            }
            return View();
        }

        public class QrModel { 
        public int Id { get; set; }
        public string Title { get; set; }
        public string Desc { get; set; }
        public string Stock { get; set; }
        public string QrCode { get; set; }
    }
    }
}
