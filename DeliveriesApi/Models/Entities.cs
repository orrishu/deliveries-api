using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DeliveriesApi.Models
{
    public class TenderItem
    {
        [Key]
        public int TenderID { get; set; }
        public DateTime TenderDate { get; set; }
        public string Title { get; set; }
    }

    public class Branch
    {
        public int BranchID { get; set; }
        public string BranchName { get; set; }
    }

    public class Advertiser
    {
        public int AdvertiserID { get; set; }
        public string AdvertiserName { get; set; }
    }

    public class TenderType
    {
        public int TenderTypeID { get; set; }
        public string TenderTypeName { get; set; }
    }
}