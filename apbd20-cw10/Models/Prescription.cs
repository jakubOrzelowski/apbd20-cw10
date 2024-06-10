using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace apbd20_cw10.Models;


public class Prescription
{
    [Key]
    public int IdPrescription { get; set; }
    public DateTime Date { get; set; }
    public DateTime DueDate { get; set; }
    public int DoctorId { get; set; }
    public int PatientId { get; set; }

    [ForeignKey(nameof(DoctorId))]
    public Doctor Doctor { get; set; } = null!;
    [ForeignKey(nameof(PatientId))]
    public Patient Patient { get; set; } = null!;
}