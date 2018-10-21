using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace myblogNew.Areas.Tarik.Models.DAL
{
    public class login
    {
        myblogNew.Models.myBlogContext data = new myblogNew.Models.myBlogContext();

        public string GetLogin(string kullaniciAdi, string sifre)
        {
            var login = data.Kullanicilars.Where(p => p.KullaniciAdi == kullaniciAdi && p.Sifre == sifre).FirstOrDefault();
            if (login != null)
            {
                System.Web.Security.FormsAuthentication.SetAuthCookie(login.Mail, true);
                return login.Mail;
            }
            else
            {
                return "yok";
            }

        }
    }
}