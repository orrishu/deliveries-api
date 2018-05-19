using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DeliveriesApi.Models
{
    public class CodeItem
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public int Count { get; set; }
    }
}