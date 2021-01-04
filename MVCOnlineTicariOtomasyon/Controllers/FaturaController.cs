using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCOnlineTicariOtomasyon.Models.Sınıflar;

namespace MVCOnlineTicariOtomasyon.Controllers
{
    public class FaturaController : Controller
    {
        Context c = new Context();
        // GET: Fatura
        public ActionResult Index()
        {
            var liste = c.Faturalars.ToList();
            return View(liste);
        }
        [HttpGet]
        public ActionResult FaturaEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult FaturaEkle(Faturalar f)
        {
            c.Faturalars.Add(f);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult FaturaGetir(int id) 
        {
            var deger = c.Faturalars.Find(id);
            return View("FaturaGetir", deger);
        }
        public ActionResult FaturaGuncelle(Faturalar f)
        {
            var deger = c.Faturalars.Find(f.FaturaID);
            deger.FaturaSeriNo = f.FaturaSeriNo;
            deger.FaturaSıraNo = f.FaturaSıraNo;
            deger.FaturaTarih = f.FaturaTarih;
            deger.Saat = f.Saat;
            deger.TeslimAlan = f.TeslimAlan;
            deger.TeslimEden = f.TeslimEden;
            deger.VergiDairesi = f.VergiDairesi;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult FaturaDetay(int id)
        {
            var deger = c.FaturaKalems.Where(x => x.FaturaID == id).ToList();
            return View(deger);
        }
         [HttpGet]
        public ActionResult YeniKalem()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniKalem(FaturaKalem f)
        {
            c.FaturaKalems.Add(f);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}