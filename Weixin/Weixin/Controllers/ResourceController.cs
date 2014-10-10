using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Weixin.Models;

namespace Weixin.Controllers
{
    public class ResourceController : Controller
    {
        private WeixinContext db = new WeixinContext();

        //
        // GET: /Resource/

        public ActionResult Index()
        {
            var resources = db.Resources.Include(r => r.QRCode);
            return View(resources.ToList());
        }

        //
        // GET: /Resource/Details/5

        public ActionResult Details(int id = 0)
        {
            Resource resource = db.Resources.Find(id);
            if (resource == null)
            {
                return HttpNotFound();
            }
            return View(resource);
        }

        //
        // GET: /Resource/Create

        public ActionResult Create()
        {
            ViewBag.QRCodeId = new SelectList(db.QRCodes, "QRCodeId", "SiteUrl");
            return View();
        }

        //
        // POST: /Resource/Create

        [HttpPost]
        public ActionResult Create(Resource resource)
        {
            if (ModelState.IsValid)
            {
                db.Resources.Add(resource);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.QRCodeId = new SelectList(db.QRCodes, "QRCodeId", "SiteUrl", resource.QRCodeId);
            return View(resource);
        }

        //
        // GET: /Resource/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Resource resource = db.Resources.Find(id);
            if (resource == null)
            {
                return HttpNotFound();
            }
            ViewBag.QRCodeId = new SelectList(db.QRCodes, "QRCodeId", "SiteUrl", resource.QRCodeId);
            return View(resource);
        }

        //
        // POST: /Resource/Edit/5

        [HttpPost]
        public ActionResult Edit(Resource resource)
        {
            if (ModelState.IsValid)
            {
                db.Entry(resource).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.QRCodeId = new SelectList(db.QRCodes, "QRCodeId", "SiteUrl", resource.QRCodeId);
            return View(resource);
        }

        //
        // GET: /Resource/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Resource resource = db.Resources.Find(id);
            if (resource == null)
            {
                return HttpNotFound();
            }
            return View(resource);
        }

        //
        // POST: /Resource/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Resource resource = db.Resources.Find(id);
            db.Resources.Remove(resource);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}