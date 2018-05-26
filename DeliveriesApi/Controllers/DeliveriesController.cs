using DeliveriesApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.SqlClient;
using System.Data;



namespace DeliveriesApi.Util
{
    public class DeliveriesController : ApiController
    {
        [ActionName("GetDeliveries")]
        [HttpGet]
        public object GetDeliveries()
        {
            //http://localhost:56110/api/deliveries/getdeliveries
            //debug
            //test 2
            DB oDb = new DB();
            DataTable dt = new DataTable();
            dt = oDb.GetDeliveries();
            /*
            List<DeliveryItem> lst = new List<DeliveryItem>();
            
            foreach(DataRow dr in dt.Rows)
            {
                DeliveryItem oItem = new DeliveryItem();
                oItem.Id = Convert.ToInt32(dr["DeliveryID"]); 
                oItem.From = dr["CompanyNameGet"].ToString();
                oItem.To = dr["CompanyNameLet"].ToString();
                oItem.DeliveryNote = dr["DeliveryNumber"].ToString();
                oItem.Description = dr["Comment"].ToString();
                oItem.Name1 = dr["ContactManName"].ToString();
                oItem.Name2 = dr["Receiver"].ToString();
                oItem.Combo1 = "";
                oItem.Combo2 = "";
                oItem.Combo3 = "";
                oItem.Receiver1 = "";
                oItem.Collect = Utils.ParamValueInt(dr["Govayna"].ToString());
                oItem.Date = Convert.ToDateTime(dr["DeliveryDate"]);
                oItem.ReceivedAt = dr["ReceivdTime"].ToString();
                oItem.CustomerName = dr["CustomerName"].ToString();
                oItem.FromAddress = dr["MyOut"].ToString();
                oItem.ToAddress = dr["MyDes"].ToString();
                oItem.Importance = dr["UrgencysName"].ToString();
                oItem.Field1 = Utils.ParamYesNo(Convert.ToInt32(dr["IsDouble"].ToString()));
                oItem.CourierCollected = dr["EmployeeID"].ToString();
                oItem.CourierDelivered = dr["EmployeeIDSec"].ToString();
                oItem.Status = dr["DeliveryStatus"].ToString();
                oItem.EndTime = dr["DeliveryTimeTras"].ToString();
                lst.Add(oItem);

            }
            */
            List<DeliveryItem> lst = (from a in dt.AsEnumerable()
                                      select new DeliveryItem()
                                      {
                                          Id = Convert.ToInt32(a["DeliveryID"]),
                                          From = a["CompanyNameGet"].ToString(),
                                          To = a["CompanyNameLet"].ToString(),
                                          DeliveryNote = a["DeliveryNumber"].ToString(),
                                          Description = a["Comment"].ToString(),
                                          Name1 = a["ContactManName"].ToString(),
                                          Name2 = a["Receiver"].ToString(),
                                          Combo1 = "",
                                          Combo2 = "",
                                          Combo3 = "",
                                          Receiver1 = "",
                                          Collect = Utils.ParamValueInt(a["Govayna"].ToString()),
                                          Date = Convert.ToDateTime(a["DeliveryDate"]),
                                          ReceivedAt = a["ReceivdTime"].ToString(),
                                          CustomerName = a["CustomerName"].ToString(),
                                          FromAddress = a["MyOut"].ToString(),
                                          ToAddress = a["MyDes"].ToString(),
                                          Importance = a["UrgencysName"].ToString(),
                                          Field1 = Utils.ParamYesNo(Convert.ToInt32(a["IsDouble"].ToString())),
                                          CourierCollected = a["EmployeeID"].ToString(),
                                          CourierDelivered = a["EmployeeIDSec"].ToString(),
                                          Status = a["DeliveryStatus"].ToString(),
                                          EndTime = a["DeliveryTimeTras"].ToString()
                                      }).ToList();

            dt.Dispose();
            dt = null;
            return lst;
        }


        [ActionName("GetEmployees")]
        [HttpGet]
        public object GetEmployees()
        {
            //http://localhost:56110/api/deliveries/GetEmployees

            DB oDb = new DB();
            DataTable dt = new DataTable();
            dt = oDb.GetEmployees();

            List<Employee> lst = new List<Employee>();

            foreach (DataRow dr in dt.Rows)
            {
                Employee oItem = new Employee();
                oItem.EmployeeID = Convert.ToInt32(dr["EmployeeID"]);
                oItem.EmployeeName = dr["EmployeeName"].ToString();
                lst.Add(oItem);

            }
            

            return lst;
        }

        [ActionName("GetDeliveryStatus")]
        [HttpGet]
        public object GetDeliveryStatus()
        {
            //http://localhost:56110/api/deliveries/GetDeliveryStatus

            DB oDb = new DB();
            DataTable dt = new DataTable();
            dt = oDb.GetDeliveryStatus();

            List<DeliveryStatus> lst = new List<DeliveryStatus>();

            foreach (DataRow dr in dt.Rows)
            {
                DeliveryStatus oItem = new DeliveryStatus();
                oItem.StatusID = Convert.ToInt32(dr["StatusID"]);
                oItem.StatusName = dr["StatusName"].ToString();
                lst.Add(oItem);

            }


            return lst;
        }

    }
}
