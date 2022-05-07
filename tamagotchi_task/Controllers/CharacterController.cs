using Microsoft.AspNetCore.Mvc;
using tamagotchi_task.Domain;
using tamagotchi_task.Managers.EF_Realizations;
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

                return RedirectToAction("Avatar", "Character");
            }
            return View(model);
        }

        public IActionResult Avatar() 
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
