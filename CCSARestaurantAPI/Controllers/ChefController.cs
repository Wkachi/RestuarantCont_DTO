using CCSARestaurant.Core;
using CCSARestaurant.DB;
using CCSARestaurant.DB.Repositories;
using CCSARestaurantAPI.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace CCSARestaurantAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ChefController : ControllerBase
    {
        public ChefController(ChefRepository chefRepository)
        {
            _chefRepository = chefRepository;
        }

        //Read
        [HttpGet(Name = "GetChef")]
        public IEnumerable<Chef> Get()
        {
            var chef = _chefRepository.GetAll();
            return chef;
        }

        //Create
        [HttpPost("/create-chef-using-params")]
        public IActionResult CreateChef(int Id)
        {
            var chef = new Chef
            {
                Name = name;
                Dishes = dishes;
                Shifts = shifts

            };

            _chefRepository.Add(chef);
            return Ok(chef.Id);
        }

        //Create
        [HttpPost("/create-shift")]
        public IActionResult CreateChef([FromBody] ChefDTO chef)
        {
            var myChef = new Chef
            {
                Name = chef.Name,
                Dishes = chef.Dishes,
                Shifts = chef.Shifts

            };

            _chefRepository.Add(mychef);
            return Ok(myChef.Id);
        }

        //Update
        [HttpPut("/update-name")]
        public IActionResult UpdateChefName(int id)
        {
            var chef = _chefRepository.GetById(id);
            if (chef == null)
            {
                return BadRequest();
            }

            chef.Id = id;

            _chefRepository.Update(chef);
            return Ok(chef.Id);
        }

        //Delete
        [HttpDelete("/delete-chef-name")]
        public IActionResult DeleteChefById(int id)
        {
            var chef = _chefRepository.GetById(id);
            if (chef == null)
            {
                return BadRequest();
            }

            _chefRepository.DeleteById(id);
            return Ok(chef.Id);
        }

        private readonly ChefRepository _chefRepository;
    }
}
