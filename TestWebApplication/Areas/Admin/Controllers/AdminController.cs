using Microsoft.AspNetCore.Mvc;
using TestWebApplication.Domain;

namespace TestWebApplication.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminController(DataManager dataManager) : Controller
	{
		private readonly DataManager dataManager = dataManager;

		public IActionResult Index() => View(dataManager.ServiceItems.Get());
	}
}
