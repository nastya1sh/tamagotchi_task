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
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Character> Characters { get; set; }
        //Пока не хочу подключать класс User, так как в строке 9 есть IdentityUser

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Не могу сделать этот метод partial, придётся кому-то одному писать
            base.OnModelCreating(modelBuilder);

            //Повторяющийся код, как-нибудь надо потом сократить
            modelBuilder.Entity<CharacterTask>().HasKey(c => c.Id); //До сих пор не понимаю, зачем ему явно объявляет PK
            modelBuilder.Entity<Character>().HasKey(c => c.Id);

            /*modelBuilder.Entity<Character>().HasData(new Character
            {
                Эта конструкция создаёт элемент таблицы Character, но пока редактировать БД не будем
            }) ;*/
        }
    }
}
