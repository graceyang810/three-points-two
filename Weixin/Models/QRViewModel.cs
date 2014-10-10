using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Weixin.Models
{
    //二维码
    public class QRViewModel
    {
        [Display(Name = "序号")]
        public int Id { get; set; }
        public int QRCodeId { get; set; }
        [Display(Name = "网址")]
        public string SiteUrl { get; set; }
        [Display(Name = "文本内容")]
        public string Content { get; set; }
        [Display(Name="总空间")]
        public float TotalSize { get; set; }
        [Display(Name = "已用空间")]
        public float UsedSize { get; set; }
        [Display(Name = "生成时间")]
        public DateTime CreateTime { get; set; }
        [Display(Name = "最近修改时间")]
        public Nullable<DateTime> UpdateTime { get; set; }
        [Display(Name = "用户昵称")]
        public string UserName { get; set; }
        [Display(Name = "用户头像")]
        public string UserPicUrl { get; set; }
        [Display(Name = "资源列表")]
        public List<ResourceViewModel> Resources { get; set; }
       
       
    }
    public class ResourceViewModel
    {
        [Display(Name = "资源地址")]
        public String Url { get; set; }
        [Display(Name = "资源类型")]
        public int Type { get; set; }
        [Display(Name = "资源大小")]
        public float Size { get; set; }
    }
}