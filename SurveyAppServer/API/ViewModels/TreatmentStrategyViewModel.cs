namespace SurveyAppServer.ViewModels;

public class TreatmentStrategyViewModel
{
    public int TreatmentStrategyId { get; set; }
    public string Diagnosis { get; set; } = null!;
    public string Treatment { get; set; } = null!;
    public string Recommendation { get; set; } = null!;
    public int PatientId { get; set; }
    public int DoctorId { get; set; }
}