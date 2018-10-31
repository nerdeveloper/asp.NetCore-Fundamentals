using System;
using System.Collections.Generic;
using System.Linq;
using odetofood.Entities;

namespace odetofood.Services
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetAll();
        Restaurant Get(int id);
    }
    public class InMemoryRestaurantData : IRestaurantData
    {
        public InMemoryRestaurantData()
        {
            _restaurants = new List<Restaurant>
            {
                new Restaurant { Id = 1, Name = "King Lebron James"},
                new Restaurant { Id = 2, Name = "Mark Zuckerberg" },
                new Restaurant { Id = 3, Name = "Priest"}
            };
        }
        public IEnumerable<Restaurant> GetAll()
        {
            return _restaurants;
        }

        public Restaurant Get(int id)
        {
            return _restaurants.FirstOrDefault(r => r.Id == id);
        }

        List<Restaurant> _restaurants;
    }
}
