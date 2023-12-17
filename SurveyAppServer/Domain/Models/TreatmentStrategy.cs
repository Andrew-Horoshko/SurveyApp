using Domain.Models.Users;

namespace Domain.Models;

public class TreatmentStrategy
{
    public int TreatmentStrategyId { get; set; }
    public string Diagnosis { get; set; } = null!;
    public string Treatment { get; set; } = null!;
    public string Recomendation { get; set; } = null!;
    public int PatientId { get; set; }
    public int DoctorId { get; set; }
    public User Patient { get; set; }
    public User Doctor { get; set; }
}