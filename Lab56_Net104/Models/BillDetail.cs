namespace Buoi1.Models
{
    public class BillDetail
    {
        public Guid Id { get; set; }
        public Guid IdSp { get; set; }
        public Guid IdHD { get; set; }
        public int Quanlity { get; set; }
        public int Price { get; set; }
        public virtual Bill Bill { get; set; }
        public virtual Product Product { get; set; }
    }
}
