using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DeliveriesApi.Models;

namespace DeliveriesApi.Controllers
{
    public class SearchController : ApiController
    {
        [ActionName("Autocomplete")]
        [HttpGet]
        //api/Search/AutoComplete?query=Moses
        public object Autocomplete(string query)
        {
            return new
            {
                type = "person",
                id = 11,
                text = "Moses"
            };
        }

        [ActionName("ResultPage")]
        [HttpGet]
        //api/Search/ResultPage?page=1&pageSize=10&filters=[{field:'subsubject',values:[10001,10032]},{field:'area',values:[1,3,21]}]&tags=[{type:'people',id:33542},{type:'people_partial',id:'מירי'}]
        public object GetResultPage(string tags, string filters, int page = 1, int pageSize = 10, string sort = "")
        {
            //debug
            return new
            {
                info = new
                {
                    count = 11,
                    page = 1
                },
                data = new {CompanyID = 1, CompanyName = "TestM"} 
            };
        }

        [ActionName("GetFilters")]
        [HttpGet]
        //api/Search/GetFilters?tags=[{type:'people',id:33542},{type:'people_partial',id:'מירי'}]&filters=[{field:'subsubject',values:[10001,10032]},{field:'area',values:[1,3,21]}]&tags=[{type:'people',id:33542},{type:'people_partial',id:'מירי'}]
        public object GetFilters(string tags, string filters, string sort = "")
        {
            //debug
            return new
            {
                field = "Class",
                values = new int[2] { 10001, 10032 }
            };
        }               
    }
}
