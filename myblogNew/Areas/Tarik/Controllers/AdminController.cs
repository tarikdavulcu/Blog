using myblogNew.Areas.Tarik.Models;
using myblogNew.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace myblogNew.Areas.Tarik.Controllers
{
    [security]
    public class AdminController : Controller
    {
        myblogNew.Models.myBlogContext data = new myblogNew.Models.myBlogContext();
        // GET: Tarik/Admin

        public ActionResult Index()
        {
            int[] count = new int[4];
            count[0] = data.Blogs.Count();
            count[1] = data.Kullanicilars.Count();
            count[2] = data.Mesajlars.Count();
            count[3] = data.SiteAyarlaris.Count();
            return View(count);
        }
        public ActionResult Kullanicilar(string id)
        {
            if (id == null || id == "")
            {
                return View(data.Kullanicilars.ToList());
            }
            else
            {
                int a = int.Parse(RouteData.Values["id"].ToString());
                var ku = data.Kullanicilars.Where(p => p.KullaniciID == a).FirstOrDefault();
                data.Kullanicilars.Remove(ku);
                data.SaveChanges();
                return Redirect("/Tarik/Admin/Kullanicilar");
            }
        }
        public ActionResult KullaniciDetayi(string id)
        {
            int idd = 0;
            if (id != null)
            {
                idd = Convert.ToInt32(id);
            }
            return View(data.Kullanicilars.Where(p => p.KullaniciID == idd).ToList());
        }
        //[HttpPost]
        //public ActionResult KullaniciSil(FormCollection kullanici)
        //{
        //    int a = int.Parse(RouteData.Values["id"].ToString());
        //    var ku = data.Kullanicilars.Where(p => p.KullaniciID == a).FirstOrDefault();
        //    data.Kullanicilars.Remove(ku);
        //    data.SaveChanges();
        //    return Redirect("/Tarik/Admin/Kullanicilar");
        //}
        [HttpPost]
        public ActionResult KullaniciGuncelle(FormCollection kullanici)
        {
            int a = int.Parse(RouteData.Values["id"].ToString());
            var ku = data.Kullanicilars.Where(p => p.KullaniciID == a).FirstOrDefault();
            ku.KullaniciAdi = kullanici["txtAdi"].ToString();
            ku.Mail = kullanici["txtMail"].ToString();
            data.SaveChanges();
            return Redirect("/Tarik/Admin/Kullanicilar");
        }
        [HttpPost]
        public ActionResult YeniKullanici(FormCollection kullanici)
        {
            Kullanicilar ku = new myblogNew.Models.Kullanicilar();
            ku.KullaniciAdi = kullanici["txtAdi"].ToString();
            ku.Mail = kullanici["txtMail"].ToString();
            data.Kullanicilars.Add(ku);
            data.SaveChanges();
            return Redirect("/Tarik/Admin/Kullanicilar");
        }



        public ActionResult Bloglar(string id)
        {
            if (id == null || id == "")
            {
                return View(data.Blogs.ToList());
            }
            else
            {
                int a = int.Parse(RouteData.Values["id"].ToString());
                var ku = data.Blogs.Where(p => p.BlogID == a).FirstOrDefault();
                data.Blogs.Remove(ku);
                data.SaveChanges();
                return Redirect("/Tarik/Admin/Bloglar");
            }
        }
        [ValidateInput(false)]
        public ActionResult BlogDetayi(string id)
        {
            int idd = 0;
            if (id != null)
            {
                idd = Convert.ToInt32(id);
            }
            return View(data.Blogs.Where(p => p.BlogID == idd).ToList());
        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult BlogGuncelle(FormCollection blog)
        {
            var k = data.Kullanicilars.Where(p => p.Mail == HttpContext.User.Identity.Name).FirstOrDefault();
            string filePath = "", type = "";
            string yeniAd = blog["txtAdi"].ToString().ToLower().Replace(" ", "-").Replace("ö", "o").Replace("Ö", "o").Replace("Ü", "u").Replace("ü", "u").Replace("ı", "i").Replace("I", "i").Replace("İ", "i").Replace("Ş", "s").Replace("ş", "s").Replace("Ğ", "g").Replace("ğ", "g");


            int a = int.Parse(RouteData.Values["id"].ToString());
            var bu = data.Blogs.Where(p => p.BlogID == a).FirstOrDefault();
            bu.Baslik = blog["txtAdi"].ToString();
            bu.AltBaslik = blog["txtMail"].ToString();
            bu.Icerik = blog["txtIcerik"].ToString();
            bu.SeoLink = blog["txtSeo"].ToString();
            bu.KullaniciID = k.KullaniciID;


            if (Request.Files.Count > 0)
            {
                foreach (string file in Request.Files)
                {
                    var resim = Request.Files[file];
                    if (resim.ContentLength > 0)
                    {
                        System.IO.File.Delete(Server.MapPath("~/" + bu.Resim));
                        type = resim.ContentType;
                        type = type.Replace("image/", ".");
                        filePath = Server.MapPath("~/Content/img/BlogResim/" + yeniAd + type);
                        Bitmap yeniResim = ImageReSize(resim.InputStream, 1024, 768);
                        yeniResim.Save(filePath);
                        bu.Resim = "Content/img/BlogResim/" + yeniAd + type;
                    }
                }
            }

            data.SaveChanges();
            return Redirect("/Tarik/Admin/Bloglar");
        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult YeniBlog(FormCollection blog)
        {
            var k = data.Kullanicilars.Where(p => p.Mail == HttpContext.User.Identity.Name).FirstOrDefault();
            string filePath = "", type = "";
            string yeniAd = blog["txtAdi"].ToString().ToLower().Replace(" ", "-").Replace("ö", "o").Replace("Ö", "o").Replace("Ü", "u").Replace("ü", "u").Replace("ı", "i").Replace("I", "i").Replace("İ", "i").Replace("Ş", "s").Replace("ş", "s").Replace("Ğ", "g").Replace("ğ", "g");

            if (Request.Files.Count > 0)
            {
                foreach (string file in Request.Files)
                {
                    var resim = Request.Files[file];
                    if (resim.ContentLength > 0)
                    {
                        type = resim.ContentType;
                        type = type.Replace("image/", ".");
                        filePath = Server.MapPath("~/Content/img/BlogResim/" + yeniAd + type);
                        Bitmap yeniResim = ImageReSize(resim.InputStream, 1024, 768);
                        yeniResim.Save(filePath);
                    }
                }
            }

            Blog bu = new myblogNew.Models.Blog();
            bu.Baslik = blog["txtAdi"].ToString();
            bu.AltBaslik = blog["txtMail"].ToString();
            bu.Icerik = blog["txtIcerik"].ToString();
            bu.SeoLink = blog["txtSeo"].ToString();
            bu.Resim = "Content/img/BlogResim/" + yeniAd + type;
            bu.KullaniciID = k.KullaniciID;
            data.Blogs.Add(bu);
            data.SaveChanges();



            return Redirect("/Tarik/Admin/Bloglar");
        }

        Bitmap ImageReSize(Stream resim, int genislik, int yukseklik)
        {
            Bitmap orjinalResim = new Bitmap(resim);
            int w = 0;
            w = orjinalResim.Width;
            int h = 0;
            h = orjinalResim.Height;
            double oran = Convert.ToDouble(w) / Convert.ToDouble(h);

            if (oran <= 1 && w > genislik)
            {
                w = genislik;
                h = Convert.ToInt32(Math.Round(decimal.Parse(w.ToString()) / genislik));
            }
            else if (oran > 1 && h > yukseklik)
            {
                h = yukseklik;
                w = Convert.ToInt32(Math.Round(decimal.Parse(h.ToString()) * yukseklik));
            }
            return new Bitmap(orjinalResim, genislik, yukseklik);
            //return new Bitmap(orjinalResim, w, h);

        }

        public ActionResult Mesajlar(string id)
        {
            if (id == null || id == "")
            {
                return View(data.Mesajlars.ToList());
            }
            else
            {
                int a = int.Parse(RouteData.Values["id"].ToString());
                var ku = data.Mesajlars.Where(p => p.MesajID == a).FirstOrDefault();
                data.Mesajlars.Remove(ku);
                data.SaveChanges();
                return Redirect("/Tarik/Admin/Mesajlar");
            }
        }
        public ActionResult MesajDetayi(string id)
        {
            int idd = 0;
            if (id != null)
            {
                idd = Convert.ToInt32(id);
            }
            return View(data.Mesajlars.Where(p => p.MesajID == idd).ToList());
        }
        [HttpPost]
        public ActionResult MesajGuncelle(FormCollection mesaj)
        {
            int a = int.Parse(RouteData.Values["id"].ToString());
            var me = data.Mesajlars.Where(p => p.MesajID == a).FirstOrDefault();
            me.Ad = mesaj["txtAdi"].ToString();
            me.Mail = mesaj["txtMail"].ToString();
            me.Telefon = mesaj["txtTelefon"].ToString();
            me.Mesaj = mesaj["txtMesaj"].ToString();
            data.SaveChanges();
            return Redirect("/Tarik/Admin/Mesajlar");
        }
        [HttpPost]
        public ActionResult YeniMesaj(FormCollection mesaj)
        {

            Mesajlar me = new myblogNew.Models.Mesajlar();
            me.Ad = mesaj["txtAdi"].ToString();
            me.Mail = mesaj["txtMail"].ToString();
            me.Telefon = mesaj["txtTelefon"].ToString();
            me.Mesaj = mesaj["txtMesaj"].ToString();
            data.Mesajlars.Add(me);
            data.SaveChanges();
            return Redirect("/Tarik/Admin/Mesajlar");
        }



        public ActionResult Menu(string id)
        {
            if (id == null || id == "")
            {
                return View(data.Menus.ToList());
            }
            else
            {
                int a = int.Parse(RouteData.Values["id"].ToString());
                var me = data.Menus.Where(p => p.MenuID == a).FirstOrDefault();
                data.Menus.Remove(me);
                data.SaveChanges();
                return Redirect("/Tarik/Admin/Menu");
            }
        }
        public ActionResult MenuDetayi(string id)
        {
            int idd = 0;
            if (id != null)
            {
                idd = Convert.ToInt32(id);
            }
            return View(data.Menus.Where(p => p.MenuID == idd).ToList());
        }
        [HttpPost]
        public ActionResult MenuGuncelle(FormCollection menu)
        {
            int a = int.Parse(RouteData.Values["id"].ToString());
            var me = data.Menus.Where(p => p.MenuID == a).FirstOrDefault();
            me.Adi = menu["txtAdi"].ToString();
            me.Aciklama = menu["txtAciklama"].ToString();
            me.Link = menu["txtLink"].ToString();
            me.SiraNo = Convert.ToInt32(menu["txtSiraNo"]);
            data.SaveChanges();
            return Redirect("/Tarik/Admin/Menu");
        }
        [HttpPost]
        public ActionResult YeniMenu(FormCollection menu)
        {
            Menu me = new myblogNew.Models.Menu();
            me.Adi = menu["txtAdi"].ToString();
            me.Aciklama = menu["txtAciklama"].ToString();
            me.Link = menu["txtLink"].ToString();
            me.SiraNo = Convert.ToInt32(menu["txtSiraNo"]);
            data.Menus.Add(me);
            data.SaveChanges();
            return Redirect("/Tarik/Admin/Menu");
        }



        public ActionResult Site(string id)
        {
            if (id == null || id == "")
            {
                return View(data.SiteAyarlaris.ToList());
            }
            else
            {
                int a = int.Parse(RouteData.Values["id"].ToString());
                var sa = data.SiteAyarlaris.Where(p => p.SiteAyarID == a).FirstOrDefault();
                data.SiteAyarlaris.Remove(sa);
                data.SaveChanges();
                return Redirect("/Tarik/Admin/Site");
            }
        }
        public ActionResult SiteDetayi(string id)
        {
            int idd = 0;
            if (id != null)
            {
                idd = Convert.ToInt32(id);
            }
            return View(data.SiteAyarlaris.Where(p => p.SiteAyarID == idd).ToList());
        }
        [HttpPost]
        public ActionResult SiteGuncelle(FormCollection site)
        {
            int a = int.Parse(RouteData.Values["id"].ToString());
            var si = data.SiteAyarlaris.Where(p => p.SiteAyarID == a).FirstOrDefault();
            si.SiteAdi = site["txtAdi"].ToString();
            si.SiteAnasayfa = site["txtMail"].ToString();
            si.SiteAnasayfaAltBaslik = site["txtAnasayfaAlt"].ToString();
            si.SiteAnasayfaResim = site["txtAnasayfaResim"].ToString();
            si.SiteCopyright = site["txtCopyright"].ToString();
            si.SiteFacebook = site["txtFacebook"].ToString();
            si.SiteFavicon = site["txtFavicon"].ToString();
            si.SiteGithub = site["txtGithub"].ToString();
            si.SiteHakkimda = site["txtHakkimda"].ToString();
            si.SiteHakkimdaAciklama = site["txtHakkimdaAciklama"].ToString();
            si.SiteHakkimdaAltBaslik = site["txtHakkimdaAlt"].ToString();
            si.SiteHakkimdaResim = site["txtHakkimdaResim"].ToString();
            si.SiteIletisim = site["txtIletisim"].ToString();
            si.SiteIletisimAciklama = site["txtIletisimAciklama"].ToString();
            si.SiteIletisimAltBaslik = site["txtIletisimAlt"].ToString();
            si.SiteIletisimResim = site["txtIletisimResim"].ToString();
            si.SiteInstagram = site["txtInstagram"].ToString();
            si.SiteLinkedin = site["txtLinkedin"].ToString();
            si.SiteLinki = site["txtSiteLinki"].ToString();
            si.SiteLogo = site["txtLogo"].ToString();
            si.SiteTitle = site["txtTitle"].ToString();
            si.SiteTwitter = site["txtTwitter"].ToString();
            data.SaveChanges();
            return Redirect("/Tarik/Admin/Site");
        }
        [HttpPost]
        public ActionResult YeniSite(FormCollection site)
        {
            SiteAyarlari si = new myblogNew.Models.SiteAyarlari();
            si.SiteAdi = site["txtAdi"].ToString();
            si.SiteAnasayfa = site["txtMail"].ToString();
            data.SiteAyarlaris.Add(si);
            data.SaveChanges();
            return Redirect("/Tarik/Admin/Site");
        }
    }
}