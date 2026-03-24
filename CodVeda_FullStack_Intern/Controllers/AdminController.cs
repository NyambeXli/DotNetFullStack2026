using Microsoft.AspNetCore.Mvc;
using CodVeda_FullStack_Intern.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace CodVeda_FullStack_Intern.Controllers
{
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdminController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> RegisteredUsers()
        {
            var userName = HttpContext.Session.GetString("UserName");
            if (userName != "System Admin")
            {
                return RedirectToAction("Index", "Books");
            }

            var users = await _context.Users
                .OrderBy(u => u.FullName)
                .ToListAsync();

            return View(users);
        }
    }
}