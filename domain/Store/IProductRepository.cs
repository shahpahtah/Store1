using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store
{
    public interface IProductRepository
    {
        public bool isCategory(string query);
        public bool isGender(string query);
        //Product[] GetByCategory(string category);
        //Product[] GetByTitle(string title);
        //Product[] GetByGender(string gender);
        public Product[] GetAll();
        public Product[] GetAllByIds(IEnumerable<int> bookIds);
        //Product GetById(int id);
        
    }
}
