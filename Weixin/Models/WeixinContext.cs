using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Weixin.Models
{
    public class WeixinContext:DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<QRCode> QRCodes { get; set; }

        public DbSet<Resource> Resources { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<QRCode>().Property(e => e.SiteUrl).
        }
    }
}