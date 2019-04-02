using ApplicationLayout.Filters;
using System.Web.Mvc;

namespace ApplicationLayout.Controllers
{
    [Authentication]
    public class HelpController : Controller
    {
        #region Help
        // GET: Help
        public ActionResult Index()
        {
            return View();
        }
        #endregion

        #region Elements
        // GET: Elements
        public ActionResult Elements()
        {
            return View();
        }
        #endregion

        #region Icons
        // GET: Icons
        public ActionResult Icons()
        {
            return View();
        }
        #endregion
    }
}