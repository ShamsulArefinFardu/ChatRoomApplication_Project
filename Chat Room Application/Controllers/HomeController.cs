using Chat_Room_Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace Chat_Room_Application.Controllers
{
    public class HomeController : Controller
    {
        private ChatRoomContext context = new ChatRoomContext();

        //public ActionResult Index()
        //{
        //    return View();
        //}

        public ActionResult Register()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        //[Authorize(Roles = "Admin")]
        public ActionResult Admin()
        {
            ViewBag.InactiveUserList = new SelectList(context.Users.Where(u => u.Active == false).Select(u => new { u.UserName, User = u.UserName + ": " + u.Email }), "UserName", "User");
            ViewBag.ActiveUserList = new SelectList(context.Users.Where(u => u.Active == true).Except(context.UserRoles.Include(Ur => Ur.User).Select(ur => ur.User)).Select(u => new { u.UserName, User = u.UserName + ": " + u.Email }), "UserName", "User");
            ViewBag.RoleList = new SelectList(context.Roles.Select(r => new { r.RoleID, r.Name }), "RoleID", "Name");
            ViewBag.ChatRoomList = new SelectList(context.ChatRooms.Select(cr => new { cr.RoomName }), "RoomName", "RoomName");
            ViewBag.UserListWithRole = new SelectList(context.UserRoles.Select(ur => new { ur.UserRoleID, ur.UserName }), "UserRoleID", "UserName");
            ViewBag.Roles = context.Roles.ToList();
            ViewBag.ChatRooms = context.ChatRooms.ToList();
            var RoomWiseUsers = context.ConversationRooms.Include(cr => cr.UserRole).OrderBy(cr => cr.RoomName).ThenBy(cr => cr.UserRole.UserName).ToList();
            ViewBag.RoomWiseUsers = RoomWiseUsers;
            return View();
        }

        public ActionResult Chat()
        {
            //string loginName = Request.QueryString.Get("user");
            //ViewBag.RoomBasedUseres = context.ConversationRooms.Include(cr => cr.UserRole).Where(cr => cr.Allowed == true).OrderBy(cr => cr.RoomName).ThenBy(cr => cr.UserRole.UserName).ToList();
            //ViewBag.RoomBasedUseres = context.ConversationRooms.Include(CreateDatabaseIfNotExists => CreateDatabaseIfNotExists.UserRole).Where(cr => cr.UserRole.UserName == loginName && cr.Allowed == true).Select(cr => cr.RoomName).ToList();
            return View();
        }
    }
}