using Shop.Interfaces;
using Shop.Models;

namespace Shop.Services
{
    public class ProductService : IProductservice
    {
        private readonly TestContext _context;
        public ProductService()
        {
            _context = new TestContext();
        }
        public void AddProduct(ProductDto product)
        {
            using(var context= _context)
            {
                var p = new Product()
                {
                    Description = product.Description,
                    Productid = product.Productid,
                    Price = product.Price,
                };
                context.Products.Add(p);
                context.SaveChanges();
            }
        }

        public void DeletProductById(int id)
        {
            using(var context= _context)
            {
                var productes = from c in context.Products
                                select new ProductDto()
                                {
                                    Description=c.Description,
                                    Price = c.Price,
                                    Productid = c.Productid,
                                };
                var prod = productes.FirstOrDefault(c => c.Productid == id);
                if (prod == null)
                {
                    throw new Exception("Tath product is not found");
                }
                else
                {
                    var p = new Product()
                    {
                       Description=prod.Description,
                       Productid=prod.Productid,
                       Price=prod.Price,
                    };
                    context.Products.Remove(p);
                    context.SaveChanges();
                }
            }
        }

        public IEnumerable<ProductDto> GetProducts()
        {
            using(var context= _context)
            {
                var products = from p in context.Products
                               select new ProductDto()
                               {
                                   Description = p.Description,
                                   Price = p.Price,
                                   Productid = p.Productid,
                               };
                return products;
            }
        }
    }
}
