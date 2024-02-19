using Microsoft.AspNetCore.Mvc;
using TestWebApplication.Domain;
using TestWebApplication.Domain.Entities;

namespace TestWebApplication.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ServiceItemsController : Controller
    {
        private readonly DataManager dataManager;
        private readonly IWebHostEnvironment hostEnvironment;

        public ServiceItemsController(DataManager dataManager, IWebHostEnvironment hostEnvironment)
        {
            this.dataManager = dataManager;
            this.hostEnvironment = hostEnvironment;
        }
        public IActionResult Edit(Guid id)
        {
            var entity = id == default ? new ServiceItem()
                                       : dataManager.ServiceItems.GetById(id);
            return View(entity);
        }
        [HttpPost]
        public IActionResult Edit(ServiceItem model, IFormFile titleImageFile) 
        { 
            if(ModelState.IsValid)
            {
                if(titleImageFile != null)
                {
                    model.TitleImagePath = titleImageFile.FileName;
                    using (var stream = new FileStream(Path.Combine(hostEnvironment.WebRootPath, "img/", titleImageFile.FileName), FileMode.Create))
                        titleImageFile.CopyTo(stream);
                }
                dataManager.ServiceItems.Save(model);
                return RedirectToAction(nameof(AdminController.Index), nameof(AdminController).Replace("Controller", string.Empty));
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult Delete(Guid id)
        {
            dataManager.ServiceItems.Delete(id);
            return RedirectToAction(nameof(AdminController.Index), nameof(AdminController).Replace("Controller", string.Empty));
        }
    }
}
