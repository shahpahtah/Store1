using Store.Web.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Web.App
{
    public class ProductService
    {
        IProductRepository _repository;
        public ProductService(IProductRepository productRepository) {
            _repository = productRepository;
        }
        public  IReadOnlyCollection<ProductModel> GetByCategory(string category)
        {
            var products = _repository.GetAll().Where(i => i.category.Contains(category)).ToArray();
            return products.Select(Map).ToArray();
        }
        public IReadOnlyCollection<ProductModel> GetAll()
        {
            var products = _repository.GetAll();
            return products.Select(Map).ToArray();
        }
      
		private ProductModel Map(Product product)
		{
			return new ProductModel { category=product.category, name=product.name, categories=product.categories, description=product.description, gender=product.gender, characteristic= product.characteristic, id=product.id, imgsrc= product.imgsrc , price= product.price};
		}

		public IReadOnlyCollection<ProductModel> GetByGender(string gender)
        {
            var products=_repository.GetAll().Where(i => i.gender.ToLower() == gender.ToLower()).ToArray();
			return products.Select(Map).ToArray();
		}
        public IReadOnlyCollection<ProductModel> GetByTitle(string title)
        {
            var products= _repository.GetAll().Where(i => i.description.Contains(title)).ToArray();
			return products.Select(Map).ToArray();
		}
        public ProductModel GetById(int id)
        {
            var products = _repository.GetAll().Single(i => i.id == id);
			return Map(products);
		}
        public bool isCategory(string query)
        {
            return _repository.isCategory(query);
        }
        public IReadOnlyCollection<ProductModel> Starts(string query)
        {
            var products =_repository.GetAll().Where(i => i.name.ToLower().StartsWith(query.ToLower())).ToArray();
			return products.Select(Map).ToArray();
		}
        public IReadOnlyCollection<ProductModel> GetByQuery(string query)
        {
			IReadOnlyCollection<ProductModel>  products =Starts(query);
           
            if (products.Count> 0)
            {
                return products;
            }
            else if (_repository.isGender(query))
            {
                products = GetByGender(query);
            }
            else if (isCategory(query))
            {
                products = GetByCategory(query);
            }
            else
            {
                products = GetByTitle(query);
            }
            return products;
        }
    }
}
