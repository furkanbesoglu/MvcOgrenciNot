using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOgrenciNot.Models.Entity;

namespace MvcOgrenciNot.Controllers
{
    public class KuluplerController : Controller
    {
        // GET: Kulupler
        MvcOkulEntities1 db = new MvcOkulEntities1();
        public ActionResult Index()
        {
            var kulupler = db.Kulupler.ToList();
            return View(kulupler);
        }
        [HttpGet]
        public ActionResult KulupEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult KulupEkle(Kulupler k)
        {
            var kulupler = db.Kulupler.Add(k);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KulupSil(int id)
        {
            var kulup = db.Kulupler.Find(id);
            db.Kulupler.Remove(kulup);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KulupGetir(int id)
        {
            var klp = db.Kulupler.Find(id);
            return View("KulupGetir",klp);
        }
        public ActionResult Guncelle(Kulupler k)
        {
            var klp = db.Kulupler.Find(k.KulupID);
            klp.KulupAD = k.KulupAD;
            klp.KulupKontenjan = k.KulupKontenjan;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}