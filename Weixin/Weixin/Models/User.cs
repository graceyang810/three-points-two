using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Weixin.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string NickName { get; set; }
        public string OpenId { get; set; }
        public string PicUrl { get; set; }
        public virtual List<QRCode> QRCodes { get; set; }
    }
}