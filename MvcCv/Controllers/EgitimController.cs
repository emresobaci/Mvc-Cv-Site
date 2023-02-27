
using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class EgitimController : Controller
    {
        // GET: Egitim

        GenericRepository<TblEgitimlerim> repo = new GenericRepository<TblEgitimlerim>();
        public ActionResult Index()
        {
            var egitim = repo.List();

            return View(egitim);
        }
        [HttpGet]
        public ActionResult EgitimEkle()
        {
            return View(); 
        }
        [HttpPost]
        public ActionResult EgitimEkle(TblEgitimlerim GelenParametre)
        {
            //Eğer şart sağlamıyorsa EğitimEkle'ye geri dön diyoruz.
            if (!ModelState.IsValid)
            {
                return View("EgitimEkle");
            }
            repo.Tadd(GelenParametre);
            return RedirectToAction("Index");

        }
        public ActionResult EgitimSil(int id)
        {
            var egitim = repo.Find(x => x.ID == id);
            repo.Tdelete(egitim);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EgitimDuzenle(int id)
        {
            var egitim = repo.Find(x => x.ID == id);
            return View(egitim);
        }
        [HttpPost]
        public ActionResult EgitimDuzenle(TblEgitimlerim GelenDeger)
        {
            if (!ModelState.IsValid)
            {
                return View("EgitimDuzenle");
            }
            var egitim = repo.Find(x => x.ID == GelenDeger.ID);
            egitim.Baslik = GelenDeger.Baslik;
            egitim.AltBaslik1 = GelenDeger.AltBaslik1;
            egitim.AltBaslik2 = GelenDeger.AltBaslik2;
            egitim.GNO=GelenDeger.GNO;
            egitim.Tarih = GelenDeger.Tarih;
            repo.TUpdate(egitim);
            return RedirectToAction("Index");
        }


    }
}