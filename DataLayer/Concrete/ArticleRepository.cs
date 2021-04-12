using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Validation;
using DataLayer.Entities;
using DataLayer.Infrastructure;
using System.Web;

namespace DataLayer.Concrete
{
    public class ArticleRepository : Base, IRepository<Article>
    {
        private readonly WebsiteContext db;

        public ArticleRepository() : this(HttpContext.Current.Server.MapPath("~/logs/appErrorsLog.txt")) { }

        public ArticleRepository(string path)
            : base(path)
        {
            db = new WebsiteContext();
        }
        /// <summary>
        /// Geting the most top article
        /// </summary>
        public Article Default
        {
            get
            {
                return db.Articles
                    .Include(a=>a.Articles)
                    .FirstOrDefault();
            }
        }
        /// <summary>
        /// Retrieving all articles
        /// </summary>
        public IQueryable<Article> All
        {
            get
            {
                return db.Articles;
            }
        }
        /// <summary>
        /// Finding an article by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Article Find(int id)
        {
            return db.Articles
                .Include(a => a.Articles)
                .Where(a => a.ArticleId == id).SingleOrDefault();
        }
        /// <summary>
        /// Saving or updating to the database
        /// </summary>
        /// <param name="entity"></param>
        public void InsertOrUpdate(Article entity)
        {
            if (entity.ArticleId == 0)
                db.Entry(entity).State = EntityState.Added;
            else
                db.Entry(entity).State = EntityState.Modified;
        }
        /// <summary>
        /// Deleting...
        /// </summary>
        /// <param name="entity"></param>
        public void Delete(Article entity)
        {
            db.Articles.Remove(entity);
        }

        /// <summary>
        /// Saving To Database
        /// </summary>
        /// <returns></returns>
        public bool Save()
        {
            bool saved = false;
            try
            {
                db.SaveChanges();
                saved = true;
            }
            //something went wrong and the error message is saved to error log
            catch (DbEntityValidationException ex)
            {
                this.WriteErrorMessageToLog(
                    ex.EntityValidationErrors
                    .SelectMany(er => er.ValidationErrors)
                    .Select(e => new Dictionary<string, string> {
                    {e.PropertyName , e.ErrorMessage}
                    }).SingleOrDefault()
                );
            }
            return saved;
        }
        /// <summary>
        /// Dispose db object
        /// </summary>
        public void Dispose()
        {
            if (db != null)
                db.Dispose();
        }
    }
}
