using Microsoft.AspNetCore.Mvc;
using tamagotchi_task.Domain;
using tamagotchi_task.Managers.Interfaces;
using tamagotchi_task.Models.ViewModels;

namespace tamagotchi_task.Controllers
{
    public class CharacterController : Controller
    {
        private readonly ICharacterManager _characterManager;
        private readonly IUserManager _userManager;

        public CharacterController(ICharacterManager characterManager, IUserManager userManager) 
        {
            _characterManager = characterManager;
            _userManager = userManager;
        }

        public IActionResult Create()
        {
            if (User.Identity.IsAuthenticated)
                return View();
            else
                return RedirectToAction("Login", "Account");
        }
        [HttpPost]
        public async Task<IActionResult> Create(CharacterModel model) 
        {
            if (ModelState.IsValid)
            {
                //Вместо получения ID пользователя воспользуемся его именем
                MyUser user = await _userManager.FindUserByNameAsync(User.Identity.Name);
                if (user == null) //Если вдруг пользователь не авторизирован - пока-пока!
                    return RedirectToAction("Login", "Account");

                //Добавляем персонажа в бд
                await _characterManager.AddCharacterToDataBase(Guid.NewGuid(), user, model.Name);

                return RedirectToAction("Avatar", "Character");
            }
            return View(model);
        }

        public IActionResult Animal() 
        {
            if (User.Identity.IsAuthenticated)
                return View();
            else
                return RedirectToAction("Login", "Account");
        }
        [HttpPost]
        public IActionResult Animal(AnimalModel model)
        {
            return View();
        }

        public IActionResult Color()
        {
            if (User.Identity.IsAuthenticated)
                return View();
            else
                return RedirectToAction("Login", "Account");
        }
        [HttpPost]
        public IActionResult Color(ColorModel model)
        {
            return View();
        }

        public IActionResult Wallpaper()
        {
            if (User.Identity.IsAuthenticated)
                return View();
            else
                return RedirectToAction("Login", "Account");
        }
        [HttpPost]
        public IActionResult Wallpaper(WallpaperModel model)
        {
            return View();
        }

        public IActionResult Accessory()
        {
            if (User.Identity.IsAuthenticated)
                return View();
            else
                return RedirectToAction("Login", "Account");
        }
        [HttpPost]
        public IActionResult Accessory(AccessoryModel model)
        {
            return View();
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
