using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using tamagotchi_task.Domain;
using tamagotchi_task.Managers.Interfaces;
using tamagotchi_task.Models.ViewModels;

namespace tamagotchi_task.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        //При использовании асинхронного програмирования нельзя брать реализацию!
        //Вместо MyUserManager используем IUserManager, и биндим её через AddTransient (или AddScoped)
        private readonly IUserManager _userManager;
        private readonly IChatManager _chatManager;
        public AccountController(IUserManager userManager, IChatManager chatManager)
        {
            _userManager = userManager;
            _chatManager = chatManager;
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
            MyUser user = await _userManager.FindUserByNamePasswordAsync(model.Name, model.Password);
            if (user != null)
            {
                await Authenticate(model.Name); //Аутентификация

                //Если у пользователя нет животинки, то пусть идёт создавать новую
                if (_userManager.HasAnimal(user.Id) == null)
                    return RedirectToAction("Create", "Character");

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
                MyUser user = await _userManager.FindUserByNameAsync(model.Name);
                if (user == null)
                {
                    Guid id = Guid.NewGuid(); //У нас Id не int, поэтому нужно его генерить ручками

                    //Добавление нового пользователя в глобальный чат
                   Chat chat = await _chatManager.FindChatByName("Global Chat");
                    //Если chat == null, выйдет SQL Exception

                    //Добавляем пользователя в бд
                    await _userManager.AddUserToDataBase(id, model.Name, model.Password, chat);

                    await Authenticate(model.Name); //Аутентификация

                    return RedirectToAction("Create", "Character");
                }
                else
                    ModelState.AddModelError("", "This user already exists!");
            }
            return View(model);
        }

        [AllowAnonymous]
        public IActionResult Profile()
        {
            if (User.Identity.IsAuthenticated)
                return View();
            else
               return RedirectToAction("Login", "Account");
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