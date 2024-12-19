 using Store.data;
using System.Xml;

namespace Store;

public class Product
{
    public  List<string> categories = new List<string> { "юбка", "футболка", "джинсы", "рубашка", "куртка", "платье","свитшот","бомбер","свитер","жакет"};
    private readonly ProductDto dto;
    public int id { get { return dto.Id; } }
    public string gender 
    {
        get => dto.gender;
        set=>dto.gender= value;
    }
        public decimal price { get => dto.price;
        set => dto.price= value;
    }
    public string name { get => dto.name;
    set => dto.name = value;}
    public string description { get => dto.description; set => dto.description = value; }
    public string category { get => dto.category;set => dto.category = value; }
    public string imgsrc  { get => dto.imgsrc; set => dto.imgsrc = value; }
    public string characteristic { get => dto.characteristic; set => dto.characteristic = value; }   
    internal Product(ProductDto dto)
    {
        this.dto = dto;

    }
    public Product()
    {

    }
    public static class DtoFactory
    {
        public static ProductDto Create(string name,string  description, string gender, decimal price, string category, string imgsrc, string characteristic)
        {
            return new ProductDto
            {
                name = name
                ,
                description = description
                ,
                gender = gender
                    ,
                price = price
                        ,
                category = category
                            ,
                imgsrc = imgsrc
                                ,
                characteristic = characteristic

            };
        }
    }

    public static class Mapper 
    { 
        public static Product Map(ProductDto dto)=>new Product(dto);
        public static ProductDto Map(Product product) => product.dto;
    }




}
