using System;
using Microsoft.AspNetCore.Mvc;
using StudyProject.Domain;

namespace StudyProject.Controllers
{
    public class ServicesController : Controller
    {
        private readonly ManagDb managDb;

        public ServicesController(ManagDb managDb)
        {
            this.managDb = managDb;
        }

        public IActionResult Index(Guid id)
        {
            if (id != default)
            {
                return View("Show", managDb.MyServices.ServiceId(id));
            }

            ViewBag.TextField = managDb.MyTexts.GetTextKeyWord("PageServices");
            return View(managDb.MyServices.AllService());
        }
    }
}
