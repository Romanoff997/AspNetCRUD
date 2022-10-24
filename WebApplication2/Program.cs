using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Domain.Repositories.EntityFramework;
using WebApplication2.Domen;
using WebApplication2.Domen.Repositories.Abstract;
using WebApplication2.Domen.Repositories.DAL;
using WebApplication2.Service;
using WebApplication4.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.AddAuthentication("Bearer").AddApplicationCookie();  // схема аутентификации - с помощью jwt-токенов
    //.AddJwtBearer();      // подключение аутентификации с помощью jwt-токенов

builder.Services.AddDbContext<MyDbContext>(x => x.UseSqlServer("Server=.\\SQLEXPRESS;Database=CRUDDB;Trusted_Connection=True; User Id=sa; Password=qwerty; MultipleActiveResultSets=True;"));

//builder.Services.AddTransient<IEmployeeInfoRepository, EmployeeDAL>();
builder.Services.AddTransient<IEmployeeInfoRepository, EFServiceItemsRepository>();
builder.Services.AddTransient<DataManager>();
builder.Services.AddIdentity<IdentityUser, IdentityRole>(opts =>
{
    opts.User.RequireUniqueEmail = true;
    opts.Password.RequiredLength = 4;
    opts.Password.RequireNonAlphanumeric = false;
    opts.Password.RequireLowercase = false;
    opts.Password.RequireUppercase = false;
    opts.Password.RequireDigit = false;
}).AddEntityFrameworkStores<MyDbContext>().AddDefaultTokenProviders();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.Cookie.Name = "MySite";
    options.Cookie.HttpOnly = true;
    options.LoginPath = "/account/login";
    options.AccessDeniedPath = "/account/accessdenied";
    options.SlidingExpiration = true;
});

builder.Services.AddAuthorization(x=>
{
    x.AddPolicy("AdminArea", x => x.RequireRole("admin"));
});

builder.Services.AddControllersWithViews(x => 
{
    x.Conventions.Add(new AdminAreaAuthorization("Admin", "AdminArea"));
});
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

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(name: "admin", 
        pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
    endpoints.MapControllerRoute(name: "default",
        pattern: "{controller=Employee}/{action=Index}/{id?}");
});

app.Run();
