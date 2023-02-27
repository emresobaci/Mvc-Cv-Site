using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCv.Models.Entity;
using MvcCv.Repositories;

namespace MvcCv.Controllers
{
    public class HobiController : Controller
    {
        // GET: Hobi
        GenericRepository<TblHobilerim> repo = new GenericRepository<TblHobilerim>();
        
        public ActionResult Index()
        {
            var hobiler = repo.List();
            return View(hobiler);
        }
        [HttpGet]
        public ActionResult HobiGuncelleme(int id)
        {
            var hobi = repo.Find(x => x.ID == id);
            return View(hobi);
        }
        [HttpPost]
        public ActionResult HobiGuncelleme(TblHobilerim GelenDeger)
        {
            var hobi = repo.Find(x => x.ID == GelenDeger.ID);
            hobi.Aciklama1 = GelenDeger.Aciklama1;
            hobi.Aciklama2 = GelenDeger.Aciklama2;
            repo.TUpdate(hobi);
            return RedirectToAction("Index");
        }


    }
}