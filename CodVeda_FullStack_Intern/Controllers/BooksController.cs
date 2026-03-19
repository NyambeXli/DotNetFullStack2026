//BooksController
using Microsoft.AspNetCore.Mvc;
using CodVeda_FullStack_Intern.Data;
using Microsoft.AspNetCore.Http;
using CodVeda_FullStack_Intern.Models;
using Microsoft.EntityFrameworkCore; 
using System.Linq;
using System.Threading.Tasks; 

namespace CodVeda_FullStack_Intern.Controllers
{
    public class BooksController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BooksController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var currentUser = HttpContext.Session.GetString("UserName");
            var books = (currentUser == "System Admin")
                        ? await _context.Books.ToListAsync()
                        : await _context.Books.Where(b => !b.IsHidden).ToListAsync();

            return View(books);
        }

        public IActionResult Create()
        {
            if (HttpContext.Session.GetString("UserName") != "System Admin")
                return RedirectToAction("Index");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Book book)
        {
            if (HttpContext.Session.GetString("UserName") != "System Admin")
                return RedirectToAction("Index");

            if (ModelState.IsValid)
            {
                _context.Add(book);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(book);
        }

        public async Task<IActionResult> Edit(int id)
        {
            if (HttpContext.Session.GetString("UserName") != "System Admin")
                return RedirectToAction("Index");

            var book = await _context.Books.FindAsync(id);
            if (book == null) return NotFound();

            return View(book);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Book book)
        {
            if (HttpContext.Session.GetString("UserName") != "System Admin")
                return RedirectToAction("Index");

            if (ModelState.IsValid)
            {
                _context.Update(book);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(book);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            if (HttpContext.Session.GetString("UserName") != "System Admin")
                return RedirectToAction("Index");

            var book = await _context.Books.FindAsync(id);
            if (book != null)
            {
                _context.Books.Remove(book);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> ToggleHide(int id)
        {
            if (HttpContext.Session.GetString("UserName") != "System Admin")
                return RedirectToAction("Index");

            var book = await _context.Books.FindAsync(id);
            if (book != null)
            {
                book.IsHidden = !book.IsHidden;
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
