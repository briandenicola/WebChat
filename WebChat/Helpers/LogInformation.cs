using System;
using System.Collections.Generic;
using System.Linq;

namespace WebChat.Helpers
{
    public class LogInformation
    {
        private IEnumerable<WebChat.Models.aspnet_Logging> _logs;
        private IEnumerable<WebChat.Models.aspnet_User> _users;
        private IEnumerable<WebChat.Models.aspnet_Role> _roles;
        private IEnumerable<WebChat.Helpers.UserRole> _usersInRoles;

        public IEnumerable<WebChat.Models.aspnet_Role> Roles
        {
            get { return _roles; }
            set { _roles = value; }
        }
        public IEnumerable<WebChat.Models.aspnet_User> Users
        {
            get { return _users; }
            set { _users = value; }
        }
        public IEnumerable<WebChat.Models.aspnet_Logging> Logs
        {
            get { return _logs; }
            set { _logs = value; }
        }

        public IEnumerable<WebChat.Helpers.UserRole> UsersInRoles
        {
            get { return _usersInRoles; }
            set { _usersInRoles = value; }
        }
    }
}

