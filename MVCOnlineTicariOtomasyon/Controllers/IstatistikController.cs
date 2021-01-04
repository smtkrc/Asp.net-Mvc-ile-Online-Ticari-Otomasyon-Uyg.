using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCOnlineTicariOtomasyon.Models.Sınıflar;

namespace MVCOnlineTicariOtomasyon.Controllers
{
    public class IstatistikController : Controller
    {
        // GET: Istatistik
        Context c = new Context();
        public ActionResult Index()
        {
            var deger1 = c.Carilers.Where(x => x.Durum == true).Count().ToString();
            var deger2 = c.Uruns.Where(x => x.Durum == true).Count().ToString();
            var deger3 = c.Personels.Where(x => x.Durum == true).Count().ToString();
            var deger4 = c.Kategoris.Count().ToString();
            var deger5 = c.Uruns.Where(x => x.Durum == true).Sum(x => x.Stok).ToString();
            var deger7 = c.Uruns.Where(x => x.Durum == true).Count(x => x.Stok <= 20).ToString();
            var deger6 = (from x in c.Uruns where x.Durum == true select x.Marka).Distinct().Count().ToString();
            var deger8 = (from x in c.Uruns where x.Durum == true orderby x.SatisFiyat descending select x.UrunAd).FirstOrDefault();
            var deger9 = (from x in c.Uruns where x.Durum == true orderby x.SatisFiyat select x.UrunAd).FirstOrDefault();
            var deger10 = c.Uruns.Where(x => x.Durum == true).Count(x => x.UrunAd == "Buz Dolabi").ToString();
            var deger11 = c.Uruns.Where(x => x.Durum == true).Count(x => x.UrunAd == "Notebook").ToString();
            var deger14 = c.SatisHarekets.Where(x => x.Durum == true).Sum(x => x.ToplamTutar).ToString();
            DateTime bugün = DateTime.Today;
            var deger15 = c.SatisHarekets.Where(x => x.Durum == true).Count(x => x.Tarih == bugün).ToString();
           // var deger16 = c.SatisHarekets.Where(x => x.Tarih == bugün).Sum(y => y.ToplamTutar).ToString();
            var deger12 = c.Uruns.Where(x => x.Durum == true).GroupBy(x => x.Marka).OrderByDescending(y => y.Count()).Select(z => z.Key).FirstOrDefault();
            var deger13 = c.Uruns.Where(x => x.Durum == true).Where(u => u.UrunID == (c.SatisHarekets.GroupBy(x => x.Urunid).OrderByDescending(z => z.Count()).Select(y => y.Key).FirstOrDefault())).
                Select(m => m.UrunAd).FirstOrDefault();
            ViewBag.d1 = deger1;
            ViewBag.d2 = deger2;
            ViewBag.d3 = deger3;
            ViewBag.d4 = deger4;
            ViewBag.d5 = deger5;
            ViewBag.d6 = deger6;
            ViewBag.d7 = deger7;
            ViewBag.d8 = deger8;
            ViewBag.d9 = deger9;
            ViewBag.d10 = deger10;
            ViewBag.d11 = deger11;
            ViewBag.d12 = deger12;
            ViewBag.d13 = deger13;
            ViewBag.d14 = deger14;
            ViewBag.d15 = deger15;
            // ViewBag.d16 = deger16;
            return View();
        }
        public ActionResult KolayTablolar()
        {
            var deger = from x in c.Carilers
                        where x.Durum == true
                        group x by x.CariSehir into g
                        select new SinifGrup
                        {
                            Sehir = g.Key,
                            Sayi = g.Count()
                        };
            return View(deger.ToList());
        }
        public PartialViewResult Partian1()
        {
            var deger2 = from x in c.Personels
                         where x.Durum == true
                         group x by x.Departman.DepartmanAD
                        into g
                         select new SinifGrup2
                         {
                             Departman = g.Key,
                             Sayi = g.Count()
                         };
            return PartialView(deger2.ToList());
        }
        public PartialViewResult Partial2()
        {
            var deger3 = c.Carilers.Where(x => x.Durum == true).ToList();
            return PartialView(deger3);
        }
        public PartialViewResult Partial3()
        {
            var deger4 = c.Uruns.Where(x => x.Durum == true).ToList();
            return PartialView(deger4);
        }
        public PartialViewResult Partial4()
        {
            var deger5 = from x in c.Uruns
                         where x.Durum == true
                         group x by x.Marka into g
                         select new SinifGrup3
                         {
                             MarkaAd = g.Key,
                             Sayi = g.Count()
                         };
            return PartialView(deger5.ToList());
        }
    }
}