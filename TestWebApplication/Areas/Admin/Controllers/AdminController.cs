using Microsoft.AspNetCore.Mvc;
using TestWebApplication.Domain;

namespace TestWebApplication.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminController : Controller
	{
		private readonly DataManager dataManager;
		public AdminController(DataManager dataManager) =>
			this.dataManager = dataManager;
		public IActionResult Index() => View(dataManager.ServiceItems.Get());
	}
}
