using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MVC_TDPC13.DB;
using MVC_TDPC13.DB.Entities;
using MVC_TDPC13.Models;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace MVC_TDPC13.Controllers
{
    /*
    - creare DB per l'identity IdentityAuthDB
    - eseguire script DBscript.txt
    - creare classe User : IdentityUser
    - creare classe UserDBContext : IdentityDbContext<User>
    - aggiungere la connection string in appsettings.json
    - registrare i servizi in startup in ConfigureServices(IServiceCollection services):
        services.AddDbContext<UserDBContext>(options => options.UseSqlServer(Configuration.GetConnectionString("AuthDB")));

        //User Management
        services.AddIdentity<User, IdentityRole>()
            .AddEntityFrameworkStores<UserDBContext>()
            .AddDefaultTokenProviders();
        services.AddScoped<SignInManager<User>>();
        services.AddScoped<UserManager<User>>();
        services.AddScoped<RoleManager<IdentityRole>>();
    - aggiungere in startup in Configure(IApplicationBuilder app, IWebHostEnvironment env):
        app.UseAuthentication();
        app.UseAuthorization();
    - creare la classe LoginModel
    - creare la view Login.cshtml
    - copiare i link di navigazione dal Layout.cshtml
    - in HomeController: 
        - fare dependency injection di:
            private SignInManager<User> signInManager;
            private UserManager<User> userManager;
            private UserDBContext dbContext;
            public HomeController(SignInManager<User> signInManager,
                UserManager<User> userManager,
                UserDBContext dbContext)
            {
                this.signInManager = signInManager;
                this.userManager = userManager;
                this.dbContext = dbContext;
            }
        - creare l'endpoint public IActionResult Login()
        - creare l'endpoint public async Task<IActionResult> Login(LoginModel loginModel)
        - creare l'endpoint public async Task<IActionResult> Logout()
     */
    public class HomeController : Controller
    {
        private SignInManager<User> signInManager;
        private UserManager<User> userManager;
        private UserDBContext dbContext;
        public HomeController(SignInManager<User> signInManager,
            UserManager<User> userManager,
            UserDBContext dbContext)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.dbContext = dbContext;
        }

        public IActionResult Index()
        {
            return View();
        }
        [Authorize]
        public IActionResult HiddenPage()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            try
            {
                User user = await userManager.FindByNameAsync(loginModel.UserName);
                if (user != null)
                {
                    var result = await signInManager.PasswordSignInAsync(loginModel.UserName, loginModel.Password, false, lockoutOnFailure: true);
                    if (result.Succeeded)
                    {

                    }
                }
            }
            catch (Exception ex)
            {

            }
            return Redirect("Index");
        }

        [Authorize]
        public async Task<IActionResult> Logout()
        {
            try
            {
                if (signInManager.IsSignedIn(User))
                {
                    await signInManager.SignOutAsync();
                }
            }
            catch (Exception ex)
            {
            }
            return Redirect("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

