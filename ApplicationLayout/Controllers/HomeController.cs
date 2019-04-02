using System.Web.Mvc;
using ApplicationLayout.Filters;

namespace ApplicationLayout.Controllers
{
    [Authentication]
    public class HomeController : Controller
    {
        #region Index
        public ActionResult Index()
        {
            return View();
        }
        #endregion
    }
}