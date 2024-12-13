using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantMenuManager.Models
{
    internal class Dish
    {
        required public int Id  { get; set; }

        required public string Name { get; set; }

        required public double Price { get; set; }

        required public DishType Type { get; set; }
    }
}
