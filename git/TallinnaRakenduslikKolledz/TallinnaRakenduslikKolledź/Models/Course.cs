using TallinnaRakenduslikKolledz.Models;

namespace TallinnaRakenduslikKolledź.Models
{
    public class Course
    {
        public int CourseId { get; set; }
        public string Title { get; set; }
        public int Credits { get; set; }
        public Department? Department { get; set; }
        public int? DepartmentID { get; set; }

        public ICollection<Enrollment>? Enrollments { get; set; }

        public ICollection<CourseAssignment>? CourseAssignments { get; set; }
    }
}
