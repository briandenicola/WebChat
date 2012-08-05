using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebChat.Models
{
    public class ChatRoomRepository : WebChat.Models.IChatRoomRepository
    {

        WebChatDataContext db = new WebChatDataContext();

        public IQueryable<ChatRoom> FindAllChatRooms()
        {
            return db.ChatRooms;
        }

        public ChatRoom GetChatRoom(int id)
        {
            return db.ChatRooms.SingleOrDefault(c => c.ChatRoomID == id);
        }

        public void Add(ChatRoom room)
        {
            db.ChatRooms.InsertOnSubmit(room);
        }

        public void Delete(ChatRoom room)
        {
            db.LoggedInUsers.DeleteAllOnSubmit(room.LoggedInUsers);
            db.Messages.DeleteAllOnSubmit(room.Messages);
            db.ChatRooms.DeleteOnSubmit(room);
        }

        public void RemoveFromLoggedInUsers(LoggedInUser user)
        {
            db.LoggedInUsers.DeleteOnSubmit(user);
        }

        public void Save()
        {
            db.SubmitChanges();
        }
    }
}
