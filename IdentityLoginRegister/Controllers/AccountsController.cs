using IdentityLoginRegister.Data;
using IdentityLoginRegister.Models.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IdentityLoginRegister.Controllers
{
    public class AccountsController : Controller
    {
        private readonly ApplicationDbContext dbContext;
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;

        public AccountsController(ApplicationDbContext DbContext, UserManager<IdentityUser> userManager ,SignInManager<IdentityUser> signInManager )
        {
            dbContext = DbContext;
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task <IActionResult> Register(RegisterVM model) 
        {
            IdentityUser user = new IdentityUser()
            {
                Email = model.Email,
                PhoneNumber = model.Phone,
                UserName = model.Email,
            };
          var result=  await userManager.CreateAsync(user,model.Password);
            if(result.Succeeded)
            {
                return RedirectToAction("Login");
            }
            return View(model);
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginVM model)
        {
            var result = await signInManager.PasswordSignInAsync(model.Email,model.Password,model.RememberMe,false) ;
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }

    }
}
