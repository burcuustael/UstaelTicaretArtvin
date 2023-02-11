using Microsoft.AspNetCore.Mvc;
using UstaelTicaretArtvin.Service.Abstract;
using UstaelTicaretArtvin.WebUI.Models;

namespace UstaelTicaretArtvin.WebUI.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService _service;

        public ProductsController(IProductService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var model = await _service.GetAllAsync(p => p.IsActive);
            return View(model);
        }
        public async Task<IActionResult> Search(string q)
        {
            var model = await _service.GetAllAsync(p=>p.IsActive && p.Name.Contains(q));
            return View(model);
        }

        public async Task<IActionResult> Detail(int id)
        {
            var product = await _service.GetProductByCategoriesBrandsAsync(id);
            var model = new ProductDetailViewModel()
            {
                Product = product,
                Products = await _service.GetAllAsync(p=>p.CategoryId== product.CategoryId && p.Id != id)
            };
            return View(model);
        }  


    }
}
