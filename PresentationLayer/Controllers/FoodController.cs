using BusinessLayer;
using DataLayer;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{
    public class FoodController : Controller
    {
        private readonly FoodContext foodContext;

        public FoodController()
        {
            foodContext = new FoodContext();
        }

        public IActionResult Index()
        {
            return View(foodContext.ReadAll(isReadOnly: true));
        }

        public IActionResult Details(int? id)
        {
            if (id == null) return NotFound();

            var food = foodContext.Read(id.Value, isReadOnly: true);
            if (food == null) return NotFound();

            return View(food);
        }

        public IActionResult Create()
        {
            return View(new Food());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Name,Quantity,Price")] Food food)
        {
            if (!ModelState.IsValid) return View(food);

            foodContext.Create(food);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int? id)
        {
            if (id == null) return NotFound();

            var food = foodContext.Read(id.Value, isReadOnly: true);
            if (food == null) return NotFound();

            return View(food);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Name,Quantity,Price")] Food food)
        {
            if (id != food.Id) return NotFound();
            if (!ModelState.IsValid) return View(food);

            foodContext.Update(food);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int? id)
        {
            if (id == null) return NotFound();

            var food = foodContext.Read(id.Value, isReadOnly: true);
            if (food == null) return NotFound();

            return View(food);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            foodContext.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
