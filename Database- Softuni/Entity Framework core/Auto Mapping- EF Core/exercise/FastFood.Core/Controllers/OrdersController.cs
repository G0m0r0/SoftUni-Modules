﻿namespace FastFood.Core.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Data;
    using FastFood.Models;
    using Microsoft.AspNetCore.Mvc;
    using ViewModels.Orders;

    public class OrdersController : Controller
    {
        private readonly FastFoodContext context;
        private readonly IMapper mapper;

        public OrdersController(FastFoodContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public IActionResult Create()
        {
            CreateOrderViewModel viewOrder = new CreateOrderViewModel
            {
                Items = context.Items.ProjectTo<CreateOrderItemViewModel>(mapper.ConfigurationProvider).ToList(),
                Employees = context.Employees.ProjectTo<CreateOrderEmployeeViewModel>(mapper.ConfigurationProvider).ToList(),
            };

            return View(viewOrder);
        }

        [HttpPost]
        public IActionResult Create(CreateOrderInputModel model)
        {
            if(!ModelState.IsValid)
            {
                return RedirectToAction("Error", "Home");
            }

            Order order = mapper.Map<Order>(model);
            OrderItem orderItem = mapper.Map<OrderItem>(model);

            orderItem.Order = order;

            context.Orders.Add(order);
            context.OrderItems.Add(orderItem);
            context.SaveChanges();

            return RedirectToAction("All", "Orders");
        }

        public IActionResult All()
        {
            List<OrderAllViewModel> orders = context.Orders.ProjectTo<OrderAllViewModel>(mapper.ConfigurationProvider).ToList();

            return View(orders);
        }
    }
}
