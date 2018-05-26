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

    public class Employee
    {
        public int EmployeeID { get; set; }
        public string EmployeeName { get; set; }
    }

    public class DeliveryStatus
    {
        public int StatusID { get; set; }
        public string StatusName { get; set; }
    }
}