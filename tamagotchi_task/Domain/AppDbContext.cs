using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace tamagotchi_task.Domain
{
    //Всё перечисленное ниже может не сработать, если не установить специальные расширения
    //Этот класс - дар Microsoft и заодно главный элемент в EF Core
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        #region Создание таблиц
        public DbSet<Chat> Chats { get; set; }     
        public DbSet<Message> Messages { get; set; }     
        public DbSet<Character> Characters { get; set; }
        public DbSet<Forage> Forages { get; set; }
        public DbSet<MyUser> MyUsers { get; set; }
        public DbSet<Potions> Potions { get; set; }
        public DbSet<Showcase> Showcases { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<Toys> Toys { get; set; }
        public DbSet<CharacterTask> CharacterTasks { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Chat>().HasData(new Chat
            {
                Id = new Guid("0FA0052E-B8FB-42F6-B8BA-BF205FDE5EFC"),
                Name = "Global Chat", //Нужна для удобного поиска при создании нового пользователя
                MyUsers = new List<MyUser>(),
                Messages = new List<Message>()
            });

            #region Добавление предметов
            modelBuilder.Entity<Forage>().HasData(new Forage
            {
                Id = new Guid("5ba2279b-e785-43e4-89f9-d75e805985a2"),
                Name = "Beer",
                Buff_HP = 1,
            }); //Beer
            modelBuilder.Entity<Forage>().HasData(new Forage
            {
                Id = new Guid("5ba3030b-e785-43e4-89f9-d75e805985a2"),
                Name = "Fried Fish",
                Buff_HP = 4,
            }); //Fried Fish
            modelBuilder.Entity<Potions>().HasData(new Potions
            {
                Id = new Guid("df691f45-64ab-4618-b3d9-4256a94cdf6a"),
                Name = "Elixir of Wisdom",
                Buff_XP = 5,
            }); //Elixir of Wisdom
            modelBuilder.Entity<Potions>().HasData(new Potions
            {
                Id = new Guid("df691f45-ddad-4618-b3d9-4256a94cdf6a"),
                Name = "COCKtail",
                Buff_XP = 30,
            }); //Cocktail
            modelBuilder.Entity<Toys>().HasData(new Toys
            {
                Id = new Guid("37514fe5-e7f3-4926-89ad-60a4d7dc55ab"),
                Name = "Ring",
                Buff_Strength = 1
            }); //Ring
            #endregion

            #region Добавление витрины
            modelBuilder.Entity<Showcase>().HasData(new Showcase
            {
                Id = new Guid("1a3a93a0-796c-471a-9c25-a93771b8e6df"),
                Item_Type = "Forage",
                Item_Name = "Beer",
                Image = "/img/beer.png",
                Price = 1,
                Level = 1,
                ForageId = new Guid("5ba2279b-e785-43e4-89f9-d75e805985a2"),
            }); //Beer
            modelBuilder.Entity<Showcase>().HasData(new Showcase
            {
                Id = new Guid("3b11ab11-0696-41e0-9d6d-abc0119a942c"),
                Item_Type = "Potions",
                Item_Name = "Elixir of Wisdom",
                Image = "/img/flask_xp.png",
                Price = 2,
                Level = 1,
                PotionId = new Guid("df691f45-64ab-4618-b3d9-4256a94cdf6a"),
            }); //Elixir of Wisdom
            modelBuilder.Entity<Showcase>().HasData(new Showcase
            {
                Id = new Guid("4ff8e8f7-bcc5-4172-a94e-fdf959ba1760"),
                Item_Type = "Toys",
                Item_Name = "Ring",
                Image = "/img/ring.png",
                Price = 3,
                Level = 1,
                ToyId = new Guid("37514fe5-e7f3-4926-89ad-60a4d7dc55ab"),
            }); //Ring
            modelBuilder.Entity<Showcase>().HasData(new Showcase
            {
                Id = new Guid("4ff8edd7-bcc5-4172-a94e-fdf959ba1760"),
                Item_Type = "Forage",
                Item_Name = "Fried Fish",
                Image = "/img/flask_intellect.png",
                Price = 5,
                Level = 3,
                ForageId = new Guid("5ba3030b-e785-43e4-89f9-d75e805985a2"),
            }); //Fried Fish
            modelBuilder.Entity<Showcase>().HasData(new Showcase
            {
                Id = new Guid("323a9b11-0696-41e0-9d6d-abc0119a942c"),
                Item_Type = "Potions",
                Item_Name = "COCKtail",
                Image = "/img/xp.png",
                Price = 10,
                Level = 5,
                PotionId = new Guid("df691f45-ddad-4618-b3d9-4256a94cdf6a"),
            }); //Cocktail

            //Аксессуары
            modelBuilder.Entity<Showcase>().HasData(new Showcase
            {
                Id = new Guid("7716b8f6-4d7d-49d5-95ff-8ffe1065b142"),
                Item_Type = "Accessories",
                Item_Name = "Desperado's Coat",
                Image = "/img/Item1prew.png",
                Price = 10,
                Level = 1,
            }); //Desperado's Coat
            modelBuilder.Entity<Showcase>().HasData(new Showcase
            {
                Id = new Guid("516ef915-6b18-4dea-8dd4-0e24abc5bb98"),
                Item_Type = "Accessories",
                Item_Name = "Sombrero",
                Image = "/img/Item2prew.png",
                Price = 1500,
                Level = 100,
            }); //Sombrero
            modelBuilder.Entity<Showcase>().HasData(new Showcase
            {
                Id = new Guid("5eaf1a37-0b00-4b90-b73d-d739f9ec6d32"),
                Item_Type = "Accessories",
                Item_Name = "Clown's Glasses",
                Image = "/img/Item3prew.png",
                Price = 60,
                Level = 3,
            }); //Clown's Glasses
            modelBuilder.Entity<Showcase>().HasData(new Showcase
            {
                Id = new Guid("219920cd-971d-4db7-94e8-246bac987be0"),
                Item_Type = "Accessories",
                Item_Name = "Astrohelmet",
                Image = "/img/Item4prew.png",
                Price = 30,
                Level = 2,
            }); //Astrohelmet
            modelBuilder.Entity<Showcase>().HasData(new Showcase
            {
                Id = new Guid("12c40c10-eb5b-4ba2-80c4-5352fe5a6c24"),
                Item_Type = "Accessories",
                Item_Name = "Motorcycle Helmet",
                Image = "/img/Item5prew.png",
                Price = 100,
                Level = 5,
            }); //Motorcycle Helmet
            #endregion

            #region Решение конфликта
            //Эта штука появилась после добавления чата
            modelBuilder.Entity<Message>()
                .HasOne(e => e.MyUser)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);
            #endregion

            #region Дефолтные значения Character
            modelBuilder.Entity<Character>().Property(b => b.Intellect).HasDefaultValue(0);
            modelBuilder.Entity<Character>().Property(b => b.Strength).HasDefaultValue(0);
            modelBuilder.Entity<Character>().Property(b => b.Money).HasDefaultValue(0);
            modelBuilder.Entity<Character>().Property(b => b.XP).HasDefaultValue(0);
            modelBuilder.Entity<Character>().Property(b => b.Level).HasDefaultValue(1);
            modelBuilder.Entity<Character>().Property(b => b.HP).HasDefaultValue(6);
            modelBuilder.Entity<Character>().Property(b => b.AnimalImage).HasDefaultValue("/img/catAnimal.png");
            modelBuilder.Entity<Character>().Property(b => b.ColorImage).HasDefaultValue("/img/cat0.png");
            modelBuilder.Entity<Character>().Property(b => b.WallpaperImage).HasDefaultValue("/img/circle.png");
            #endregion
        }
    }
}
