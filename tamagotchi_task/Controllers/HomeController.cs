using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using tamagotchi_task.Models;

namespace tamagotchi_task.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    //Код ниже позволяет делать редирект сразу на модуль аутентификации
    //Если пользователь ещё не вошёл на сайт (нужно закомментить всё сверху, чтобы использовать)
    /*[Authorize]
    public IActionResult Index()
    {
        return Content(User.Identity.Name);
    }*/
}