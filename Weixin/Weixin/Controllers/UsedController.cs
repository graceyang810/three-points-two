using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Weixin.Models;

namespace Weixin.Controllers
{
    public class UsedController : Controller
    {
        private WeixinContext db = new WeixinContext();

        //
        // GET: /Used/
        public ActionResult Index()
        {
            var models = new List<QRViewModel>();
            var i = 1;

            foreach (var item in db.QRCodes.Where(u => u.UsedSize > 0).ToList())
            {
                var resources = new List<ResourceViewModel>();
                foreach (var r in item.Resources)
                {
                    resources.Add(new ResourceViewModel
                    {
                        Url = r.Url,
                        Type = r.Type,
                        Size = r.Size
                    });
                }
                var model = new QRViewModel
                {
                    Id = i++,
                    QRCodeId = item.QRCodeId,
                    SiteUrl = item.SiteUrl,
                    Content = item.Content,
                    CreateTime = item.CreateTime,
                    UpdateTime = item.UpdateTime,
                    TotalSize = item.TotalSize,
                    UsedSize = item.UsedSize,
                    UserName = item.User.NickName,
                    UserPicUrl = item.User.PicUrl,
                    Resources = resources
                };
                models.Add(model);
            }
            return View(models);
        }
        public ActionResult Edit(int id)
        {
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
            db.QRCodes.Remove(qrcode);//会自动级联删除对应资源
            db.SaveChanges();
            return RedirectToAction("Index");
        }



    }
}
