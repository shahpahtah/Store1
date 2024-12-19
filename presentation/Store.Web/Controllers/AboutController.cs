using Microsoft.AspNetCore.Mvc;

namespace Store.Web.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
