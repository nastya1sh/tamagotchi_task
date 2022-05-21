 using Microsoft.AspNetCore.Mvc;
using tamagotchi_task.Managers.Interfaces;
namespace tamagotchi_task.Views.ViewComponents
{
    public class MessageViewComponent: ViewComponent
    {

        private readonly IChatManager _ChatManager;
        private readonly IUserManager _UserManager;

        public MessageViewComponent(IChatManager chatManager, IUserManager userManager)
            {
            _ChatManager = chatManager;
            _UserManager = userManager;
        }

        public IViewComponentResult Invoke()
        {
            var messages = _ChatManager.WriteNLastMessages();
            string username = User.Identity.Name;
            ViewBag.Username = username;
            return View(messages);
        }
    }
}



