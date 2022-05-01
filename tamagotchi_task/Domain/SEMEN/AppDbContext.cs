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
        public DbSet<Forage> Forage { get; set; }
        public DbSet<LoginUser> Users { get; set; }
        public DbSet<ForageCharacter> ForageCharacter { get; set; }
        public DbSet<PotionCharacter> PotionCharacter { get; set; }
        public DbSet<Potions> Potions { get; set; }
        public DbSet<Showcase> Showcases { get; set; }
        public DbSet<Tags> Tags { get; set; }
        public DbSet<TagsTasks> TagsTasks { get; set; }
        public DbSet<ToyCharacter> ToyCharacter{ get; set; }
        public DbSet<Toys> Toys { get; set; }
       


protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Не могу сделать этот метод partial, придётся кому-то одному писать
            base.OnModelCreating(modelBuilder);

            //Повторяющийся код, как-нибудь надо потом сократить
            modelBuilder.Entity<CharacterTask>().HasKey(c => c.Id); //До сих пор не понимаю, зачем ему явно объявляет PK
            modelBuilder.Entity<Character>().HasKey(c => c.Id);
            modelBuilder.Entity<Forage>().HasKey(c => c.Id);
            modelBuilder.Entity<ForageCharacter>().HasKey(c => c.Id);
            modelBuilder.Entity<PotionCharacter>().HasKey(c => c.Id);
            modelBuilder.Entity<Potions>().HasKey(c => c.Id);
            modelBuilder.Entity<Showcase>().HasKey(c => c.Id);
            modelBuilder.Entity<Tags>().HasKey(c => c.Id);
            modelBuilder.Entity<TagsTasks>().HasKey(c => c.Id);
            modelBuilder.Entity<ToyCharacter>().HasKey(c => c.Id);
            modelBuilder.Entity<Toys>().HasKey(c => c.Id);
            

            /*modelBuilder.Entity<Character>().HasData(new Character
            {
                Эта конструкция создаёт элемент таблицы Character, но пока редактировать БД не будем
            }) ;*/
        }
    }
}
