using CCSARestaurant.Core;
using CCSARestaurant.DB;
using CCSARestaurant.DB.Repositories;
using CCSARestaurantAPI.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace CCSARestaurantAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DishController : ControllerBase
    {
        public DishController(DishRepository dishRepository)
        {
            _dishRepository = dishRepository;
        }

        //Read
        [HttpGet(Name = "GetDish")]
        public IEnumerable<Dish> Get()
        {
            var dishes = _dishRepository.GetAll();
            return dishes;
        }

        //Create
        [HttpPost("/create-dish-using-params")]
        public IActionResult CreateDish(string name, decimal price, chef chef)
        {
            var dish = new Dish
            {
                Name = name,
                Price = price,
                Chef = chef
            };

            _dishRepository.Add(dish);
            return Ok(dish.Id);
        }

        //Create
        [HttpPost("/create-dish")]
        public IActionResult CreateDish([FromBody] DishDTO dish)
        {
            var myDish = new Dish
            {
                Name = dish.Name,
                Price = dish.Price,
                Chef = dish.Chef
            };

            _dishRepository.Add(myDish);
            return Ok(myDish.Id);
        }

        //Update
        [HttpPut("/update-name")]
        public IActionResult UpdateDish(int id, string Name)
        {
            var dish = _dishRepository.GetById(id);
            if (dish == null)
            {
                return BadRequest();
            }

            dish.Name = name;

            _dishRepository.Update(dish);
            return Ok(dish.Id);
        }

        //Delete
        [HttpDelete("/delete-dish-name")]
        public IActionResult DeleteDishNameById(int id)
        {
            var dish = _dishRepository.GetById(id);
            if (dish == null)
            {
                return BadRequest();
            }

            _dishRepository.DeleteById(id);
            return Ok(dish.Id);
        }

        private readonly DishRepository _dishRepository;
    }
}
