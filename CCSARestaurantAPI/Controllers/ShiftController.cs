using CCSARestaurant.Core;
using CCSARestaurant.DB;
using CCSARestaurant.DB.Repositories;
using CCSARestaurantAPI.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace CCSARestaurantAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShiftController : ControllerBase
    {
        public ShiftController(ShiftRepository shiftRepository)
        {
            _shiftRepository = shiftRepository;
        }

        //Read
        [HttpGet(Name = "GetShift")]
        public IEnumerable<Shift> Get()
        {
            var shift = _shiftRepository.GetAll();
            return shift;
        }

        //Create
        [HttpPost("/create-shift-using-params")]
        public IActionResult CreateEntity(int Id)
        {
            var shift = new Shift
            {
                ChefsOnShift = chefsOnShift

            };

            _shiftRepository.Add(shift);
            return Ok(shift.Id);
        }

        //Create
        [HttpPost("/create-shift")]
        public IActionResult CreateEntity([FromBody] ShiftDTO shift)
        {
            var myShift = new Shift
            {
                ChefsOnShift = shift.ChefsOnShift,

            };

            _shiftRepository.Add(myshift);
            return Ok(myEntity.Id);
        }

        //Update
        [HttpPut("/update-chefs-on-shift")]
        public IActionResult UpdateChefsOnShift(int id)
        {
            var shift = _shiftRepository.GetById(id);
            if (shift == null)
            {
                return BadRequest();
            }

            shift.Id = id;

            _shiftRepository.Update(shift);
            return Ok(shift.Id);
        }

        //Delete
        [HttpDelete("/delete-shift-id")]
        public IActionResult DeleteShiftById(int id)
        {
            var shift = _shiftRepository.GetById(id);
            if (shift == null)
            {
                return BadRequest();
            }

            _shiftRepository.DeleteById(id);
            return Ok(shift.Id);
        }

        private readonly ShiftRepository _shiftRepository;
    }
}
