using lastProj.Services;
using Microsoft.AspNetCore.Mvc;

namespace lastProj.Controllers
{
    public class HomeController : Controller
    {
        private IRepository _repository;
        public HomeController(IRepository repository)
        {
            _repository = repository;
        }
        /// <summary>
        /// Showing Top2 Animals with largest amount of comments
        /// </summary>
        /// <returns></returns>
        public IActionResult HomePage()
        {
            ViewBag.TopTwo = _repository.GetTopTwo();
            return View();
        }

    }
}
