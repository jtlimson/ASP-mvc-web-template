using ApplicationLayout.Filters;
using ApplicationLayout.Models;
using ApplicationLayout.ViewModels;
using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ApplicationLayout.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        //model to perform functionalities for AccountController
        AccountModel accountModel = new AccountModel();

        #region Login GET
        // GET: /Account/Login
        public ActionResult Login(string ReturnUrl)
        {
            //Assign value to ReturnUrl from the browser address bar
            ViewBag.ReturnUrl = ReturnUrl;
            if (Session.Count > 0)
            {
                //redirect user to appropriate landing page
                if (!string.IsNullOrEmpty(ReturnUrl) && Url.IsLocalUrl(ReturnUrl))
                {
                    return Redirect(ReturnUrl);
                }
                else return Redirect(accountModel.redirectUrl());
            }
            return View();
        }
        #endregion

        #region Login POST
        // POST: /Account/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model, string ReturnUrl)
        {
            //check if token from @Html.AntiForgeryToken() in form is valid
            if (ModelState.IsValid)
            {
                var _username = model.UserName;
                var _password = model.Password;

                //checks if LDAP authentication is enabled in web.config
                AppSettings config = new AppSettings();
                bool bypass = bool.Parse(config.BypassLDAP);
                Session["IsAuthenticated"] = "false";

                if (!bypass)
                {
                    try
                    {
                        //perform LDAP Authentication
                        var stat = accountModel.HttpStatus("http://lrdcweb.lrdc.metrobank.com/authentication/knet2/", _username, _password);
                        if ((int)stat < 400 || (int)stat == 404)
                        {
                            Session["IsAuthenticated"] = "true";
                        }
                        else
                        {
                            ModelState.AddModelError("", "Invalid username or password.");
                        }
                    }
                    catch (Exception e)
                    {
                        ModelState.AddModelError("", e.Message.ToString());
                    }
                }
                else
                {
                    //LDAP login bypassed
                    Session["IsAuthenticated"] = "true";
                }

                if (Session["IsAuthenticated"].ToString() == "true")
                {
                    //redirect user to appropriate landing page
                    if (!string.IsNullOrEmpty(ReturnUrl) && Url.IsLocalUrl(ReturnUrl))
                    {
                        return Redirect(ReturnUrl);
                    }
                    else return Redirect(accountModel.redirectUrl());
                }

            }
            return View(model);
        }
        #endregion

        #region Logout POST
        // POST: /Account/LogOut
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Clear();
            return RedirectToAction("Login", "Account");
        }
        #endregion
    }
}