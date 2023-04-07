namespace Buoi1.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public Guid IdCv { get; set; }
        public int Status { get; set; }
        public virtual Role Role { get; set; }
        public virtual Cart Cart { get; set; }
        public virtual ICollection<Bill> Bill { get; set; }
    }
}
