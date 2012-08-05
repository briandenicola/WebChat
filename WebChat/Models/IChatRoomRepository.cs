using System;

namespace WebChat.Models
{
    interface IChatRoomRepository
    {
        void Add(ChatRoom room);
        void Delete(ChatRoom room);
        System.Linq.IQueryable<ChatRoom> FindAllChatRooms();
        ChatRoom GetChatRoom(int id);
        void Save();
    }
}
