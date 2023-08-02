
using CCSARestaurant.Core;

namespace CCSARestaurantAPI.DTOs
{
    public class ChefDTO
    {
        public virtual string Name { get; set; }
        public virtual List<Dish> Dishes { get; set; }
        public virtual List<Shift> Shifts { get; set; }
    }
}
