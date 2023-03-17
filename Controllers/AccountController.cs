using HotelProject.Data.Services;
using HotelProject.Data.Static;
using HotelProject.Data.ViewModels;
using HotelProject.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
namespace HotelProject.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUsersService _service;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AccountController(IUsersService service, SignInManager<User> signInManager, UserManager<User> userManager)
        {
            _service = service;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var users = await _service.getAll();
            return View(users);
        }

        public IActionResult Login() => View(new LoginVM());

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            if (!ModelState.IsValid) return View(loginVM);

            var user = await _userManager.FindByEmailAsync(loginVM.EmailAddress);
            if (user != null)
            {
                var passwordCheck = await _userManager.CheckPasswordAsync(user, loginVM.Password);
                if (passwordCheck)
                {
                    var result = await _signInManager.PasswordSignInAsync(user, loginVM.Password, false, false);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Movies");
                    }
                }
                TempData["Error"] = "Wrong credentials. Please, try again!";
                return View(loginVM);
            }

            TempData["Error"] = "Wrong credentials. Please, try again!";
            return View(loginVM);
        }


        public IActionResult Register() => View(new User());

        [HttpPost]
        public async Task<IActionResult> Register(User user)
        {
            if (!ModelState.IsValid) return View(user);

            var newUser = await _userManager.FindByEmailAsync(user.Email);
            if (newUser != null)
            {
                TempData["Error"] = "This email address is already in use";
                return View(newUser);
            }

            var newUser1 = new User()
            {
                Name = user.Name,
                Email = user.Email,
                Password = user.Password,
                ConfirmPassword = user.ConfirmPassword,
                PhoneNumber = user.PhoneNumber,
                UserId = user.UserId,
                
            };
            var newUserResponse = await _userManager.CreateAsync(newUser1, user.Password);

            if (newUserResponse.Succeeded)
                await _userManager.AddToRoleAsync(newUser1, UserRoles.User);

            return View("RegisterCompleted");
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Movies");
        }
        public IActionResult AccessDenied(string ReturnUrl)
        {
            return View();
        }

    }
}
