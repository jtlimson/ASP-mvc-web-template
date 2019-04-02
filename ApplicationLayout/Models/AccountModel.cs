using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace ApplicationLayout.Models
{
    public class AccountModel
    {
        #region HttpStatus
        //<description>
        //sends the logged in employee's username and password for ldap validation
        //</description>
        //<param>string url, string username, string password</param>
        //<return>httpstatuscode(200, 404, 500, etc.)</return>
        public HttpStatusCode HttpStatus(string url, string username, string password)
        {
            try
            {
                using (var wc = new System.Net.WebClient())
                {
                    // credentials
                    wc.Credentials = new System.Net.NetworkCredential(username, password);

                    // make it a POST instead of a GET
                    wc.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";

                    // send and get answer in a string
                    string result = wc.UploadString(url.Trim(), "POST");
                }
                return HttpStatusCode.Accepted;

            }
            catch (System.Net.WebException ex)
            {
                return (HttpStatusCode)ex.Response.ContentLength;
            }
        }
        #endregion

        #region redirectUrl
        //<description>
        //identifies the appropriate landing page for logged in user
        //</description>
        //<param></param>
        //<return>string url</return>
        public string redirectUrl()
        {
            return "Home/Index";
        }
        #endregion
    }
}