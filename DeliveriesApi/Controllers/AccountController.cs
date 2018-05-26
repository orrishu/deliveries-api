using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DeliveriesApi.Util
{
    public class AccountController : ApiController
    {

        #region Login POST test
        /*  //use that to test POST with fiddler
        POST http://localhost:56110/api/Account/Login HTTP/1.1
        Host: localhost:56110
        Connection: keep-alive
        Content-Length: 36
        Pragma: no-cache
        Cache-Control: no-cache
        Accept: application/json, text/plain, * /*
        User-Agent: Mozilla/5.0 (Windows NT 6.3; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/60.0.3112.78 Safari/537.36
        Content-Type: application/json;charset=UTF-8
        Accept-Encoding: gzip, deflate
        Accept-Language: en-US,en;q=0.8,he;q=0.6

        {"userName":"ori","password":"9999"} 
        */
        #endregion

        [ActionName("Login")]        
        [HttpPost]
        public object Login(Models.LoginData loginData)
        {            
            //implement: check login
            Models.Login oLogin = new Models.Login();
 
            if (oLogin.CheckLogin())
            {
                //implement: logged user handle
                string encryptedToken = oLogin.Token;   //implement encryption
                long milliseconds = DateTimeOffset.Now.AddDays(7).ToUnixTimeMilliseconds();

                //implement: return token to site. if needed, use FormsAuthentication with persistent cookie and [Authorize] attribute
                return new { token = encryptedToken, expires = milliseconds };
            }
            else
            {
                //no such user exists
                var resp = new HttpResponseMessage();
                resp.StatusCode = HttpStatusCode.Unauthorized;
                //add login message to the response
                string msg = "{ \"error\":\"user was not found with given credentials\" }";
                resp.Content = new StringContent(msg, System.Text.Encoding.UTF8, "application/json");

                return resp;
            }
        }

    }
}
