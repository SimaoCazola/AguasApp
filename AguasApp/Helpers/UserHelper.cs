﻿using AguasApp.Data.Entities;
using AguasApp.Models;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace AguasApp.Helpers
{
    public class UserHelper : IUserHelper
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserHelper(UserManager<User> userManager, SignInManager<User> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager; //esta classe faz a gestão dos users
            _signInManager = signInManager; //esta classe faz a gestão dos signin/singout/recuperação de pass
            _roleManager = roleManager; //esta classe faz a gestão dos roles
        }

        // USER METHODS:
        public async Task<IdentityResult> AddUserAsync(User user, string password)
        {
            return await _userManager.CreateAsync(user, password);
        }

        //Adicionar o user ao role
        public async Task AddUserToRoleAsync(User user, string roleName)
        {
            await _userManager.AddToRoleAsync(user, roleName);
        }

        public async Task<IdentityResult> ChangePasswordAsync(User user, string oldPassword, string newPassword)
        {
            //recebe o user, a pass antiga e a nova
            return await _userManager.ChangePasswordAsync(user, oldPassword, newPassword);
        }

        //verificar se o role existe
        public async Task CheckRoleAsync(string roleName)
        {
            var roleExists = await _roleManager.RoleExistsAsync(roleName);

            //se o role não existir
            if (!roleExists)
            {
                await _roleManager.CreateAsync(new IdentityRole
                {
                    Name = roleName
                });
            }
        }


        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await _userManager.FindByEmailAsync(email);
        }


        public async Task<User> GetUserByIdAsync(string userId)
        {
            return await _userManager.FindByIdAsync(userId);
        }

        public async Task<SignInResult> LoginAsync(LoginViewModel model)
        {
            return await _signInManager.PasswordSignInAsync(
                model.Username,
                model.Password,
                model.RememberMe,
                false); //false -> pq se me enganar na password -> posso voltar a tentar
        }

        public async Task LogoutAsync()
        {
            await _signInManager.SignOutAsync();
        }

        //é só um bypass -> recebe os dados do user e actualiza
        public async Task<IdentityResult> UpdateUserAsync(User user)
        {
            return await _userManager.UpdateAsync(user);
        }


        //Ver se o user está associado ao role
        public async Task<bool> IsUserInRoleAsync(User user, string roleName)
        {
            return await _userManager.IsInRoleAsync(user, roleName);
        }


        //return do resultado quer seja válido ou n -> apenas verifica.
        public async Task<SignInResult> ValidatePasswordAsync(User user, string password)
        {
            return await _signInManager.CheckPasswordSignInAsync(
                user,
                password,
                false);                                            //false para n bloquear ao fim de x tentativas
        }


    }
}
