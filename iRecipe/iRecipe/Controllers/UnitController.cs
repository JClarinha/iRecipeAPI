using iRecipeAPI.Domain;
using iRecipeAPI.Services.Implementations;
using iRecipeAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace iRecipeAPI.Controllers
{


    [Route("iRecipeAPI/[Controller]")]
    [ApiController]
    public class UnitController : ControllerBase
    {
        private IUnitService _unitService;

        public UnitController(IUnitService unitService)
        {
            _unitService = unitService;
        }

        [HttpGet]
        public List<Unit> GetAllUnits()
        {
            return _unitService.GetAll();
        }


        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var unit = _unitService.GetById(id);
            if (unit == null)
            {
                return NotFound(); 
            }
            return Ok(unit); 
        }

        [HttpPost]
        public Unit SaveUnit(Unit unit)
        {
            return _unitService.SaveUnit(unit);
        }

        [HttpDelete("{id}")]
        public void DeleteUnit(int id)
        {
            _unitService.RemoveUnit(id);
        }

    }
}
