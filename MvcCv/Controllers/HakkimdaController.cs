using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class HakkimdaController : Controller
    {
        // GET: Hakkimda
        GenericRepository<TblHakkimda> repo = new GenericRepository<TblHakkimda>();

        public ActionResult Index()
        {
            var hakkimda = repo.List();
            return View(hakkimda);
        }
        [HttpGet]
        public ActionResult HakkimdaGuncelleme(int id)
        {
            var hakkimda = repo.Find(x => x.ID == id);
            return View(hakkimda);
        }
        [HttpPost]
        public ActionResult HakkimdaGuncelleme(TblHakkimda GelenDeger)
        {
            var hakkimda = repo.Find(x => x.ID == GelenDeger.ID);
            hakkimda.Ad = GelenDeger.Ad;
            hakkimda.Soyad = GelenDeger.Soyad;
            hakkimda.Adres = GelenDeger.Adres;  
            hakkimda.Telefon= GelenDeger.Telefon;
            hakkimda.Mail = GelenDeger.Mail;
            hakkimda.Aciklama = GelenDeger.Aciklama;
            hakkimda.Resim = hakkimda.Resim;
            repo.TUpdate(hakkimda);
            return RedirectToAction("Index");
        }
    }
}