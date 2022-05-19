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
            return View();// доделать (нужно ?)
        }

        [HttpPost]
        public async Task<IActionResult> Chat(MessageModel model)
        {
            Chat chat = await _ChatManager.FindChatByName("Global Chat");
            MyUser myUser = await _UserManager.FindUserByNameAsync(User.Identity.Name);           
           await _ChatManager.SendMessage(model.Text, chat, myUser);
           // string ChatName = _ChatManager.WriteChatName(chat);
           // _ChatManager.WriteNLastMessages(chat); // десять последний сообщений
           // var users = _ChatManager.WriteAllUsers(chat); // все юзеры 
            return View();
        }
        //[HttpPost]
        //private async Task<IActionResult> SendMessage(string text)
        //{
        //    if (text.Length > 0)
        //    {
        //        Chat  chat = await _ChatManager.FindChatByName("Global Chat");// заявка на будущее
        //        MyUser myUser = await _UserManager.FindUserByNameAsync(User.Identity.Name); 
        //            _ChatManager.SendMessage(text, chat, myUser);
        //    }
        //    return RedirectToAction("Home","Chat");
        //}

        public IActionResult ShowNLastMessages()
        {

            return View();
        }
    }
     
}
