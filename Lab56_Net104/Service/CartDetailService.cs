using Buoi1.IServices;
using Buoi1.Models;

namespace Buoi1.Services
{
    public class CartDetailService : ICartDetailService
    {
        ShopDbContext _dbContext;
        public CartDetailService()
        {
            _dbContext = new ShopDbContext();
        }
        public bool CreateCartDetails(CartDetails p)
        {
            try
            {
                _dbContext.CartDetails.Add(p);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;

            }
        }

        public bool DeleteCartDetails(Guid id)
        {
            try
            {
                //Find(Id) chỉ dùng được khi id là khóa chính
                var bill = _dbContext.CartDetails.FirstOrDefault(x => x.Id == id);
                _dbContext.CartDetails.Remove(bill);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;

            }
        }

        public List<CartDetails> GetAllCartDetails()
        {
            return _dbContext.CartDetails.ToList();
        }

        public CartDetails GetCartDetailsById(Guid id)
        {
            return _dbContext.CartDetails.FirstOrDefault(c => c.Id == id);
        }

        public List<CartDetails> GetCartDetailsByName(string name)
        {
            throw new NotImplementedException();
        }

        public bool UpdateCartDetails(CartDetails p)
        {
            try
            {
                //Find(Id) chỉ dùng được khi id là khóa chính
                var cartDetails = _dbContext.CartDetails.FirstOrDefault(x => x.Id == p.Id);
                cartDetails.IdSp = p.IdSp;
                cartDetails.IdGH = p.IdGH;
                cartDetails.Quanlity = p.Quanlity;
                _dbContext.CartDetails.Update(cartDetails);
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
