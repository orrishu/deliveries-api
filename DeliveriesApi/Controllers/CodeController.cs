using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DeliveriesApi.Models;

namespace DeliveriesApi.Util
{
    public class CodeController : ApiController
    {
        [ActionName("GetCodes")]
        [HttpGet]
        public object GetCodes()
        {
            //http://localhost:56110/api/code/getcodes
            //debug
            List<CodeItem> lst = new List<CodeItem>()
            {
                new CodeItem() { Id = 1, Code = "AHFKKSKKDDD", Count = 11} ,
                 new CodeItem() { Id = 2, Code = "AHFKEERRDDD", Count = 12}
            };

            return lst;
        }
    }
}
