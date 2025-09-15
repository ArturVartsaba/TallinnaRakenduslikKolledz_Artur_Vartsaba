using Microsoft.AspNetCore.Mvc;
using TallinnaRakenduslikKolledź.Models;

namespace TallinnaRakenduslikKolledz.Models
{
    public class InstructorIndexData : Controller
    {
        public IEnumerable<Instructor> Instructors { get; set; }
        public IEnumerable<Course> Courses { get; set; }
        public IEnumerable<Enrollment> Enrollments { get; set; }
    }
}
