using System;
using System.Collections.Generic;
using System.Linq;

namespace WebChat.Helpers
{
    public class UserRole
    {
        private string _userName;
        private string _roleName;

        public string UserName
        {
            get { return _userName; }
            set { _userName = value; }
        }

        public string RoleName
        {
            get { return _roleName; }
            set { _roleName = value; }
        }
    }
}

