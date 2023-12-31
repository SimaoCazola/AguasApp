﻿using AguasApp.Data;
using AguasApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Microsoft.EntityFrameworkCore;
using AguasApp.Data.Entities;
using AguasApp.Helpers;
using System.Linq;
using Microsoft.AspNetCore.Hosting;

namespace AguasApp.Controllers
{
    /*[Authorize] */// aqui estou autorizar apenas users registrados a executar essa accao
    public class OrdersController : Controller
    {
        private readonly DataContext _context;
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;
        private readonly IUserHelper _userHelper;
     

        public OrdersController(DataContext context, IOrderRepository orderRepository,
            IProductRepository productRepository, 
            IUserHelper userHelper)
        {
            _context = context;
            _orderRepository = orderRepository;
            _productRepository = productRepository;
            _userHelper = userHelper;
        }
        

        //ADD TO CART METHOD POST METHOD
        public async Task<IActionResult> AddItemToCart(int? id)
        {
            if (id == null)
            {
                return new NotFoundViewResult("ProductNotFound");
            }

            var item = await _productRepository.GetByIdAsync(id.Value);

            //string user = _context.Users.FirstOrDefault()?.Id;

            await _orderRepository.AddItemToCartAsync(item, this.User.Identity.Name);
            return RedirectToAction("Create");
            //return View();
        }




        // IAction do Tipo Create para mostrar os orders
        public async Task<IActionResult> Index()
        {
           
            // Guardar na variavel model todas informacoes ja com os codigos para mostrar na view
            var model = await _orderRepository.GetOrderAsync(this.User.Identity.Name);
           
            return View(model);
        }

        public async Task<IActionResult> IndexAdmin() 
        {

            // Guardar na variavel model todas informacoes ja com os codigos para mostrar na view
            var model = await _orderRepository.GetOrderAsync(this.User.Identity.Name);

            return View(model);
        }

        // IAction do Tipo CREATE para mostrar os ordersDetails
        public async Task<IActionResult> Create()
        {
            
            // Guardar na variavel model todas informacoes ja com os codigos para mostrar na view
            var model = await _orderRepository.GetDetailTempsAsync(this.User.Identity.Name);
          
            return View(model);
        }

        
        // Mostrar a view do botao AddProduct da Combox--> CREATE
        public IActionResult AddProduct()
        {
            var model = new AddItemViewModel
            {
                Quantity = 1,
                Products = _productRepository.GetComboProducts()
            };
            return View(model);
        }

        // Executar as funcoes do botao AddProduct da Combox--> POST
        [HttpPost]
        public async Task<IActionResult> AddProduct(AddItemViewModel model)
        {
            /*Verficar primeiro se o model e valido*/
            if (ModelState.IsValid)
            {
                await _orderRepository.AddItemToOrderAsync(model, this.User.Identity.Name);
                return RedirectToAction("Create");
            }
            return View(model);
        }


        // POST do Delete
        public async Task<IActionResult> DeleteItem(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            await _orderRepository.DeleteDetailTempAsync(id.Value);
            return RedirectToAction("Create");
        }


        // POST Increase
        public async Task<IActionResult> Increase(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            await _orderRepository.ModifyOrderDetailTempQuantityAsync(id.Value, 1);
            return RedirectToAction("Create");
        }


        // POST Decrease
        public async Task<IActionResult> Decrease(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            await _orderRepository.ModifyOrderDetailTempQuantityAsync(id.Value, -1);
            return RedirectToAction("Create");
        }

        // POST CONFIRM 
        public async Task<IActionResult> ConfirmOrder()
        {
            var response = await _orderRepository.ConfirmOrderAsync(this.User.Identity.Name);
            if (response)
            {
                return RedirectToAction("ConfirmOrder", "BuyServices");
            }
            return RedirectToAction("Create");
        }

        // GET DELIVERY VIEW PARA APARECER A VIEW

        public async Task<IActionResult> Deliver(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _orderRepository.GetOrderAsync(id.Value);
            if (order == null)
            {
                return NotFound();
            }

            var model = new DeliveryViewModel
            {
                Id = order.Id,
                DeliverDate = DateTime.Today
            };

            return View(model);
        }

        // POST DELIVERY VIEW PARA FAZER O SUBMIT DO QUE ESTIVER NO FORMULARIO
        [HttpPost]
        public async Task<IActionResult> Deliver(DeliveryViewModel model)
        {
            if (ModelState.IsValid)
            {
                await _orderRepository.DeliverOrder(model);
                return RedirectToAction("IndexAdmin");
            }

            return View();
        }


    }
}
