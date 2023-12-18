using Domain.Models;
using Domain.Models.Users;

namespace BLL.Services.Interfaces;

public interface ITreatmentStrategyService
{
    // CRUD
    Task<TreatmentStrategy> GetTreatmentStrategyAsync(int treatmentStrategyId);

    Task<TreatmentStrategy> CreateTreatmentStrategyAsync(TreatmentStrategy treatmentStrategy);

    Task UpdateTreatmentStrategyAsync(TreatmentStrategy treatmentStrategy);

    Task DeleteTreatmentStrategyAsync(int treatmentStrategyId);
    
    // Business logic
    Task<User> GetPatientAsync(int treatmentStrategyId);
    
    Task<User> GetDoctorAsync(int treatmentStrategyId);
}