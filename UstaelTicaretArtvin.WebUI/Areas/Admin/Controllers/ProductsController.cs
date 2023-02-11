using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using UstaelTicaretArtvin.Entities;
using UstaelTicaretArtvin.Service.Abstract;
using UstaelTicaretArtvin.WebUI.Utils;

namespace UstaelTicaretArtvin.WebUI.Areas.Admin.Controllers
{
    [Area("Admin"), Authorize(Policy = "AdminPolicy")]

    public class ProductsController : Controller
    {
        private readonly IService<Product> _service;
        private readonly IService<Category> _serviceCategory;
        private readonly IService<Brand> _serviceBrand;
        private readonly IProductService _productService;

        public ProductsController(IService<Product> service, IService<Category> serviceCategory, IService<Brand> serviceBrand, IProductService productService)
        {
            _service = service;
            _serviceCategory = serviceCategory;
            _serviceBrand = serviceBrand;
            _productService = productService;
        }

        // GET: ProductsController
        public async Task<ActionResult> Index()
        {
            var model = await _productService.GetAllProductsByCategoriesBrandsAsync();
            return View(model);
        }

        // GET: ProductsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProductsController/Create
        public async Task<ActionResult> Create()
        {
            ViewBag.CategoryId = new SelectList(await _serviceCategory.GetAllAsync(), "Id", "Name");
            ViewBag.BrandId = new SelectList(await _serviceBrand.GetAllAsync(), "Id", "Name");

            return View();
        }

        // POST: ProductsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateAsync(Product product, IFormFile? Image)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (Image is not null) product.Image = await FileHelper.FileLoaderAsync(Image, filePath: "/wwwroot/Img/Products/");
                    await _service.AddAsync(product);
                    await _service.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    ModelState.AddModelError("", "Hata Oluştu!");
                }
            }
            ViewBag.CategoryId = new SelectList(await _serviceCategory.GetAllAsync(), "Id", "Name");
            ViewBag.BrandId = new SelectList(await _serviceBrand.GetAllAsync(), "Id", "Name");
            return View(product);
        }

        // GET: ProductsController/Edit/5
        public async Task<ActionResult> EditAsync(int id)
        {
            var model = await _service.FindAsync(id);
            ViewBag.CategoryId = new SelectList(await _serviceCategory.GetAllAsync(), "Id", "Name");
            ViewBag.BrandId = new SelectList(await _serviceBrand.GetAllAsync(), "Id", "Name");
            return View(model);
        }

        // POST: ProductsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditAsync(int id, Product product, IFormFile? Image)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (Image is not null) product.Image = await FileHelper.FileLoaderAsync(Image, filePath: "/wwwroot/Img/Products/");
                    _service.Update(product);
                    await _service.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    ModelState.AddModelError("", "Hata Oluştu!");
                }
            }
            ViewBag.CategoryId = new SelectList(await _serviceCategory.GetAllAsync(), "Id", "Name");
            ViewBag.BrandId = new SelectList(await _serviceBrand.GetAllAsync(), "Id", "Name");
            return View(product);
        }

        // GET: ProductsController/Delete/5
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var model = await _service.FindAsync(id);
            return View(model);
        }

        // POST: ProductsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Product product)
        {
            try
            {
                FileHelper.FileRemover(product.Image);
                _service.Delete(product);
                _service.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
