using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UstaelTicaretArtvin.Entities;
using UstaelTicaretArtvin.Service.Abstract;
using UstaelTicaretArtvin.WebUI.Utils;

namespace UstaelTicaretArtvin.WebUI.Areas.Admin.Controllers
{
    [Area("Admin"), Authorize(Policy ="AdminPolicy")]
    public class BrandsController : Controller
    {
        private readonly IService<Brand> _service;

        public BrandsController(IService<Brand> service)
        {
            _service = service;
        }

        // GET: BrandsController
        public ActionResult Index()
        {
            List<Brand> brands = _service.GetAll();
            return View(brands);
        }

        // GET: BrandsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: BrandsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BrandsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateAsync(Brand brand, IFormFile? Logo)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    brand.Logo = await FileHelper.FileLoaderAsync(Logo);
                    _service.Add(brand);
                    _service.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    ModelState.AddModelError("", "Hata Oluştu!");
                }
            }

            return View(brand);
        }



        // POST: BrandsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create2(Brand brand, IFormFile? Logo)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    brand.Logo = await FileHelper.FileLoaderAsync(Logo);
                    _service.Add(brand);
                    _service.SaveChanges();
                    return RedirectToAction("Create", "Products");
                }
                catch
                {
                    ModelState.AddModelError("", "Hata Oluştu!");
                }
            }

            return View(brand);
        }

        // GET: BrandsController/Edit/5
        public async Task<ActionResult> EditAsync(int id)
        {
            var model = await _service.FindAsync(id);
            return View(model);
        }

        // POST: BrandsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditAsync(int id, Brand brand, IFormFile? Logo)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (Logo is not null) brand.Logo = await FileHelper.FileLoaderAsync(Logo);
                    _service.Update(brand);
                    _service.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    ModelState.AddModelError("", "Hata Oluştu!");
                }
            }
            return View(brand);
        }

        // GET: BrandsController/Delete/5
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var model = await _service.FindAsync(id);
            return View(model);
        }

        // POST: BrandsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Brand brand)
        {
            try
            {
                FileHelper.FileRemover(brand.Logo);
                _service.Delete(brand);
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
