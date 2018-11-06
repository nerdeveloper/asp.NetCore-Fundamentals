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
        Restaurant Add(Restaurant newResturant);
    }

    public class SqlResturantData: IRestaurantData
    {
        private OdeToFoodDB _context;

        public SqlResturantData(OdeToFoodDB context)
        {
            _context = context;
        }

        public Restaurant Add(Restaurant newResturant)
        {
            _context.Add(newResturant);
            return newResturant;
        }

        public Restaurant Get(int id)
        {
            return _context.Restaurants.FirstOrDefault(r => r.Id == id);
                  }

        public IEnumerable<Restaurant> GetAll()
        {
            return _context.Restaurants;
        }
    }
    public class InMemoryRestaurantData : IRestaurantData
    {
        static  InMemoryRestaurantData()
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

        public Restaurant Add(Restaurant newResturant)
        {
            newResturant.Id = _restaurants.Max(r => r.Id) + 1 ;
            _restaurants.Add(newResturant);
            return newResturant;

        }

       static List<Restaurant> _restaurants;
    }
}
