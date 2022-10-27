using FuelQueManagement_Service.Models;
using FuelQueManagement_Service.Services;
using Microsoft.AspNetCore.Mvc;

namespace FuelQueManagement_Service.Controllers;

[ApiController]
[Route("[controller]")]
public class FuelStationController : ControllerBase
{
    // Declere  the fuel station service 
    private readonly FuelStationService _fuelStationService;
    public FuelStationController(FuelStationService fuelStationService) =>
        _fuelStationService = fuelStationService;

    // refers  create a fuel station
    [HttpPost]
    public async Task<FuelStationModel> Create(FuelStationModel request)
    {
        try
        {
            var res = await _fuelStationService.Create(request);
            return res;
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    // refers the  get all fuel stations
    [HttpGet]
    public async Task<List<FuelStationModel>> GetFuelStations()
    {
        try
        {
            var res = await _fuelStationService.GetFuelStations();
            return res;
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    // refers the  get fuel station by id
    [HttpGet("{id}")]
    public async Task<FuelStationModel> GetFuelStationById(string id)
    {
        try
        {
            var res = await _fuelStationService.GetFuelStationById(id);
            return res;
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    // refers  to update diesel status
    [HttpPut]
    [Route("UpdateDieselStatus")]
    public async Task<FuelStationModel> UpdateDieselStatus(bool status, string id)
    {
        try
        {
            var res = await _fuelStationService.UpdateDieselStatus(status, id);
            return res;
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    // refers to  to update petrol status
    [HttpPut]
    [Route("UpdatePetrolStatus")]
    public async Task<FuelStationModel> UpdatePetrolStatus(bool status, string id)
    {
        try
        {
            var res = await _fuelStationService.UpdatePetrolStatus(status, id);
            return res;
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    [HttpPut]
    [Route("UpdateFuelAmount")]
    // refers  to update the total fuel amount
    public async void UpdateTotalFuelAmount(string stationId, int amount, string type)
    {
        try
        {
            var currentAmount = await _fuelStationService.getCurrentFuelAmount(stationId, type);
            _fuelStationService.UpdateTotalFuelAmount(stationId, amount, type, currentAmount);
        }
        catch(Exception ex)
        {

        }
    }
}
