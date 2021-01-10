using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOgrenciNot.Controllers
{
    public class HesapController : Controller
    {
        // GET: Hesap
        public ActionResult Index(double sinav1 = 0, double sinav2 = 0, double sinav3 = 0, double proje = 0)
        {
            double sonuc = (sinav1 + sinav2 + sinav3 + proje) / 4;
            ViewBag.dgr = sonuc;
            return View();
        }
    }
}