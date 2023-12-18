using BLL.Services.Interfaces;
using Domain.Models;
using SurveyAppServer.ViewModels;

using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SurveyAppServer.ViewModels.Users;

namespace SurveyAppServer.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TreatmentStrategyController : Controller
{
    private readonly ITreatmentStrategyService _treatmentStrategyService;
    private readonly IMapper _mapper;

    public TreatmentStrategyController(ITreatmentStrategyService treatmentStrategyService, IMapper mapper)
    {
        _treatmentStrategyService = treatmentStrategyService;
        _mapper = mapper;
    }

    // CRUD
    [HttpGet]
    public async Task<ActionResult<TreatmentStrategyViewModel>> GetTreatmentStrategy(int treatmentStrategyId)
    {
        var treatmentStrategy = await _treatmentStrategyService.GetTreatmentStrategyAsync(treatmentStrategyId);

        var treatmentStrategyViewModel = _mapper.Map<TreatmentStrategyViewModel>(treatmentStrategy);

        return Ok(treatmentStrategyViewModel);
    }
    
    [HttpPost]
    public async Task<ActionResult<TreatmentStrategyViewModel>> CreateTreatmentStrategy(
        TreatmentStrategyViewModel treatmentStrategyViewModel)
    {
        var treatmentStrategy = _mapper.Map<TreatmentStrategy>(treatmentStrategyViewModel);
        
        treatmentStrategy = await _treatmentStrategyService.CreateTreatmentStrategyAsync(treatmentStrategy);

        treatmentStrategyViewModel = _mapper.Map<TreatmentStrategyViewModel>(treatmentStrategy);

        return Ok(treatmentStrategyViewModel);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateTreatmentStrategy(TreatmentStrategyViewModel treatmentStrategyViewModel)
    {
        var treatmentStrategy = _mapper.Map<TreatmentStrategy>(treatmentStrategyViewModel);

        await _treatmentStrategyService.UpdateTreatmentStrategyAsync(treatmentStrategy);

        return NoContent();
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteTreatmentStrategy(int treatmentStrategyId)
    {
        await _treatmentStrategyService.DeleteTreatmentStrategyAsync(treatmentStrategyId);

        return NoContent();
    }
    
    // Business logic
    [HttpGet("Patient")]
    public async Task<ActionResult<UserViewModel>> GetPatient(int treatmentStrategyId)
    {
        var patient = await _treatmentStrategyService.GetPatientAsync(treatmentStrategyId);

        var patientViewModel = _mapper.Map<UserViewModel>(patient);

        return Ok(patientViewModel);
    }

    [HttpGet("Doctor")]
    public async Task<ActionResult<UserViewModel>> GetDoctor(int treatmentStrategyId)
    {
        var doctor = await _treatmentStrategyService.GetDoctorAsync(treatmentStrategyId);

        var doctorViewModel = _mapper.Map<UserViewModel>(doctor);

        return Ok(doctorViewModel);
    }
}