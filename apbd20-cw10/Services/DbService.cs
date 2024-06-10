using apbd20_cw10.Data;
using apbd20_cw10.DTOs;
using apbd20_cw10.Models;
using Microsoft.EntityFrameworkCore;

namespace apbd20_cw10.Services;

public class DbService : IDbService
{
    private readonly DoctorContext _context;

    public DbService(DoctorContext context)
    {
        _context = context;
    }
    
    public async Task<bool> AddPrescriptionAsync(NewPrescriptionDto newPrescription)
    {
        if (newPrescription.Medicaments.Count > 10)
        {
            throw new ArgumentException("Prescription cannot include more than 10 medicaments.");
        }

        if (!await IsDatesRight(newPrescription.Date, newPrescription.DueDate))
        {
            throw new ArgumentException("DueDate cannot be earlier than Date.");
        }

        var patient = await IsPatientExists(newPrescription.Patient);

        var medicamentIds = newPrescription.Medicaments.Select(m => m.IdMedicament).ToList();
        if (!await IsMedicamentsExist(medicamentIds))
        {
            throw new ArgumentException("One or more medicaments do not exist.");
        }

        var prescription = new Prescription
        {
            Date = newPrescription.Date,
            DueDate = newPrescription.DueDate,
            DoctorId = 1, 
            PatientId = patient.IdPatient
        };

        _context.Prescriptions.Add(prescription);
        await _context.SaveChangesAsync();

        foreach (var med in newPrescription.Medicaments)
        {
            var prescriptionMedicament = new PrescriptionMedicament
            {
                IdMedicament = med.IdMedicament,
                IdPrescription = prescription.IdPrescription,
                Dose = med.Dose,
                Details = med.Description
            };
            _context.PrescriptionMedicaments.Add(prescriptionMedicament);
        }

        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> IsMedicamentsExist(List<int> medicamentIds)
    {
        var existingMedicamentIds = await _context.Medicaments
            .Where(m => medicamentIds.Contains(m.IdMedicament))
            .Select(m => m.IdMedicament)
            .ToListAsync();

        return existingMedicamentIds.Count == medicamentIds.Count;
    }

    public async Task<bool> IsDatesRight(DateTime date, DateTime dueDate)
    {
        return dueDate > date;
    }

    public async Task<Patient> IsPatientExists(PatientDto patientRequest)
    {
        var patient = await _context.Patients
            .FirstOrDefaultAsync(p => p.IdPatient == patientRequest.IdPatient);

        if (patient == null)
        {
            patient = new Patient
            {
                FirstName = patientRequest.FirstName,
                LastName = patientRequest.LastName,
                BirthDate = patientRequest.BirthDate
            };
            _context.Patients.Add(patient);
            await _context.SaveChangesAsync();
        }

        return patient;
    }
}