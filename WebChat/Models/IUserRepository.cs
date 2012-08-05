using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebChat.Models
{
    interface IUserRepository
    {
        System.Linq.IQueryable<aspnet_User> FindAllUsers();
        System.Linq.IQueryable<aspnet_Role> FindAllRoles();
        System.Linq.IQueryable<aspnet_Logging> GetLogs();
    }
}
