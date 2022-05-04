using Microsoft.AspNetCore.Mvc;

namespace tamagotchi_task.Controllers
{
    public partial class HomeController : Controller
    {
        public IActionResult Chat()
        {
            return View();
        }
    }
     
}
