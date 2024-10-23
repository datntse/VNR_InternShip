using Microsoft.AspNetCore.Mvc;
using SQLitePCL;
using System.Diagnostics;
using VNR_Internship.Models;

namespace VNR_Internship.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly VnrInternShipContext _context;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _context = new VnrInternShipContext();

        }

        public IActionResult Index(int? id)
        {
            var listCourse = _context.KhoaHocs.ToList();
            var courseId = listCourse.First().Id;
            var listSubject = _context.MonHocs.Where(_ => _.KhoaHocId.Equals(courseId));
            if (id != null) {
                listSubject = _context.MonHocs.Where(_ => _.KhoaHocId.Equals(id));
            } 
            ViewData["listSubject"] = listSubject.ToList();
            return View(listCourse);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
