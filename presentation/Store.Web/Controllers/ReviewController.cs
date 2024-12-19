using Microsoft.AspNetCore.Mvc;

namespace Store.Web.Controllers
{
    public class ReviewController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult ShowThankYou(string name)
        {
            return PartialView("_ThankYou",name);
        }
    }
}
