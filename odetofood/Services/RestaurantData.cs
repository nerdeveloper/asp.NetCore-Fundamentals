using System;
using System.Collections.Generic;
using odetofood.Models;

namespace odetofood.Services
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetAll();
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
        List<Restaurant> _restaurants;
    }
}
