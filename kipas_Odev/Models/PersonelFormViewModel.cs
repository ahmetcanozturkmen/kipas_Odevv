using System.ComponentModel.DataAnnotations;

namespace kipas_Odev.Models
{
    public class PersonelFormViewModel
    {
        public int Id { get; set; }

        [StringLength(20)]
        public string? Title { get; set; }

        [Required(ErrorMessage = "First name is required.")]
        [StringLength(50)]
        public string FirstName { get; set; } = null!;

        [Required(ErrorMessage = "Last name is required.")]
        [StringLength(50)]
        public string LastName { get; set; } = null!;

        public DateOnly? BirthDate { get; set; }

        [StringLength(100)]
        public string? Position { get; set; }

        public DateOnly? HireDate { get; set; }

        [StringLength(50)]
        public string? State { get; set; }

        [StringLength(250)]
        public string? Address { get; set; }

        [StringLength(1000)]
        public string? Notes { get; set; }
    }
}