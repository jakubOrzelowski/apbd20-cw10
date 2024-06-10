using apbd20_cw10.DTOs;
using apbd20_cw10.Models;

namespace apbd20_cw10.Services;

public interface IDbService
{
    Task<bool> AddPrescriptionAsync(NewPrescriptionDto prescriptionDto);
    Task<bool> IsMedicamentsExist(List<int> medicamentIds);
    Task<bool> IsDatesRight(DateTime date, DateTime dueDate);
    Task<Patient> IsPatientExists(PatientDto patientDto);
}