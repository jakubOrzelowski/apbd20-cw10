using apbd20_cw10.Models;
using Microsoft.EntityFrameworkCore;

namespace apbd20_cw10.Data;

public class DoctorContext : DbContext
{
    protected DoctorContext()
    {
    }

    public DoctorContext(DbContextOptions options) : base(options)
    {
    }
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Medicament> Medicaments { get; set; }
    public DbSet<Patient> Patients{ get; set; }
    public DbSet<Prescription> Prescriptions { get; set; }
    public DbSet<PrescriptionMedicament> PrescriptionMedicaments { get; set; }
}