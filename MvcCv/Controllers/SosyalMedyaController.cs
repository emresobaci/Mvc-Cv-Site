using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCv.Models.Entity;
using MvcCv.Repositories;

namespace MvcCv.Controllers
{
    public class SosyalMedyaController : Controller
    {
        // GET: SosyalMedya
        GenericRepository<TblSosyalMedya> repo = new GenericRepository<TblSosyalMedya>();
        public ActionResult Index()
        {
            var sosyal = repo.List();

            return View(sosyal);
        }
        [HttpGet]
        public ActionResult YeniSosyal()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniSosyal(TblSosyalMedya p)
        {
            repo.Tadd(p);
            return RedirectToAction("Index");
        }
        public ActionResult SosyalSil(int id)
        {
            var sosyal = repo.Find(x => x.ID == id);
            sosyal.Durum = false;
            repo.TUpdate(sosyal);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult SosyalDuzenle(int id)
        {
            var sosyal = repo.Find(x => x.ID == id);
            return View(sosyal);
        }
        [HttpPost]
        public ActionResult SosyalDuzenle(TblSosyalMedya GelenDegerler)
        {
            var sosyal = repo.Find(x => x.ID == GelenDegerler.ID);
            sosyal.Ad = GelenDegerler.Ad;
            sosyal.Durum = true;
            sosyal.Link = GelenDegerler.Link;
            sosyal.icon = GelenDegerler.icon;
            repo.TUpdate(sosyal);
            return RedirectToAction("Index");
        }
    }
}