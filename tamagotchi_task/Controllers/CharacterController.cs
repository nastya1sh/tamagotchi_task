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
        private readonly IInventoryManager _inventoryManager;

        public CharacterController(
            ICharacterManager characterManager, IUserManager userManager,
            IShowcaseManager showcaseManager, IInventoryManager inventoryManager)
        {
            _characterManager = characterManager;
            _userManager = userManager;
            _showcaseManager = showcaseManager;
            _inventoryManager = inventoryManager;
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
                await _characterManager.SetAvatar(chara, model);

                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }

        public IActionResult Inventory()
        {
            if (User.Identity.IsAuthenticated)
                return View(_inventoryManager.GetItems());
            else
                return RedirectToAction("Login", "Account");
        }
        [HttpPost]
        public async Task<IActionResult> Use(Guid itemID)
        {
            Character chara = await _characterManager.FindCharacterByUser(User.Identity.Name);
            await _inventoryManager.UseItem(chara, itemID);
            return RedirectToAction("Inventory", "Character");
        }

        public IActionResult Shop()
        {
            if (User.Identity.IsAuthenticated)
                return View(_showcaseManager.ShowAll());
            else
                return RedirectToAction("Login", "Account");
        }
        [HttpPost]
        public async Task<IActionResult> Buy(Guid itemID)
        {
            Character chara = await _characterManager.FindCharacterByUser(User.Identity.Name);
            await _showcaseManager.BuyItem(chara, itemID);
            return RedirectToAction("Shop", "Character");
        }
    }
}
