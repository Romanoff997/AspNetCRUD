using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Domain.Repositories.EntityFramework;
using WebApplication2.Domen;
using WebApplication2.Domen.Repositories.Abstract;
using WebApplication2.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.AddAuthentication("Bearer").AddApplicationCookie();  // схема аутентификации - с помощью jwt-токенов
//.AddJwtBearer();      // подключение аутентификации с помощью jwt-токенов

//var connectionString = builder.Configuration.GetChildren();
builder.Services.AddDbContext<MyDbContext>(options=>options.UseSqlServer("Server=.\\SQLEXPRESS;Database=CRUDDB;Trusted_Connection=True; User Id=sa; Password=qwerty; MultipleActiveResultSets=True;"));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

//builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
//    .AddEntityFrameworkStores<MyDbContext>();
//builder.Services.AddTransient<IEmployeeInfoRepository, EmployeeDAL>();
builder.Services.AddTransient<IEmployeeInfoRepository, EFServiceItemsRepository>();
builder.Services.AddTransient<DataManager>();
builder.Services.AddIdentity<IdentityUser,IdentityRole>(opts =>
{
    opts.SignIn.RequireConfirmedAccount = false;//
    opts.Password.RequiredLength = 5;   // минимальная длина
    opts.Password.RequireNonAlphanumeric = false;   // требуются ли не алфавитно-цифровые символы
    opts.Password.RequireLowercase = false; // требуются ли символы в нижнем регистре
    opts.Password.RequireUppercase = false; // требуются ли символы в верхнем регистре
    opts.Password.RequireDigit = false; // требуются ли цифры
    opts.User.RequireUniqueEmail = true;
    opts.SignIn.RequireConfirmedEmail = false;
    //opts.Password.RequiredLength = 4;
    //opts.Password.RequireNonAlphanumeric = false;
    //opts.Password.RequireLowercase = false;
    //opts.Password.RequireUppercase = false;
    //opts.Password.RequireDigit = false;
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
    //x.AddPolicy("AdminArea", x => x.RequireRole("admin"));
});

//builder.Services.AddControllersWithViews(x => 
//{
//    x.Conventions.Add(new AdminAreaAuthorization("Admin", "AdminArea"));
//});
//builder.Services.AddAuthentication().AddGoogle(googleOptions =>
//{
//    googleOptions.ClientId = "800725451921-d0lbe2vius042b9s861fvska2ua32m9l.apps.googleusercontent.com";
//    googleOptions.ClientSecret = "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";
//});

builder.Services.AddRazorPages();

var app = builder.Build();

builder.Configuration.AddJsonFile("appsettings.json");
var config = app.Configuration.Get<Config>();

//client id 800725451921-d0lbe2vius042b9s861fvska2ua32m9l.apps.googleusercontent.com
//client secret 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

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}
app.UseWebSockets();
//app.UseDefaultFiles();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseCookiePolicy();
app.UseAuthorization();
app.UseAuthentication();

app.UseEndpoints(endpoints =>
{
    //endpoints.MapControllerRoute(name: "admin", 
    //    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
    //endpoints.MapControllerRoute(name: "Identity", 
    //    pattern: "{area:exists}/{controller=Account}/{action=Index}/{id?}");
    endpoints.MapControllerRoute(name: "default",
        pattern: "{controller=Employee}/{action=Index}/{id?}");
    endpoints.MapRazorPages();
});

app.Run();
