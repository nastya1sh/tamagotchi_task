using Microsoft.EntityFrameworkCore;
using tamagotchi_task.Domain;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
//Подключаем контекст БД, чтобы не писать команды SQL, а использовать EF Core
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(
        "Data Source=(local); Database=Characters; Persist Security Info=False; MultipleActiveResultSets=True; Trusted_Connection=True;"
        ));

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();