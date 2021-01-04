using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCOnlineTicariOtomasyon.Models.Sınıflar;
using System.Web.Security;

namespace MVCOnlineTicariOtomasyon.Controllers
{
    public class CariPanelController : Controller
    {
        // GET: CariPanel
        Context c = new Context();

        [Authorize]
        public ActionResult Index()
        {
            var uyemail = (string)Session["CariMail"];
            var deger = c.Carilers.FirstOrDefault(x => x.CariMail == uyemail);
            ViewBag.m = uyemail;
            return View(deger);
        }
        public ActionResult Siparislerim()
        {
            var uyemail = (string)Session["CariMail"];
            var id = c.Carilers.Where(x => x.CariMail == uyemail.ToString()).Select(y => y.CariID).FirstOrDefault();
            var degerler = c.SatisHarekets.Where(x => x.Cariid == id).ToList();
            return View(degerler);
        }
    }
}