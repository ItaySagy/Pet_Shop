using lastProj.Models;
using lastProj.Services;
using Microsoft.AspNetCore.Mvc;

namespace lastProj.Controllers
{
    public class CatalogController : Controller
    {
        private IRepository _repository;

        public CatalogController(IRepository repository)
        {
            _repository = repository;
        }
        public IActionResult CatalogPage()
        {
            ViewBag.Category = _repository.GetCategories();
            return View(_repository.GetAnimals());
        }
        public IActionResult ShowByCategory(int id)
        {
            if (id == 0)
            {
                ViewBag.Category = _repository.GetCategories();
                return View("CatalogPage", _repository.GetAnimals());
            }
            ViewBag.Category = _repository.GetCategories();
            return View("CatalogPage", _repository.GetAnimalsByCategory(id));
            //return RedirectToAction("ShowByCategory", _repository.GetAnimalById(id));
        }
        public IActionResult AddComment(string newComment, int animalid)
        {
            if (newComment != null)
            {
                if (ModelState.IsValid)
                {
                    _repository.InsertComment(new Comment() { AnimalId = animalid, Comments = newComment });
                    return RedirectToAction("CatalogPage");
                }
                return RedirectToAction("ShowDetails");
            }
            return RedirectToAction("ShowDetails");
        }
        public IActionResult ShowDetails(string name)
        {
            var animal = _repository.GetAnimalByName(name);
            ViewBag.Animal = animal;
            ViewBag.Comments = _repository.GetCommentsByAnimal(animal);
            return View(animal);
        }

    }
}
