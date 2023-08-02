using CCSARestaurant.Core;

namespace CCSARestaurantAPI.DTOs
{
    public class ShiftDTO
    {
        public virtual List<Chef> ChefsOnShift { get; set; }
    }
}
