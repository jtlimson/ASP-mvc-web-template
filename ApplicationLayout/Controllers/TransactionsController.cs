using ApplicationLayout.Filters;
using System.Web.Mvc;

namespace ApplicationLayout.Controllers
{
    [Authentication]
    public class TransactionsController : Controller
    {
        #region Index
        // GET: Transactions
        public ActionResult Index()
        {
            return View();
        }
        #endregion
    }
}