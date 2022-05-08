using Microsoft.AspNetCore.Mvc;
using tamagotchi_task.Managers.Interfaces;

namespace tamagotchi_task.Views.ViewComponents
{
    public class ShowCharacterViewComponent : ViewComponent
    {
        private readonly ICharacterManager _characterManager;

        public ShowCharacterViewComponent(ICharacterManager characterManager)
        {
            _characterManager = characterManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var character = await _characterManager.FindCharacterByUser(User.Identity.Name);

            return View(character);
        }
    }
}
