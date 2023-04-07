using Buoi1.IServices;
using Buoi1.Models;

namespace Buoi1.Services
{
    public class RoleService : IRoleService
    {
        ShopDbContext _dbContext;
        public RoleService()
        {
            _dbContext = new ShopDbContext();
        }
        public bool CreateRole(Role p)
        {
            try
            {
                _dbContext.Roles.Add(p);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;

            }
        }


        public bool DeleteRole(Guid id)
        {
            try
            {
                //Find(Id) chỉ dùng được khi id là khóa chính
                var role = _dbContext.Roles.FirstOrDefault(x => x.Id == id);
                _dbContext.Roles.Remove(role);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;

            }
        }

        public List<Role> GetAllRoles()
        {
            return _dbContext.Roles.ToList();
        }

        public Role GetRoleById(Guid id)
        {
            return _dbContext.Roles.FirstOrDefault(x => x.Id == id);
        }

        public List<Role> GetRoleByName(string name)
        {
            return _dbContext.Roles.Where(c => c.Name.Contains(name)).ToList();
        }

        public bool UpdateRole(Role p)
        {
            try
            {
                //Find(Id) chỉ dùng được khi id là khóa chính
                var role = _dbContext.Roles.FirstOrDefault(x => x.Id == p.Id);
                role.Name = p.Name;
                role.Description = p.Description;
                role.Status = p.Status;
                _dbContext.Roles.Update(role);
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
