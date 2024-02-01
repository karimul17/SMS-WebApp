using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SMS.WebApp.DatabaseContext;
using SMS.WebApp.Models;

namespace SMS.WebApp.Controllers
{
    public class StudentController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StudentController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]

        public async Task<IActionResult> Index()
        {
            var data = await _context.Set<Studdent>().AsNoTracking().ToListAsync();
            return View(data);

        }

        [HttpGet]
        public async Task<IActionResult> CreateOrEidt(int id)
        {
            if (id == 0)
            {
                return View(new Studdent());
            }
            else
            {
                var data = await _context.Set<Studdent>().FindAsync(id);
                return View(data);
            }
        }
        [HttpPost]
        public async Task<IActionResult> CreateOrEidt(int id, Studdent studdent)
        {
            if (id == 0)
            {
                if (ModelState.IsValid)
                {
                    await _context.Set<Studdent>().AddAsync(studdent);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index");
                }


            }
            else
            {
                _context.Set<Studdent>().Update(studdent);
                _context.SaveChanges();

                return RedirectToAction("Index");

            }
            return View(studdent);
        }



        public async Task<IActionResult> Delete(int id)
        {
            if (id != 0)
            {
                var data = await _context.Set<Studdent>().FindAsync(id);
                if (data is not null)
                {
                    _context.Set<Studdent>().Remove(data);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index");
                }

            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Details(int id)
        {
            var data = await _context.Set<Studdent>().FindAsync(id);
            return View(data);
        }
    }
}
