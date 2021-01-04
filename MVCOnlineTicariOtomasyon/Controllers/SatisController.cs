using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCOnlineTicariOtomasyon.Models.Sınıflar;

namespace MVCOnlineTicariOtomasyon.Controllers
{
    public class SatisController : Controller
    {
        Context c = new Context();
        // GET: Satis
        public ActionResult Index()
        {
            var deger = c.SatisHarekets.Where(x=>x.Durum==true).ToList();
            return View(deger);
        }
        [HttpGet]
        public ActionResult YeniSatis()
        {
            List<SelectListItem> deger1 = (from x in c.Uruns.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.UrunAd,
                                               Value = x.UrunID.ToString()
                                           }).ToList();
            List<SelectListItem> deger2 = (from x in c.Carilers.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CariAD + " " + x.CariSoyad,
                                               Value = x.CariID.ToString()
                                           }).ToList();
            List<SelectListItem> deger3 = (from x in c.Personels.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.PersonelAd + " " + x.PersonelSoyad,
                                               Value = x.PersonelID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            ViewBag.dgr2 = deger2;
            ViewBag.dgr3 = deger3;
            return View();
        }

        [HttpPost]
        public ActionResult YeniSatis(SatisHareket s)
        {
            s.Durum = true;
            s.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            c.SatisHarekets.Add(s);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult SatisGetir(int id)
        {
            List<SelectListItem> deger1 = (from x in c.Uruns.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.UrunAd,
                                               Value = x.UrunID.ToString()
                                           }).ToList();
            List<SelectListItem> deger2 = (from x in c.Carilers.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CariAD + " " + x.CariSoyad,
                                               Value = x.CariID.ToString()
                                           }).ToList();
            List<SelectListItem> deger3 = (from x in c.Personels.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.PersonelAd + " " + x.PersonelSoyad,
                                               Value = x.PersonelID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            ViewBag.dgr2 = deger2;
            ViewBag.dgr3 = deger3;
            var deger = c.SatisHarekets.Find(id);
            return View("SatisGetir", deger);
        }
        public ActionResult SatisGuncelle(SatisHareket s)
        {
            var urn = c.SatisHarekets.Find(s.SatisID);
            urn.Cariid = s.Cariid;
            urn.Adet = s.Adet;
            urn.Fiyat = s.Fiyat;
            urn.Personel_PersonelID = s.Personel_PersonelID;
            urn.Tarih = s.Tarih;
            urn.ToplamTutar = s.ToplamTutar;
            urn.Urunid = s.Urunid;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult SatisDetay(int id)
        {
            var deger = c.SatisHarekets.Where(x => x.SatisID == id).ToList();
            return View(deger);
        }
        public ActionResult SatisSil(int id)
        {
           var deger= c.SatisHarekets.Find(id);
            deger.Durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}