using Buoi1.IServices;
using Buoi1.Models;

namespace Buoi1.Services
{
    public class UserService : IUserService
    {
        ShopDbContext _dbContext;
        public UserService()
        {
            _dbContext = new ShopDbContext();
        }
        public bool CreateUser(User p)
        {
            try
            {
                _dbContext.Users.Add(p);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;

            }
        }

        public bool DeleteUser(Guid id)
        {
            try
            {
                //Find(Id) chỉ dùng được khi id là khóa chính
                var user = _dbContext.Users.FirstOrDefault(x => x.Id == id);
                _dbContext.Users.Remove(user);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;

            }
        }

        public List<User> GetAllUsers()
        {
            return _dbContext.Users.ToList();
        }

        public User GetUserById(Guid id)
        {
            return _dbContext.Users.FirstOrDefault(c => c.Id == id);
        }

        public List<User> GetUserByName(string name)
        {
            return _dbContext.Users.Where(c => c.Name.Contains(name)).ToList();
        }

        public bool UpdateUser(User p)
        {
            try
            {
                //Find(Id) chỉ dùng được khi id là khóa chính
                var user = _dbContext.Users.FirstOrDefault(x => x.Id == p.Id);
                user.Name = p.Name;
                user.Status = p.Status;
                user.Password = p.Password;
                user.IdCv = p.IdCv;
                _dbContext.Users.Update(user);
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
