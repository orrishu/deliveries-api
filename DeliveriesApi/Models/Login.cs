using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DeliveriesApi.Models
{
    public class Login
    {
        //Login BL
        
        public enum LoginStatus
        {
            OK = 1,
            NoSuchUserExists = 100,            
            GeneralError = 999
        }

        private LoginData m_loginProps;
        private LoginStatus m_loginStatusCode;
        private string m_loginMessage;
        private MinifiedUser m_User;

        public LoginStatus LoginStatusCode
        {
            get { return m_loginStatusCode; }
        }

        public string LoginMessage
        {
            get { return m_loginMessage; }
        }

        public MinifiedUser User
        {
            get { return m_User; }
        }

        public Login(LoginData loginProps)
        {
            this.m_loginProps = loginProps;
        }

        internal bool CheckLogin()
        {            
            //implement login check on db;
            DB oData = new DB();
            User oUser = null;
            
            //something like: 

            try
            {
                //check db for user and pass
                oUser = oData.Login(this.m_loginProps.userName, this.m_loginProps.password);
            }
            catch (Exception e)
            {
                if (e.Message.Contains("Sequence contains no elements"))
                    this.m_loginStatusCode = LoginStatus.NoSuchUserExists;
                else
                {
                    this.m_loginStatusCode = LoginStatus.GeneralError;
                    this.m_loginMessage = e.Message;
                }

                return false;
            }

            //** DEBUG: **
           // oUser = new User() { EmployeeID = 1, EmployeeName = "shimmi" };

            if (oUser == null)
            {
                this.m_loginStatusCode = LoginStatus.NoSuchUserExists;
                return false;
            }
            else
            {
                //if user is logged on, add user to m_inforUser
                //create a string of user data params.
                //note, that EVERY CHANGE on the encrypted string should also reflect to UserHelper.DecryptUserData() method!
                string userData = oUser.EmployeeID.ToString() + "|*|" + oUser.EmployeeName.ToString();

                userData = StEncrypter.Encrypt4Web(userData);

                this.m_User = new MinifiedUser()
                {
                    userName = this.m_loginProps.userName,
                    contactName = HttpUtility.UrlEncode(oUser.EmployeeName.ToString()),
                    userData = userData,
                    persistent = this.m_loginProps.rememberMe
                };

                this.m_loginStatusCode = LoginStatus.OK;

                return true;
            }

        }

        /// <summary>
        /// gets the status code and returns a user-friendly message in hebrew
        /// </summary>
        /// <param name="loginStatus"></param>
        /// <returns></returns>
        public static string FriendlyLoginMessage(LoginStatus loginStatus)
        {
            string ret = "";
            switch (loginStatus)
            {
                case LoginStatus.OK:
                    ret = "התחברות עברה בהצלחה";
                    break;
                case LoginStatus.NoSuchUserExists:
                    ret = "משתמש בשם זה לא קיים או הסיסמא שגויה";
                    break;               
                case LoginStatus.GeneralError:
                    ret = "שגיאה כללית בהתחברות למערכת";
                    break;
                default:
                    ret = "";
                    break;
            }

            return ret;
        }
    }

    public class UserHelper
    {
        /// <summary>
        /// get a 'minified' user and convert it to TenderUser class
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static object GetCurrentUser(bool minified = false)
        {
            try
            {
                //forms authentication: this way returns the current logged on user
                string userName = System.Web.HttpContext.Current.User.Identity.Name;                

                if (!string.IsNullOrEmpty(userName))    //only if user is logged via forms authentication
                {
                    System.Web.HttpCookie cookie = System.Web.HttpContext.Current.Request.Cookies.Get("UserData");

                    if (cookie != null)
                    {
                        //return current user from cookie
                        MinifiedUser oUser = Newtonsoft.Json.JsonConvert.DeserializeObject<MinifiedUser>(cookie.Value);
                        if (!minified)
                        {
                            User oTenderUser = UserHelper.DecryptUserData(oUser);
                            return oTenderUser;
                        }
                        else
                            return oUser;
                    }
                    else
                        return null;
                }
                else
                    return null;
            }
            catch
            {
                return null;
            }
        }        

        private static User DecryptUserData(MinifiedUser user)
        {
            try
            {
                //get user data from userData prop, and decrypt it;
                string userData = StEncrypter.Decrypt4Web(user.userData);
                //split the params to an array;
                string[] arr = userData.Split(new string[] { "|*|" }, StringSplitOptions.None);
                //get params. note, that EVERY CHANGE on the encrypted string should also reflect to that method!
                int iEmployeeID = int.Parse(arr[0]);               
                string sEmployeeName = arr[1];

                User oUser = new User()
                {
                    EmployeeID = iEmployeeID,
                    EmployeeName = sEmployeeName
                };

                return oUser;
            }
            catch
            {
                return null;
            }
        }
    }

    public class LoginData
    {
        public string userName { get; set; }
        public string password { get; set; }
        public bool rememberMe { get; set; }
    }

    public class User
    {
        public int EmployeeID { get; set; }
        public string EmployeeName { get; set; }
    }

    public class MinifiedUser
    {
        public string userName { get; set; }
        public string contactName { get; set; }
        public string userData { get; set; }
        public bool persistent { get; set; }        
    }
}