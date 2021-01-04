using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCOnlineTicariOtomasyon.Models.Sınıflar;

namespace MVCOnlineTicariOtomasyon.Controllers
{
    public class PersonelController : Controller
    {
        Context c = new Context();
        // GET: Personel
        public ActionResult Index()
        {
            var deger = c.Personels.Where(x => x.Durum == true).ToList();
            return View(deger);
        }
        public ActionResult PersonelGetir(int id)
        {
            List<SelectListItem> deger1 = (from x in c.Departmans.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.DepartmanAD,
                                               Value = x.DepartmanID.ToString()
                                           }).ToList();
            ViewBag.dgr3 = deger1;
            var deger = c.Personels.Find(id);
            return View("PersonelGetir", deger);
        }
        public ActionResult PersonelSil(int id)
        {
            var deger = c.Personels.Find(id);
            deger.Durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult PersonelEkle()
        {
            List<SelectListItem> deger1 = (from x in c.Departmans.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.DepartmanAD,
                                               Value = x.DepartmanID.ToString()
                                           }).ToList();
            ViewBag.dgr2 = deger1;
            return View();
        }

        [HttpPost]
        public ActionResult PersonelEkle(Personel p)
        {
            p.Durum = true;
            c.Personels.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult PersonelGuncelle(Personel p1)
        {
            var deger = c.Personels.Find(p1.PersonelID);
            deger.PersonelAd = p1.PersonelAd;
            deger.PersonelSoyad = p1.PersonelSoyad;
            deger.PersonelGorsel = p1.PersonelGorsel;
            deger.Departmanid = p1.Departmanid;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult PersonelListe()
        {
            var deger = c.Personels.ToList();
            return View(deger);
        }
    }
}