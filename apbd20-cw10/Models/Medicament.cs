using System.ComponentModel.DataAnnotations;

namespace apbd20_cw10.Models;

public class Medicament
{
    [Key]
    public int IdMedicament { get; set; }
    [MaxLength(100)]
    public string Name { get; set; } = string.Empty;
    [MaxLength(100)]
    public string Description { get; set; } = string.Empty;
    [MaxLength(100)]
    public string Type { get; set; } = string.Empty;
}