using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Weixin.Models;

namespace Weixin.Controllers
{
    public class EmptyController : Controller
    {
        private WeixinContext db = new WeixinContext();
        //
        // GET: /UnUsed/

        public ActionResult Index()
        {
            var models = new List<QRViewModel>();
            var i=1;
            foreach (var item in db.QRCodes.Where(u=>u.UsedSize==0).ToList())
            {
                var model = new QRViewModel
                {
                    Id=i++,
                    QRCodeId = item.QRCodeId,
                    SiteUrl = item.SiteUrl,
                    CreateTime = item.CreateTime,
                    TotalSize = item.TotalSize,
                    UsedSize = item.UsedSize
                };
                models.Add(model);
            }
            return View(models);
        }

        // 
        // POST: /UnUsed/Create
        [HttpPost]
        public ActionResult Create(float totalSize=1 , int createCount = 1)
        {
            if (totalSize <= 0)
                return RedirectToAction("Index");
            for (var i = 0; i < createCount; i++)
            {
                var createTime = DateTime.Now;
                var str = createTime.ToString("yyMMddHHmmssffff");
                //考虑是否用完整网址？！完整->二维码，检索不便 部分->检索方便，二维码不能直接
                var url = "http://" + Request.Url.Authority + "/wx/";
                var siteUrl = url + System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(str, "MD5").ToLower().Substring(8, 16);
                QRCode qrcode = new QRCode
                {
                    SiteUrl = siteUrl,
                    TotalSize = totalSize,
                    UsedSize = 0,
                    CreateTime = createTime
                };
                db.QRCodes.Add(qrcode);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        //[HttpPost]
        public ActionResult Edit(int id, float totalSize=1)
        {
            if (totalSize <= 0)
                return RedirectToAction("Index");
            QRCode qrcode = db.QRCodes.Find(id);
            if (qrcode == null)
            {
                return HttpNotFound();
            }
            qrcode.TotalSize = totalSize;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //先用get
        // POST: /UnUsed/Delete/5
        [HttpGet, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            QRCode qrcode = db.QRCodes.Find(id);
            if (qrcode == null)
            {
                return HttpNotFound();
            }
            db.QRCodes.Remove(qrcode);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //未试
        [HttpPost, ActionName("DeleteMore")]
        public ActionResult DeleteMore(List<int> ids)
        {
            foreach (var id in ids)
            {
                QRCode qrcode = db.QRCodes.Find(id);
                if (qrcode == null)
                {
                    return HttpNotFound();
                }
                db.QRCodes.Remove(qrcode);
            }
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
