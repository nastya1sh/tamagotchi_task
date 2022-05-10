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
        private readonly IShowcaseManager _showcaseManager;

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
                await _characterManager.AddCharacterToDataBase(Guid.NewGuid(), user, model.Name);

                return RedirectToAction("AvatarCreate", "Character");
            }
            return View(model);
        }

        public IActionResult AvatarCreate() 
        {
            if (User.Identity.IsAuthenticated)
                return View();
            else
                return RedirectToAction("Login", "Account");
        }
        [HttpPost]
        public async Task<IActionResult> AvatarCreate(AvatarModel model)
        {
            if (ModelState.IsValid)
            {
                Character chara = await _characterManager.FindCharacterByUser(User.Identity.Name);
                _characterManager.SetAnimal(chara, model.Animal);
                _characterManager.SetColor(chara, model.Color);
                _characterManager.SetWallpaper(chara, model.Wallpaper);
                _characterManager.SetAccessory(chara, model.Accessory);

                return RedirectToAction("Index", "Home");
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
