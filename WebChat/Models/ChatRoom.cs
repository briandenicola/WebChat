using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebChat.Models
{
    public partial class ChatRoom
    {
        public bool IsOwner(string userName)
        {
            return ChatRoomCreator.Equals(userName, StringComparison.InvariantCultureIgnoreCase);
        }

        public bool IsUserLoggedIn(string userName)
        {
            return LoggedInUsers.Any(r => r.UserName.Equals(userName, StringComparison.InvariantCultureIgnoreCase));
        }

        public IList<LoggedInUser> getAllUsers()
        {
            return LoggedInUsers.ToList<LoggedInUser>();
        }

        public int getUserCount()
        {
            return LoggedInUsers.Count;
        }

        public int getMessageCount()
        {
            return Messages.Count;
        }

    }
}
