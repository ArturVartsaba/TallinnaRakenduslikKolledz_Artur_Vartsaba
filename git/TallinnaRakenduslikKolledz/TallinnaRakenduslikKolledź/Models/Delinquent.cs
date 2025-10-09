using System.ComponentModel.DataAnnotations;

namespace TallinnaRakenduslikKolledz.Models
{
    public enum Violation { Varastamine, lammutamine, Ropendamine, Rünnak, Rumal }
    public enum Position { Õpilane, Õpetaja }
    public class Delinquent
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Violation? ViolationType { get; set; }
        public Position? Position { get; set; }
        public string? Status { get; set; }
    }
}
