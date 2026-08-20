using KamuPortal.Data;
using KamuPortal.Models;
using Microsoft.AspNetCore.Mvc;

namespace KamuPortal.Controllers
{
    public class HaberlerController : Controller
    {
        private readonly AppDbContext _context;

        public HaberlerController(AppDbContext context)
        {
            _context = context;
        }

        private bool GirisYapilmisMi()
        {
            return HttpContext.Session.GetString("Admin") != null; 
        }
        public IActionResult Index()
        {
            if (!_context.Haberler.Any())
            {
                _context.Haberler.Add(new Haber
                {
                    Baslik = "Valilikten açıklama!",
                    Tarih = new DateTime(2026, 7, 16),
                    Icerik = "Basın açıklaması yayınlandı."
                });

                _context.Haberler.Add(new Haber
                {
                    Baslik = "Teknofest Başvuruları Başladı!",
                    Tarih = new DateTime(2026, 7, 19),
                    Icerik = "Gençler için başvurular başladı."
                });
                _context.SaveChanges(); 
            }

            var haberler = _context.Haberler.ToList();

            return View(haberler);
        }

        //GET
        public IActionResult Create()
        {
            if (!GirisYapilmisMi())
            {
                return RedirectToAction("Login", "Admin");
            }
            return View();
        }

        //POST
        [HttpPost]
        public IActionResult Create(Haber haber)
        {
            if (!GirisYapilmisMi())
            {
                return RedirectToAction("Login", "Admin");
            }
            if (ModelState.IsValid)
            {
                _context.Haberler.Add(haber);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(haber);
        }


        //GET
        public IActionResult Edit(int id) 
        {
            var haber = _context.Haberler.Find(id);

            if (!GirisYapilmisMi())
            {
                return RedirectToAction("Login", "Admin");
            }

            if (haber == null)
            {
                return NotFound();
            }
            return View(haber);
        }

        //POST
        [HttpPost]
        public IActionResult Edit(Haber haber)
        {
            if (!GirisYapilmisMi())
            {
                return RedirectToAction("Login", "Admin");
            }
            if (ModelState.IsValid) 
            {
                _context.Haberler.Update(haber); 
                _context.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(haber);
        }

        //GET
        public IActionResult Delete(int id)
        {
            var haber = _context.Haberler.Find(id);

            if (!GirisYapilmisMi())
            {
                return RedirectToAction("Login", "Admin");
            }

            if (haber == null)
            {  
                return NotFound(); 
            }

            return View(haber);
        }

        //POST
        [HttpPost]
        public IActionResult Delete(Haber haber)
        {
            if (!GirisYapilmisMi())
            {
                return RedirectToAction("Login", "Admin");
            }

            _context.Haberler.Remove(haber);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            var haber = _context.Haberler.Find(id);

            if (haber == null)
            {
                return NotFound();
            }
            return View(haber);
        }
    }
}
