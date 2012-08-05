using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using WebChat.Models;

namespace WebChat.Controllers
{
    public class JavaScriptController : Controller
    {
        ChatRoomRepository roomRepository = new ChatRoomRepository();
        
        //[Authorize(Roles="Admins,Friends")]
        public JsonResult GetMessages(int id)
        {
            ChatRoom room = roomRepository.GetChatRoom(id);

            if (room == null)
                return this.Json(null);

            var msg = (from m in room.Messages
                       orderby m.MessageTimeStamp
                       select new
                       {
                           MessageId = m.MessageID,
                           MessageText = m.MessageText,
                           MessageOwner = m.MessageOwner,
                           MessageTimeStamp = m.MessageTimeStamp
                       }).ToList();

            //return this.Json(msg);
            return Json(msg, JsonRequestBehavior.AllowGet); 
        }

        //[Authorize(Roles="Admins,Friends")]
        public JsonResult GetMessagesAfter(int roomid, int msgid)
        {
            ChatRoom room = roomRepository.GetChatRoom(roomid);

            if (room == null)
                return this.Json(null);

            var msg = (from m in room.Messages
                       where m.MessageID > msgid
                       orderby m.MessageTimeStamp
                       select new
                       {
                           MessageId = m.MessageID,
                           MessageText = m.MessageText,
                           MessageOwner = m.MessageOwner,
                           MessageTimeStamp = m.MessageTimeStamp
                       }).ToList();

            //return this.Json(msg);
            return Json(msg, JsonRequestBehavior.AllowGet); 
        }

        //[Authorize(Roles="Admins,Friends")]
        public JsonResult GetUsers(int id)
        {
            ChatRoom room = roomRepository.GetChatRoom(id);

            if (room == null)
                return this.Json(null);

            var users = (from u in room.LoggedInUsers
                         select new
                         {
                             UserLogin = u.LoginTimeStamp,
                             UserName = u.UserName
                         }).ToList();

            //return this.Json(users);
            return Json(users, JsonRequestBehavior.AllowGet); 
        }
    }
}
