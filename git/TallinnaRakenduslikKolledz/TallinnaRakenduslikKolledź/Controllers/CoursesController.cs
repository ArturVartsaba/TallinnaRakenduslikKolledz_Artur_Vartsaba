using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TallinnaRakenduslikKolledz.Data;
using TallinnaRakenduslikKolledz.Models;

namespace TallinnaRakenduslikKolledz.Controllers
{
    public class CoursesController : Controller
    {
        private readonly SchoolContext _context;
        public CoursesController(SchoolContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var courses =  await _context.Courses.Include(c => c.Department)
                .AsNoTracking()
                .ToListAsync();
            return View(courses);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewData["Tegevus"] = "loomine";
            //PopulateDepartmentsDropDownList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Course course) 
        {
            if (ModelState.IsValid)
            {
                _context.Courses.Add(course);
                await _context.SaveChangesAsync();
                //PopulateDepartmentsDropDownList(course.DepartmentID);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            ViewData["Tegevus"] = "kustutamine";
            if (id == null || _context.Courses == null) 
            { 
                return NotFound();
            }
            var courses = await _context.Courses
                .Include(c => c.Department)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);
            if (courses == null) 
            { 
                return NotFound();
            }
            return View(courses);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Courses == null) 
            { 
                return NotFound();
            }
            var course = await _context.Courses.FindAsync(id);
            if (course != null)
            {
                _context.Courses.Remove(course);
            }
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private void PopulateDepartmentsDropDownList(object selectedDepartment = null)
        {
            var departmentsQuery = from d in _context.Departments
                                   orderby d.Name
                                   select d;
            ViewBag.DepartmentID = new SelectList(departmentsQuery.AsNoTracking(), "DepartmentID", "Name", selectedDepartment);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            ViewData["Tegevus"] = "vaatamine";
            var course = await _context.Courses.FindAsync(id);
            return View("Delete", course);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            ViewData["Tegevus"] = "muutmine";
            if (id == null)
            {
                return NotFound();
            }
            var course = await _context.Courses.FindAsync(id);
            if (course == null)
            {
                return NotFound();
            }
            return View("Create", course);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Course course)
        {
            if (ModelState.IsValid)
            {
                _context.Courses.Update(course);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View("Create", course);
        }
    }
}
