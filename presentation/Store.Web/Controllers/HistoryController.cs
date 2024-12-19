using Microsoft.AspNetCore.Mvc;

namespace Store.Web.Controllers
{
    public class HistoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
