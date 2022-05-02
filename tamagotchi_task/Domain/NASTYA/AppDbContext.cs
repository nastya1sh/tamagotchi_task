using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using tamagotchi_task.Domain.Entities;

namespace tamagotchi_task.Domain
{
    //Всё перечисленное ниже может не сработать, если не установить специальные расширения
    //Этот класс - дар Microsoft и заодно главный элемент в EF Core
    public partial class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public DbSet<CharacterTask> CharacterTasks { get; set; }
        //Всё остальное есть уже в папке SEMEN
        public DbSet<Accessories> Accessories { get; set; }
        public DbSet<Animal> Animals { get; set; }
        public DbSet<Avatar> Avatars { get; set; }
        public DbSet<Chat> Chats { get; set; }
        public DbSet<Fur> Furs { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Wallpaper> Wallpapers { get; set; }

    }
}
