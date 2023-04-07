using Buoi1.Models;

namespace Buoi1.IServices
{
    public interface IRoleService
    {
        public bool CreateRole(Role p);
        public bool UpdateRole(Role p);
        public bool DeleteRole(Guid id);
        public List<Role> GetAllRoles();
        public Role GetRoleById(Guid id);
        public List<Role> GetRoleByName(string name);
    }
}
