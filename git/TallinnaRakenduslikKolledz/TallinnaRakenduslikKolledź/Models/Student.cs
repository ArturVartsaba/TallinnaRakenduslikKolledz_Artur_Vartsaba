using System.ComponentModel.DataAnnotations;

namespace TallinnaRakenduslikKolledź.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public ICollection<Enrollment>? Enrollments { get; set; }

        /*Lis kolm omadust õpilasele, ise mõtled välja*/

        public string? Gender {  get; set; }
        public int? Age { get; set; }
        public string? LanguageGroup { get; set; }
    }
}
