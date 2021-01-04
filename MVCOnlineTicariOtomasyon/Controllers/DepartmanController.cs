using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCOnlineTicariOtomasyon.Models.Sınıflar;

namespace MVCOnlineTicariOtomasyon.Controllers
{
    public class DepartmanController : Controller
    {
        // GET: Departman
        Context c = new Context();
        public ActionResult Index()
        {
            var degerler = c.Departmans.Where(x => x.Durum == true).ToList();
          
            return View(degerler);
        }
        [HttpGet]
        public ActionResult DepartmanEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DepartmanEkle(Departman d)
        {
            d.Durum = true;
            c.Departmans.Add(d);
            c.SaveChanges();
           return  RedirectToAction("Index");
        }
        public ActionResult DepartmanSil(int id)
        {
            var deger = c.Departmans.Find(id);
            deger.Durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DepartmanGetir(int id)
        {
            var deger = c.Departmans.Find(id);
            return View("DepartmanGetir", deger);
        }
        public ActionResult DepartmanGuncelle(Departman d)
        {
            var deger = c.Departmans.Find(d.DepartmanID);
            deger.DepartmanAD = d.DepartmanAD;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DepartmanDetay(int id)
        {
            var deger = c.Personels.Where(x => x.Departmanid == id).ToList();
            var dpr = c.Departmans.Where(x => x.DepartmanID == id).Select(y => y.DepartmanAD).FirstOrDefault();
            ViewBag.d = dpr;
            return View(deger);
        }
        public ActionResult DepartmanPersonelSatis(int id)
        {
            var degerler = c.SatisHarekets.Where(x => x.Personel_PersonelID == id).ToList();
            var dgr = c.Personels.Where(x => x.PersonelID == id).Select(y => y.PersonelAd +" "+ y.PersonelSoyad).FirstOrDefault();
            ViewBag.dp = dgr;
            return View(degerler);
        }
    }
}