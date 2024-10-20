using Microsoft.AspNetCore.Mvc;

namespace iRecipeAPI.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
