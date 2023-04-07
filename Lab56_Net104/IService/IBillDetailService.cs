using Buoi1.Models;

namespace Buoi1.IServices
{
    public interface IBillDetailService
    {
        public bool CreateBillDetail(BillDetail p);
        public bool UpdateBillDetail(BillDetail p);
        public bool DeleteBillDetail(Guid id);
        public List<BillDetail> GetAllBillDetails();
        public BillDetail GetBillDetailById(Guid id);
        public List<BillDetail> GetBillDetailByName(string name);
    }
}
