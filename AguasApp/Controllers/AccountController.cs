using AguasApp.Data.Entities;
using AguasApp.Helpers;
using AguasApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System;

namespace AguasApp.Controllers
{
  
    public class AccountController : Controller
    {
        private readonly IUserHelper _userHelper;
        private readonly IConfiguration _configuration;

        public AccountController(IUserHelper userHelper, IConfiguration configuration)
        {
            _userHelper = userHelper;
            _configuration = configuration;
        }


        /*------OPEN Login GET------------------------------------------------*/
        // Metodo com view para mostrar os dados do login da view model LoginViewModel
        public ActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }

            return View(); 
        }
        /*------CLOSE Login GET--------------------------------------------------------*/



        /*------OPEN Login POST--------------------------------------------------------*/
        //Metodo sem view para processar os dados do login
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _userHelper.LoginAsync(model);
                if (result.Succeeded)
                {
                    return this.RedirectToAction("Index", "Home");
                }
            }
            this.ModelState.AddModelError(string.Empty, "Failded to login");
            return View(model);
        }
        /*------CLOSE Login POST--------------------------------------------------------*/


        /*------OPEN Logout--------------------------------------------------------*/
        // Metodo metodo sem view para fechar o login e direccionar o user para home
        public async Task<IActionResult> Logout()
        {
            await _userHelper.LogoutAsync();
            return RedirectToAction("Index", "Home");
        }
        /*------CLOSE Logout--------------------------------------------------------*/


        /*------OPEN Register GET--------------------------------------------------------*/
        //Metodo com view para mostrar os dados do novo registro do novo utilizador
        public IActionResult Register() 
        {
            return View();
        }
        /*------CLOSE Register GET--------------------------------------------------------*/


        /*------OPEN Register POST--------------------------------------------------------*/
        // Metodo sem view para processar os dados registro de um novo utilizador
        [HttpPost]
        public async Task<IActionResult> Register(RegisterNewUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userHelper.GetUserByEmailAsync(model.Username);

                //ver se o user existe
                if (user == null)
                {
                    user = new User
                    {
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        Email = model.Username,
                        UserName = model.Username,
                        PhoneNumber = model.PhoneNumber,
                        Address = model.Address,
                    };

                    //se não existir -> adicionar
                    var result = await _userHelper.AddUserAsync(user, model.Password);

                    //se n conseguir criar o user -> aparece uma msg de erro e retorna a view model
                    if (result != IdentityResult.Success)
                    {
                        ModelState.AddModelError(string.Empty, "The user couldn't be created.");
                        return View(model);
                    }

                    //se conseguir criar o user -> fica logo logado
                    var loginViewModel = new LoginViewModel
                    {
                        Password = model.Password,
                        RememberMe = false,
                        Username = model.Username
                    };

                    //Fazer o sign in
                    var result2 = await _userHelper.LoginAsync(loginViewModel);

                    //Se conseguir fazer o sign in
                    if (result2.Succeeded)
                    {
                        return RedirectToAction("Index", "Home");
                    }

                    //se não conseguir fazer o login -> envia uma msg de erro
                    ModelState.AddModelError(string.Empty, "The user coundn't be logged");
                }
            }
            return View(model);
        }
        /*------CLOSE Register POST--------------------------------------------------------*/



        /*------OPEN ChangeUser GET--------------------------------------------------*/
        // Metodo com view para mostrar os dados do utilizador por modificar ou editar 
        public async Task<IActionResult> ChangeUser() 
        {
            //encontrar o user
            var user = await _userHelper.GetUserByEmailAsync(this.User.Identity.Name);

            //criar o modelo para aparecerem os dados
            var model = new ChangeUserViewModel();
            if (user != null)
            {
                model.FirstName = user.FirstName;
                model.LastName = user.LastName;
                model.Address = user.Address;
                model.PhoneNumber = user.PhoneNumber;
            }

            return View(model);
        }
        /*------CLOSE ChangeUser GET-------------------------------------------------*/



        /*------OPEN ChangeUser POST--------------------------------------------------------*/
        // Metodo sem View para processar a modificacao ou edicao dos dados do utilizador
        [HttpPost]
        public async Task<IActionResult> ChangeUser(ChangeUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                //encontrar o user
                var user = await _userHelper.GetUserByEmailAsync(this.User.Identity.Name);
                if (user != null)
                {
                    user.FirstName = model.FirstName;
                    user.LastName = model.LastName;
                    user.Address = model.Address;
                    user.PhoneNumber = model.PhoneNumber;

                    var response = await _userHelper.UpdateUserAsync(user);

                    if (response.Succeeded)
                    {
                        ViewBag.UserMessage = "User Updated.";
                    }

                    else
                    {
                        ModelState.AddModelError(string.Empty, response.Errors.FirstOrDefault().Description);
                    }
                }
            }

            return View(model);
        }
        /*------CLOSE ChangeUser POST--------------------------------------------------------*/


        /*------OPEN ChangePassword GET-----------------------------------------*/
        // Metodo com views para mostrar os dados do ChangePassword
        public IActionResult ChangePassword() 
        {
            return View();
        }
        /*------CLOSE ChangePassword GET----------------------------------------*/



        /*------OPEN ChangePassword POST-----------------------------------------*/
        // Metodo sem view para processar os dados do change password
        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                //verificar se o user existe
                var user = await _userHelper.GetUserByEmailAsync(this.User.Identity.Name);

                //se o user existir -> posso mudar a pass
                if (user != null)
                {
                    var result = await _userHelper.ChangePasswordAsync(user, model.OldPassword, model.NewPassword);
                    if (result.Succeeded)
                    {
                        return this.RedirectToAction("ChangeUser");
                    }
                    else
                    {
                        this.ModelState.AddModelError(string.Empty, result.Errors.FirstOrDefault().Description);
                    }
                }
                else
                {
                    this.ModelState.AddModelError(string.Empty, "User not found.");
                }

            }

            return this.View(model);
        }
        /*------CLOSE ChangePassword POST-----------------------------------------*/


        /*------OPEN RecoverPassword GET--------------------------------*/
        // Metodo com view para mostrar os dados RecoverPassword
        public IActionResult RecoverPassword()
        {
            return View();
        }
        /*------CLOSE RecoverPassword GET--------------------------------*/
    }
}

