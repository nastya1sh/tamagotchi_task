using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using tamagotchi_task.Domain;
using tamagotchi_task.Models.ViewModels;

namespace tamagotchi_task.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly AppDbContext db;
        public AccountController(AppDbContext context)
        {
            db = context;
        }

        [HttpGet]
        //Без AllowAnonymous невозможно регаться
        [AllowAnonymous]
        public IActionResult Login(string returnUrl)
        {
            ViewBag.returnUrl = returnUrl;
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel model)
        {
            //if (ModelState.IsValid) { -- С этой штукой не работает, но это может быть небезопасно
            //Проверка параметров пользователя
            MyUser user = await db.MyUsers.FirstOrDefaultAsync(u => u.Name == model.Name && u.Password == model.Password);
            if (user != null)
            {
                await Authenticate(model.Name); //Аутентификация

                return RedirectToAction("Index", "Home");
            }
            ModelState.AddModelError("", "Incorrect username or password.");
            return View(model);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                MyUser user = await db.MyUsers.FirstOrDefaultAsync(u => u.Name == model.Name);
                if (user == null)
                {
                    Guid id = Guid.NewGuid(); //У нас Id не int, поэтому нужно его генерить ручками

                    //Добавление нового пользователя в глобальный чат
                    Chat chat = await db.Chats.FirstOrDefaultAsync(c => c.Name == "Global Chat");
                    //Если chat == null, выйдет SQL Exception

                    //Добавляем пользователя в бд
                    db.MyUsers.Add(new MyUser { Id = id, Name = model.Name, Password = model.Password, Chats = chat });

                    await db.SaveChangesAsync();

                    await Authenticate(model.Name); //Аутентификация

                    return RedirectToAction("Index", "Home");
                }
                else
                    ModelState.AddModelError("", "Incorrect username or password.");
            }
            return View(model);
        }

        [AllowAnonymous]
        public IActionResult Profile()
        {
            return View();
        }

        //Сейчас будет куча непонятных штук (обратим внимание на то, что он private)
        private async Task Authenticate(string userName)
        {
            //Создаем один claim
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, userName)
            };
            //Создаем объект ClaimsIdentity
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            //Установка аутентификационных куки
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Account");
        }
    }
}