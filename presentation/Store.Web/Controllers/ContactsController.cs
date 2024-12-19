using Microsoft.AspNetCore.Mvc;

namespace Store.Web.Controllers
{
    public class ContactsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
