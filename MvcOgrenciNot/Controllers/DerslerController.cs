using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOgrenciNot.Models.Entity;

namespace MvcOgrenciNot.Controllers
{
    public class DerslerController : Controller
    {
        // GET: Dersler
        MvcOkulEntities1 db = new MvcOkulEntities1();
        public ActionResult Index()
        {
            var ders = db.Dersler.ToList();
            return View(ders);
        }
        [HttpGet]
        public ActionResult DersEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DersEkle(Dersler d)
        {
            var ders = db.Dersler.Add(d);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DersSil(int id)
        {
            var ders = db.Dersler.Find(id);
            db.Dersler.Remove(ders);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DersGetir(int id)
        {
            var ders=db.Dersler.Find(id);
            return View("DersGetir",ders);
        }
        public ActionResult Guncelle(Dersler d)
        {
            var ders = db.Dersler.Find(d.DersID);
            ders.DersAD = d.DersAD;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}