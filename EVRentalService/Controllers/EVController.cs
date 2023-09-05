using EVRentalBusiness.Service;
using EVRentalEntity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EVRentalService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EVController : ControllerBase
    {
        ElectricVehicleService _electricVehicleService = null;
        private readonly ILogger<EVController> _logger;
        public EVController(ElectricVehicleService electricVehicleService, ILogger<EVController> logger) 
        {
            _electricVehicleService= electricVehicleService;
            _logger= logger;
        }

        [HttpPost("AddEV")]
        public IActionResult AddEV(EVModel ev)
        {
            _logger.LogInformation("Seri Log is Working Adding EV");
            string result = _electricVehicleService.AddEV(ev);
            return Ok(result);
        }

        [HttpGet("GetAll")]

        public IActionResult GetAll() 
        {
            List<EVModel> result = _electricVehicleService.GetAll();
            return Ok(result);  
        }

        [HttpDelete("DeleteEVById")]
        public IActionResult DeleteEVbyId(int id)
        {
            string result = _electricVehicleService.DeleteEVbyId(id);
            return Ok(result);
        }


        [HttpGet("GetEVById")]
        public IActionResult GetEVbyId(int id)
        {
            EVModel result = null;
            if(id!=0)
                result = _electricVehicleService.GetEVbyId(id);
            else
                return BadRequest();
            return Ok(result);
        }

        [HttpPut("UpdateEV")]
        public IActionResult UpdateEV(EVModel ev)
        {
            string result = _electricVehicleService.UpdateEV(ev);
            return Ok(result);  
        }
    }
}
