using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.data
{
	public class ProductDto
	{

		public int Id { get; set; }
		public string gender { get; set; }
		public decimal price { get; set; }
		public string name { get; set; }
		public string description { get; set; }
		public string category { get; set; }
		public string imgsrc { get; set; }
		public string characteristic
		{

		get; set; }
	
	}
}
