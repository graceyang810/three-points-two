using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Weixin.Models
{
    public enum Type { 
        Image=0,
        Audio=1,
        Video=2
    }
    public class Resource
    {
        public int ResourceId { get; set; }
        public string Url { get; set; }
        public int Type { get; set; }
        public float Size { get; set; }
        public int QRCodeId { get; set; }
        public virtual QRCode QRCode { get; set; }

    }
}