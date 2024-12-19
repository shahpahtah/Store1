using Microsoft.AspNetCore.Mvc;
using Store.Web.App;
using Store.Web.Models;

namespace Store.Web.Controllers
{
    public class SearchController : Controller
    {
        private readonly ProductService productService;
        public SearchController(ProductService productService)
        {       
            this.productService = productService;
        }
        
        [HttpPost]
        public IActionResult Index(string? query)
        {
            IReadOnlyCollection<ProductModel> products;
            products=productService.GetByQuery(query);
            return View(products);
        }
    }
}
