using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NeonWorld.EF;
using NeonWorld.Entities;
using NeonWorld.ViewModels.System.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeonWorld.Application.System.Orders
{
    public class OrderService : IOrderService
    {
        private readonly NeonWorldDbContext _context;
        private readonly IMapper _mapper;

        public OrderService(NeonWorldDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public bool CreateOrder(Order orders)
        {
            _context.Orders.Add(orders);
            foreach (var item in orders.OrderDetails)
            {
                _context.OrderDetails.Add(item);
            }
            return _context.SaveChanges() > 0;
        }

        public OrderVm GetOrder(Guid userId)
        {
            var getOrder = _context.Orders.FirstOrDefault(o => o.UserID == userId);

            var getOrderDetails = from od in _context.OrderDetails
                                  join p in _context.Products on od.ProductID equals p.ProductID
                                  where od.OrderID == getOrder.OrderID
                                  select new OrderDetail {Price = od.Price, Product = p, Quantity = od.Quantity};
            var result = getOrderDetails;
            return new OrderVm()
            {
                OrderID = getOrder.OrderID,
                OrderDetails = getOrderDetails.ToList()
            };
        }
    }
}
