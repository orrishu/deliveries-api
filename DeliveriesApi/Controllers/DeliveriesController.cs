using DeliveriesApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DeliveriesApi.Controllers
{
    public class DeliveriesController : ApiController
    {
        [ActionName("GetDeliveries")]
        [HttpGet]
        public object GetDeliveries()
        {
            //http://localhost:56110/api/deliveries/getdeliveries
            //debug
            //test
            List<DeliveryItem> lst = new List<DeliveryItem>()
            {
                new DeliveryItem() { Id = 1, From = "קורקט מתנות", To = "רקמות נייטיב", DeliveryNote = "Aa1234", Description = "תיק גב סמסונייט", Name1 = "אפרת",
                Name2 = "אבשלום", Combo1 = "", Combo2 = "מעטפה-", Combo3 = "", Receiver1 = "", Collect = 500, Date = DateTime.Now, ReceivedAt = "11:47",
                CustomerName  = "רקמות נייטיב", FromAddress = "ניר אליהו", ToAddress = "הנגר 10 חולון", Importance = "רגיל", Field1 = "לא", CourierCollected = "דורון",
                CourierDelivered = "אבשלום",  Status="הועבר", EndTime  = "11:47" }
            };

            return lst;
        }
    }
}
