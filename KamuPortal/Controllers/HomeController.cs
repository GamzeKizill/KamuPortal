using System.Diagnostics;
using KamuPortal.Models;
using Microsoft.AspNetCore.Mvc;
using KamuPortal.Data;
using Microsoft.EntityFrameworkCore;

namespace KamuPortal.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _appDbContext;   

        public HomeController(ILogger<HomeController> logger, AppDbContext appDbContext)
        {
            _logger = logger;
            _appDbContext = appDbContext;
        }

        public IActionResult Index()
        {
            var sonHaberler = _appDbContext.Haberler
                .OrderByDescending(x => x.Tarih)
                .Take(3)
                .ToList();

            return View(sonHaberler);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel 
            { 
                RequestId = Activity.Current?.Id 
                ?? HttpContext.TraceIdentifier 
            });
        }
    }
}
