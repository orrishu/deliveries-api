using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DeliveriesApi.Models
{
    public class MyDB: DbContext
    {
        public DbSet<Branch> Branches { get; set; }
        public DbSet<TenderItem> Tender { get; set; }
    }
}