using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.T4Templating;
using Store.Web.App;

namespace Store.Web.Controllers
{
    public class CatalogController : Controller
    {
        public   ProductService productservice ;
        public CatalogController(ProductService productservice)
        {
            this.productservice = productservice;
        }

        public IActionResult Index()
        {
            
            return View();
        }
        public IActionResult CatalogByGender(string gender)
        {
          
                return View(productservice.GetByGender(gender));
            
        }

    }
}
