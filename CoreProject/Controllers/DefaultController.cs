using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreProject.Models;

namespace CoreProject.Controllers
{
    public class DefaultController : Controller
    {
        Context c = new Context();
        public IActionResult Index()
        {
            var degerler = c.Birims.ToList();
            return View(degerler);
        }

        public IActionResult YeniBirim()
        {
            return View();
        }
        [HttpPost] //sayfadan gelen post işleminde çalışır
        public IActionResult YeniBirim(Birim B)
        {
            c.Birims.Add(B);
            c.SaveChanges();
            return RedirectToAction("Index");

        }
        public IActionResult BirimSil(int id)
        {
            var dep = c.Birims.Find(id);
            c.Birims.Remove(dep);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult BirimGetir(int id)
        {
            var depart = c.Birims.Find(id);
            return View("BirimGetir", depart);
        }
        public IActionResult BirimGuncelle(Birim d)
        {
            var dep = c.Birims.Find(d.BirimID);
            dep.BirimAd = d.BirimAd;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult BirimDetay(int id)
        {
            var degerler = c.Personels.Where(x => x.BirimID == id).ToList();
            var brmad = c.Birims.Where(x => x.BirimID == id).Select(y => y.BirimAd).FirstOrDefault();
            ViewBag.brm = brmad;
            return View(degerler);
        }
    }
}
