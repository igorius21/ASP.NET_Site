using Microsoft.AspNetCore.Mvc;
using StudyProject.Domain;

namespace StudyProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ManagDb managDb;

        public HomeController(ManagDb managerDb)
        {
            this.managDb = managerDb;
        }

        public IActionResult PageIndex()
        {
            return View(managDb.MyTexts.GetTextKeyWord("PageIndex"));
        }

        public IActionResult PageContacts()
        {
            return View(managDb.MyTexts.GetTextKeyWord("PageContacts"));
        }
    }
}