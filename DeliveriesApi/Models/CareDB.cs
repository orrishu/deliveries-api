using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DeliveriesApi.Models
{
    public class CareDB: DbContext
    {
        public DbSet<TenderUser> UserDetails { get; set; }
    }
}