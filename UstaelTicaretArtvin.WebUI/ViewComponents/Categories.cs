using Microsoft.AspNetCore.Mvc;
using UstaelTicaretArtvin.Entities;
using UstaelTicaretArtvin.Service.Abstract;

namespace UstaelTicaretArtvin.WebUI.ViewComponents
{
    public class Categories : ViewComponent
    {
        private readonly IService<Category> _service;

        public Categories(IService<Category> service)
        {
            _service = service;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(await _service.GetAllAsync(c=>c.IsActive && c.IsTopMenu));
        }

    }
}
