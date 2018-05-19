using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DeliveriesApi.Models
{
    public class Login
    {
        //Login BL
        private string m_token;

        public string Token
        {
            get { return m_token; }
            //set { m_token = value; }
        }

        internal bool CheckLogin()
        {
            throw new NotImplementedException();
        }
        
    }

    public class LoginData
    {
        public string userName { get; set; }
        public string password { get; set; }
    }

    public class TenderUser
    {
        public int InstalledProductID { get; set; }
        public int Customer2ReleaseID { get; set; }
        public int CustomerID { get; set; }
    }
}