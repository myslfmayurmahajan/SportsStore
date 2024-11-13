﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using SportsStore.Models;
namespace SportsStore.Controllers
{
    public class OrderController :Controller
    {
        private IOrderRepository repository;
        private Cart cart;
        public OrderController(IOrderRepository repoService, Cart cartService)
        {
            repository = repoService;
            cart=cartService;   
        }
        public ViewResult List() => View(repository.Orders.Where(o => !o.Shipped));
        [HttpPost]
        public IActionResult MarkShipped(int orderId)
        {
            Order order = repository.Orders
                .FirstOrDefault(o => o.OrderId == orderId);
            if(order !=null)
            {
                order.Shipped = true;   
                repository.SaveOrder(order);
            }
            return RedirectToAction(nameof(List));
        }
        public ViewResult Checkout()
        { 
                
                return View(new Order());
         }
        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            if (cart.Lines.Count() == 0)
            {

                ModelState.AddModelError("", "Sorry, Your cart is empty!");
            }
            if (ModelState.IsValid)
            {
                order.Lines = cart.Lines.ToArray();
                repository.SaveOrder(order);
                cart.Clear();
                return RedirectToPage("/completed", new { orderId = order.OrderId });

            }
            else
            {
                return View();
            }


            
        }
    }
}