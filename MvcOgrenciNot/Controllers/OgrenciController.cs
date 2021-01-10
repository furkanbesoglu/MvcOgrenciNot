using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOgrenciNot.Models.Entity;

namespace MvcOgrenciNot.Controllers
{
    public class OgrenciController : Controller
    {
        // GET: Ogrenci
        MvcOkulEntities1 db = new MvcOkulEntities1();
        public ActionResult Index()
        {
            var ogr = db.Ogrenciler.ToList();
            return View(ogr);
        }
        [HttpGet]
        public ActionResult OgrenciEkle()
        {
            List<SelectListItem> deger1 = (from i in db.Kulupler.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.KulupAD,
                                               Value = i.KulupID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            return View();
        }
        [HttpPost]
        public ActionResult OgrenciEkle(Ogrenciler p)
        {
            var degerler = db.Kulupler.Where(x => x.KulupID == p.Kulupler.KulupID).FirstOrDefault();
            p.Kulupler = degerler;
            var ogr = db.Ogrenciler.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult OgrenciSil(int id)
        {
            var ogr = db.Ogrenciler.Find(id);
            db.Ogrenciler.Remove(ogr);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult OgrenciGetir(int id)
        {
            var ogr = db.Ogrenciler.Find(id);

            List<SelectListItem> deger2 = (from i in db.Kulupler.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.KulupAD,
                                               Value = i.KulupID.ToString()
                                           }).ToList();
            ViewBag.dgr2 = deger2;

            return View("OgrenciGetir",ogr);
        }
        public ActionResult Guncelle(Ogrenciler o)
        {
            var ogr = db.Ogrenciler.Find(o.OgrenciID);
            ogr.OgrenciAD = o.OgrenciAD;
            ogr.OgrenciSoyad = o.OgrenciSoyad;
            ogr.OgrenciFoto = o.OgrenciFoto;
            ogr.OgrenciCinsiyet = o.OgrenciCinsiyet;
            var degerler = db.Kulupler.Where(x => x.KulupID == o.Kulupler.KulupID).FirstOrDefault();
            ogr.KulupID = degerler.KulupID;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}