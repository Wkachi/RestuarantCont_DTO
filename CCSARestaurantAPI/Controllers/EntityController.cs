using CCSARestaurant.Core;
using CCSARestaurant.DB;
using CCSARestaurant.DB.Repositories;
using CCSARestaurantAPI.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace CCSARestaurantAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EntityController : ControllerBase
    {
        public EntityController(EntityhRepository entityRepository)
        {
            _entityRepository = entityRepository;
        }

        //Read
        [HttpGet(Name = "GetEntity")]
        public IEnumerable<Entity> Get()
        {
            var entities = _entityRepository.GetAll();
            return entities;
        }

        //Create
        [HttpPost("/create-entity-using-params")]
        public IActionResult CreateEntity(int Id)
        {
            var Id = new Id
            {
                Id = id
               
            };

            _entityRepository.Add(entity);
            return Ok(entity.Id);
        }

        //Create
        [HttpPost("/create-entity")]
        public IActionResult CreateEntity([FromBody] EntityDTO entity)
        {
            var myEntity = new Entity
            {
                Id = entity.Id,
               
            };

            _entityRepository.Add(myentity);
            return Ok(myEntity.Id);
        }

        //Update
        [HttpPut("/update-id")]
        public IActionResult UpdateEntity(int id)
        {
            var entity = _entityRepository.GetById(id);
            if (entity == null)
            {
                return BadRequest();
            }

            entity.Id = id;

            _entityRepository.Update(entity);
            return Ok(entity.Id);
        }

        //Delete
        [HttpDelete("/delete-entity-id")]
        public IActionResult DeleteEntityById(int id)
        {
            var entity = _entityRepository.GetById(id);
            if (dish == null)
            {
                return BadRequest();
            }

            _entityRepository.DeleteById(id);
            return Ok(entity.Id);
        }

        private readonly EntityRepository _entityRepository;
    }
}
