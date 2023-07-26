using Controllers.Model;
using Microsoft.AspNetCore.Mvc;

namespace Controllers.Controllers
{
    // Здесь название класса и название метода опредеяет путь к ендпоинту, надо быть аккуратнее
    public class HomeController : Controller
    {
        // Этот метод выполнится при запросе корня домена благодаря шаблону маршрутизации
        public IActionResult Index()
        {
            return Content("This is Home");
        }

        // Так методы тоже будут работать, но делать так не стоит
        // Возвращаемое методом значение должно реализовывать IActionResult
        // Для удобства можно использовать множество унаследованных от Controller методов
        public string Test()
        {
            return $"Test passed";
        }

        // Маршрутизатор сразу пытается привести параметры к нужному типу
        public IActionResult Product(int id)
        {
            return Content($"Here is product with id = {id}");
        }

        // Это action будет принимать returnUrl из параметров пути только с шаблоном маршрутизации withReturn
        // Но вызвать его можно и с дефолтным шаблоном, но в этом случае returnUrl он будет
        // принимать из параметров запроса, так что аккуратнее, лучше помечать параметры аттрибутом
        public IActionResult EmailLink([FromRoute] string returnUrl)
        {
            return Content($"www.somedomain.com/email?returnUrl={returnUrl}");
        }

        // Можно сочетать подходы маршрутизации по именам контроллера и имена метода с атрибутами
        // Но нужно быть остороженее - здесь в url не будет home, т.к. у контроллера нет аттрибута
        // Как по мне - лучше один подход применять везде, или хотя бы в рамках одного контроллера
        [HttpPost("product/{productId?}/add-to-category")]
        public IActionResult Add2Category([FromRoute] int productId, [FromBody] CategoryViewModel category)
        {
            return Content($"Added product {productId} to {category?.Name} category");
        }
    }
}
