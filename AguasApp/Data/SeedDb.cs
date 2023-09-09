using AguasApp.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using AguasApp.Helpers;

namespace AguasApp.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;
        private readonly IUserHelper _userHelper;
        private Random _random; //Gera os dados aleatoriamente

        public SeedDb(DataContext context, IUserHelper userHelper)
        {
            _context = context;
            _userHelper = userHelper;
            _random = new Random();
        }

        /*------OPEN SEED METHOD------------------------------------------------*/
        // Metodo que Cria o    SEED DE FORMA ASYNCRONA:
        public async Task SeedAsync()
        {

            /*------OPEN--------------------------------------------------------*/
            //Essa variavel Verifica se a base de dados esta criada ou nao. Se ja estiver criada simplesmente continua...
            //await _context.Database.MigrateAsync();
            await _context.Database.EnsureCreatedAsync();
            /*------CLOSE--------------------------------------------------------*/


            /*------OPEN--------------------------------------------------------*/
            //verificar se os roles existem
            await _userHelper.CheckRoleAsync("Admin");
            await _userHelper.CheckRoleAsync("Customer");
            await _userHelper.CheckRoleAsync("Employee");
            /*------CLOSE--------------------------------------------------------*/



            /*------OPEN--------------------------------------------------------*/
            //Criar o Utilizador ADMIN
            var user = await _userHelper.GetUserByEmailAsync("cazolastudio@gmail.com");
            /*------CLOSE--------------------------------------------------------*/




            //Verifificar se o Utilizador é nulo, caso for nulo cria um novo user
            if (user == null)
            {
                /*------OPEN--------------------------------------------------------*/
                user = new User
                {
                    //NOTA - NÃO COLOQUEI COUNTRY NEM CITY PQ AINDA NÃO OS CRIÁMOS -> PARA IREM PARA UMA COMBOBOX
                    FirstName = "Simao",
                    LastName = "Andre",
                    Email = "cazolastudio@gmail.com",
                    UserName = "cazolastudio@gmail.com",
                    PhoneNumber = "914105858",
                    Address = "Odivelas",
                };
                /*------CLOSE--------------------------------------------------------*/


                /*------OPEN--------------------------------------------------------*/
                //Variavel que adiciona o utilizador e a password
                var result = await _userHelper.AddUserAsync(user, "123456");
                /*------CLOSE--------------------------------------------------------*/


                /*------OPEN--------------------------------------------------------*/
                // Verifica se o a variavel result teve sucesso ou nao
                if (result != IdentityResult.Success)
                {
                    throw new InvalidOperationException("Could not creat user in seeder");
                }
                /*------CLOSE--------------------------------------------------------*/


                /*------OPEN--------------------------------------------------------*/
                // Adicionar o administrador para ficar como o user por defeito
                await _userHelper.AddUserToRoleAsync(user, "Admin");
                /*------CLOSE--------------------------------------------------------*/

            }


            /*------OPEN--------------------------------------------------------*/
            //Serve para confirmar se o user está no role é o Admin
            var isInRole = await _userHelper.IsUserInRoleAsync(user, "Admin");
            /*------CLOSE--------------------------------------------------------*/


            /*------OPEN--------------------------------------------------------*/
            // Se o user no role nao for o Admin, adiciona o admin por defeito
            if (!isInRole)
            {
                await _userHelper.AddUserToRoleAsync(user, "Admin");
            }
            /*------CLOSE--------------------------------------------------------*/



            /*------OPEN--------------------------------------------------------*/

            // Verificar se na tabela Producto esta vazio, caso estiver vou adicionar produtos
            if (!_context.Products.Any())
            {
                AddProduct("Agua Potavel", user);
                AddProduct("Agua Tonica", user);
                AddProduct("Agua com gas", user);
                AddProduct("Agua", user);
                await _context.SaveChangesAsync();
            }
            /*------CLOSE--------------------------------------------------------*/
        }
        /*------CLOSE SEED METHOD------------------------------------------------*/


        /*------OPEN--------------------------------------------------------*/
        // Metodo para adicionar um produto
        private void AddProduct(string name, User user)
        {
            _context.Products.Add(new Product
            {
                Name = name,
                Price = _random.Next(1000),
                IsAvailable = true,
                Stock = _random.Next(100),
                User = user,

            });
        }
        /*------CLOSE--------------------------------------------------------*/
    }
}
