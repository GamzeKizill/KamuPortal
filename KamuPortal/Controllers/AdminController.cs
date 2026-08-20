using KamuPortal.Data;
using KamuPortal.Models;
using Microsoft.AspNetCore.Mvc;

namespace KamuPortal.Controllers
{
    public class AdminController : Controller
    {
        private readonly AppDbContext _context;

        public AdminController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Login()
        {
            if (!_context.Adminler.Any())
            {
                _context.Adminler.Add(new Admin
                {
                    KullaniciAdi = "admin",
                    Sifre = "123456"
                });

                _context.SaveChanges();
            }

            return View();
        }

        [HttpPost]
        public IActionResult Login(string kullaniciAdi, string sifre)
        {
            var admin = _context.Adminler.FirstOrDefault(x =>
                x.KullaniciAdi == kullaniciAdi &&
                x.Sifre == sifre);

            if (admin != null)
            {
                HttpContext.Session.SetString(
                    "Admin",
                    admin.KullaniciAdi 
                );

                return RedirectToAction("Dashboard");
            }

            ViewBag.Hata = "Kullanıcı adı veya şifre yanlış.";

            return View();
        }

        public IActionResult Dashboard()
        {
            var admin = HttpContext.Session.GetString("Admin");

            if (admin == null)
            {
                return RedirectToAction("Login");
            }

            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();

            return RedirectToAction("Login");
        }
    }
}  