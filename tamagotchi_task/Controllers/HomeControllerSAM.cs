using Microsoft.AspNetCore.Mvc;
using tamagotchi_task.Domain;
using tamagotchi_task.Managers.Interfaces;

namespace tamagotchi_task.Controllers
{
    public partial class HomeController : Controller
    {
         public async Task<IActionResult> Chat()
        {
            Chat chat = await _ChatManager.FindChatByName("Global Chat");
            string ChatName = _ChatManager.WriteChatName(chat);
           // _ChatManager.WriteNLastMessages(chat); // десять последний сообщений
            var users = _ChatManager.WriteAllUsers(chat); // все юзеры
           
            
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SendMessage(string text)
        {
            if (text.Length > 0)
            {
                Chat  chat = await _ChatManager.FindChatByName("Global Chat");// заявка на будущее
                MyUser myUser = await _UserManager.FindUserByNameAsync(User.Identity.Name); 
                    _ChatManager.SendMessage(text, chat, myUser);
            }
            return RedirectToAction("Home","Chat");
        }

        public IActionResult ShowNLastMessages()
        {

            return View();
        }
    }
     
}
