using ApplicationLayout.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

// HTML helper extension class
public static class PageHelper
{
    
    #region CurrentMenu
    /// <summary>
    /// HtmlHelper class
    /// Validates if the controller variable is the current controller accessed
    /// Used in Views->Shared->_Layout to highlight the current menu
    /// Sample usage @Html.CurrentMenu("maintenance")
    /// </summary>
    /// <param name="controller">string (defaults to null)</param>
    /// <param name="action">string (defaults to null)</param>
    /// <returns>string</returns>
    public static string CurrentMenu(this HtmlHelper html, string controller = null, string action = null)
    {
        string cssClass = "active";
        string currentAction = ((string)html.ViewContext.RouteData.Values["action"]).ToLower();
        string currentController = ((string)html.ViewContext.RouteData.Values["controller"]).ToLower();

        //if no value for controller, controller variable defaults to the value of currentController
        if (String.IsNullOrEmpty(controller))
            controller = currentController;
        //if no value for action, action variable defaults to the value of currentAction
        if (String.IsNullOrEmpty(action))
            action = currentAction;

        return (controller == currentController && action == currentAction) ? cssClass : String.Empty;
    }
    #endregion

    #region PageTitle
    /// <summary>
    /// HtmlHelper class
    /// Returns the current contoller and action and use this as the current title of the page
    /// This is used in Views->Shared->_Layout
    /// Sample usage @Html.PageTitle()
    /// </summary>
    /// <returns>string</returns>
    public static string PageTitle(this HtmlHelper html)
    {
        string currentAction = ((string)html.ViewContext.RouteData.Values["action"]);
        string currentController = ((string)html.ViewContext.RouteData.Values["controller"]);

        return currentController + '-' + currentAction;
    }
    #endregion
       
    #region GetBaseUrl
    /// <summary>
    /// UrlHelper class
    /// Returns the base Url of the application
    /// Sample usage @Url.GetBaseUrl()
    /// </summary>
    /// <param name="controller">string (defaults to null)</param>
    /// <param name="action">string (defaults to null)</param>
    /// <returns>string URL</returns>
    public static string GetBaseUrl()
    {
        var appSettings = new AppSettings();
        return appSettings.BaseURL;
    }
    #endregion
}