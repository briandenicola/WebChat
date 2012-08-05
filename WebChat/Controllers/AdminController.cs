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
    public class AdminController : Controller
    {
        UserRepository userRepository = new UserRepository();
        
        [Authorize(Roles = "Admins")]
        public ActionResult Index()
        {
            LogInformation info = new LogInformation();
            info.Logs = userRepository.GetLogs()
                .OrderByDescending(c => c.UserTimeStamp )
                .Take(25);
            info.Roles = userRepository.FindAllRoles();
            info.Users = userRepository.FindAllUsers();
            info.UsersInRoles = userRepository.GetUsersInRoles();

            return View(info);
        }

    }
}