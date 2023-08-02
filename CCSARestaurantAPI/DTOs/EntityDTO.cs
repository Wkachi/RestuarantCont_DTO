using CCSARestaurant.Core;

namespace CCSARestaurantAPI.DTOs
{
    public class EntityDTO
    {
        public virtual string Name { get; set; }
        public virtual decimal Price { get; set; }
        public virtual chef Chef { get; set; }
    }
}
