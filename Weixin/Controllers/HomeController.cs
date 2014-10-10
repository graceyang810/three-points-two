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
        }
    }
}
