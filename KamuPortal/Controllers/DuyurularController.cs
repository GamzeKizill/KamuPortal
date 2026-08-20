using KamuPortal.Data;
using KamuPortal.Models;
using Microsoft.AspNetCore.Mvc;

namespace KamuPortal.Controllers
{
    public class DuyurularController : Controller
    {
        private readonly AppDbContext _context;
        
        public DuyurularController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var duyurular = _context.Duyurular.ToList();
            return View(duyurular);
        }

        public IActionResult Create()
        {
            if (HttpContext.Session.GetString("Admin") == null)
            {
                return RedirectToAction("Login", "Admin");
            }

            return View();

        }

        [HttpPost]
        public IActionResult Create(Duyurular duyuru)
        {
            if (ModelState.IsValid)
            {
                _context.Duyurular.Add(duyuru);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(duyuru);
        }
    }
}
