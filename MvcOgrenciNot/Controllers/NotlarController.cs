using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOgrenciNot.Models;
using MvcOgrenciNot.Models.Entity;

namespace MvcOgrenciNot.Controllers
{
    public class NotlarController : Controller
    {
        // GET: Notlar
        MvcOkulEntities1 db = new MvcOkulEntities1();
        public ActionResult Index()
        {
            var notlar = db.Notlar.ToList();
            return View(notlar);
        }
        [HttpGet]
        public ActionResult YeniSinav()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniSinav(Notlar n)
        {
            var not = db.Notlar.Add(n);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult NotGetir(int id)
        {
            var not = db.Notlar.Find(id);
            return View("NotGetir", not);
        }
        [HttpPost]
        public ActionResult NotGetir(Class1 model, Notlar n, int sinav1 = 0, int sinav2 = 0, int sinav3 = 0, int proje = 0)
        {
            if (model.İslem == "Hesapla")
            {
                //İslem Bir
                int ORT = (sinav1 + sinav2 + sinav3 + proje) / 4;
                ViewBag.dgr = ORT;
            }
            if (model.İslem == "Guncelle")
            {
                //İslem İki
                var not = db.Notlar.Find(n.NotID);
                not.Sinav1 = n.Sinav1;
                not.Sinav2 = n.Sinav2;
                not.Sinav3 = n.Sinav3;
                not.Proje = n.Proje;
                not.Ortalama = n.Ortalama;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}