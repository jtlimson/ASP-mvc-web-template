using ApplicationLayout.Filters;
using System.Web.Mvc;

namespace ApplicationLayout.Controllers
{
    [Authentication]
    public class MaintenanceController : Controller
    {
        #region Index
        // GET: Maintenance
        public ActionResult Index()
        {
            return View();
        }
        #endregion
    }
}