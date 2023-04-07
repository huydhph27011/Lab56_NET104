﻿using Buoi1.Models;

namespace Buoi1.IServices
{
    public interface IBillService
    {
        public bool CreateBill(Bill p);
        public bool UpdateBill(Bill p);
        public bool DeleteBill(Guid id);
        public List<Bill> GetAllBills();
        public Bill GetBillById(Guid id);
        public List<Bill> GetProductByName(string name);
    }
}
