using Buoi1.Models;

namespace Buoi1.IServices
{
    public interface ICartDetailService
    {
        public bool CreateCartDetails(CartDetails p);
        public bool UpdateCartDetails(CartDetails p);
        public bool DeleteCartDetails(Guid id);
        public List<CartDetails> GetAllCartDetails();
        public CartDetails GetCartDetailsById(Guid id);
        public List<CartDetails> GetCartDetailsByName(string name);
    }
}
