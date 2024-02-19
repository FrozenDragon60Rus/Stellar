using Microsoft.AspNetCore.Mvc;
using TestWebApplication.Domain;
using TestWebApplication.Domain.Entities;

namespace TestWebApplication.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TextFieldsController : Controller
    {
        private readonly DataManager dataManager;
        public TextFieldsController(DataManager dataManager) =>
            this.dataManager = dataManager;
        public IActionResult Edit(string codeWord) =>
            View(dataManager.TextFields
                            .GetByCodeWord(codeWord));

        [HttpPost]
        public IActionResult Edit(TextField model)
        {
            if(ModelState.IsValid)
            {
                dataManager.TextFields.Save(model);
                return RedirectToAction(nameof(AdminController.Index), nameof(AdminController).Replace("Controller", string.Empty));
            }
            return View(model);
        }
    }
}
