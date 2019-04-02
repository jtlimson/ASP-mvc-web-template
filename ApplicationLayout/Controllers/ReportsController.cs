using ApplicationLayout.Filters;
using System.Web.Mvc;

namespace ApplicationLayout.Controllers
{
    [Authentication]
    public class ReportsController : Controller
    {
        #region Index
        // GET: Reports
        public ActionResult Index()
        {
            return View();
        }
        #endregion
    }
}