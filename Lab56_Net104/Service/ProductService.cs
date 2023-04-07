using Buoi1.IServices;
using Buoi1.Models;

namespace Buoi1.Services
{
    public class ProductService : IProductService
    {
        ShopDbContext _dbContext;

        public ProductService()
        {
            _dbContext = new ShopDbContext();
        }

        public bool CreateProduct(Product p)
        {
            try
            {
                _dbContext.Products.Add(p);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
                
            }
        }

        public bool DeleteProduct(Guid id)
        {
            try
            {
                //Find(Id) chỉ dùng được khi id là khóa chính
                var product = _dbContext.Products.FirstOrDefault(x => x.Id == id);
                _dbContext.Products.Remove(product);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;

            }
        }

        public List<Product> GetAllProducts()
        {
            return _dbContext.Products.ToList();
        }

        public Product GetProductById(Guid id)
        {
            return _dbContext.Products.FirstOrDefault(c => c.Id == id);
        }

        public List<Product> GetProductByName(string name)
        {
            return _dbContext.Products.Where(c => c.Name.Contains(name)).ToList();
        }

        public bool UpdateProduct(Product p)
        {
            try
            {
                //Find(Id) chỉ dùng được khi id là khóa chính
                var product = _dbContext.Products.FirstOrDefault(x => x.Id == p.Id);
                product.Name = p.Name;
                product.Description = p.Description;
                product.Price = p.Price;
                product.Status = p.Status;
                product.Supplier = p.Supplier;
                product.AvailableQuantity = p.AvailableQuantity;
                _dbContext.Products.Update(product);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;

            }
        }
    }
}
