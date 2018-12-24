using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace VidlyPrototype.Controllers
{
    public class LanguagesController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult Change(string LanguageAbbreviation)
        {
            if(LanguageAbbreviation != null)
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(LanguageAbbreviation);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(LanguageAbbreviation);

            }

            HttpCookie cookie = new HttpCookie("Language");
            cookie.Value = LanguageAbbreviation;
            Response.Cookies.Add(cookie);

            return RedirectToAction("Index", "Home");
        }
    }
}