using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Demo_Upload_Multiple_Images.Models;

namespace Demo_Upload_Multiple_Images.Controllers
{
    public class Sub_ImagesController : Controller
    {
        private Demo_Multiple_ImagesEntities db = new Demo_Multiple_ImagesEntities();

        // GET: Sub_Images
        public ActionResult Index()
        {
            var sub_Images = db.Sub_Images.Include(s => s.Product);
            return View(sub_Images.ToList());
        }

        // GET: Sub_Images/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sub_Images sub_Images = db.Sub_Images.Find(id);
            if (sub_Images == null)
            {
                return HttpNotFound();
            }
            return View(sub_Images);
        }

        // GET: Sub_Images/Create
        public ActionResult Create()
        {
            ViewBag.product_id = new SelectList(db.Products, "id", "name");
            return View();
        }

        // POST: Sub_Images/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "id,url_images,product_id")] Sub_Images sub_Images)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Sub_Images.Add(sub_Images);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    ViewBag.product_id = new SelectList(db.Products, "id", "name", sub_Images.product_id);
        //    return View(sub_Images);
        //}

        public ActionResult Create(Sub_Images sub_Images, HttpPostedFileBase[] photo)
        {
            ViewBag.product_id = new SelectList(db.Products, "id", "name", sub_Images.product_id);
            int? id_product = sub_Images.product_id;
            if (photo != null)
            {
                List<string> file = new List<string>();
                foreach (var photos in photo)
                {
                    photos.SaveAs(Server.MapPath("~/Content/images/" + photos.FileName));
                    //file.Add(photos.FileName);
                    Sub_Images sub_Images1 = new Sub_Images();
                    sub_Images1.url_images = photos.FileName;
                    sub_Images1.product_id = id_product;
                    db.Entry(sub_Images1).State = EntityState.Added;
                    db.SaveChanges();
                }
            }
            //else
            //{
            //    string pictures = "no-image.png";
            //    sub_Images.url_images = pictures;
            //}
            //db.Sub_Images.Add(sub_Images);
            //db.SaveChanges();
            return RedirectToAction("Index");
        }


        // GET: Sub_Images/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sub_Images sub_Images = db.Sub_Images.Find(id);
            if (sub_Images == null)
            {
                return HttpNotFound();
            }
            ViewBag.product_id = new SelectList(db.Products, "id", "name", sub_Images.product_id);
            return View(sub_Images);
        }

        // POST: Sub_Images/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,url_images,product_id")] Sub_Images sub_Images)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sub_Images).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.product_id = new SelectList(db.Products, "id", "name", sub_Images.product_id);
            return View(sub_Images);
        }

        // GET: Sub_Images/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sub_Images sub_Images = db.Sub_Images.Find(id);
            if (sub_Images == null)
            {
                return HttpNotFound();
            }
            return View(sub_Images);
        }

        // POST: Sub_Images/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sub_Images sub_Images = db.Sub_Images.Find(id);
            db.Sub_Images.Remove(sub_Images);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
