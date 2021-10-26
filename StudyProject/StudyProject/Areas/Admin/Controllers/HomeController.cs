using Microsoft.AspNetCore.Mvc;
using StudyProject.Domain;

namespace StudyProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        private readonly ManagDb managDb;

        public HomeController(ManagDb managDb)
        {
            this.managDb = managDb;
        }

        public IActionResult Index()
        {
            return View(managDb.MyServices.AllService());
        }
    }
}