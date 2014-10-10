using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace Weixin.Models
{
    public class QRCode
    {
        public int QRCodeId { get; set; }
        [Required]
        public string SiteUrl { get; set; }
        public string Content { get; set; }
        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "值必须大于0")]
        public float TotalSize { get; set; }
        [Required]
        public float UsedSize { get; set; }
        [Required]
        public DateTime CreateTime { get; set; }
        public Nullable<DateTime> UpdateTime { get; set; }
        public int? UserId { get; set; }
        public virtual User User { get; set; }
        public virtual List<Resource> Resources { get; set; }
    }
}