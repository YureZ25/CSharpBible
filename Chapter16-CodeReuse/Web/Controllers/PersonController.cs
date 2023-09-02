using Microsoft.AspNetCore.Mvc;
using Services.Services.Contracts;
using Services.ViewModels;

namespace Web.Controllers
{
    public class PersonController : Controller
    {
        private IPersonService _personService;

        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _personService.GetAll());
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromForm] PersonVM person)
        {
            await _personService.Insert(person);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var person = await _personService.GetById(id);

            if (person == null) return NotFound();

            return View(person);
        }

        [HttpPost]
        public async Task<IActionResult> Edit([FromForm] PersonVM person)
        {
            await _personService.Update(person);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        [ActionName("Remove")] // Обходной путь, в классе не может быть 2 метода с одинаковым названием и аргументами
        public async Task<IActionResult> ComfirmRemove(int id)
        {
            var person = await _personService.GetById(id);

            if (person == null) return NotFound();

            return View(person);
        }

        [HttpPost]
        public async Task<IActionResult> Remove(int id)
        {
            await _personService.DeleteById(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
