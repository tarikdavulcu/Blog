using Microsoft.Web.Helpers;
using myblogNew.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace myblogNew.Controllers
{
    public class BlogController : Controller
    {
        myBlogContext context = new myBlogContext();
        ReCaptcha r = new ReCaptcha();

        // GET: Blog
        public ActionResult Index(string id)
        {
            ViewBag.ayarlar = context.SiteAyarlaris.ToList();

            var data = context.Blogs.ToList();

            if (id != null && id != "All")
            {
                data = context.Blogs.Where(p => p.Kullanicilar.KullaniciAdi == id).ToList();
            }
            else if (id == null)
            {
                data = context.Blogs.Take(2).ToList();
            }
            else if (id == "All")
            {
                data = context.Blogs.ToList();
            }
            return View(data);
        }

        public ActionResult Iletisim()
        {
            return View(context.SiteAyarlaris.ToList());
        }

        void MailGonderme(string body)
        {
            var kimden = new MailAddress("info@tarikdavulcu.com");
            var kime = new MailAddress("info@tarikdavulcu.com");
            const string konu = "Tarık Davulcu | Siteden Gelen | İletişim Formu";
            using (var smtp = new SmtpClient
            {
                Host = "webmail.tarikdavulcu.com",
                Port = 587,
                EnableSsl = false,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new System.Net.NetworkCredential(kimden.Address, "20342034T-d")
            })
            {
                using (var message = new MailMessage(kimden, kime) { Subject = konu, Body = body })
                {
                    smtp.Send(message);
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
            MailGonderme(body.ToString());
            
            return Redirect("/Blog/Iletisim");
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
            return View(context.Blogs.Where(p => p.SeoLink == id).ToList());
        }
    }
}