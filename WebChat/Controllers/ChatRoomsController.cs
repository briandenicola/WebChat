using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using WebChat.Models;
using WebChat.Helpers;

namespace WebChat.Controllers
{
    public class ChatRoomsController : Controller
    {
        //
        // GET: /ChatRooms/
        ChatRoomRepository roomRepository = new ChatRoomRepository();

        public ActionResult Index(int? page)
        {
            const int pageSize = 5;

            var rooms = roomRepository.FindAllChatRooms()
                .OrderByDescending(c => c.ChatRoomID);
                
            var pageinatedRooms = new PaginatedList<ChatRoom>(rooms, page ?? 0, pageSize);
               
            return View(pageinatedRooms);
        }

        [Authorize(Roles="Admins,Friends")]
        public ActionResult Room(int id, FormCollection collection)
        {
            ChatRoom room = roomRepository.GetChatRoom(id);

            if (room == null)
                return View("NotFound");

            if( collection.Count > 0 )
                AddMessage(id, User.Identity.Name, collection[0]);
            
            return View(room);
        }

        //
        // GET: /ChatRooms/Create
        [Authorize(Roles="Admins")]
        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /ChatRooms/Create
        [AcceptVerbs(HttpVerbs.Post),Authorize(Roles="Admins")]
        public ActionResult Create(ChatRoom room)
        {
            try
            {
                room.ChatRoomCreator = User.Identity.Name;
                room.ChatRoomCreateDate = DateTime.Now;

                roomRepository.Add(room);
                roomRepository.Save();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [Authorize(Roles="Admins")]
        public ActionResult Delete(int id)
        {
            ChatRoom room = roomRepository.GetChatRoom(id);

            if (room == null)
                return View("NotFound");
            
            if (!room.IsOwner(User.Identity.Name))
                return View("NotOwner");
            
            return View(room);

        }

        [AcceptVerbs(HttpVerbs.Post), Authorize(Roles="Admins")]
        public ActionResult Delete(int id, string confirmButton)
        {
            ChatRoom room = roomRepository.GetChatRoom(id);

            if (room == null)
                return View("NotFound");

            if (!room.IsOwner(User.Identity.Name))
                return View("InvalidOwner");

            roomRepository.Delete(room);
            roomRepository.Save();

            return View("Deleted");
        }

        //
        // GET: /ChatRooms/Edit/5
        [Authorize(Roles="Admins")]
        public ActionResult Edit(int id)
        {
            ChatRoom room = roomRepository.GetChatRoom(id);

            if (room.IsOwner(User.Identity.Name))
                return View(room);
            else
                return View("InvalidOwner");
        }

        //
        // POST: /ChatRooms/Edit/5

        [AcceptVerbs(HttpVerbs.Post), Authorize(Roles="Admins")]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                ChatRoom room = roomRepository.GetChatRoom(id);

                if (room == null)
                    return View("NotFound");

                if (room.IsOwner(User.Identity.Name))
                {
                    try
                    {
                        UpdateModel(room);
                        roomRepository.Save();
                        return RedirectToAction("Index");
                    }
                    catch
                    {
                        return View();
                    }
                }
                else
                    return View("InvalidOwner");
            }
            catch
            {
                return View();
            }
        }

        [Authorize(Roles = "Friends,Admins")]
        public ActionResult Join(int id)
        {
            ChatRoom room = roomRepository.GetChatRoom(id);

            if (room == null)
                return RedirectToAction("NotFound", "ChatRooms");
            try
            {
                LoggedInUser user = new LoggedInUser();
                user.UserName = User.Identity.Name;
                user.LastMessageTimeStamp = DateTime.Now;
                user.LoginTimeStamp = DateTime.Now;
                room.LoggedInUsers.Add(user);
                roomRepository.Save();

                AddMessage(id, User.Identity.Name, " has joined the chat");

            }
            catch
            {
                RedirectToAction("Error", "ChatRooms");
            }

            return RedirectToAction("Room", "ChatRooms", new { id = room.ChatRoomID });
        }

        [Authorize(Roles = "Friends,Admins")]
        public ActionResult Leave(int id)
        {
            ChatRoom room = roomRepository.GetChatRoom(id);

            if (room == null)
                return RedirectToAction("NotFound", "ChatRooms");

            try
            {
                LoggedInUser user = room.LoggedInUsers.SingleOrDefault(u => u.UserName == User.Identity.Name);
                roomRepository.RemoveFromLoggedInUsers(user);
                roomRepository.Save();

                AddMessage(id, User.Identity.Name, " has left the chat");

            }
            catch
            {
                RedirectToAction("Error", "ChatRooms");
            }

            return RedirectToAction("Index", "ChatRooms");
        }

        private void AddMessage(int id, string user, string msgText)
        {
            ChatRoom room = roomRepository.GetChatRoom(id);

            Message msg = new Message();

            msg.MessageOwner = user;
            msg.MessageTimeStamp = DateTime.Now;
            msg.MessageText = msgText;

            room.Messages.Add(msg);
            roomRepository.Save();
        }

    }
}
