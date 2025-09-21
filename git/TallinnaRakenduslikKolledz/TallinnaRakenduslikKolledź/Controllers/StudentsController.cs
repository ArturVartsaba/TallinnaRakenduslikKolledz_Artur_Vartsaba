using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TallinnaRakenduslikKolledz.Data;
using TallinnaRakenduslikKolledź.Models;

namespace TallinnaRakenduslikKolledz.Controllers
{
    public class StudentsController : Controller
    {
        private readonly SchoolContext _context;
        public StudentsController(SchoolContext context) 
        { 
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.Students.ToListAsync());
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// Get create view for student
        /// </summary>
        /// <param name="student">object of student</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,LastName,FirstName,EnrollmentDate,Gender")] Student student) 
        {
            if (ModelState.IsValid)
            {
                _context.Students.Add(student);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
                // return RedirectToAction(nameof(Index));
            }
            return View(student);
        }

        /// <summary>
        /// Get delete view for student
        /// </summary>
        /// <param name="id">id of student</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) 
            { 
                return NotFound();
            }
            var student = await _context.Students.FirstOrDefaultAsync(m => m.Id == id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id) 
        { 
            var student = await _context.Students.FindAsync(id);
            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        
        /// <summary>
        /// Get details view for student
        /// </summary>
        /// <param name="id">id of student</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var student = await _context.Students.FindAsync(id);
            return View(student);
        }
        /// <summary>
        /// Get edit view for student
        /// </summary>
        /// <param name="id">id of student</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Edit(int? id) 
        {
            if (id == null) 
            { 
                return NotFound();
            }
            var student = await _context.Students.FindAsync(id);
            if (student == null) 
            { 
                return NotFound();
            }
            return View(student);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("Id,LastName,FirstName,EnrollmentDate,Gender")] Student student)
        {
            if (ModelState.IsValid)
            {
                _context.Students.Update(student);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }
    }
}
