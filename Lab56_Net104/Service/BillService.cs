using Buoi1.IServices;
using Buoi1.Models;

namespace Buoi1.Services
{
    public class BillService : IBillService
    {
        ShopDbContext _dbContext;
        public BillService()
        {
            _dbContext = new ShopDbContext();
        }
        public bool CreateBill(Bill p)
        {
            try
            {
                _dbContext.Bills.Add(p);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;

            }
        }

        public bool DeleteBill(Guid id)
        {
            try
            {
                //Find(Id) chỉ dùng được khi id là khóa chính
                var bill = _dbContext.Bills.FirstOrDefault(x => x.Id == id);
                _dbContext.Bills.Remove(bill);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;

            }
        }

        public List<Bill> GetAllBills()
        {
            return _dbContext.Bills.ToList();
        }

        public Bill GetBillById(Guid id)
        {
            return _dbContext.Bills.FirstOrDefault(c => c.Id == id);
        }

        public List<Bill> GetProductByName(string name)
        {
            throw new NotImplementedException();
        }

        public bool UpdateBill(Bill p)
        {
            try
            {
                //Find(Id) chỉ dùng được khi id là khóa chính
                var bill = _dbContext.Bills.FirstOrDefault(x => x.Id == p.Id);
                bill.UserId = p.UserId;
                bill.CreateDate = p.CreateDate;
                bill.Status = p.Status;
                _dbContext.Bills.Update(bill);
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
