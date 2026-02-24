using Microsoft.AspNetCore.Mvc;
using CodVeda_FullStack_Intern.Models;
using CodVeda_FullStack_Intern.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace CodVeda_FullStack_Intern.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _context;
        
        public AccountController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(User newUser)
        {
            var emailExists = await _context.Users.AnyAsync(u => u.Email == newUser.Email);
            
            if (emailExists)
            {
                ModelState.AddModelError("Email", "This email address is already in our database.");
            }

            if (ModelState.IsValid)
            {
                _context.Users.Add(newUser);
                await _context.SaveChangesAsync(); 
                return RedirectToAction("Login");
            }
            return View(newUser);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string email, string password)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                ViewBag.ErrorMessage = "Email and password are required";
                return View();
            }

            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email && u.Password == password);

            if (user != null)
            {
                HttpContext.Session.SetString("UserName", user.FullName);
                return RedirectToAction("Index", "Home");
            }

            ViewBag.ErrorMessage = "Invalid Login Attempt";
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}
