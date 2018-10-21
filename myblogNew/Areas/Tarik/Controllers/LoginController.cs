using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace myblogNew.Areas.Tarik.Controllers
{
    public class LoginController : Controller
    {
        // GET: Tarik/Login
        [AllowAnonymous]
        public ActionResult Index()
        {

            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public ActionResult LoginControl(FormCollection login)
        {
            Models.DAL.login l = new Models.DAL.login();
           string result= l.GetLogin(login["email"].ToString(), login["password"].ToString());

            if (result!="yok")
            {

                return Redirect("/Tarik/Admin/Index");
            }
            else
            {
                return Redirect("/Tarik/Login/Index");
            }
        }


        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return Redirect("/Tarik/Login");
        }

    }
}