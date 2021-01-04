using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCOnlineTicariOtomasyon.Models.Sınıflar;

namespace MVCOnlineTicariOtomasyon.Controllers
{
    public class CariController : Controller
    {
        Context c = new Context();
        // GET: Cari
        public ActionResult Index()
        {
            var deger = c.Carilers.Where(x => x.Durum == true).ToList();
            return View(deger);
        }
        [HttpGet]
        public ActionResult CariEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CariEkle(Cariler x)
        {
            x.Durum = true;
            c.Carilers.Add(x);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult CariGetir(int id)
        {
            var deger = c.Carilers.Find(id);
            return View("CariGetir", deger);
        }
        public ActionResult CariGuncelle(Cariler x)
        {
            if (!ModelState.IsValid)
            {
                return View("CariGetir");
            }
            var deger = c.Carilers.Find(x.CariID);
            deger.CariAD = x.CariAD;
            deger.CariSoyad = x.CariSoyad;
            deger.CariSehir = x.CariSehir;
            deger.CariMail = x.CariMail;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult CariSil(int id)
        {
            var deger = c.Carilers.Find(id);
            deger.Durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult MusteriSatis(int id)
        {
            var dgr = c.Carilers.Where(x => x.CariID == id).Select(y => y.CariAD + " " + y.CariSoyad).FirstOrDefault();
            ViewBag.dq = dgr;
            var deger = c.SatisHarekets.Where(x => x.Cariid == id).ToList();
            return View(deger);

        }
    }
}