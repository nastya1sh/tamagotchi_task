﻿using Microsoft.AspNetCore.Mvc;
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

        public async Task<IActionResult> Create()
        {
            if (User.Identity.IsAuthenticated)
            {
                //Проверяем, есть ли у пользователя зверушка
                if (await _characterManager.FindCharacterByUser(User.Identity.Name) != null)
                    return RedirectToAction("Index", "Home"); //Если уже есть, то не даём создать новую

                return View();
            }
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

        public async Task<IActionResult> AvatarCreate() 
        {
            if (User.Identity.IsAuthenticated)
            {
                //Отправляем в представление все аксессуары у зверушки (или просто null, если их нет) 
                ViewBag.Accessories = _inventoryManager
                    .GetAccessories(await _characterManager.FindCharacterByUser(User.Identity.Name)).ToList();
                //То же самое делаем с обоями
                ViewBag.Wallpapers = _inventoryManager
                    .GetWallpapers(await _characterManager.FindCharacterByUser(User.Identity.Name)).ToList();

                return View();
            }
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
        
        public async Task<IActionResult> EditAvatar() 
        {
            if (User.Identity.IsAuthenticated)
            {
                Character chara = await _characterManager.FindCharacterByUser(User.Identity.Name);
                //Отправляем в представление все аксессуары у зверушки (или просто null, если их нет) 
                ViewBag.Accessory = chara.AccessoryImage;
                //То же самое делаем с обоями
                ViewBag.Wallpaper = chara.WallpaperImage;
                ViewBag.Color = chara.ColorImage;
                ViewBag.Accessories = _inventoryManager
                    .GetAccessories(await _characterManager.FindCharacterByUser(User.Identity.Name)).ToList();
                //То же самое делаем с обоями
                ViewBag.Wallpapers = _inventoryManager
                    .GetWallpapers(await _characterManager.FindCharacterByUser(User.Identity.Name)).ToList();
                return View();
            }
            else
                return RedirectToAction("Login", "Account");
        }
        [HttpPost]
        public async Task<IActionResult> EditAvatar(AvatarModel model)
        {
            if (ModelState.IsValid)
            {
                Character chara = await _characterManager.FindCharacterByUser(User.Identity.Name);
                await _characterManager.SetAvatar(chara, model);

                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Inventory(string searchString)
        {
            if (User.Identity.IsAuthenticated)
            {
                //Выводим список вещей из инвентаря зверушки
                var items = _inventoryManager.GetItems(await _characterManager.FindCharacterByUser(User.Identity.Name));
                if (!String.IsNullOrEmpty(searchString))
                {
                    items = items.Where(s => s.Item_Name.ToUpper().Contains(searchString.ToUpper()));
                }

                return View(items);
            }
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

        [HttpGet]
        public async Task<IActionResult> Shop(string searchString)
        {
            if (User.Identity.IsAuthenticated)
            {
                //Нам нужно взять уровень персонажа, чтобы вывести предметы в магазине
                Character chara = await _characterManager.FindCharacterByUser(User.Identity.Name);
                //Выводим список вещей в магазине (назвал products, чтобы отличать от вещей в инвентаре)
                var products = _showcaseManager.GetItems(chara);
                if (!String.IsNullOrEmpty(searchString))
                {
                    products = products.Where(s => s.Item_Name.ToUpper().Contains(searchString.ToUpper()));
                }

                return View(products);
            }
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

        public async Task<IActionResult> Dead()
        {
            return View();
        }
    }
}
