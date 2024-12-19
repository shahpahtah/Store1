using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Store.Web.App;

namespace Store.Web.Controllers
{
    public class DescController : Controller
    {
        // GET: DescController
        private readonly ProductService productservice;
        public DescController(ProductService productservice) {
            this.productservice=productservice;
        }

        public ActionResult Index(int id)
        {
            ProductModel product = productservice.GetById(id);
            return View(product);
        }

    }
}
