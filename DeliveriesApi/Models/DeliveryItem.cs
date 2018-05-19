using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DeliveriesApi.Models
{
    public class DeliveryItem
    {
        public int Id { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public string DeliveryNote { get; set; }
        public string Description { get; set; }
        public string Name1 { get; set; }
        public string Name2 { get; set; }
        public string Combo1 { get; set; }
        public string Combo2 { get; set; }
        public string Combo3 { get; set; }
        public string Receiver1 { get; set; }
        public int Collect { get; set; }
        public DateTime Date { get; set; }
        public string ReceivedAt { get; set; }
        public string CustomerName { get; set; }
        public string FromAddress { get; set; }
        public string ToAddress { get; set; }
        public string Importance { get; set; }
        public string Field1 { get; set; }
        public string CourierCollected { get; set; }
        public string CourierDelivered { get; set; }
        public string Status { get; set; }
        public string EndTime { get; set; }
    }
}