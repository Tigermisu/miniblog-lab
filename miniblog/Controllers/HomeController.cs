using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using miniblog.Models;

namespace miniblog.Controllers
{
    public class HomeController : Controller
    {
        private readonly MiniblogDbContext _context;

        public HomeController(MiniblogDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            LoadPages();
            LoadCategories();

            return View();
        }

        [HttpGet("Category/{categoryId}")]
        public IActionResult Category(int categoryId) {
            LoadPages(categoryId);
            LoadCategories();

            return View("~/Views/Home/Index.cshtml");
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private void LoadPages() {
            LoadPages(0);
        }

        private void LoadPages(int categoryId) {
            var query = _context.Pages.OrderByDescending(p => p.Date);

            if (categoryId > 0) {
                ViewData["Pages"] = query.Where(p => p.CategoryId == categoryId).ToList();
                ViewData["Category"] = _context.Categories.Find(categoryId);
            } else {
                ViewData["Pages"] = query.ToList();
            }
        }

        private void LoadCategories() {
            ViewData["Categories"] = _context.Categories.ToList();
        }
    }
}
