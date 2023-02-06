using lastProj.Models;
using lastProj.Services;
using Microsoft.AspNetCore.Mvc;

namespace lastProj.Controllers
{
    public class AdminController : Controller
    {
        private IRepository _repository;
        public AdminController(IRepository repository)
        {
            _repository = repository;
        }
        public IActionResult AdminPage()
        {
            ViewBag.Category = _repository.GetCategories();
            return View(_repository.GetAnimals());
        }

        [HttpGet]
        public IActionResult CreateAnimal()
        {
            ViewBag.Category = _repository.GetCategories();
            return View();
        }
        [HttpPost]
        public IActionResult SaveAnimal(Animal animal)
        {
            if (ModelState.IsValid)
            {
                _repository.InsertAnimal(animal);
                return RedirectToAction("AdminPage");
            }
            return RedirectToAction("AdminPage");
        }

        [HttpGet]
        public IActionResult EditPage(int Id)
        {
            Animal animal = _repository.GetAnimalById(Id);
            ViewBag.Category = _repository.GetCategories();
            return View(animal);
        }
        [HttpPost]
        public IActionResult EditPage(int Id, Animal animal)
        {///Id is empty
            if (ModelState.IsValid)
            {
                _repository.UpdateAnimal(Id, animal);
                return RedirectToAction("AdminPage");
            }
            return RedirectToAction("AdminPage");
        }
        public IActionResult DeleteAnimal(string name)
        {
            var animal = _repository.GetAnimalByName(name);
            _repository.DeleteAnimal(animal.AnimalId);
            return RedirectToAction("AdminPage");
        }
        public IActionResult ShowByCategory(int id)
        {
            if (id == 0)
            {
                ViewBag.Category = _repository.GetCategories();
                return View("AdminPage", _repository.GetAnimals());
            }
            ViewBag.Category = _repository.GetCategories();
            return View("AdminPage", _repository.GetAnimalsByCategory(id));
        }
    }
}
