namespace Buoi1.Models
{
    public class CartDetails
    {
        public Guid Id { get; set; }
        public Guid IdGH { get; set; }
        public Guid IdSp { get; set; }
        public int Quanlity { get; set; }
        public virtual Cart Cart { get; set; }
        public virtual Product Product { get; set; }
    }
}
