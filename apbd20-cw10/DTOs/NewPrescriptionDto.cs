using System.ComponentModel.DataAnnotations;

namespace apbd20_cw10.DTOs;

public class NewPrescriptionDto
{
    [Required]
    public PatientDto Patient { get; set; }
    [Required]
    [MaxLength(10)]
    public ICollection<MedicamentDto> Medicaments { get; set; }
    [Required]
    public DateTime Date { get; set; }
    [Required]
    public DateTime DueDate { get; set; }
}

public class PatientDto
{
    [Required]
    public int IdPatient { get; set; }
    [Required]
    [MaxLength(100)]
    public string FirstName { get; set; } = string.Empty;
    [Required]
    [MaxLength(100)]
    public string LastName { get; set; } = string.Empty;
    [Required]
    public DateTime BirthDate { get; set; }
}

public class MedicamentDto
{
    [Required]
    public int IdMedicament { get; set; }
    public int? Dose { get; set; }
    [Required]
    [MaxLength(100)]
    public string Description { get; set; } = string.Empty;
}