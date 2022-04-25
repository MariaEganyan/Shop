using Shop.Models;

namespace Shop.Interfaces
{
    public interface IProductservice
    {
        IEnumerable<ProductDto> GetProducts();
        void AddProduct(ProductDto product);
        void DeletProductById(int id);
    }
}
