using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Domain.Repositories.EntityFramework;
using WebApplication2.Domen;
using WebApplication2.Domen.Repositories.Abstract;
using WebApplication2.Domen.Repositories.DAL;
using WebApplication2.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.AddAuthentication("Bearer").AddApplicationCookie();  // схема аутентификации - с помощью jwt-токенов
    //.AddJwtBearer();      // подключение аутентификации с помощью jwt-токенов
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<MyDbContext>(x => x.UseSqlServer("Server=.\\SQLEXPRESS;Database=CRUDDB;Trusted_Connection=True; User Id=sa; Password=qwerty; MultipleActiveResultSets=True;"));
//builder.Services.AddTransient<IEmployeeInfoRepository, EmployeeDAL>();
builder.Services.AddTransient<IEmployeeInfoRepository, EFServiceItemsRepository>();
builder.Services.AddTransient<DataManager>();


var app = builder.Build();

builder.Configuration.AddJsonFile("appsettings.json");
var config = app.Configuration.Get<Config>();




// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseCookiePolicy();
app.UseAuthorization();
app.UseAuthentication();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Employee}/{action=Index}/{id?}");

app.Run();
