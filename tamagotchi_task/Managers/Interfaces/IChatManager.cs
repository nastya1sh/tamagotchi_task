namespace tamagotchi_task.Managers.Interfaces
{
    public interface IChatManager
    {
        public Task<Chat> FindChatByName(string chatName);
    }
}
