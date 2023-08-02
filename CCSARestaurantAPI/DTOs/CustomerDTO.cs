using CCSARestaurant.Core;

namespace CCSARestaurantAPI.DTOs
{
    public class CustomerDTO
    {
        public virtual string FirstName { get; set; }
        public virtual string Surname { get; set; }
        public virtual string PhoneNumber { get; set; }
    }
}
