using CCSARestaurant.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCSARestaurant.DB.Repositories
{
    public class ShiftRepository : Repository<Shift>
    {
        public ShiftRepository(SessionFactory sessionFactory) : base(sessionFactory)
        {
        }


    }
}
