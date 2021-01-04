    using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCOnlineTicariOtomasyon.Models.Sınıflar;

namespace MVCOnlineTicariOtomasyon.Controllers
{
    public class UrunController : Controller
    {
        // GET: Urun
        Context c = new Context();
        public ActionResult Index()
        {
            var deger = c.Uruns.Where(x => x.Durum == true).ToList();
            return View(deger);
        }
        [HttpGet]
        public ActionResult YeniUrun()
        {
            List<SelectListItem> deger1 = (from x in c.Kategoris.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.KATEGORIAD,
                                               Value = x.KATEGORIID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            return View();
        }
        [HttpPost]
        public ActionResult YeniUrun(Urun a)
        {
            c.Uruns.Add(a);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UrunSil(int id)
        {
            var deger = c.Uruns.Find(id);
            deger.Durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UrunGetir(int id)
        {
            var getir = c.Uruns.Find(id);
            return View("UrunGetir", getir);
        }
        [HttpGet]
        public ActionResult UrunGuncelle()
        {
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult UrunGuncelle(Urun u)
        {
            var urn = c.Uruns.Find(u.UrunID);
            urn.UrunAd = u.UrunAd;
            urn.Marka = u.Marka;
            urn.SatisFiyat = u.SatisFiyat;
            urn.AlisFiyat = u.AlisFiyat;
            urn.Stok = u.Stok;
            urn.UrunGorsel = u.UrunGorsel;
            urn.KategoriID = u.KategoriID;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UrunListesi()
        {
            var deger = c.Uruns.ToList();
            return View(deger);
        }
    }

}