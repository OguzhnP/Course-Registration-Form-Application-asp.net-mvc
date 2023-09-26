using KursBasvuru.Models;
using Microsoft.AspNetCore.Mvc;

namespace KursBasvuru.Controllers
{
    public class CourseController : Controller
    {
        public IActionResult Index()
        {
            var model = Repository.Applications;
            return View(model);
        }
        public IActionResult Apply()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Apply([FromForm]Candidate candidate)
        {
            if (Repository.Applications.Any(c=> c.Email == candidate.Email))  
                ModelState.AddModelError("", "There is already an application for you");
           

            if (ModelState.IsValid)
            { 
                Repository.Add(candidate);
                return View("Feedback", candidate);
            }
            return View();
        }
    }
}
