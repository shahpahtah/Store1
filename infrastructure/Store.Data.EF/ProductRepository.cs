using Microsoft.EntityFrameworkCore.Design;
using Store.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Data.EF
{
    public class ProductRepository : IProductRepository
    {
        private readonly DbContextFactory dbContextFactory;
        public ProductRepository(DbContextFactory dbContextFactory)
        {
            this.dbContextFactory = dbContextFactory;
        }
        public Product[] GetAll()
        {
            var dbcontext = dbContextFactory.Create(typeof(ProductRepository));
            return dbcontext.Products.Select(Product.Mapper.Map).ToArray();
        }

        public Product[] GetAllByIds(IEnumerable<int> bookIds)
        {
            var dbcontext = dbContextFactory.Create(typeof(ProductRepository));
            return dbcontext.Products.Where(Product => bookIds.Contains(Product.Id)).Select(Product.Mapper.Map).ToArray();
        }

        public bool isCategory(string query)
        {
            var product = new Product();
            if (product.categories.Contains(query.ToLower()))
            {
                return true;
            }
            return false;
        }

        public bool isGender(string query)
        {
            if (query.ToLower() == "женское" || query.ToLower() == "мужское")
            {
                return true;
            }
            return false;
        }
    }
}
