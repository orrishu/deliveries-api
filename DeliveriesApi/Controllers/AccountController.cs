using DeliveriesApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Security;

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
        public object Login(LoginData loginData)
        {            
            //implement: check login
            Login oLogin = new Login(loginData);
 
            if (oLogin.CheckLogin())
            {
                //user is logged
                FormsAuthentication.SetAuthCookie(loginData.userName, loginData.rememberMe);
                //return the user profile from login object;
                MinifiedUser oUser = oLogin.User;
                oLogin = null;
                int iRemember = loginData.rememberMe ? 90 : 1;
                System.Web.HttpCookie newCookie = new System.Web.HttpCookie("UserData");
                newCookie.Name = "UserData";
                newCookie.Path = "/";
                newCookie.Value = Newtonsoft.Json.JsonConvert.SerializeObject(oUser);
                newCookie.Expires = DateTime.Now.AddDays(iRemember);

                System.Web.HttpContext.Current.Response.Cookies.Add(newCookie);

                return oUser;
            }
            else
            {
                //no such user exists
                var resp = new HttpResponseMessage();
                resp.StatusCode = HttpStatusCode.Unauthorized;
                //add login message to the response
                string msg = "{ \"error\":\"" + Models.Login.FriendlyLoginMessage(oLogin.LoginStatusCode);
                if (oLogin.LoginStatusCode == Models.Login.LoginStatus.GeneralError) msg += ": " + oLogin.LoginMessage;
                msg += "\" }";
                resp.Content = new StringContent(msg, System.Text.Encoding.UTF8, "application/json");

                return resp;
            }
        }

        [ActionName("LogOut")]
        [HttpGet]        
        public object LogOut()
        {
            //this will remove the authentication cookie from the client
            FormsAuthentication.SignOut();

            var resp = new HttpResponseMessage();
            resp.StatusCode = HttpStatusCode.OK;
            //delete userdata cookie
            //var cookie = new CookieHeaderValue("UserData", String.Empty);     //CookieHeaderValue not working ... ;
            //cookie.Path = "/";
            //cookie.Expires = DateTime.Now.AddDays(-1);
            //resp.Headers.AddCookies(new CookieHeaderValue[] { cookie });
            //use that instead
            System.Web.HttpCookie cookie = new System.Web.HttpCookie("UserData")
            {
                Name = "UserData",
                Path = "/",
                Value = String.Empty,
                Expires = DateTime.Now.AddDays(-1)
            };
            System.Web.HttpContext.Current.Response.Cookies.Add(cookie);
            resp.Content = new StringContent("{ \"logged\": false }", System.Text.Encoding.UTF8, "application/json");

            return resp;
        }

        ///api/account/me
        [ActionName("Me")]
        [HttpGet]
        public object Me()
        {
            MinifiedUser oUser = (MinifiedUser)UserHelper.GetCurrentUser(true);
            if (oUser != null)
            {
                if (oUser.persistent)
                {
                    //need to postpone the cookie for each request. it is because user has checked 'remember me' when logged...
                    int iRemember = 90;
                    System.Web.HttpCookie newCookie = new System.Web.HttpCookie("UserData");
                    newCookie.Name = "UserData";
                    newCookie.Path = "/";
                    newCookie.Value = Newtonsoft.Json.JsonConvert.SerializeObject(oUser);
                    newCookie.Expires = DateTime.Now.AddDays(iRemember);
                    //newCookie.Domain = "192.118.60.111";

                    System.Web.HttpContext.Current.Response.Cookies.Add(newCookie);
                }
                return oUser;
            }
            else
            {
                //if user did not match, or was not present on cookie, return 401
                var resp = new HttpResponseMessage();
                resp.StatusCode = HttpStatusCode.Unauthorized;
                string msg = "{\"Message\":\"Authorization has been denied for this request.\"}";
                resp.Content = new StringContent(msg, System.Text.Encoding.UTF8, "application/json");

                return resp;
            }
        }        
        
        [HttpGet]
        [Authorize]
        public object TestAuth()
        {
            //implement: use [Authorize] attribute for all methods through api... ;
            return "OK: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
        }

        ///api/account/me
        [ActionName("TestUser")]
        [HttpGet]
        public object TestUser()
        {
            User oUser = (User)UserHelper.GetCurrentUser();

            return oUser;
        }

    }
}
