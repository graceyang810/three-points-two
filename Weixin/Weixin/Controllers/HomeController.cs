using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Weixin.Models;

namespace Weixin.Controllers
{
    public class HomeController : Controller
    {
        private WeixinContext db = new WeixinContext();
        //
        // GET: /Home/
       
        public ActionResult Index()
        {      
            return View();
           
        }
        public ActionResult wx(string str)
        {    
            //var url = "http://" + Request.Url.Authority + "/wx/"+str;
            //ViewBag.Url = Request.Url;
            if (str == String.Empty)
                return HttpNotFound();
            var url = Request.Url.ToString();
            var qrcodes = db.QRCodes.Where(q => q.SiteUrl == url);
            if (qrcodes.LongCount()==0)
            {
                return HttpNotFound();
            }
            var qrcode=qrcodes.First();
            if (qrcode.UsedSize > 0)
            {
                var resources = new List<ResourceViewModel>();
                foreach (var r in qrcode.Resources)
                {
                    resources.Add(new ResourceViewModel
                    {
                        Url=r.Url,
                        Type=r.Type,
                        Size=r.Size
                    });
                }
                QRViewModel v = new QRViewModel
                {
                    QRCodeId = qrcode.QRCodeId,
                    TotalSize = qrcode.TotalSize,
                    UsedSize = qrcode.UsedSize,
                    Content = qrcode.Content,
                    CreateTime = qrcode.CreateTime,
                    UpdateTime = qrcode.UpdateTime,
                    UserName = qrcode.User.NickName,
                    UserPicUrl = qrcode.User.PicUrl,
                    Resources = resources
                };
                return View("used",v);
            }
            else
            {
                QRViewModel v = new QRViewModel
                {
                    QRCodeId = qrcode.QRCodeId,
                    TotalSize = qrcode.TotalSize,
                    UsedSize = qrcode.UsedSize,
                    CreateTime = qrcode.CreateTime,
                   
                };
                return View("empty",v);
            }
           
            //if (qrcode.UsedSize > 0)
            //{
            //    ViewBag.TotalSize = qrcode.TotalSize;
            //    ViewBag.UsedSize = qrcode.UsedSize;
            //    ViewBag.CreateTime = qrcode.CreateTime;
            //    ViewBag.UpdateTime = qrcode.UpdateTime;
            //    ViewBag.NickName = qrcode.User.NickName;
            //}
            //else
            //{
            //    ViewBag.TotalSize = qrcode.TotalSize;
            //    ViewBag.CreateTime = qrcode.CreateTime;
            //}
           
        }

        //以下皆弃用
        public ActionResult qr(bool used=true)
        {
            var models = new List<QRViewModel>();
            var i = 1;
            if (used)
            {
                foreach (var item in db.QRCodes.Where(u => u.UsedSize > 0).ToList())
                {
                    var model = new QRViewModel
                    {
                        Id = i++,
                        QRCodeId = item.QRCodeId,
                        SiteUrl = item.SiteUrl,
                        CreateTime = item.CreateTime,
                        UpdateTime = item.UpdateTime,
                        TotalSize = item.TotalSize,
                        UsedSize = item.UsedSize,
                        UserName = item.User.NickName,
                        UserPicUrl = item.User.PicUrl
                    };
                    models.Add(model);
                }
                return View("ViewUsed",models);
            }else
            {
                foreach (var item in db.QRCodes.Where(u => u.UsedSize == 0).ToList())
                {
                    var model = new QRViewModel
                    {
                        Id = i++,
                        QRCodeId = item.QRCodeId,
                        SiteUrl = item.SiteUrl,
                        CreateTime = item.CreateTime,
                        TotalSize = item.TotalSize,
                        UsedSize = item.UsedSize
                    };
                    models.Add(model);     
                }
                return View("ViewUnused",models);
            }
            
        }
     

        // 
        // POST: /Home/Create
        [HttpPost]
        public ActionResult Create(float totalSize = 1, int createCount = 1)
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
            return RedirectToAction("qr", new { used=false});
        }

        //[HttpPost]
        public ActionResult Edit(int id, float totalSize = 1)
        {
           
            QRCode qrcode = db.QRCodes.Find(id);
            if (qrcode == null)
            {
                return HttpNotFound();
            }
            if (totalSize < qrcode.UsedSize)
                return RedirectToAction("Index");
            qrcode.TotalSize = totalSize;
            db.SaveChanges();
            return RedirectToAction("qr", new { used = false });
        }

        //先用get
        // POST: /Home/Delete/5
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
    }
}
