using Microsoft.AspNetCore.Mvc;
using tamagotchi_task.Domain;
using tamagotchi_task.Managers.Interfaces;
using tamagotchi_task.Models.ViewModels;
using tamagotchi_task.Models.ViewModels.Avatar;

namespace tamagotchi_task.Controllers
{
    public class CharacterController : Controller
    {
        private readonly ICharacterManager _characterManager;
        private readonly IUserManager _userManager;
        private readonly IShowcaseManager _showcaseManager;
        private Character _character = new Character();

        public CharacterController(ICharacterManager characterManager, IUserManager userManager, IShowcaseManager showcaseManager)
        {
            _characterManager = characterManager;
            _userManager = userManager;
            _showcaseManager = showcaseManager;
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
                _character.Id = Guid.NewGuid();
                _character.MyUsers = user;
                _character.Name = model.Name;

                return RedirectToAction("Color", "Character");
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
        public async Task<IActionResult> Animal(AnimalModel model)
        {
            if (ModelState.IsValid)
            {
                _character.AnimalImage = model.Animal;

                return RedirectToAction("Color", "Character");
            }
            return View(model);
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
            if (ModelState.IsValid)
            {
                _character.ColorImage = model.Color;

                return RedirectToAction("Wallpaper", "Character");
            }
            return View(model);
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
            if (ModelState.IsValid)
            {
                _character.WallpaperImage = model.Wallpaper;

                return RedirectToAction("Wallpaper", "Character");
            }
            return View(model);
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
            if (ModelState.IsValid)
            {
                _character.AccessoryImage = model.Accessory;

                return RedirectToAction("Wallpaper", "Character");
            }
            return View(model);
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
