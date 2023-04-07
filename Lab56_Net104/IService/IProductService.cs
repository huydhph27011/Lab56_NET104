using Buoi1.Models;

namespace Buoi1.IServices
{
    public interface IProductService
    {
        public bool CreateProduct(Product p);
        public bool UpdateProduct(Product p);
        public bool DeleteProduct(Guid id);
        public List<Product> GetAllProducts();
        public Product GetProductById(Guid id);
        public List<Product> GetProductByName(string name);
    }
}