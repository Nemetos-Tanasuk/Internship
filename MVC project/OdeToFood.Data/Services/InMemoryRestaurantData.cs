using System.Collections.Generic;
using System.Linq;
using OdeToFood.Data.Models;

namespace OdeToFood.Data.Services
{
    public class InMemoryRestaurantData : IRestaurantData
    {
        List<Restaurant> restaurants;

        public InMemoryRestaurantData()
        {
            this.restaurants = new List<Restaurant>()
            {
                new Restaurant{ID = 1, Name = "Scott's Pizza", Cuisine = CuisineType.Italian},
                new Restaurant{ID = 2, Name = "Tersiguels", Cuisine = CuisineType.French},
                new Restaurant{ID = 3, Name = "Mango Grove", Cuisine = CuisineType.Indian },
                new Restaurant{ID = 4, Name = "Hanul Dacilor", Cuisine = CuisineType.Romanian },
            };
        }

        public void Add(Restaurant restaurant)
        {
            this.restaurants.Add(restaurant);
            restaurant.ID = restaurants.Max(r => r.ID) + 1;
        }

        public void Delete(int id)
        {
            var restaurant = Get(id);
            if (restaurant != null)
            {
                restaurants.Remove(restaurant);
            }
        }

        public Restaurant Get(int id)
        {
            return this.restaurants.FirstOrDefault(r => r.ID == id);
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return this.restaurants.OrderBy(r => r.Name);
        }

        public void Update(Restaurant restaurant)
        {
            var existing = Get(restaurant.ID);
            if (existing != null)
            {
                existing.Name = restaurant.Name;
                existing.Cuisine = restaurant.Cuisine;
            }
            
        }
    }
}
