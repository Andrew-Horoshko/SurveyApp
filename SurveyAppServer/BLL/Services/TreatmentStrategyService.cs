using BLL.Exceptions;
using BLL.Services.Interfaces;
using Domain;
using Domain.Models;
using Domain.Models.Users;

namespace BLL.Services;

public class TreatmentStrategyService : ITreatmentStrategyService
{
    private const string TreatmentStrategyTarget = "TreatmentStrategy";
    private const string UserTarget = "User";
    private readonly IBaseRepository<TreatmentStrategy> _treatmentStrategyRepository;
    private readonly IUserRepository _userRepository;

    public TreatmentStrategyService(IBaseRepository<TreatmentStrategy> treatmentStrategyRepository, IUserRepository userRepository)
    {
        _treatmentStrategyRepository = treatmentStrategyRepository;
        _userRepository = userRepository;
    }

    // CRUD
    public async Task<TreatmentStrategy> GetTreatmentStrategyAsync(int treatmentStrategyId)
    {
        var treatmentStrategy = await _treatmentStrategyRepository.GetByIdAsync(treatmentStrategyId);

        if (treatmentStrategy == null)
        {
            throw new EntityNotFoundException(TreatmentStrategyTarget, treatmentStrategyId);
        }

        return treatmentStrategy;
    }

    public async Task<TreatmentStrategy> CreateTreatmentStrategyAsync(TreatmentStrategy treatmentStrategy)
    {
        return await _treatmentStrategyRepository.CreateAsync(treatmentStrategy);
    }

    public async Task UpdateTreatmentStrategyAsync(TreatmentStrategy treatmentStrategy)
    {
        await _treatmentStrategyRepository.UpdateAsync(treatmentStrategy);
    }

    public async Task DeleteTreatmentStrategyAsync(int treatmentStrategyId)
    {
        await _treatmentStrategyRepository.DeleteAsync(treatmentStrategyId);
    }
    
    // Business logic
    public async Task<User> GetPatientAsync(int treatmentStrategyId)
    {
        var treatmentStrategy = await GetTreatmentStrategyAsync(treatmentStrategyId);

        int patientId = treatmentStrategy.PatientId;
        var patient = await _userRepository.GetByIdAsync(patientId);

        if (patient == null)
        {
            throw new EntityNotFoundException(UserTarget, patientId);
        }

        return patient;
    }

    public async Task<User> GetDoctorAsync(int treatmentStrategyId)
    {
        var treatmentStrategy = await GetTreatmentStrategyAsync(treatmentStrategyId);

        int doctorId = treatmentStrategy.DoctorId;
        var doctor = await _userRepository.GetByIdAsync(doctorId);

        if (doctor == null)
        {
            throw new EntityNotFoundException(UserTarget, doctorId);
        }

        return doctor;
    }
}