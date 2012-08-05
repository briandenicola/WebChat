using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebChat.Helpers;

namespace WebChat.Models
{
    public class UserRepository : WebChat.Models.IUserRepository
    {

        UsersDataContext db = new UsersDataContext();

        public IQueryable<aspnet_User> FindAllUsers()
        {
            return db.aspnet_Users;
        }

        public IQueryable<aspnet_Role> FindAllRoles()
        {
            return db.aspnet_Roles;
        } 

        public IQueryable<aspnet_Logging> GetLogs()
        {
            return db.aspnet_Loggings;
        }

        public string GetRoleName(System.Guid id)
        {
            return db.aspnet_Roles
                    .Where( r => r.RoleId == id )
                    .SingleOrDefault()
                    .RoleName;
        }

        public string GetUserName(System.Guid id)
        {
            return db.aspnet_Users
                    .Where( u => u.UserId== id )
                    .SingleOrDefault()
                    .UserName;
        }

        public List<UserRole> GetUsersInRoles()
        {
            var mapping  = (from r in db.aspnet_UsersInRoles
                            select new UserRole
                            {
                                RoleName = GetRoleName(r.RoleId),
                                UserName = GetUserName(r.UserId)
                            }).ToList();
            return mapping;

        }

    }
}