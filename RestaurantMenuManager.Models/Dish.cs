using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantMenuManager.Models
{
    public class Dish
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public double Price { get; set; }
        public string Type { get; set; }

        public Dish()
        {
        }

        public Dish(int Id, string Name, double Price, string Type)
        {
            this.Id = Id;
            this.Name = Name;
            this.Price = Price;
            this.Type = Type;
        }
    }
}
