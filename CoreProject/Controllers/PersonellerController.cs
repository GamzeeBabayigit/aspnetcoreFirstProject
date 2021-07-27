using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreProject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;

namespace CoreProject.Controllers
{
    public class PersonellerController : Controller
    {
        Context c = new Context();
        [Authorize]
        public IActionResult Index()
        {
            var degerler = c.Personels.Include(x=>x.Birim).ToList();
            return View(degerler);
        }
        [HttpGet]
        public IActionResult YeniPersonel()
        {
            List<SelectListItem> degerler = (from x in c.Birims.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.BirimAd,
                                                 Value = x.BirimID.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;
            return View();
        }

        public IActionResult YeniPersonel(Personel p)
        {
            var per = c.Birims.Where(x => x.BirimID == p.Birim.BirimID).FirstOrDefault();
            p.Birim=per;
            //üsrt iki satır ile ilişkili tablodan gelen değerlerin işlemi yapılır 
            c.Personels.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");

        }
        public IActionResult PersonelSil(int id)
        {
            var dep = c.Personels.Find(id);
            c.Personels.Remove(dep);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

         
    }

}
