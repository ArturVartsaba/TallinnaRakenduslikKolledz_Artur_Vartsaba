using System.ComponentModel.DataAnnotations;
using System.Reflection;

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
        [EnumDataType(typeof(Violation))]
        public Violation? ViolationType { get; set; }
        [EnumDataType(typeof(Position))]
        public Position? Position { get; set; }
        public string? Status { get; set; }
    }
}
