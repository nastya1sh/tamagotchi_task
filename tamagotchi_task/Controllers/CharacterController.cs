using Microsoft.AspNetCore.Mvc;

namespace tamagotchi_task.Controllers
{
    public class CharacterController : Controller
    {
        public IActionResult Create()
        {
            if (User.Identity.IsAuthenticated)
                return View();
            else
                return RedirectToAction("Login", "Account");
        }

        public IActionResult Inventory()
        {
            if (User.Identity.IsAuthenticated)
                return View();
            else
                return RedirectToAction("Login", "Account");
        }

        public IActionResult Shop()
        {
            if (User.Identity.IsAuthenticated)
                return View();
            else
                return RedirectToAction("Login", "Account");
        }
    }
}
