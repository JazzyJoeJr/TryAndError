using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ZwartOpWit.Models;
using System.Linq;
using Microsoft.Extensions.Configuration;

namespace ZwartOpWit.Controllers
{
    public class UserController : Controller
    {
        private readonly AppDBContext _context;

        public UserController(AppDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ViewResult Index()
        {
            UserListVM userListVM = new UserListVM();
            
            userListVM.userList = _context.Users.ToList(); 

            return View(userListVM);
        }

        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }

        [HttpGet]
        public ViewResult Read(int id)
        {
            UserVM userVM = new UserVM();
            userVM.user = _context.Users.FirstOrDefault(x => x.Id == id);

            return View(userVM);
        }

        [HttpGet]
        public ViewResult Update(int id)
        {
            UserVM userVM = new UserVM();
            userVM.user = _context.Users.FirstOrDefault(x => x.Id == id);
            return View(userVM);
        }

        [HttpPost]
        public IActionResult Create(User user)
        {
            if (_context.Users.Any(e => e.Username == user.Username))
            {
                ModelState.AddModelError("Username", "Username is already in use.");
                
            }
            if (!ModelState.IsValid)
            {
                return View(user);
            }
            _context.Users.Add(user);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Update(User user)
        {
            User originalUser;
            UserVM userVM;

            userVM = new UserVM();
            //originalUser = _context.Users.FirstOrDefault(e => e.Id == user.Id);

            ////Check if user that needs to be updated exists
            //if (originalUser == null)
            //{
            //    throw new Exception("No user found with id " + user.Id);
            //}

            ////Validate if another user already uses this username
            //if (_context.Users.Any(e => e.Username == user.Username && e.Username != originalUser.Username))
            //{
            //    ModelState.AddModelError("user.Username", "Username is already in use.");
            //}

            if (!ModelState.IsValid)
            {
                userVM.user = user;
                return View(userVM);
            }
            _context.Entry(user).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var original = _context.Users.FirstOrDefault(e => e.Id == id);
            if (original != null)
            {
                _context.Users.Remove(original);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        
    }
}
