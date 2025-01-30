using Microsoft.AspNetCore.Mvc;
using System.Linq;

using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UserController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: User/Login
        public IActionResult Login()
        {
            return View();
        }

        // POST: User/Login
        [HttpPost]
        public IActionResult Login(User user)
        {
            var existingUser = _context.Users
                .FirstOrDefault(u => u.Name == user.Name && u.Password == user.Password);

            if (existingUser != null)
            {
                HttpContext.Session.SetString("UserName", existingUser.Name);
                return RedirectToAction("Index", "Dashboard");
            }

            ViewBag.Message = "Invalid credentials!";
            return View();
        }

        // GET: User/Signup
        public IActionResult Signup()
        {
            return View();
        }

        // POST: User/Signup
        [HttpPost]
        public IActionResult Signup(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return RedirectToAction("Login");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }

    }
}
