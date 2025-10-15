using System.ComponentModel.DataAnnotations;
using TallinnaRakenduslikKolledz.Models;

namespace TallinnaRakenduslikKolledz.Models
{
    public class Department
    {
        [Key]
        public int DepartmentId { get; set; }
        public string Name { get; set; }
        public decimal Budget { get; set; }
        public DateTime StartDate { get; set; }
        public int? InstructorID { get; set; }
        public Instructor? Administrator { get; set; }
        public ICollection<Course>? Courses { get; set; }
        public byte? RowVersion { get; set; }

        /* 3 isiklikult unikaalset andmevälja kursusele juurde */

        public string? Email { get; set; }
        public string? Location { get; set; }
        public string? PhoneNumber { get; set; }
    }
}
