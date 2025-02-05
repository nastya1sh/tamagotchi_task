﻿using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using tamagotchi_task.Service;
using tamagotchi_task.Managers.Interfaces;
using tamagotchi_task.Managers.EF_Realizations;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

#region Подключение контекста
//Соединяем Config и appsettings.json
builder.Configuration.Bind("Project", new Config());

//Подключаем контекст БД
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(Config.ConnectionString));
#endregion

#region Настройки Cookies
//Устанавливаем конфигурацию подключения через "печеньки"
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options => //CookieAuthenticationOptions
    {
        options.LoginPath = new Microsoft.AspNetCore.Http.PathString("/Account/Login");
    });
builder.Services.AddControllersWithViews();
#endregion

#region Внедрение зависимостей
builder.Services.AddTransient<IUserManager, MyUserManager>();
builder.Services.AddTransient<IChatManager, ChatManager>();
builder.Services.AddTransient<ITaskManager, TaskManager>();
builder.Services.AddTransient<ICharacterManager, CharacterManager>();
builder.Services.AddTransient<IShowcaseManager, ShowcaseManager>();
builder.Services.AddTransient<IInventoryManager, InventoryManager>();
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization(); //Работает с ролями пользователей
app.UseAuthentication(); //Позволяет проверять подлинность пользователей по логину/паролю

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Register}/{id?}");

app.Run();