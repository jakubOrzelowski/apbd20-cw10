using System.ComponentModel.DataAnnotations;

namespace apbd20_cw10.Models;

public class Patient
{
    [Key]
    public int IdPatient { get; set; }
    [MaxLength(100)]
    public string FirstName { get; set; } = string.Empty;
    [MaxLength(120)]
    public string LastName { get; set; } = string.Empty;
    public DateTime BirthDate { get; set; }
}