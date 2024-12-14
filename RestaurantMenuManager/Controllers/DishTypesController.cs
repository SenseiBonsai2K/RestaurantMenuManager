using Microsoft.AspNetCore.Mvc;
using RestaurantMenuManager.Models;
using RestaurantMenuManager.ViewModels;

namespace RestaurantMenuManager.Controllers
{
    public class DishTypesController : Controller
    {

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            PopulateDishTypes();
            DishTypesIndexViewModel vm = new DishTypesIndexViewModel();
            vm.AllDishTypes = Static.DishTypes.ToArray();
            return View(vm);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            DishTypesCreateViewModel vm = new DishTypesCreateViewModel();
            vm.DishType = new DishType();
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Create(DishTypesCreateViewModel vm)
        {
            if (Static.DishTypes.Any(dt => dt.Id == vm.DishType.Id))
            {
                ModelState.AddModelError("DishType.Id", "The Id is already in use.");
            }

            if(vm.DishType.Id < 0)
            {
                ModelState.AddModelError("DishType.Id", "The Id HAVE to be positive and not 0.");
            }

            if (ModelState.IsValid)
            {
                Static.DishTypes.Add(vm.DishType);
                return Redirect("/DishTypes/Index");
            }
            return View(vm);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int Id)
        {
            DishTypesEditViewModel vm = new DishTypesEditViewModel();
            vm.DishType = Static.DishTypes.Where(dt => dt.Id == Id).First();
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(DishType dishType, DishTypesEditViewModel vm)
        {
            DishType staticDT = Static.DishTypes.Where(dt => dt.Id == dishType.Id).First();

            if(ModelState.IsValid) staticDT.Type = dishType.Type;

            return Redirect("/DishTypes/Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var dishType = Static.DishTypes.FirstOrDefault(dt => dt.Id == id);
            if (dishType != null)
            {
                Static.DishTypes.Remove(dishType);
            }
            return Redirect("/DishTypes/Index");
        }

        public void PopulateDishTypes()
        {
            if (Static.DishTypes == null)
            {
                Static.DishTypes = new List<DishType>();
  
                Static.DishTypes.Add(new DishType(1, "Apetaizer"));
                Static.DishTypes.Add(new DishType(2, "Main Course"));
                Static.DishTypes.Add(new DishType(3, "Dessert")); ;
            };
        }
    }
}
