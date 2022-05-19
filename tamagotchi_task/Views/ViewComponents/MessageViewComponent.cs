 using Microsoft.AspNetCore.Mvc;
using tamagotchi_task.Managers.Interfaces;
namespace tamagotchi_task.Views.ViewComponents
{
    public class MessageViewComponent: ViewComponent
    {
               
            private readonly IChatManager _ChatManager;

            public MessageViewComponent(IChatManager chatManager)
            {
            _ChatManager = chatManager;
            }

        public IViewComponentResult Invoke()
        {
            var messages = _ChatManager.WriteNLastMessages();

            return View(messages);
        }
    }
}



