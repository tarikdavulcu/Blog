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
            var kimden = new MailAddress("tarikdavulcu@gmail.com");
            var kime = new MailAddress("tarikdavulcu@gmail.com");
            const string konu = "Tarık Davulcu | Siteden Gelen | İletişim Formu";
            using (var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new System.Net.NetworkCredential(kimden.Address, "ltco utxx vetl pwcv")
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
    }
}
