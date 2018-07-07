using DeliveriesApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.SqlClient;
using System.Data;
using Newtonsoft.Json;

namespace DeliveriesApi.Util
{
    public class DeliveriesController : ApiController
    {
        [ActionName("GetDeliveries")]
        [HttpGet]
        public object GetDeliveries(int page, int pageSize, string filters="", string sort = "")
        {
            //http://localhost:56110/api/deliveries/getdeliveries?page=1&pageSize=20
            //debug
            //test 2
            DB oDb = new DB();
            DataTable dt = new DataTable();
            DataTable dtemp = new DataTable();
            DataTable dtstat = new DataTable();

            dtemp = oDb.GetEmployees();
            dtstat = oDb.GetDeliveryStatus();

            
            

            dt = oDb.GetDeliveries(filters, sort);

            IEnumerable<DeliveryItem> lst = (from a in dt.AsEnumerable()
                                             select new DeliveryItem()
                                             {
                                                 DeliveryID = Utils.ParamValueInt(a["DeliveryID"].ToString()),
                                                 DeliveryNumber = Utils.ParamValueInt(a["DeliveryNumber"].ToString()),
                                                 MySort = Utils.ParamValueInt(a["MySort"].ToString()),
                                                 FinishtimeSenc = Utils.ParamValueDate(a["Finishtime"].ToString()),
                                                 DeliveryTime = Utils.ParamValueDate(a["DeliveryTime"].ToString()),
                                                 CustomerName = Utils.ParamValuestring(a["CustomerName"].ToString()),
                                                 CompanyNameLet = Utils.ParamValuestring(a["CompanyNameLet"].ToString()),
                                                 MyOut = Utils.ParamValuestring(a["MyOut"].ToString()),
                                                 CityName_1 = Utils.ParamValuestring(a["CityName_1"].ToString()),
                                                 archOut = Utils.ParamValuestring(a["archOut"].ToString()),
                                                 mysort2 = Utils.ParamValueInt(a["mysort2"].ToString()),
                                                 CompanyNameGet = Utils.ParamValuestring(a["CompanyNameGet"].ToString()),
                                                 Mydes = Utils.ParamValuestring(a["Mydes"].ToString()),
                                                 cityName = Utils.ParamValuestring(a["cityName"].ToString()),
                                                 archDes = Utils.ParamValuestring(a["archDes"].ToString()),
                                                 employeeID = Utils.ParamValueInt(a["employeeID"].ToString()),
                                                 oEmployeeID = Utils.ParamValueEmployee(Utils.ParamValueInt(a["employeeID"].ToString()), dtemp),
                                                 employeeIDsec = Utils.ParamValueInt(a["employeeIDsec"].ToString()),
                                                 oEmployeeIDsec = Utils.ParamValueEmployee(Utils.ParamValueInt(a["employeeIDsec"].ToString()), dtemp),
                                                 DeliveryStatus = Utils.ParamValueInt(a["DeliveryStatus"].ToString()),
                                                 oDeliveryStatus= Utils.ParamValueStatus(Utils.ParamValueInt(a["DeliveryStatus"].ToString()), dtstat),
                                                 FinishTime = Utils.ParamValueDate(a["FinishTime"].ToString()),
                                                 UrgencysName = Utils.ParamValuestring(a["UrgencysName"].ToString()),
                                                 Govayna = Utils.ParamValueInt(a["Govayna"].ToString()),
                                                 CustomerDeliveryNo = Utils.ParamValueInt(a["CustomerDeliveryNo"].ToString()),
                                                 Barcode = Utils.ParamValuestring(a["Barcode"].ToString()),
                                                 Comment = Utils.ParamValuestring(a["Comment"].ToString()),
                                                 ContactManName = Utils.ParamValuestring(a["ContactManName"].ToString()),
                                                 UserName = Utils.ParamValuestring(a["UserName"].ToString()),
                                                 WhereToWhere = Utils.ParamValueInt(a["WhereToWhere"].ToString()),
                                                 VehicleTypeID = Utils.ParamValueInt(a["VehicleTypeID"].ToString()),
                                                 EmployeeID_Third = Utils.ParamValueInt(a["EmployeeID_Third"].ToString()),
                                                 oEmployeeID_Third = Utils.ParamValueEmployee(Utils.ParamValueInt(a["EmployeeID_Third"].ToString()), dtemp),
                                                 DeliveyOut = Utils.ParamValuestring(a["DeliveyOut"].ToString()),
                                                 Receiver = Utils.ParamValuestring(a["Receiver"].ToString()),
                                                 DeliveryDate = Utils.ParamValueDate(a["DeliveryDate"].ToString()),
                                                 //tehumDate = Utils.ParamValueDate(a["TehumDateOnly"].ToString()),
                                                 PakageNum = Utils.ParamValueInt(a["PakageNum"].ToString()),
                                                 BoxNum = Utils.ParamValueInt(a["BoxNum"].ToString()),
                                                 Waiting = Utils.ParamValueInt(a["Waiting"].ToString()),
                                                 CustomerID = Utils.ParamValueInt(a["CustomerID"].ToString())          
                                      });

            dt.Dispose();
            dt = null;
            //return lst;
            return new
            {
                info = new
                {
                    count = lst.Count(),
                    page
                },
                data = lst.Skip(pageSize * (page - 1)).Take(pageSize)
            };
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

        [ActionName("GetVehicleType")]
        [HttpGet]
        public object GetVehicleType()
        {
            //http://localhost:56110/api/deliveries/GetVehicleType

            DB oDb = new DB();
            DataTable dt = new DataTable();
            dt = oDb.GetVehicleType();

            List<VehicleType> lst = new List<VehicleType>();

            foreach (DataRow dr in dt.Rows)
            {
                VehicleType oItem = new VehicleType();
                oItem.VehicleTypeID = Convert.ToInt32(dr["VehicleTypeID"]);
                oItem.VehicleTypeName = dr["VehicleTypeName"].ToString();
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

        [ActionName("SetDeliveryEmployee")]
        [HttpGet]
        public object SetDeliveryEmployee(int DeliveryNumber, int EmployeeID, int Type)
        {
            //http://localhost:56110/api/deliveries/SetDeliveryEmployee?DeliveryNumber=219861&EmployeeID=156&Type=1
            //Type: 1=אוסף
            //Type: 2=מוסר
            //Type: 3=שליח שלישי
            DB oDb = new DB();
            string res = oDb.SetDeliveryEmployee(DeliveryNumber, EmployeeID, Type);

           // if(res!="1")


            return res;
        }

        [ActionName("SetDeliveryStatus")]
        [HttpGet]
        public object SetDeliveryStatus(int DeliveryNumber, int StatusID)
        {
            //http://localhost:56110/api/deliveries/SetDeliveryStatus?DeliveryNumber=219861&StatusID=1
           
            DB oDb = new DB();
            string res = oDb.SetDeliveryStatus(DeliveryNumber, StatusID);

            // if(res!="1")


            return res;
        }

    }
}
