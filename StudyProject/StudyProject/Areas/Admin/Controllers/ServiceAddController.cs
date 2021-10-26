using System;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudyProject.Domain;
using StudyProject.Domain.Entities;
using StudyProject.Service;

namespace StudyProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ServiceAddController : Controller
    {
        private readonly ManagDb managDb;
        private readonly IWebHostEnvironment hostEnviron;
        public ServiceAddController(ManagDb managDb, IWebHostEnvironment hostEnviron)
        {
            this.managDb = managDb;
            this.hostEnviron = hostEnviron;
        }

        public IActionResult Edit(Guid id)
        {
            var entity = id == default ? new MyService() : managDb.MyServices.ServiceId(id);
            return View(entity);
        }
        [HttpPost]
        public IActionResult Edit(MyService mod, IFormFile Image)
        {
            if (ModelState.IsValid)
            {
                if (Image != null)
                {
                    mod.Image = Image.FileName;
                    using (var stream = new FileStream(Path.Combine(hostEnviron.WebRootPath, "images/", Image.FileName), FileMode.Create))
                    {
                        Image.CopyTo(stream);
                    }
                }
                managDb.MyServices.SaveService(mod);
                return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).CutController());
            }
            return View(mod);
        }

        [HttpPost]
        public IActionResult Delete(Guid id)
        {
            managDb.MyServices.DelService(id);
            return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).CutController());
        }
    }
}