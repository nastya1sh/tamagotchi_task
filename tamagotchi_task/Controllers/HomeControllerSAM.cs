using Microsoft.AspNetCore.Mvc;
using tamagotchi_task.Domain;
using tamagotchi_task.Managers.Interfaces;
using tamagotchi_task.Models.ViewModels;

namespace tamagotchi_task.Controllers
{
    public partial class HomeController : Controller
    { // заметки : как он понимает что делать по какой кнопке ?
        public async Task<IActionResult> Chat()
        {
            if (User.Identity.IsAuthenticated)
            {            
                return View();
            }
            else
                return RedirectToAction("Login", "Account");           
        }

        [HttpPost]
        public async Task<IActionResult> Chat(MessageModel model)
        {
            Chat chat = await _ChatManager.FindChatByName("Global Chat");
            MyUser myUser = await _UserManager.FindUserByNameAsync(User.Identity.Name);           
           await _ChatManager.SendMessage(model.Text, chat, myUser); 
            return View();
        }            
    }     
}
