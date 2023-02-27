using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class SertifikaController : Controller
    {
        // GET: Sertifika

        GenericRepository<TblSertifikalar> repo = new GenericRepository<TblSertifikalar>();
        public ActionResult Index()
        {
            var sertifika = repo.List();

            return View(sertifika);
        }

        [HttpGet]
        public ActionResult SertifikaGetir(int id)
        {
            var sertifika = repo.Find(x => x.ID==id);
            return View(sertifika);

        }
        [HttpPost]
        public ActionResult SertifikaGetir(TblSertifikalar GelenDeger)
        {
            var sertifika = repo.Find(x => x.ID == GelenDeger.ID);
            sertifika.Aciklama = GelenDeger.Aciklama;
            sertifika.Tarih = GelenDeger.Tarih;
            repo.TUpdate(sertifika);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult YeniSertifika()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniSertifika(TblSertifikalar GelenDeger)
        {
            repo.Tadd(GelenDeger);
            return RedirectToAction("Index");
        }
      
        public ActionResult SertifikaSil(int id)
        {
            var sertifika = repo.Find(x => x.ID == id);
            repo.Tdelete(sertifika);
            return RedirectToAction("Index");
        }
    }
}