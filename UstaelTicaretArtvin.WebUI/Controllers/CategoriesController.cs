using Microsoft.AspNetCore.Mvc;
using UstaelTicaretArtvin.Service.Abstract;

namespace UstaelTicaretArtvin.WebUI.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ICategoryService _service;

        public CategoriesController(ICategoryService service)
        {
            _service = service;
        }
        public async Task<IActionResult> IndexAsync(int id)
        {
            var model = await _service.GetCategoryByProducts(id);
            return View(model);
        }
    }
}
