using Controllers.Model;
using Microsoft.AspNetCore.Mvc;

namespace Controllers.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly IDictionary<int, CategoryViewModel> _categories = new List<CategoryViewModel>
        {
            new() { Id = 0, Name = "Воздушный фильтр"},
            new() { Id = 1, Name = "Топливный фильтр"},
            new() { Id = 2, Name = "Форсунки"},
            new() { Id = 3, Name = "Амортизаторы"},
            new() { Id = 4, Name = "Колодки"},
            new() { Id = 5, Name = "Моторное масло"},
            new() { Id = 6, Name = "Прокладка двигателя"},
            new() { Id = 7, Name = "Сайлентблок"},
            new() { Id = 8, Name = "Рулевой наконечник"},
            new() { Id = 9, Name = "Термостат"},
            new() { Id = 10, Name = "Бендикс стартера"},
        }.ToDictionary(k => k.Id);


        public IActionResult Categories()
        {
            // Возвращаем весь список
            return Json(_categories.Values.ToArray());
        }

        public IActionResult Category(int id)
        {
            // Обработка некорректных входных данныз - валидвация
            if (id < 0) return BadRequest($"{nameof(id)} must be more than zero!");

            if (id is > 0 and < 10) return Json(_categories[id]); // Возврат в виде json

            return NotFound(); // Стандартный ответ 404
        }
    }
}
