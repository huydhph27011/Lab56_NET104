using Buoi1.IServices;
using Buoi1.Models;

namespace Buoi1.Services
{
    public class BillDetailService : IBillDetailService
    {
        ShopDbContext _dbContext;
        public BillDetailService()
        {
            _dbContext = new ShopDbContext();
        }
        public bool CreateBillDetail(BillDetail p)
        {
            try
            {
                _dbContext.BillDetails.Add(p);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;

            }
        }

        public bool DeleteBillDetail(Guid id)
        {
            try
            {
                //Find(Id) chỉ dùng được khi id là khóa chính
                var bill = _dbContext.BillDetails.FirstOrDefault(x => x.Id == id);
                _dbContext.BillDetails.Remove(bill);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;

            }
        }

        public List<BillDetail> GetAllBillDetails()
        {
            return _dbContext.BillDetails.ToList();
        }

        public BillDetail GetBillDetailById(Guid id)
        {
            return _dbContext.BillDetails.FirstOrDefault(c => c.Id == id);
        }

        public List<BillDetail> GetBillDetailByName(string name)
        {
            throw new NotImplementedException();
        }

        public bool UpdateBillDetail(BillDetail p)
        {
            try
            {
                //Find(Id) chỉ dùng được khi id là khóa chính
                var bill = _dbContext.BillDetails.FirstOrDefault(x => x.Id == p.Id);
                bill.IdSp = p.IdSp;
                bill.IdHD = p.IdHD;
                bill.Quanlity = p.Quanlity;
                bill.Price = p.Price;
                _dbContext.BillDetails.Update(bill);
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
