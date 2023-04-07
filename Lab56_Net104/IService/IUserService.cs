﻿using Buoi1.Models;
namespace Buoi1.IServices
{
    public interface IUserService
    {
        public bool CreateUser(User p);
        public bool UpdateUser(User p);
        public bool DeleteUser(Guid id);
        public List<User> GetAllUsers();
        public User GetUserById(Guid id);
        public List<User> GetUserByName(string name);
    }
}
