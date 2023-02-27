using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using MvcCv.Models.Entity;

namespace MvcCv.Repositories
{
    public class GenericRepository<T> where T : class,new()
    {
       DbCvEntities1 db = new DbCvEntities1();

        public List<T> List()
        {
            return db.Set<T>().ToList();
        }

        public void Tadd(T parametre)
        {
            db.Set<T>().Add(parametre);
            db.SaveChanges();
        }

        public void Tdelete(T parametre)
        {
            db.Set<T>().Remove(parametre);
            db.SaveChanges();
        }

        public T Tget(int id)
        {
            return db.Set<T>().Find(id);
        }

        public void TUpdate (T parametre)
        {
            db.SaveChanges();
        }

        public T Find(Expression<Func<T,bool>> where)
        {
            return db.Set<T>().FirstOrDefault(where);
        }


    }
}