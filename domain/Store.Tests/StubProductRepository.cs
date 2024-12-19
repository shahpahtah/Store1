using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Tests
{
    public class StubProductRepository : IProductRepository
    {
        public Product[] ResultOfGetAll {  get; set; }
        public bool ResultOfisCategory {  get; set; }
        public bool ResultOfisGender {  get; set; }
        public Product[] GetAll()
        {
            return ResultOfGetAll;
        }

		public Product[] GetAllByIds(IEnumerable<int> bookIds)
		{
			throw new NotImplementedException();
		}

		public bool isCategory(string query)
        {
            return ResultOfisCategory;
        }

        public bool isGender(string query)
        {
            return ResultOfisCategory;
        }
    }
}
