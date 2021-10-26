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
    public class TextAddController : Controller
    {
        private readonly ManagDb managDb;
        private readonly IWebHostEnvironment hostEnviron;
        public TextAddController(ManagDb managDb, IWebHostEnvironment hostEnviron)
        {
            this.managDb = managDb;
            this.hostEnviron = hostEnviron;
        }

        public IActionResult Edit(string keyWord)
        {
            var count = managDb.MyTexts.GetTextKeyWord(keyWord);
            return View(count);
        }

        [HttpPost]
        public IActionResult Edit(Text mod, IFormFile Image)
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
                managDb.MyTexts.SaveText(mod);
                return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).CutController());
            }
            return View(mod);
        }
    }
}