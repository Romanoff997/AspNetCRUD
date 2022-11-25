using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.ViewModels;
using WebApplication2.Domen;
using WebApplication2.Models;
using WebApplication2.Services;

namespace WebApplication2.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly MyDbContext context;
        private IJsonConverter JsonConverter = new JsonNewtonConverter();

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, MyDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            this.context = context;

        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                IdentityUser user = new IdentityUser { Email = model.Email, UserName = model.Email };
                //добавляем пользователя
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    //установка куки
                    await _signInManager.SignInAsync(user, false);
                    UserInfo currUser = new UserInfo() { Id = user.Id, Energy = "0", Rubies = "0", Gold = "0" };
                    context.UserAssets.Add(currUser);
                    context.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult Index()
        {
            var userId = _userManager.GetUserId(User);
            UserInfo currUser = context.UserAssets.ToList().Where(x => x.Id == userId).FirstOrDefault();
            return View(new ProfileViewModel() {userInfo = currUser });
        }
        [HttpPost]
        public IActionResult Index(ProfileViewModel currUser)
        {
            UserInfo user = context.UserAssets.ToList().Where(x=>x.Id==(currUser.userInfo.Id)).FirstOrDefault();//.OrderByDescending(x => x.Id).Take(1).DefaultIfEmpty();
            if (user != null)
            {
                user.Energy = currUser.userInfo.Energy;
                user.Rubies = currUser.userInfo.Rubies;
                user.Gold = currUser.userInfo.Gold;
                context.SaveChanges();
            }
            return View(currUser);
        }

        [HttpGet]
        public IActionResult JsonIndex(string id)//JsonResult JsonIndex(string id)
        {
            UserInfo re = context.UserAssets.ToList().Where(x=>x.Id.ToString().Equals(id)).FirstOrDefault();
            string jsn = JsonConverter.WriteJson<UserInfo>(re);
            //return new JsonResult(re);
            return View("Index",new ProfileViewModel() {userInfo=re, Json=jsn });
        }

        [HttpGet]
        public IActionResult Login(string returnUrl = null)
        {
            return View(new LoginViewModel()); //{ ReturnUrl = returnUrl });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result =
                    await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Неправильный логин и (или) пароль");
                }
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            // удаляем аутентификационные куки
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
